// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

using Leadtools;
using Leadtools.Demos;
using Leadtools.Drawing;
using Leadtools.WinForms;
using Leadtools.Barcode;
using Leadtools.Controls;

namespace BarcodeMainDemo.ViewerControl
{
   /// <summary>
   /// This control contains an instance of RasterImageViewer plus
   /// a tool strip control for common operations
   /// </summary>
   public partial class ViewerControl : UserControl
   {
      #region Private
      // Minimum and maximum scale percentages allowed
      private const double _minimumViewerScalePercentage = 1;
      private const double _maximumViewerScalePercentage = 6400;
      //Interactive modes
      private ImageViewerNoneInteractiveMode _noneInteractiveMode = null;
      private ImageViewerPanZoomInteractiveMode _panInteractiveMode = null;
      private ImageViewerZoomToInteractiveMode _zoomToInteractiveMode = null;
      private ImageViewerRubberBandInteractiveMode _rectInteractiveMode = null;
      private ImageViewerAddRegionInteractiveMode _regionInteractiveMode = null;


      // Current interactive mode (with the mouse)
      private ViewerControlInteractiveMode _interactiveMode = ViewerControlInteractiveMode.SelectMode;

      // Current document barcodes
      private DocumentBarcodes _documentBarcodes;

      private bool _disableExtraDrawing;
      public bool _viewerRegion = false;
      public bool _viewerRegionCopy = false;
      public int _viewerRegionPage;
      public RasterRegion RegionG;

      public bool FourPoints = false;

      private void UpdatePageInfo()
      {
         StringBuilder sb = new StringBuilder();

         if(_rasterImageViewer.Image != null)
         {
            RasterImage image = _rasterImageViewer.Image;

            sb.AppendFormat(DemosGlobalization.GetResxString(GetType(), "Resx_Size"), image.ImageWidth, image.ImageHeight, image.XResolution, image.YResolution, image.BitsPerPixel);
         }

         _pageInfoLabel.Text = sb.ToString();
      }

      public ImageViewerNoneInteractiveMode NoneInteractiveMode
      {
         get
         {
            return _noneInteractiveMode;
         }
         set
         {
            _noneInteractiveMode = value;
         }
      }

      public ImageViewerPanZoomInteractiveMode PanInteractiveMode
      {
         get
         {
            return _panInteractiveMode;
         }
         set
         {
            _panInteractiveMode = value;
         }
      }

      public ImageViewerZoomToInteractiveMode ZoomToInteractiveMode
      {
         get
         {
            return _zoomToInteractiveMode;
         }
         set
         {
            _zoomToInteractiveMode = value;
         }
      }

      public ImageViewerRubberBandInteractiveMode RectInteractiveMode
      {
         get
         {
            return _rectInteractiveMode;
         }
         set
         {
            _rectInteractiveMode = value;
         }
      }

      public ImageViewerAddRegionInteractiveMode RegionInteractiveMode
      {
         get
         {
            return _regionInteractiveMode;
         }
         set
         {
            _regionInteractiveMode = value;
         }
      }

      private delegate void DoActionDelegate(string action, object data);

      private void DoAction(string action, object data)
      {
         // Raise the action event so the main form can handle it

         if(Action != null)
         {
            Action(this, new ActionEventArgs(action, data));
         }
      }

      #endregion Private

      #region Control
      public ViewerControl()
      {
         InitializeComponent();
      }

      protected override void OnLoad(EventArgs e)
      {
         if(!DesignMode)
         {
            InitViewer();

            // These events are needed and not visible from the designer, so hook into them here
            _zoomToolStripComboBox.LostFocus += new EventHandler(_zoomToolStripComboBox_LostFocus);
            _pageToolStripTextBox.LostFocus += new EventHandler(_pageToolStripTextBox_LostFocus);

            // Call the transform changed event
            _rasterImageViewer_TransformChanged(_rasterImageViewer, EventArgs.Empty);

            _mousePositionLabel.Text = string.Empty;
         }

         base.OnLoad(e);
      }
      #endregion Control

      #region Public
      /// <summary>
      /// The instance of RasterImageViewer used in this viewer
      /// </summary>
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public ImageViewer RasterImageViewer
      {
         get
         {
            return _rasterImageViewer;
         }
      }

      /// <summary>
      /// Called by the main form to set the new raster image and barcodes
      /// </summary>
      public void SetDocument(RasterImage image, DocumentBarcodes documentBarcodes)
      {
         _documentBarcodes = documentBarcodes;

         _rasterImageViewer.Image = image;

         UpdatePageInfo();
         UpdateUIState();
      }

      /// <summary>
      /// Called by the main form when the page number of the image is changed
      /// </summary>
      public void SetCurrentPageNumber(int pageNumber)
      {
         _rasterImageViewer.Image.Page = pageNumber;
         _rasterImageViewer.Items[0].PageNumber = pageNumber;
         UpdatePageInfo();
         UpdateUIState();
      }

      /// <summary>
      /// Called by the main form to change the page viewing mode (from the main menu)
      /// </summary>
      public void FitPage(bool fitWidth)
      {
         // Since we are doing more than one operation on the viewer, it is
         // recommended to disable then re-enable updates on the viewer to
         // minimize flickering

         _rasterImageViewer.BeginUpdate();

         if(fitWidth)
         {
            _rasterImageViewer.Zoom(ControlSizeMode.FitWidth, 1, _rasterImageViewer.DefaultZoomOrigin);
         }
         else
         {
            _rasterImageViewer.Zoom(ControlSizeMode.FitAlways, 1, _rasterImageViewer.DefaultZoomOrigin);
         }

         _rasterImageViewer.EndUpdate();

         UpdateUIState();
      }

      /// <summary>
      /// Zoom the viewer in our out
      /// </summary>
      public void ZoomViewer(bool zoomOut)
      {
         // Get the current scale factor
         double percentage = _rasterImageViewer.XScaleFactor * 100.0;

         // The valid scale factors are here
         double[] validPercentages =
         {
            _minimumViewerScalePercentage, 6.25, 12.5, 25, 33.3, 50, 66.7, 73.6, 92.5, 100,
            125, 150, 200, 300, 400, 600, 800, 1200, 1600, 2400,
            3200, _maximumViewerScalePercentage
         };

         // Find out where we are, move to the next one up or down depending on 'zoomOut'
         if(zoomOut)
         {
            for(int i = validPercentages.Length - 1; i >= 0; i--)
            {
               if(percentage > validPercentages[i])
               {
                  percentage = validPercentages[i];
                  break;
               }
            }
         }
         else
         {
            for(int i = 0; i < validPercentages.Length; i++)
            {
               if(percentage < validPercentages[i])
               {
                  percentage = validPercentages[i];
                  break;
               }
            }
         }

         SetViewerZoomPercentage(percentage);
      }

      /// <summary>
      /// Current interactive mode (what happens when the user uses the mouse on the viewer)
      /// </summary>
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public ViewerControlInteractiveMode InteractiveMode
      {
         get
         {
            return _interactiveMode;
         }
         set
         {
            _interactiveMode = value;

            foreach (ImageViewerInteractiveMode mode in _rasterImageViewer.InteractiveModes)
            {
               mode.IsEnabled = false;
            }

            // Set the RasterImageViewer interactive mode accordingly
            switch(_interactiveMode)
            {
               case ViewerControlInteractiveMode.SelectMode:
                  _rasterImageViewer.InteractiveModes.EnableById(_noneInteractiveMode.Id);
                  break;

               case ViewerControlInteractiveMode.PanMode:
                  _rasterImageViewer.InteractiveModes.EnableById(_panInteractiveMode.Id);
                  break;

               case ViewerControlInteractiveMode.ZoomToSelectionMode:
                  _rasterImageViewer.InteractiveModes.EnableById(_zoomToInteractiveMode.Id);
                  break;

               case ViewerControlInteractiveMode.RegionMode:
                  RegionInteractiveMode.Shape = ImageViewerRubberBandShape.Rectangle;
                  _rasterImageViewer.InteractiveModes.EnableById(_regionInteractiveMode.Id);
                  break;

               case ViewerControlInteractiveMode.ReadBarcodeMode:
                  RectInteractiveMode.Shape = ImageViewerRubberBandShape.Rectangle;
                  _rasterImageViewer.InteractiveModes.EnableById(_rectInteractiveMode.Id);
                  break;

               case ViewerControlInteractiveMode.WriteBarcodeMode:
                  RectInteractiveMode.Shape = ImageViewerRubberBandShape.Rectangle;
                  _rasterImageViewer.InteractiveModes.EnableById(_rectInteractiveMode.Id);
                  break;
            }

            UpdateUIState();
         }
      }

      /// <summary>
      /// Called by the main form to show/hide the barcodes
      /// </summary>
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public bool ShowBarcodes
      {
         get
         {
            return _showBarcodesToolStripButton.Checked;
         }
         set
         {
            _showBarcodesToolStripButton.Checked = value;

            if(!_showBarcodesToolStripButton.Checked)
            {
               _interactiveMode = ViewerControlInteractiveMode.SelectMode;
            }

            _rasterImageViewer.Invalidate();
            UpdateUIState();
         }
      }

      /// <summary>
      /// Called when the RasterImage region is changed from outside
      /// </summary>
      public void ImageRegionChanged()
      {
         UpdateUIState();
      }

      /// <summary>
      /// This event is fired by the control when an action occurs that must be handled by
      /// the owner (the main form)
      /// </summary>
      public event EventHandler<ActionEventArgs> Action;
      #endregion Public

      #region Viewer
      private void InitViewer()
      {
         // Use ScaleToGray and Bicubic for optimum viewing of black/white and color images
         RasterPaintProperties props = _rasterImageViewer.PaintProperties;
         props.PaintDisplayMode |= RasterPaintDisplayModeFlags.Bicubic;

         if (!RasterSupport.IsLocked(RasterSupportType.Document))
            props.PaintDisplayMode |= RasterPaintDisplayModeFlags.ScaleToGray;
         
         _rasterImageViewer.PaintProperties = props;

         // Pad the viewer
         _rasterImageViewer.Padding = new Padding(10);

         // Set the cursors
         _noneInteractiveMode = new ImageViewerNoneInteractiveMode();
         _panInteractiveMode = new ImageViewerPanZoomInteractiveMode();
         _panInteractiveMode.MouseButtons = System.Windows.Forms.MouseButtons.Left;
         _zoomToInteractiveMode = new ImageViewerZoomToInteractiveMode();
         _zoomToInteractiveMode.RubberBandCompleted += new EventHandler<ImageViewerRubberBandEventArgs>(_rasterImageViewer_InteractiveZoomTo);
         _rectInteractiveMode = new ImageViewerRubberBandInteractiveMode();
         _regionInteractiveMode = new ImageViewerAddRegionInteractiveMode();
         _regionInteractiveMode.RubberBandCompleted += new EventHandler<ImageViewerRubberBandEventArgs>(_rasterImageViewer_InteractiveRegionRectangle);
         _regionInteractiveMode.RubberBandStarted += new EventHandler<ImageViewerRubberBandEventArgs>(RegionInteractiveMode_RubberBandStarted);
         _rectInteractiveMode.RubberBandCompleted += new EventHandler<ImageViewerRubberBandEventArgs>(RectInteractiveMode_RubberBandCompleted);
         _noneInteractiveMode.IdleCursor = Cursors.Arrow;
         _noneInteractiveMode.WorkingCursor = Cursors.Arrow;

         _panInteractiveMode.IdleCursor = Cursors.Hand;
         _panInteractiveMode.WorkingCursor = Cursors.Hand;

         _zoomToInteractiveMode.IdleCursor = Cursors.Cross;
         _zoomToInteractiveMode.WorkingCursor = Cursors.Cross;

         _rectInteractiveMode.IdleCursor = Cursors.Cross;
         _rectInteractiveMode.WorkingCursor = Cursors.Cross;

         _regionInteractiveMode.IdleCursor = Cursors.Cross;
         _regionInteractiveMode.WorkingCursor = Cursors.Cross;

         _rasterImageViewer.InteractiveModes.BeginUpdate();
         _rasterImageViewer.InteractiveModes.Add(_noneInteractiveMode);
         _rasterImageViewer.InteractiveModes.Add(_panInteractiveMode);
         _rasterImageViewer.InteractiveModes.Add(_zoomToInteractiveMode);
         _rasterImageViewer.InteractiveModes.Add(_rectInteractiveMode);
         _rasterImageViewer.InteractiveModes.Add(_regionInteractiveMode);
         _rasterImageViewer.InteractiveModes.EndUpdate();
      }

      void RectInteractiveMode_RubberBandCompleted(object sender, ImageViewerRubberBandEventArgs e)
      {
         string actionName = null;

         if (InteractiveMode == ViewerControlInteractiveMode.ReadBarcodeMode)
         {
            actionName = "ReadBarcode";
         }
         else if (InteractiveMode == ViewerControlInteractiveMode.WriteBarcodeMode)
         {
            actionName = "WriteBarcode";
         }

         if (actionName != null)
         {
            LeadRect MyRect = LeadRect.Create(e.InteractiveEventArgs.Origin.X, e.InteractiveEventArgs.Origin.Y, e.InteractiveEventArgs.Position.X - e.InteractiveEventArgs.Origin.X, e.InteractiveEventArgs.Position.Y - e.InteractiveEventArgs.Origin.Y);
            Rectangle pixels = new Rectangle((int)MyRect.X, (int)MyRect.Y, (int)MyRect.Width, (int)MyRect.Height);

            if (pixels.Left > pixels.Right)
            {
               pixels = Rectangle.FromLTRB(pixels.Right, pixels.Top, pixels.Left, pixels.Bottom);
            }
            if (pixels.Top > pixels.Bottom)
            {
               pixels = Rectangle.FromLTRB(pixels.Left, pixels.Bottom, pixels.Right, pixels.Top);
            }

            if (pixels.Width > 2 && pixels.Height > 2)
            {
               RectangleF pixelsF = pixels;

               using (Matrix m = GetMatrixFromLeadMatrix(_rasterImageViewer.GetImageTransformWithDpi(true)))
               {
                  Transformer trans = new Transformer(m);
                  pixelsF = trans.RectangleToLogical(pixelsF);
               }

               pixelsF = RectangleF.Intersect(new RectangleF(0, 0, _rasterImageViewer.Image.ImageWidth, _rasterImageViewer.Image.ImageHeight), pixelsF);
               pixels = Rectangle.Round(pixelsF);

               LeadRect bounds = new LeadRect(pixels.X, pixels.Y, pixels.Width, pixels.Height);
               BeginInvoke(new DoActionDelegate(DoAction), new object[] { actionName, bounds });
            }
         }
      }

      void RegionInteractiveMode_RubberBandStarted(object sender, ImageViewerRubberBandEventArgs e)
      {
         _disableExtraDrawing = true;
         _rasterImageViewer.Invalidate();
         _rasterImageViewer.Update();
      }

      private void _rasterImageViewer_TransformChanged(object sender, EventArgs e)
      {
         if(IsHandleCreated)
         {
            if (_viewerRegionCopy)
            {
               RegionG = _rasterImageViewer.Image.GetRegion(null);
               _rasterImageViewer.CombineFloater(true);
               _viewerRegionPage = _rasterImageViewer.Image.Page;
               _viewerRegionCopy = false;
               _viewerRegion = true;
            }
            UpdateZoomValueFromControl();
            UpdateUIState();
         }
      }

      private void _rasterImageViewer_InteractiveZoomTo(object sender, ImageViewerRubberBandEventArgs e)
      {
         // Go back to selection mode
         // We must invoke this because the select button will change the
         // interactive mode of the viewer and hence, cancel the current
         // operation
         BeginInvoke(new MethodInvoker(DoSelectMode));
      }

      private void _rasterImageViewer_InteractiveRegionRectangle(object sender, ImageViewerRubberBandEventArgs e)
      {
         // Go back to selection mode
         // We must invoke this because the select button will change the
         // interactive mode of the viewer and hence, cancel the current
         // operation
         BeginInvoke(new MethodInvoker(DoSelectMode));
         BeginInvoke(new MethodInvoker(UpdateUIState));

         _disableExtraDrawing = false;
         _viewerRegionCopy = true;
      }

      private Matrix GetMatrixFromLeadMatrix(LeadMatrix matrix)
      {
         return new Matrix((float)matrix.M11, (float)matrix.M12, (float)matrix.M21, (float)matrix.M22, (float)matrix.OffsetX, (float)matrix.OffsetY);
      }

      private void _rasterImageViewer_PostImagePaint(object sender, ImageViewerRenderEventArgs e)
      {
         RasterImage image = _rasterImageViewer.Image;

         if(image != null && !_disableExtraDrawing)
         {
            if(ShowBarcodes)
            {
               using(StringFormat sf = new StringFormat())
               using(Brush normalBrush = new SolidBrush(Color.FromArgb(200, Color.DarkGreen)))
               using(Pen normalPen = new Pen(Color.FromArgb(180, Color.DarkGreen), 4))
               using(Brush selectedBrush = new SolidBrush(Color.FromArgb(200, Color.Blue)))
               using(Pen selectedPen = new Pen(Color.FromArgb(180, Color.Blue), 4))
               {
                  sf.FormatFlags = StringFormatFlags.NoWrap;

                  // Draw the barcodes for this page
                  int index = 0;
                  PageBarcodes pageBarcodes = _documentBarcodes.Pages[image.Page - 1];
                  foreach(BarcodeData data in pageBarcodes.Barcodes)
                  {
                     if(index == pageBarcodes.SelectedIndex)
                     {
                        DrawBarcodeData(e.PaintEventArgs.Graphics, image, data, sf, selectedBrush, selectedPen);
                     }
                     else
                     {
                        DrawBarcodeData(e.PaintEventArgs.Graphics, image, data, sf, normalBrush, normalPen);
                     }

                     index++;
                  }
               }
            }

            if (_viewerRegion && _rasterImageViewer.Image.Page == _viewerRegionPage)
            {
               // Draw an alpha brush around the image region
               if (!_rasterImageViewer.Image.HasRegion)
               {
                  _rasterImageViewer.Image.SetRegion(null, RegionG, RasterRegionCombineMode.Set);
               }
               LeadRect regionBounds = RegionG.GetBounds();// _rasterImageViewer.Image.GetRegionBounds(null);
               LeadRectD regionRect = new LeadRectD(regionBounds.X, regionBounds.Y, regionBounds.Width, regionBounds.Height);
               regionRect = _rasterImageViewer.ImageTransform.TransformRect(regionRect);
               regionRect.Inflate(1, 1);
               LeadRectD imageRect = new LeadRectD(0, 0, image.ImageWidth, image.ImageHeight);
               imageRect = _rasterImageViewer.ImageTransform.TransformRect(imageRect);
               imageRect.Inflate(1, 1);

               using (Region region = new Region(new Rectangle((int)imageRect.X, (int)imageRect.Y, (int)imageRect.Width, (int)imageRect.Height)))
               {
                  region.Exclude(new Rectangle((int)regionRect.X, (int)regionRect.Y, (int)regionRect.Width, (int)regionRect.Height));
                  using(Brush brush = new HatchBrush(HatchStyle.SmallConfetti, Color.Black, Color.FromArgb(64, Color.Black)))
                  {
                     e.PaintEventArgs.Graphics.FillRegion(brush, region);
                  }
               }

               e.PaintEventArgs.Graphics.DrawRectangle(Pens.Black, (int)regionRect.X, (int)regionRect.Y, (int)regionRect.Width, (int)regionRect.Height);
               e.PaintEventArgs.Graphics.DrawRectangle(Pens.Black, (int)imageRect.X, (int)imageRect.Y, (int)imageRect.Width, (int)imageRect.Height);
            }
         }
      }

      private void DrawBarcodeData(Graphics g, RasterImage image, BarcodeData data, StringFormat sf, Brush brush, Pen pen)
      {
         LeadRect rect = data.Bounds;
         LeadRectD rc = new LeadRectD(rect.X, rect.Y, rect.Width, rect.Height);
         string line = BarcodeEngine.GetSymbologyFriendlyName(data.Symbology);
         if (FourPoints && data.Symbology != BarcodeSymbology.Aztec && data.Symbology != BarcodeSymbology.Maxi && data.Symbology != BarcodeSymbology.MicroQR)
         {
            LeadPointD[] pointsL = new LeadPointD[4];                Point[] points = new Point[4];
            pointsL[0].X = ((int)rc.Left & 0xffff);                  pointsL[0].Y = ((int)rc.Left >> 16);
            pointsL[1].X = ((int)rc.Top & 0xffff);                   pointsL[1].Y = ((int)rc.Top >> 16);
            pointsL[2].X = ((int)rc.Width & 0xffff);                 pointsL[2].Y = ((int)rc.Width >> 16);
            pointsL[3].X = ((int)rc.Height & 0xffff);                pointsL[3].Y = ((int)rc.Height >> 16);
            
            _rasterImageViewer.ImageTransform.TransformPoints(pointsL);

            for (int i = 0; i < 4; i++)
            {
               points[i].X = (int)pointsL[i].X;    points[i].Y = (int)pointsL[i].Y;
            }

            g.DrawPolygon(pen, points);

            SizeF size = g.MeasureString(line, Font, points[2].X - points[0].X, sf);
            rc.Width = (int)size.Width + 1;
            rc.Height = (int)size.Height + 1;

            g.FillRectangle(brush, points[0].X, points[0].Y, (int)rc.Width, (int)rc.Height);
            g.DrawString(line, Font, Brushes.White, new RectangleF(points[0].X, points[0].Y, (int)rc.Width, (int)rc.Height), sf);
         }
         else
         {
            rc = _rasterImageViewer.ImageTransform.TransformRect(rc);
            rc.Inflate(3, 3);

            if (rc.Width < 10 || rc.Height < 10) return;

            g.DrawRectangle(pen, (int)rc.X, (int)rc.Y, (int)rc.Width, (int)rc.Height);

            SizeF size = g.MeasureString(line, Font, (int)rc.Width, sf);
            rc.Width = (int)size.Width + 1;
            rc.Height = (int)size.Height + 1;

            g.FillRectangle(brush, (int)rc.X, (int)rc.Y, (int)rc.Width, (int)rc.Height);
            g.DrawString(line, Font, Brushes.White, new RectangleF((int)rc.X, (int)rc.Y, (int)rc.Width, (int)rc.Height), sf);
         }
      }

      private void _rasterImageViewer_MouseMove(object sender, MouseEventArgs e)
      {
         string str = String.Empty;

         RasterImage image = _rasterImageViewer.Image;
         if(image != null)
         {
            LeadPoint pixels = PhysicalToLogical(new LeadPoint(e.X, e.Y));

            if(pixels.X >= 0 && pixels.X <= image.ImageWidth &&
               pixels.Y >= 0 && pixels.Y <= image.ImageHeight)
            {
               str = string.Format("{0},{1} px", (int)pixels.X, (int)pixels.Y);
            }

            if(InteractiveMode == ViewerControlInteractiveMode.SelectMode)
            {
               int index = HitTestBarcode(pixels);
               if (index != -1)
               {
                  _rasterImageViewer.Cursor = Cursors.Cross;
               }
               else if (MainForm.InversePerspectiveActive == false)
               {
                  _rasterImageViewer.Cursor = Cursors.Default;
               }
            }
         }

         _mousePositionLabel.Text = str;
      }

      private void _rasterImageViewer_MouseClick(object sender, MouseEventArgs e)
      {
         RasterImage image = _rasterImageViewer.Image;
         if(image != null && InteractiveMode == ViewerControlInteractiveMode.SelectMode)
         {
            LeadPoint pixels = PhysicalToLogical(new LeadPoint(e.X, e.Y));

            if(pixels.X >= 0 && pixels.X <= image.ImageWidth &&
               pixels.Y >= 0 && pixels.Y <= image.ImageHeight)
            {
               int index = HitTestBarcode(pixels);
               if(index != _documentBarcodes.Pages[_rasterImageViewer.Image.Page - 1].SelectedIndex)
               {
                  DoAction("SelectedBarcodeChanged", index);
               }
            }
         }
      }

      public LeadPoint PhysicalToLogical(LeadPoint physical)
      {
         PointF pixelsF = new PointF(physical.X, physical.Y);

         using (Matrix m = GetMatrixFromLeadMatrix(_rasterImageViewer.GetImageTransformWithDpi(true)))
         {
            Transformer trans = new Transformer(m);
            pixelsF = trans.PointToLogical(pixelsF);
         }

         Point pixels = Point.Round(pixelsF);
         return new LeadPoint(pixels.X, pixels.Y);
      }

      private int HitTestBarcode(LeadPoint point)
      {
         int index = 0;
         PageBarcodes pageBarcodes = _documentBarcodes.Pages[_rasterImageViewer.Image.Page - 1];
         foreach(BarcodeData data in pageBarcodes.Barcodes)
         {
            if(data.Bounds.Contains(point))
            {
               return index;
            }

            index++;
         }

         return -1;
      }
      #endregion Viewer

      #region UI
      private void UpdateUIState()
      {
         // Update the UI controls states

         _fitPageWidthToolStripButton.Checked = _rasterImageViewer.SizeMode == ControlSizeMode.FitWidth;
         _fitPageToolStripButton.Checked = _rasterImageViewer.SizeMode == ControlSizeMode.FitAlways;

         _selectModeToolStripButton.Checked = _interactiveMode == ViewerControlInteractiveMode.SelectMode;
         _panModeToolStripButton.Checked = _interactiveMode == ViewerControlInteractiveMode.PanMode;
         _zoomToSelectionModeToolStripButton.Checked = _interactiveMode == ViewerControlInteractiveMode.ZoomToSelectionMode;
         _regionModeToolStripButton.Checked = _interactiveMode == ViewerControlInteractiveMode.RegionMode;
         _deleteRegionToolStripButton.Enabled = _rasterImageViewer.Image != null && _viewerRegion; // _rasterImageViewer.Image.HasRegion;
         _readBarcodeModeToolStripButton.Checked = _interactiveMode == ViewerControlInteractiveMode.ReadBarcodeMode;
         _writeBarcodeModeToolStripButton.Checked = _interactiveMode == ViewerControlInteractiveMode.WriteBarcodeMode;

         if(_rasterImageViewer.Image != null)
         {
            if (!_toolStrip.Enabled && MainForm.InversePerspectiveActive == false)
            {
               _toolStrip.Enabled = true;
            }

            int pageNumber = _rasterImageViewer.Image.Page;
            int pageCount = _rasterImageViewer.Image.PageCount;

            _pageToolStripTextBox.Text = pageNumber.ToString();
            _pageToolStripLabel.Text = "/ " + pageCount.ToString();
            _pageToolStripTextBox.Enabled = pageCount > 1;

            _previousPageToolStripButton.Enabled = pageNumber > 1;
            _nextPageToolStripButton.Enabled = pageNumber < pageCount;
         }
         else
         {
            _pageToolStripTextBox.Text = "0";
            _pageToolStripLabel.Text = "/ 0";

            _zoomToolStripComboBox.Text = string.Empty;

            _toolStrip.Enabled = false;
         }
      }

      private void UpdateZoomValueFromControl()
      {
         // We are invoking this instead of changing the properties
         // directly because the Text value of a combo box is not
         // updated till after the lost focus or enter event is exited
         BeginInvoke(new MethodInvoker(delegate()
         {
            if(_rasterImageViewer.Image != null)
            {
               double factor = _rasterImageViewer.XScaleFactor * 100.0;
               _zoomToolStripComboBox.Text = factor.ToString("F1") + "%";
            }
            else
            {
               _zoomToolStripComboBox.Text = string.Empty;
            }
         }));
      }

      private void _previousPageToolStripButton_Click(object sender, EventArgs e)
      {
         TryGotoPage(_rasterImageViewer.Image.Page - 1);
      }

      private void _nextPageToolStripButton_Click(object sender, EventArgs e)
      {
         TryGotoPage(_rasterImageViewer.Image.Page + 1);
      }

      private void _pageToolStripTextBox_LostFocus(object sender, EventArgs e)
      {
         _pageToolStripTextBox.Text = _rasterImageViewer.Image.Page.ToString();
      }

      private void _pageToolStripTextBox_KeyPress(object sender, KeyPressEventArgs e)
      {
         if(e.KeyChar == (char)Keys.Return)
         {
            // User has pressed enter, go to the new page number

            string str = _pageToolStripTextBox.Text.Trim();

            // Try to parse the integer value
            int pageNumber;
            if(int.TryParse(str, out pageNumber))
            {
               TryGotoPage(pageNumber);
            }

            _pageToolStripTextBox.Text = _rasterImageViewer.Image.Page.ToString();
         }
      }

      private void TryGotoPage(int pageNumber)
      {
         // Check if the index is valid
         if(pageNumber >= 1 && pageNumber <= _rasterImageViewer.Image.PageCount)
         {
            // Yes, fire the event to the main form
            DoAction("PageNumberChanged", pageNumber);
         }
      }

      private void _zoomOutToolStripButton_Click(object sender, EventArgs e)
      {
         ZoomViewer(true);
      }

      private void _zoomInToolStripButton_Click(object sender, EventArgs e)
      {
         ZoomViewer(false);
      }

      private void _zoomToolStripComboBox_LostFocus(object sender, EventArgs e)
      {
         UpdateZoomValueFromControl();
      }

      private void _zoomToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         // Parse the new zoom value
         string str = _zoomToolStripComboBox.Text.Trim();

         switch(str)
         {
            case "Actual Size":
               SetViewerZoomPercentage(100);
               break;

            case "Fit Page":
               FitPage(false);
               break;

            case "Fit Width":
               FitPage(true);
               break;

            default:
               if(!string.IsNullOrEmpty(str))
               {
                  double val = double.Parse(str.Substring(0, str.Length - 1));
                  SetViewerZoomPercentage(val);
               }
               break;
         }
      }

      private void _zoomToolStripComboBox_KeyPress(object sender, KeyPressEventArgs e)
      {
         if(e.KeyChar == (char)Keys.Return)
         {
            // User has pressed enter, parse the new zoom value

            string str = _zoomToolStripComboBox.Text.Trim();

            if(!string.IsNullOrEmpty(str))
            {
               // Remove the % sign if present
               if(str.EndsWith("%"))
               {
                  str = str.Remove(str.Length - 1, 1).Trim();
               }

               // Try to parse the new zoom value
               double percentage;
               if(double.TryParse(str, out percentage))
               {
                  SetViewerZoomPercentage(percentage);
               }

               UpdateZoomValueFromControl();
            }
         }
      }

      private void SetViewerZoomPercentage(double percentage)
      {
         // Normalize the percentage based on min/max value allowed
         percentage = Math.Max(_minimumViewerScalePercentage, Math.Min(_maximumViewerScalePercentage, percentage));

         if (Math.Abs(_rasterImageViewer.XScaleFactor * 100.0 - percentage) > 0.01)
         {
            // Save the current center location in the viewer, we will use it later to
            // re-center the viewer
            Rectangle rc = Rectangle.Intersect(_rasterImageViewer.DisplayRectangle, _rasterImageViewer.ClientRectangle);
            PointF center = new PointF(rc.Left + rc.Width / 2, rc.Top + rc.Right / 2);

            using (Matrix m = GetMatrixFromLeadMatrix(_rasterImageViewer.GetImageTransformWithDpi(true)))
            {
               Transformer trans = new Transformer(m);
               center = trans.PointToLogical(center);
            }

            _rasterImageViewer.BeginUpdate();

            // Zoom
            _rasterImageViewer.Zoom(ControlSizeMode.None, percentage / 100.0, _rasterImageViewer.DefaultZoomOrigin);
            // Go back to original center point
            using (Matrix m = GetMatrixFromLeadMatrix(_rasterImageViewer.GetImageTransformWithDpi(true)))
            {
               Transformer trans = new Transformer(m);
               center = trans.PointToPhysical(center);
            }

            _rasterImageViewer.CenterAtPoint(new LeadPoint((int)center.X, (int)center.Y));

            _rasterImageViewer.EndUpdate();

            _rasterImageViewer_TransformChanged(_rasterImageViewer, EventArgs.Empty);

            UpdateUIState();
         }
      }

      private void _fitPageWidthToolStripButton_Click(object sender, EventArgs e)
      {
         FitPage(true);
      }

      private void _fitPageToolStripButton_Click(object sender, EventArgs e)
      {
         FitPage(false);
      }

      private void _selectModeToolStripButton_Click(object sender, EventArgs e)
      {
         DoSelectMode();
      }

      private void DoSelectMode()
      {
         InteractiveMode = ViewerControlInteractiveMode.SelectMode;
      }

      private void _panModeToolStripButton_Click(object sender, EventArgs e)
      {
         InteractiveMode = ViewerControlInteractiveMode.PanMode;
      }

      private void _zoomToSelectionModeToolStripButton_Click(object sender, EventArgs e)
      {
         InteractiveMode = ViewerControlInteractiveMode.ZoomToSelectionMode;
      }

      private void _regionModeToolStripButton_Click(object sender, EventArgs e)
      {
         InteractiveMode = ViewerControlInteractiveMode.RegionMode;
      }

      private void _deleteRegionToolStripButton_Click(object sender, EventArgs e)
      {
         _viewerRegion = false;
         _rasterImageViewer.Image.MakeRegionEmpty();
         ImageRegionChanged();
         _rasterImageViewer.Invalidate();
      }

      private void _writeBarcodeModeToolStripButton_Click(object sender, EventArgs e)
      {
         InteractiveMode = ViewerControlInteractiveMode.WriteBarcodeMode;
      }

      private void _readBarcodeModeToolStripButton_Click(object sender, EventArgs e)
      {
         InteractiveMode = ViewerControlInteractiveMode.ReadBarcodeMode;
      }

      private void _showBarcodesToolStripButton_Click(object sender, EventArgs e)
      {
         _showBarcodesToolStripButton.Checked = !_showBarcodesToolStripButton.Checked;
         _rasterImageViewer.Invalidate();
      }
      #endregion UI
   }
}
