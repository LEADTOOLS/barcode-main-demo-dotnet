// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools;
using Leadtools.ImageProcessing;
using Leadtools.ImageProcessing.Core;
using Leadtools.Codecs;
using Leadtools.WinForms;
using Leadtools.Twain;
using Leadtools.Barcode;
using System.Drawing.Drawing2D;
using Leadtools.Controls;

namespace BarcodeMainDemo
{
   public partial class MainForm : Form
   {
      #region Private Variables
      // The RasterCodecs instance we will use to load/save images
      private RasterCodecs _rasterCodecs;
      // The TWAIN scanning session we will use to scan (if available)
      private TwainSession _twainSession;
      // The Barcode engine
      private BarcodeEngine _barcodeEngine;
      // Barcodes read or written in this document
      private DocumentBarcodes _documentBarcodes;

      private DemoOptions _demoOptions = DemoOptions.Default;

      // A RasterImage that holds barcode symbology samples
      private RasterImage _sampleSymbologiesRasterImage;

      #endregion Private Variables

      public static bool InversePerspectiveActive = false;
      Dictionary<ImageViewer, Form> _interactiveToolsList;
      public Dictionary<ImageViewer, Form> InteractiveToolsList
      {
         get
         {
            return _interactiveToolsList;
         }
      }

      public MainForm()
      {
         InitializeComponent();

         Messager.Caption = "Barcode C# Demo";
         Text = Messager.Caption;
      }

      #region UI
      protected override void OnLoad(EventArgs e)
      {
         if(!DesignMode)
         {
            try
            {
               if(!Init())
               {
                  Close();
                  return;
               }
            }
            catch(Exception ex)
            {
               ShowError(ex);
               Close();
            }
         }

         base.OnLoad(e);
      }

      protected override void OnFormClosed(FormClosedEventArgs e)
      {
         _demoOptions.Save();

         CleanUp();

         base.OnFormClosed(e);
      }

      private void _newToolStripButton_Click(object sender, EventArgs e)
      {
         DoNewDocument();
      }

      private void _openToolStripButton_Click(object sender, EventArgs e)
      {
         DoOpenDocument();
      }

      private void _saveToolStripButton_Click(object sender, EventArgs e)
      {
         DoSaveDocument();
      }

      private void _readBarcodesToolStripButton_Click(object sender, EventArgs e)
      {
         DoReadBarcodes(false, LeadRect.Empty, true);
      }

      private void _writeBarcodeToolStripButton_Click(object sender, EventArgs e)
      {
         DoWriteBarcode(LeadRect.Empty);
      }

      private void _readBarcodeOptionsToolStripButton_Click(object sender, EventArgs e)
      {
         DoReadBarcodeOptions();
      }

      private void _fileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         _saveToolStripMenuItem.Visible = _viewerControl.Visible;
         _closeToolStripMenuItem.Visible = _viewerControl.Visible;
      }

      private void _newToolStripMenuItem_Click(object sender, EventArgs e)
      {
         DoNewDocument();
      }

      private void _openToolStripMenuItem_Click(object sender, EventArgs e)
      {
         DoOpenDocument();
      }

      private void _saveToolStripMenuItem_Click(object sender, EventArgs e)
      {
         DoSaveDocument();
      }

      private void _closeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if(_viewerControl.RasterImageViewer.Image == null) return;

         SetDocument(null, null);
      }

      private void _selectSourceToolStripMenuItem_Click(object sender, EventArgs e)
      {
         SelectTwainSource();
      }

      private void _acquireToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ScanUsingTwain();
      }

      private void _exitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void _editToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         _copyImageToolStripMenuItem.Visible = _viewerControl.Visible;
         
         _pasteImageToolStripMenuItem.Enabled = RasterClipboard.IsReady;
      }

      private void _copyImageToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if(_viewerControl.RasterImageViewer.Image == null) return;

         try
         {
            using(WaitCursor wait = new WaitCursor())
            {
               RasterClipboard.Copy(this.Handle, _viewerControl.RasterImageViewer.Image, RasterClipboardCopyFlags.Dib);
            }
         }
         catch(Exception ex)
         {
            ShowError(ex);
         }
      }

      private void _pasteImageToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if(!RasterClipboard.IsReady) return;

         RasterImage image = null;

         try
         {
            using(WaitCursor wait = new WaitCursor())
            {
               image = RasterClipboard.Paste(this.Handle);
            }
         }
         catch(Exception ex)
         {
            ShowError(ex);
         }

         if(image != null)
         {
             SetDocument(image, DemosGlobalization.GetResxString(GetType(), "Resx_ClipboardImage"));
         }
      }

      private void _viewToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         if(_viewerControl.RasterImageViewer.Image == null) return;

         _fitWidthToolStripMenuItem.Checked = _viewerControl.RasterImageViewer.SizeMode == Leadtools.Controls.ControlSizeMode.FitWidth;
         _fitPageToolStripMenuItem.Checked = _viewerControl.RasterImageViewer.SizeMode == Leadtools.Controls.ControlSizeMode.FitAlways;
      }

      private void _zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if(_viewerControl.RasterImageViewer.Image == null) return;

         _viewerControl.ZoomViewer(true);
      }

      private void _zoomInToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if(_viewerControl.RasterImageViewer.Image == null) return;

         _viewerControl.ZoomViewer(false);
      }

      private void _fitWidthToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if(_viewerControl.RasterImageViewer.Image == null) return;

         _viewerControl.FitPage(true);
      }

      private void _fitPageToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _viewerControl.FitPage(false);
      }

      private void _pageToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         if(_viewerControl.RasterImageViewer.Image == null) return;

         int page = _viewerControl.RasterImageViewer.Image.Page;
         int pageCount = _viewerControl.RasterImageViewer.Image.PageCount;

         _previousPageToolStripMenuItem.Enabled = page > 1;
         _nextPageToolStripMenuItem.Enabled = page < pageCount;
         _gotoPageToolStripMenuItem.Enabled = pageCount > 1;
      }

      private void _previousPageToolStripMenuItem_Click(object sender, EventArgs e)
      {
         GotoPage(_viewerControl.RasterImageViewer.Image.Page - 1);
      }

      private void _nextPageToolStripMenuItem_Click(object sender, EventArgs e)
      {
         GotoPage(_viewerControl.RasterImageViewer.Image.Page + 1);
      }

      private void _gotoPageToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if(_viewerControl.RasterImageViewer.Image == null) return;

         using(GotoPageDialog dlg = new GotoPageDialog())
         {
            dlg.DocumentPage = _viewerControl.RasterImageViewer.Image.Page;
            dlg.DocumentPageCount = _viewerControl.RasterImageViewer.Image.PageCount;
            if(dlg.ShowDialog(this) == DialogResult.OK)
            {
               GotoPage(dlg.DocumentPage);
            }
         }
      }

      private void _interactiveToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         if(_viewerControl.RasterImageViewer.Image == null) return;

         ViewerControl.ViewerControlInteractiveMode interactiveMode = _viewerControl.InteractiveMode;

         _selectModeToolStripMenuItem.Checked = (interactiveMode == ViewerControl.ViewerControlInteractiveMode.SelectMode);
         _panModeToolStripMenuItem.Checked = (interactiveMode == ViewerControl.ViewerControlInteractiveMode.PanMode);
         _zoomToModeToolStripMenuItem.Checked = (interactiveMode == ViewerControl.ViewerControlInteractiveMode.ZoomToSelectionMode);
         _drawRegionModeToolStripMenuItem.Checked = (interactiveMode == ViewerControl.ViewerControlInteractiveMode.RegionMode);
         _readBarcodeModeToolStripMenuItem.Checked = (interactiveMode == ViewerControl.ViewerControlInteractiveMode.ReadBarcodeMode);
         _writeBarcodeModeToolStripMenuItem.Checked = (interactiveMode == ViewerControl.ViewerControlInteractiveMode.WriteBarcodeMode);
         _writeBarcodeModeToolStripMenuItem.Enabled = _viewerControl.ShowBarcodes;
         _deleteRegionToolStripMenuItem.Enabled = _viewerControl._viewerRegion;// _viewerControl.RasterImageViewer.Image.HasRegion;
      }

      private void _selectModeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if(_viewerControl.RasterImageViewer.Image == null) return;

         _viewerControl.InteractiveMode = ViewerControl.ViewerControlInteractiveMode.SelectMode;
      }

      private void _panModeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if(_viewerControl.RasterImageViewer.Image == null) return;

         _viewerControl.InteractiveMode = ViewerControl.ViewerControlInteractiveMode.PanMode;
      }

      private void _zoomToModeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if(_viewerControl.RasterImageViewer.Image == null) return;

         _viewerControl.InteractiveMode = ViewerControl.ViewerControlInteractiveMode.ZoomToSelectionMode;
      }

      private void _drawRegionModeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if(_viewerControl.RasterImageViewer.Image == null) return;

         _viewerControl.InteractiveMode = ViewerControl.ViewerControlInteractiveMode.RegionMode;
      }

      private void _readBarcodeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if(_viewerControl.RasterImageViewer.Image == null) return;

         _viewerControl.InteractiveMode = ViewerControl.ViewerControlInteractiveMode.ReadBarcodeMode;
      }

      private void _barcodeImageTypeToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         if (_viewerControl.RasterImageViewer.Image == null) return;

         _scannedDocumentImageTypeToolStripMenuItem.Checked = (_barcodeEngine.Reader.ImageType == BarcodeImageType.ScannedDocument);
         _pictureImageTypeToolStripMenuItem.Checked = (_barcodeEngine.Reader.ImageType == BarcodeImageType.Picture);
         _unknownImageTypeToolStripMenuItem.Checked = (_barcodeEngine.Reader.ImageType == BarcodeImageType.Unknown);
      }

      private void _scannedDocumentImageTypeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_viewerControl.RasterImageViewer.Image == null) return;

         _barcodeEngine.Reader.ImageType = BarcodeImageType.ScannedDocument;
      }

      private void _pictureImageTypeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_viewerControl.RasterImageViewer.Image == null) return;

         _barcodeEngine.Reader.ImageType = BarcodeImageType.Picture;
      }

      private void _unknownImageTypeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_viewerControl.RasterImageViewer.Image == null) return;

         _barcodeEngine.Reader.ImageType = BarcodeImageType.Unknown;
      }

      private void _barcodeReturnBoundariesToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         if (_viewerControl.RasterImageViewer.Image == null) return;

         _returnBoundingRectToolStripMenuItem.Checked = (_barcodeEngine.Reader.EnableReturnFourPoints == false);
         _returnFourPointsToolStripMenuItem.Checked = (_barcodeEngine.Reader.EnableReturnFourPoints == true);
      }

      private void _returnBoundingRectToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_viewerControl.RasterImageViewer.Image == null) return;

         _barcodeEngine.Reader.EnableReturnFourPoints = false;
         _viewerControl.FourPoints = false;
         ChangingBoundingType();
         _viewerControl.RasterImageViewer.Invalidate();
      }

      private void _returnFourPointsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_viewerControl.RasterImageViewer.Image == null) return;

         _barcodeEngine.Reader.EnableReturnFourPoints = true;
         _viewerControl.FourPoints = true;
         ChangingBoundingType();
         _viewerControl.RasterImageViewer.Invalidate();
      }

      private void _writeBarcodeModeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if(_viewerControl.RasterImageViewer.Image == null) return;

         _viewerControl.InteractiveMode = ViewerControl.ViewerControlInteractiveMode.WriteBarcodeMode;
      }

      private void _deleteRegionToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if(_viewerControl.RasterImageViewer.Image == null) return;

         _viewerControl._viewerRegion = false;
         _viewerControl.RasterImageViewer.Image.MakeRegionEmpty();
         _viewerControl.ImageRegionChanged();
         _viewerControl.RasterImageViewer.Invalidate();
      }


      private void _preprocessingToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         if(_viewerControl.RasterImageViewer.Image == null) return;

         _preprocessAllPagesToolStripMenuItem.Enabled = _viewerControl.RasterImageViewer.Image.PageCount > 1;

         if (_viewerControl.RasterImageViewer.Image.BitsPerPixel == 1) 
            _lineRemoveToolStripMenuItem.Enabled = true;
         else
            _lineRemoveToolStripMenuItem.Enabled = false;

         if (_viewerControl.RasterImageViewer.Image.BitsPerPixel == 8 || _viewerControl.RasterImageViewer.Image.BitsPerPixel == 24 || _viewerControl.RasterImageViewer.Image.BitsPerPixel == 32)
         {
            _perspectiveDeskewToolStripMenuItem.Enabled = true;
         } 
         else
         {
            _perspectiveDeskewToolStripMenuItem.Enabled = false;
         }
      }

      private void _preprocessAllPagesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _preprocessAllPagesToolStripMenuItem.Checked = !_preprocessAllPagesToolStripMenuItem.Checked;
      }

      private void _flipToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if(_viewerControl.RasterImageViewer.Image == null) return;

         FlipCommand cmd = new FlipCommand(false);
         RunImageProcessingCommand(cmd);
      }

      private void _reverseToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if(_viewerControl.RasterImageViewer.Image == null) return;

         FlipCommand cmd = new FlipCommand(true);
         RunImageProcessingCommand(cmd);
      }

      private void _rotate90ClockwiseToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if(_viewerControl.RasterImageViewer.Image == null) return;

         RotateCommand cmd = new RotateCommand(90 * 100, RotateCommandFlags.Resize, RasterColor.FromKnownColor(RasterKnownColor.White));
         RunImageProcessingCommand(cmd);
      }

      private void _rotate90CounterclockwiseToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if(_viewerControl.RasterImageViewer.Image == null) return;

         RotateCommand cmd = new RotateCommand(-90 * 100, RotateCommandFlags.Resize, RasterColor.FromKnownColor(RasterKnownColor.White));
         RunImageProcessingCommand(cmd);
      }

      private void _noiseMinFilterToolStripMenuItem_Click(object sender, EventArgs e)
      {
         // Check support required to use this demo
         if (RasterSupport.IsLocked(RasterSupportType.Document))
         {
            Messager.ShowError(this, DemosGlobalization.GetResxString(GetType(), "Resx_LEADDocumentSupport"));
            return;
         }
         
         if (_viewerControl.RasterImageViewer.Image == null) return;
         ValueDialog dlg = new ValueDialog(ValueDialog.TypeConstants.Min);
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            MinimumCommand cmd = new MinimumCommand(dlg.Value);
            RunImageProcessingCommand(cmd);
         }
      }
      
      private void _noiseMedianFilterToolStripMenuItem_Click(object sender, EventArgs e)
      {
         // Check support required to use this demo
         if (RasterSupport.IsLocked(RasterSupportType.Document))
         {
            Messager.ShowError(this, DemosGlobalization.GetResxString(GetType(), "Resx_LEADDocumentSupport"));
            return;
         } 
         
         if (_viewerControl.RasterImageViewer.Image == null) return;
         ValueDialog dlg = new ValueDialog(ValueDialog.TypeConstants.Median);
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            MedianCommand cmd = new MedianCommand(dlg.Value);
            RunImageProcessingCommand(cmd);
         }
      }
      
      private void _noiseMaxFilterToolStripMenuItem_Click(object sender, EventArgs e)
      {
         // Check support required to use this demo
         if (RasterSupport.IsLocked(RasterSupportType.Document))
         {
            Messager.ShowError(this, DemosGlobalization.GetResxString(GetType(), "Resx_LEADDocumentSupport"));
            return;
         } 
         
         if (_viewerControl.RasterImageViewer.Image == null) return;
         ValueDialog dlg = new ValueDialog(ValueDialog.TypeConstants.Max);
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            MaximumCommand cmd = new MaximumCommand(dlg.Value);
            RunImageProcessingCommand(cmd);
         }
      }

      private void _lineRemoveToolStripMenuItem_Click(object sender, EventArgs e)
      {
         // Check support required to use this demo
         if (RasterSupport.IsLocked(RasterSupportType.Document))
         {
            Messager.ShowError(this, DemosGlobalization.GetResxString(GetType(), "Resx_LEADDocumentSupport"));
            return;
         } 
         
         try
         {
            LineRemoveCommand _LineRemove = null;
            LineRemoveDialog dlg = new LineRemoveDialog(new LineRemoveCommand(), _viewerControl.RasterImageViewer.Image.XResolution, _viewerControl.RasterImageViewer.Image.YResolution);
            // Open the LineRemoveCommand dialog
            if (dlg.ShowDialog() == DialogResult.OK)
            {
               _LineRemove = new LineRemoveCommand();
               //_LineRemove.Progress += new EventHandler<RasterCommandProgressEventArgs>(Command_Progress);
               // Update the LineRemoveCommand.Type to select which lines to remove
               _LineRemove.Type = dlg.LineRemoveCommand.Type;
               // Update the LineRemoveCommand UseDpi flag 
               _LineRemove.Flags = dlg.LineRemoveCommand.Flags;
               // Update the LineRemoveCommand.GapLength to set the maximum length of a break or a hole in a line.
               _LineRemove.GapLength = dlg.LineRemoveCommand.GapLength;
               // Update the LineRemoveCommand.MaximumLineWidth to set the maximum average width of a line that is considered for removal.   
               _LineRemove.MaximumLineWidth = dlg.LineRemoveCommand.MaximumLineWidth;
               // Update the LineRemoveCommand.MinimumLineLength to set the minimum length of a line considered for removal.   
               _LineRemove.MinimumLineLength = dlg.LineRemoveCommand.MinimumLineLength;
               // Update the LineRemoveCommand.MaximumWallPercent to set the maximum number of wall slices (expressed as a percent of the total length of the line) that are allowed.
               _LineRemove.MaximumWallPercent = dlg.LineRemoveCommand.MaximumWallPercent;
               // Update LineRemoveCommand.Wall to set the height of a wall. Walls are slices of a line that are too wide to be considered part of the line. 
               _LineRemove.Wall = dlg.LineRemoveCommand.Wall;
               //ProgressBar.Visible = true;
               // Run the command on the loaded image
               _LineRemove.Run(_viewerControl.RasterImageViewer.Image);

            }

         }
         catch (RasterException ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      private void _imageDeskewToolStripMenuItem_Click(object sender, EventArgs e)
      {
         // Check support required to use this demo
         if (RasterSupport.IsLocked(RasterSupportType.Document))
         {
            Messager.ShowError(this, DemosGlobalization.GetResxString(GetType(), "Resx_LEADDocumentSupport"));
            return;
         } 
         
         if (_viewerControl.RasterImageViewer.Image == null) return;

         DeskewCommand cmd = new DeskewCommand();
         RunImageProcessingCommand(cmd);
      }      

      private void _segmentationPerspectiveMenuItem_Click(object sender, EventArgs e)
      {
         if (_interactiveToolsList.ContainsKey(_viewerControl.RasterImageViewer))
            return;

         _mainMenuStrip.Enabled = false;
         _mainToolStrip.Enabled = false;
         _viewerControl._toolStrip.Enabled = false;
         _viewerControl.InteractiveMode = ViewerControl.ViewerControlInteractiveMode.SelectMode;

         PerspectiveDialog dlg = new PerspectiveDialog(this, _viewerControl);
         InversePerspectiveActive = true;
         dlg.Show();

         _interactiveToolsList.Add(_viewerControl.RasterImageViewer, dlg);
      }


      public void _enableMenus()
      {
         _mainMenuStrip.Enabled = true;
         _mainToolStrip.Enabled = true;
         _viewerControl._toolStrip.Enabled = true;
      }

      private void _perspectiveDeskewToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_viewerControl.RasterImageViewer.Image == null) return;

         _preprocessAllPagesToolStripMenuItem.Checked = false;
         
         PerspectiveDeskewCommand cmd = new PerspectiveDeskewCommand();
         RunImageProcessingCommand(cmd);
      }

      private void RunImageProcessingCommand(RasterCommand cmd)
      {
         // We must clear all the barcodes found
         DoClearAllBarcodes();

         // Run the command on all or just current page
         bool allPages = _preprocessAllPagesToolStripMenuItem.Checked;

         RasterImage image = _viewerControl.RasterImageViewer.Image;
         int savePageNumber = image.Page;

         try
         {
            using(WaitCursor wait = new WaitCursor())
            {
               for(int page = 1; page <= image.PageCount; page++)
               {
                  if(allPages)
                  {
                     image.Page = page;
                  }

                  if(page == image.Page)
                  {
                     cmd.Run(image);
                  }
               }
            }
         }
         catch(Exception ex)
         {
            ShowError(ex);
         }
         finally
         {
            if(savePageNumber != image.Page)
            {
               image.Page = savePageNumber;
            }

            _pagesControl.SetDocument(image);
         }
      }

      private void _barcodeToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         if(_viewerControl.RasterImageViewer.Image == null) return;

         bool barcodeSelected = _documentBarcodes.Pages[_viewerControl.RasterImageViewer.Image.Page - 1].SelectedIndex != -1;

         _deleteSelectedBarcodeToolStripMenuItem.Enabled = barcodeSelected;
         _zoomToSelectedBarcodeToolStripMenuItem.Enabled = barcodeSelected;
         _showBarcodesToolStripMenuItem.Checked = _viewerControl.ShowBarcodes;

         int count = 0;
         for (int i = 0; i < _documentBarcodes.Pages.Count; i++)
            count += _documentBarcodes.Pages[i].Barcodes.Count;

         _clearAllBarcodesToolStripMenuItem.Enabled = count > 0;
         _exportBarcodesToolStripMenuItem.Enabled = count > 0;
      }

      private void _readBarcodeOptionsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         DoReadBarcodeOptions();
      }

      private void _readBarcodesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         DoReadBarcodes(false, LeadRect.Empty, true);
      }

      private void _writeBarcodeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         DoWriteBarcode(LeadRect.Empty);
      }

      private void _showBarcodesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _showBarcodesToolStripMenuItem.Checked = !_showBarcodesToolStripMenuItem.Checked;
         _viewerControl.ShowBarcodes = _showBarcodesToolStripMenuItem.Checked;
         _viewerControl.RasterImageViewer.Invalidate();
      }

      private void _saveCurrentReadOptionsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         SaveBarcodeOptions(true);
      }

      private void _loadReadOptionsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         LoadBarcodeOptions(true);
      }

      private void _saveCurrentWriteOptionsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         SaveBarcodeOptions(false);
      }

      private void _loadWriteOptionsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         LoadBarcodeOptions(false);
      }

      private void _deleteSelectedBarcodeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         DoDeleteSelectedBarcode();
      }

      private void _zoomToSelectedBarcodeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if(_viewerControl.RasterImageViewer.Image == null) return;

         DoZoomToSelectedBarcode();
      }

      private void _exportBarcodesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if(_viewerControl.RasterImageViewer.Image == null) return;

         DoExportBarcodes();
      }

      private void _clearAllBarcodesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if(_viewerControl.RasterImageViewer.Image == null) return;

         DoClearAllBarcodes();
      }

      private void _aboutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("Barcode", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      private void _viewerControl_Action(object sender, ActionEventArgs e)
      {
         if(e.Action == "PageNumberChanged")
         {
            GotoPage((int)e.Data);
         }
         else if(e.Action == "ReadBarcode")
         {
            DoReadBarcodes(true, (LeadRect)e.Data, false);
         }
         else if(e.Action == "WriteBarcode")
         {
            DoWriteBarcode((LeadRect)e.Data);
         }
         else if(e.Action == "SelectedBarcodeChanged")
         {
            _documentBarcodes.Pages[_viewerControl.RasterImageViewer.Image.Page - 1].SelectedIndex = (int)e.Data;
            _viewerControl.RasterImageViewer.Invalidate();
            _barcodeControl.SelectedBarcodeChanged();
         }
      }

      private void _pagesControl_Action(object sender, ActionEventArgs e)
      {
         if(e.Action == "PageNumberChanged")
         {
            GotoPage((int)e.Data);
         }
      }

      private void _barcodeControl_Action(object sender, ActionEventArgs e)
      {
         if(e.Action == "SelectedBarcodeChanged")
         {
            int selectedIndex = (int)e.Data;
            _documentBarcodes.Pages[_viewerControl.RasterImageViewer.Image.Page - 1].SelectedIndex = (int)e.Data;
            _viewerControl.RasterImageViewer.Invalidate();
         }
         else if(e.Action == "DeleteSelectedBarcode")
         {
            DoDeleteSelectedBarcode();
         }
         else if(e.Action == "ZoomToSelectedBarcode")
         {
            DoZoomToSelectedBarcode();
         }
         else if(e.Action == "ViewSelectedBarcodeIDData")
         {
            DoViewSelectedBarcodeIDData();
         }
      }

      private void UpdateUIState()
      {
         // Update the status of the various UI controls

         bool documentOk = false;
         int pageCount = 1;

         if(_viewerControl.RasterImageViewer.Image != null)
         {
            documentOk = true;
            pageCount = _viewerControl.RasterImageViewer.Image.PageCount;
         }

         _viewToolStripMenuItem.Visible = documentOk;
         _pageToolStripMenuItem.Visible = documentOk;
         _interactiveToolStripMenuItem.Visible = documentOk;
         _barcodeToolStripMenuItem.Visible = documentOk;
         _preprocessingToolStripMenuItem.Visible = documentOk;

         _saveToolStripButton.Visible = documentOk;
         _readBarcodesToolStripButton.Visible = documentOk;
         _writeBarcodeToolStripButton.Visible = documentOk;
         _readBarcodeOptionsToolStripButton.Visible = documentOk;

         _viewerControl.Visible = documentOk;
         _pagesControl.Visible = documentOk && pageCount > 1;
         _barcodeControl.Visible = documentOk;
      }
      #endregion UI

      #region TWAIN
      private void StartupTwain()
      {
         // See if we can start a scanning session
         try
         {
            if (TwainSession.IsAvailable(this.Handle))
            {
               _twainSession = new TwainSession();

               _twainSession.Startup(this.Handle, "LEAD Technologies, Inc.", "LEAD Test Applications", "Version 1.0", Messager.Caption, TwainStartupFlags.None);

               _twainSession.AcquirePage += new EventHandler<TwainAcquirePageEventArgs>(_twainSession_AcquirePage);
            }
         }
         catch(TwainException ex)
         {
            _twainSession = null;

            if(ex.Code == TwainExceptionCode.InvalidDll)
            {
                Messager.ShowError(this, DemosGlobalization.GetResxString(GetType(), "Resx_OldVersion"));
            }
            else
            {
               ShowError(ex);
            }
         }
         catch(Exception ex)
         {
            _twainSession = null;
            ShowError(ex);
         }
         finally
         {
            if(_twainSession == null)
            {
               // No scanning device or an error
               // Hide scanning related menu items
               _scanToolStripMenuItem.Visible = false;
               _fileSep2ToolStripMenuItem.Visible = false;
            }
         }
      }

      private void ShutdownTwain()
      {
         if(_twainSession != null)
         {
            _twainSession.AcquirePage -= new EventHandler<TwainAcquirePageEventArgs>(_twainSession_AcquirePage);
            _twainSession.Shutdown();
         }
      }

      private void _twainSession_AcquirePage(object sender, TwainAcquirePageEventArgs e)
      {
         SetDocument(e.Image, DemosGlobalization.GetResxString(GetType(), "Resx_TwainScanning"));
      }

      private void SelectTwainSource()
      {
         // Select the TWAIN scanning source
         _twainSession.SelectSource(string.Empty);
      }

      private void ScanUsingTwain()
      {
         // Scan the pages using TWAIN
         try
         {
            if (!DemosGlobal.CheckKnown3rdPartyTwainIssues(this, _twainSession.SelectedSourceName()))
               return;
            _twainSession.Acquire(TwainUserInterfaceFlags.Show);
         }
         catch(Exception ex)
         {
            ShowError(ex);
         }
      }
      #endregion TWAIN

      private bool Init()
      {
         // Check support required to use this demo
         if (RasterSupport.IsLocked(RasterSupportType.Barcodes1D) && RasterSupport.IsLocked(RasterSupportType.Barcodes2D))
         {
            Messager.ShowError(this, DemosGlobalization.GetResxString(GetType(), "Resx_LEADBarcodeSupport"));
            return false;
         }

         _rasterCodecs = new RasterCodecs();
         _rasterCodecs.Options.RasterizeDocument.Load.XResolution = 300;
         _rasterCodecs.Options.RasterizeDocument.Load.YResolution = 300;
         _interactiveToolsList = new Dictionary<ImageViewer, Form>();

         _viewerControl.Visible = false;
         _pagesControl.Visible = false;
         _barcodeControl.Visible = false;

         StartupTwain();
         InitBarcodeEngine();

         UpdateUIState();

         LoadDefaultDocument();

         return true;
      }

      private void CleanUp()
      {
         // Delete all resources
         if(_sampleSymbologiesRasterImage != null)
         {
            _sampleSymbologiesRasterImage.Dispose();
         }

         if(_rasterCodecs != null)
         {
            _rasterCodecs.Dispose();
         }

         ShutdownTwain();
      }

      private void ShowError(Exception ex)
      {
         RasterException re = ex as RasterException;
         if(re != null)
         {
            Messager.ShowError(this, string.Format(DemosGlobalization.GetResxString(GetType(), "Resx_LEADError"), re.Code, ex.Message));
         }
         else
         {
            TwainException tw = ex as TwainException;
            if(tw != null)
            {
               Messager.ShowError(this, string.Format(DemosGlobalization.GetResxString(GetType(), "Resx_TwainError"), tw.Code, ex.Message));
            }
            else
            {
               Messager.ShowError(this, ex);
            }
         }
      }

      private void LoadDefaultDocument()
      {
         // Load the default image

#if LT_CLICKONCE
         string [] documentFileNames = new string [] { "Barcode1.tif", "Barcode2.tif" };
#else
         string[] documentFileNames = new string[] {
            Path.Combine(DemosGlobal.ImagesFolder, @"Barcode1.tif"), 
            Path.Combine(DemosGlobal.ImagesFolder, @"Barcode2.tif") };
#endif
         RasterImage image = null;

         foreach(string documentFileName in documentFileNames)
         {
            if(File.Exists(documentFileName))
            {
               try
               {
                  using(WaitCursor wait = new WaitCursor())
                  {
                     RasterImage pageImage = _rasterCodecs.Load(documentFileName);

                     if(image == null)
                     {
                        image = pageImage;
                     }
                     else
                     {
                        image.AddPage(pageImage);
                        pageImage.Dispose();
                     }
                  }
               }
               catch(Exception ex)
               {
                  Messager.ShowFileOpenError(this, documentFileName, ex);
               }
            }
         }

         if(image != null)
         {
            SetDocument(image, DemosGlobalization.GetResxString(GetType(), "Resx_DefaultDocument"));
         }
      }

      private void DoNewDocument()
      {
         int pages;
         int bitsPerPixel;
         int width;
         int height;
         int resolution;

         using(NewDocumentDialog dlg = new NewDocumentDialog())
         {
            dlg.DocumentPages = _demoOptions.NewDocumentPages;
            dlg.DocumentBitsPerPixel = _demoOptions.NewDocumentBitsPerPixel;
            dlg.DocumentResolution = _demoOptions.NewDocumentResolution;
            dlg.DocumentWidth = _demoOptions.NewDocumentWidth;
            dlg.DocumentHeight = _demoOptions.NewDocumentHeight;

            if(dlg.ShowDialog(this) == DialogResult.OK)
            {
               _demoOptions.NewDocumentPages = dlg.DocumentPages;
               _demoOptions.NewDocumentBitsPerPixel = dlg.DocumentBitsPerPixel;
               _demoOptions.NewDocumentResolution = dlg.DocumentResolution;
               _demoOptions.NewDocumentWidth = dlg.DocumentWidth;
               _demoOptions.NewDocumentHeight = dlg.DocumentHeight;

               pages = dlg.DocumentPages;
               bitsPerPixel = dlg.DocumentBitsPerPixel;
               width = dlg.DocumentWidth;
               height = dlg.DocumentHeight;
               resolution = dlg.DocumentResolution;
            }
            else
            {
               return;
            }
         }

         RasterImage image = null;

         // Create a RasterImage with specified pages and size
         try
         {
            FillCommand fillCmd = new FillCommand(RasterColor.FromKnownColor(RasterKnownColor.White));
            RasterByteOrder order = (bitsPerPixel == 1) ? RasterByteOrder.Rgb : RasterByteOrder.Bgr;

            using(WaitCursor wait = new WaitCursor())
            {
               for(int page = 1; page <= pages; page++)
               {
                  RasterImage pageImage = new RasterImage(
                     RasterMemoryFlags.Conventional,
                     width,
                     height,
                     bitsPerPixel,
                     order,
                     RasterViewPerspective.TopLeft,
                     null,
                     IntPtr.Zero,
                     0);

                  // Set the resolution
                  pageImage.XResolution = resolution;
                  pageImage.YResolution = resolution;

                  // Fill it
                  fillCmd.Run(pageImage);

                  if(image == null)
                  {
                     // First page
                     image = pageImage;
                  }
                  else
                  {
                     // Add it to current page
                     image.AddPage(pageImage);
                     pageImage.Dispose();
                  }
               }
            }
         }
         catch(Exception ex)
         {
            ShowError(ex);
            return;
         }

         if(image != null)
         {
            SetDocument(image, DemosGlobalization.GetResxString(GetType(), "Resx_NewDocument"));
         }
      }

      private void DoOpenDocument()
      {
         // Open a document from disk

         RasterImage image = null; // Will be disposed later.
         string fileName = null;

         if(String.IsNullOrEmpty(_demoOptions.OpenCommonDialogFolder) || !Directory.Exists(_demoOptions.OpenCommonDialogFolder))
         {
#if LT_CLICKONCE
            _demoOptions.OpenCommonDialogFolder = System.Environment.GetFolderPath( Environment.SpecialFolder.MyDocuments );
#else
            _demoOptions.OpenCommonDialogFolder = DemosGlobal.ImagesFolder;
#endif

         }

         // Show the LEADTOOLS common dialog
         ImageFileLoader loader = new ImageFileLoader();
         loader.LoadOnlyOnePage = false;
         loader.ShowLoadPagesDialog = true;
         loader.OpenDialogInitialPath = _demoOptions.OpenCommonDialogFolder;

         try
         {
            // Insert the pages loader into the document
            if(loader.Load(this, _rasterCodecs, true) > 0)
            {
               image = loader.Image;
               // Force TopLeft:
               if (image.ViewPerspective != RasterViewPerspective.TopLeft)
               {
                  ChangeViewPerspectiveCommand cmd = new ChangeViewPerspectiveCommand(true, RasterViewPerspective.TopLeft);
                  cmd.Run(image);
               }
               _demoOptions.OpenCommonDialogFolder = Path.GetDirectoryName(loader.FileName);
            }
         }
         catch(Exception ex)
         {
            Messager.ShowFileOpenError(this, loader.FileName, ex);
         }
         
         if(image != null)
         {
            SetDocument(image, fileName);
         }
      }

      private void DoSaveDocument()
      {
         if(_viewerControl.RasterImageViewer.Image == null) return;

         ImageFileSaver saver = new ImageFileSaver();

         try
         {
            saver.Save(this, _rasterCodecs, _viewerControl.RasterImageViewer.Image);
         }
         catch(Exception ex)
         {
            Messager.ShowFileSaveError(this, saver.FileName, ex);
         }
      }

      public void SetDocument(RasterImage image, string title)
      {
         this.SuspendLayout();

         try
         {
            using(WaitCursor wait = new WaitCursor())
            {
               // Create empty document barcodes
               _documentBarcodes = new DocumentBarcodes();

               if(image != null)
               {
                  for(int page = 0; page < image.PageCount; page++)
                  {
                     PageBarcodes pageBarcodes = new PageBarcodes();
                     _documentBarcodes.Pages.Add(pageBarcodes);
                  }
               }

               _viewerControl.ShowBarcodes = true;
               _viewerControl.SetDocument(image, _documentBarcodes);
               _barcodeControl.SetDocument(image, _documentBarcodes);
               _pagesControl.SetDocument(image);

               if(image != null)
               {
                  _viewerControl.Visible = true;
                  _barcodeControl.Visible = true;

                  if(image.PageCount > 1)
                  {
                     _pagesControl.Visible = true;
                  }

                  Text = string.Format("{0} - {1}", title, Messager.Caption);
               }
               else
               {
                  Text = Messager.Caption;
               }
            }
         }
         catch(Exception ex)
         {
            ShowError(ex);
         }
         finally
         {
            this.ResumeLayout();
            UpdateUIState();
         }
      }

      private void GotoPage(int pageNumber)
      {
         if(_viewerControl.RasterImageViewer.Image == null) return;

         try
         {
            _pagesControl.SetCurrentPageNumber(pageNumber);
            _viewerControl.SetCurrentPageNumber(pageNumber);
            _barcodeControl.Populate();
         }
         catch(Exception ex)
         {
            ShowError(ex);
         }
         finally
         {
            UpdateUIState();
         }
      }

      private void InitBarcodeEngine()
      {
         _barcodeEngine = new BarcodeEngine();

         _barcodeEngine.Reader.ImageType = BarcodeImageType.Unknown;
         _barcodeEngine.Reader.EnableReturnFourPoints = false;

         _demoOptions = DemoOptions.Load();

         // Create the barcodes symbologies multi-frame RasterImage
         using(Stream stream = GetType().Assembly.GetManifestResourceStream("BarcodeMainDemo.Resources.Symbologies.tif"))
         {
            _rasterCodecs.Options.Load.AllPages = true;
            _sampleSymbologiesRasterImage = _rasterCodecs.Load(stream);
         }
      }


      private void SaveBarcodeOptions(bool readOptions)
      {
         using(SaveFileDialog dlg = new SaveFileDialog())
         {
            if(readOptions)
            {
               dlg.Title = DemosGlobalization.GetResxString(GetType(), "Resx_SaveBarcodeReadOptions");
            }
            else
            {
               dlg.Title = DemosGlobalization.GetResxString(GetType(), "Resx_SaveBarcodeWriteOptions");
            }

            dlg.Filter = "XML files (*.xml)|*.xml|All files|*.*";
            dlg.DefaultExt = "xml";
            if(dlg.ShowDialog(this) == DialogResult.OK)
            {
               try
               {
                  if(readOptions)
                  {
                     _barcodeEngine.Reader.SaveOptions(dlg.FileName);
                  }
                  else
                  {
                     _barcodeEngine.Writer.SaveOptions(dlg.FileName);
                  }
               }
               catch(Exception ex)
               {
                  ShowError(ex);
               }
            }
         }
      }

      private void LoadBarcodeOptions(bool readOptions)
      {
         using(OpenFileDialog dlg = new OpenFileDialog())
         {
            if(readOptions)
            {
               dlg.Title = DemosGlobalization.GetResxString(GetType(), "Resx_LoadBarcodeReadOptions");
            }
            else
            {
                dlg.Title = DemosGlobalization.GetResxString(GetType(), "Resx_LoadBarcodeWriteOptions");
            }

            dlg.Filter = "XML files (*.xml)|*.xml|All files|*.*";
            dlg.DefaultExt = "xml";
            if(dlg.ShowDialog(this) == DialogResult.OK)
            {
               try
               {
                  if(readOptions)
                  {
                     _barcodeEngine.Reader.LoadOptions(dlg.FileName);
                  }
                  else
                  {
                     _barcodeEngine.Writer.LoadOptions(dlg.FileName);
                  }
               }
               catch(Exception ex)
               {
                  ShowError(ex);
               }
            }
         }
      }

      private void DoDeleteSelectedBarcode()
      {
         if(_viewerControl.RasterImageViewer.Image == null) return;

         PageBarcodes pageBarcodes = _documentBarcodes.Pages[_viewerControl.RasterImageViewer.Image.Page - 1];
         if(pageBarcodes != null && pageBarcodes.SelectedIndex != -1)
         {
            pageBarcodes.Barcodes.RemoveAt(pageBarcodes.SelectedIndex);
            if(pageBarcodes.SelectedIndex >= pageBarcodes.Barcodes.Count)
            {
               pageBarcodes.SelectedIndex = pageBarcodes.Barcodes.Count - 1;
            }

            _viewerControl.RasterImageViewer.Invalidate();
            _barcodeControl.Populate();
         }
      }

      private Matrix GetMatrixFromLeadMatrix(LeadMatrix matrix)
      {
         return new Matrix((float)matrix.M11, (float)matrix.M12, (float)matrix.M21, (float)matrix.M22, (float)matrix.OffsetX, (float)matrix.OffsetY);
      }
      
      private void DoViewSelectedBarcodeIDData()
      {
#if LEADTOOLS_V20_OR_LATER
         PageBarcodes pageBarcodes = _documentBarcodes.Pages[_viewerControl.RasterImageViewer.Image.Page - 1];
         if (pageBarcodes != null && pageBarcodes.SelectedIndex != -1)
         {
            BarcodeData data= pageBarcodes.Barcodes[pageBarcodes.SelectedIndex];
            AAMVAID id = BarcodeData.ParseAAMVAData(data.GetData(), false);
            if(id != null)
            {
               BarcodeControls.AAMVADialogBox aamvaDlg = new BarcodeControls.AAMVADialogBox(id);
               aamvaDlg.ShowDialog();
            }
         }
#endif// #if LEADTOOLS_V20_OR_LATER
      }

      private void DoZoomToSelectedBarcode()
      {
         PageBarcodes pageBarcodes = _documentBarcodes.Pages[_viewerControl.RasterImageViewer.Image.Page - 1];
         if(pageBarcodes != null && pageBarcodes.SelectedIndex != -1)
         {
            RasterImage image = _viewerControl.RasterImageViewer.Image;
            LeadRect bounds = pageBarcodes.Barcodes[pageBarcodes.SelectedIndex].Bounds;
            if (_viewerControl.FourPoints == true && pageBarcodes.Barcodes[pageBarcodes.SelectedIndex].Symbology != BarcodeSymbology.Aztec && pageBarcodes.Barcodes[pageBarcodes.SelectedIndex].Symbology != BarcodeSymbology.Maxi && pageBarcodes.Barcodes[pageBarcodes.SelectedIndex].Symbology != BarcodeSymbology.MicroQR)
            {
               LeadPointD[] pointsL = new LeadPointD[4];
               LeadRectD rect = new LeadRectD(bounds.X, bounds.Y, bounds.Width, bounds.Height);

               pointsL[0].X = ((int)rect.Left & 0xffff); pointsL[0].Y = ((int)rect.Left >> 16);
               pointsL[1].X = ((int)rect.Top & 0xffff); pointsL[1].Y = ((int)rect.Top >> 16);
               pointsL[2].X = ((int)rect.Width & 0xffff); pointsL[2].Y = ((int)rect.Width >> 16);
               pointsL[3].X = ((int)rect.Height & 0xffff); pointsL[3].Y = ((int)rect.Height >> 16);

               bounds.Left = (int)Math.Min(Math.Min(pointsL[0].X, pointsL[1].X), Math.Min(pointsL[2].X, pointsL[3].X));
               bounds.Right = (int)Math.Max(Math.Max(pointsL[0].X, pointsL[1].X), Math.Max(pointsL[2].X, pointsL[3].X));
               bounds.Top = (int)Math.Min(Math.Min(pointsL[0].Y, pointsL[1].Y), Math.Min(pointsL[2].Y, pointsL[3].Y));
               bounds.Bottom = (int)Math.Max(Math.Max(pointsL[0].Y, pointsL[1].Y), Math.Max(pointsL[2].Y, pointsL[3].Y));

            }
            RectangleF boundsF = new RectangleF(bounds.X, bounds.Y, bounds.Width, bounds.Height);

            // Convert this rectangle to physical
            using (System.Drawing.Drawing2D.Matrix m = GetMatrixFromLeadMatrix(_viewerControl.RasterImageViewer.GetImageTransformWithDpi(true)))
            {
               Leadtools.Drawing.Transformer trans = new Leadtools.Drawing.Transformer(m);
               boundsF = trans.RectangleToPhysical(boundsF);
            }

            // Give it a few pixels on the edges
            Rectangle rc = Rectangle.Round(boundsF);
            rc.Inflate(40, 40);

            _viewerControl.RasterImageViewer.ZoomToRect(new LeadRectD(rc.X, rc.Y, rc.Width, rc.Height));
         }
      }

      private void DoExportBarcodes()
      {
         using(SaveFileDialog dlg = new SaveFileDialog())
         {
            dlg.Title = DemosGlobalization.GetResxString(GetType(), "Resx_SaveBarcodeData");
            dlg.Filter = "XML files (*.xml)|*.xml|All files|*.*";
            dlg.DefaultExt = "xml";
            if(dlg.ShowDialog(this) == DialogResult.OK)
            {
               try
               {
                  PageBarcodes pageBarcodes = _documentBarcodes.Pages[_viewerControl.RasterImageViewer.Image.Page - 1];

                  BarcodeData[] data = new BarcodeData[pageBarcodes.Barcodes.Count];
                  for(int i = 0; i < pageBarcodes.Barcodes.Count; i++)
                  {
                     data[i] = pageBarcodes.Barcodes[i];
                  }

                  BarcodeData.Save(dlg.FileName, data);
               }
               catch(Exception ex)
               {
                  ShowError(ex);
               }
            }
         }
      }

      public void DoClearAllBarcodes()
      {
         foreach(PageBarcodes pageBarcodes in _documentBarcodes.Pages)
         {
            pageBarcodes.Barcodes.Clear();
            pageBarcodes.SelectedIndex = -1;
         }

         _viewerControl.RasterImageViewer.Invalidate();
         _barcodeControl.Populate();
      }

      private void DoReadBarcodeOptions()
      {
         if(_viewerControl.RasterImageViewer.Image == null) return;

         using(BarcodeControls.ReadBarcodeOptionsDialogBox dlg = new BarcodeControls.ReadBarcodeOptionsDialogBox(
            _barcodeEngine,
            _sampleSymbologiesRasterImage,
            _demoOptions.ReadOptionsGroupIndex,
            _demoOptions.ReadOptionsSymbologies,
            _demoOptions.ReadBarcodesWhenOptionsDialogCloses))

         {
            if(dlg.ShowDialog(this) == DialogResult.OK)
            {
               _demoOptions.ReadOptionsGroupIndex = dlg.SelectedGroupIndex;
               _demoOptions.ReadOptionsSymbologies = dlg.GetSelectedSymbologies();
               _demoOptions.ReadBarcodesWhenOptionsDialogCloses = dlg.ReadBarcodesWhenDialogCloses;

               if(_demoOptions.ReadBarcodesWhenOptionsDialogCloses)
               {
                  DoReadBarcodes(false, LeadRect.Empty, true);
               }
            }
         }
      }

      private void DoReadBarcodes(bool currentPageOnly, LeadRect bounds, bool clearOldBarcodes)
      {
         if(_viewerControl.RasterImageViewer.Image == null) return;

         RasterImage image = _viewerControl.RasterImageViewer.Image;
         using(BarcodeControls.ReadBarcodesDialogBox dlg = new BarcodeControls.ReadBarcodesDialogBox(
            _barcodeEngine,
            _demoOptions.ReadOptionsSymbologies,
            image,
            currentPageOnly,
            bounds))
         {
            dlg.ShowDialog(this);

            if(dlg.ShowReadBarcodeOptions)
            {
               DoReadBarcodeOptions();
               return;
            }

            // Merge barcodes
            if(clearOldBarcodes)
            {
               foreach(PageBarcodes pageBarcodes in _documentBarcodes.Pages)
               {
                  pageBarcodes.Barcodes.Clear();
                  pageBarcodes.SelectedIndex = -1;
               }
            }

            if(currentPageOnly)
            {
               // There should only be one page
               System.Diagnostics.Debug.Assert(dlg.DocumentBarcodes.Pages.Count == 1);

               PageBarcodes newPageBarcodes = dlg.DocumentBarcodes.Pages[0];
               PageBarcodes currentPageBarcodes = _documentBarcodes.Pages[image.Page - 1];

               foreach(BarcodeData data in newPageBarcodes.Barcodes)
               {
                  currentPageBarcodes.Barcodes.Add(data);
               }

               currentPageBarcodes.SelectedIndex = currentPageBarcodes.Barcodes.Count - 1;
            }
            else
            {
               for(int pageIndex = 0; pageIndex < dlg.DocumentBarcodes.Pages.Count; pageIndex++)
               {
                  PageBarcodes newPageBarcodes = dlg.DocumentBarcodes.Pages[pageIndex];
                  PageBarcodes pageBarcodes = _documentBarcodes.Pages[pageIndex];

                  foreach(BarcodeData data in newPageBarcodes.Barcodes)
                  {
                     pageBarcodes.Barcodes.Add(data);
                  }

                  pageBarcodes.SelectedIndex = pageBarcodes.Barcodes.Count - 1;
               }
            }

            _viewerControl.RasterImageViewer.Invalidate();
            _barcodeControl.Populate();
         }
      }

      private void DoWriteBarcode(LeadRect bounds)
      {
         if(_viewerControl.RasterImageViewer.Image == null) return;

         // Consider having a region of interest to write inside on the image
         LeadRect regionOfInterest = bounds;

         if (regionOfInterest.IsEmpty && _viewerControl.RasterImageViewer.Image.HasRegion)
         {
            LeadRect regionBounds = _viewerControl.RasterImageViewer.Image.GetRegionBounds(null);
            regionOfInterest = regionBounds;
         }
         using(BarcodeControls.WriteBarcodeDialogBox dlg = new BarcodeControls.WriteBarcodeDialogBox(
            _barcodeEngine,
            _sampleSymbologiesRasterImage,
            regionOfInterest,
            _demoOptions.WriteOptionsGroupIndex,
            _demoOptions.WriteOptionsSymbology,
            new BarcodeControls.WriteBarcodeDialogBox.WriteBarcodeDelegate(WriteBarcode)))
         {
            if(dlg.ShowDialog(this) == DialogResult.OK)
            {
               _demoOptions.WriteOptionsGroupIndex = dlg.SelectedGroupIndex;
               _demoOptions.WriteOptionsSymbology = dlg.SelectedSymbology;

               _pagesControl.SetDocument(_viewerControl.RasterImageViewer.Image);
            }
         }
      }

      private bool WriteBarcode(BarcodeData data)
      {
         try
         {
            using(WaitCursor wait = new WaitCursor())
            {
               RasterImage image = _viewerControl.RasterImageViewer.Image;

               // When writing a barcode, if the image has a region, the barcode might not all be visible
               // So same the region first if we have it and set it back after the writing is completed

               RasterRegion region = null;

               if(image.HasRegion)
               {
                  region = image.GetRegion(null);
                  image.MakeRegionEmpty();
               }

               try
               {
                  // First, calculate the rectangle for this Barcode
                  LeadRect writeBounds = new LeadRect(0, 0, image.Width, image.Height);

                  // if the specific user rectangle was specified for drawing the Barcode then overwrite the above rectangle
                  if (!data.Bounds.IsEmpty && data.Bounds != writeBounds)
                     writeBounds = data.Bounds;

                  _barcodeEngine.Writer.CalculateBarcodeDataBounds(writeBounds, image.XResolution, image.YResolution, data, null);

                  // Next, write the barcode
                  _barcodeEngine.Writer.WriteBarcode(image, data, null);
               }
               finally
               {
                  if(region != null)
                  {
                     image.SetRegion(null, region, RasterRegionCombineMode.Set);
                     region.Dispose();
                  }
               }

               if (_viewerControl.FourPoints == true && data.Symbology != BarcodeSymbology.Aztec && data.Symbology != BarcodeSymbology.Maxi && data.Symbology != BarcodeSymbology.MicroQR)
               {
                  LeadRect rect = data.Bounds;
                  LeadRectD rc = new LeadRectD(rect.X, rect.Y, rect.Width, rect.Height);

                  rect.Left   = ((int)rc.Top << 16) + (int)rc.Left;
                  rect.Top  = ((int)rc.Top << 16) + (int)rc.Right;
                  rect.Width  = ((int)rc.Bottom << 16) + (int)rc.Right;
                  rect.Height = ((int)rc.Bottom << 16) + (int)rc.Left;
                  data.Bounds = rect;
                  
               }

               // You can uncomment this to add the barcode to the list
               // of data, or just do what the demo does and read it yourself
               // Add it to the list of barcodes of current page
               PageBarcodes pageBarcodes = _documentBarcodes.Pages[image.Page - 1];
               pageBarcodes.Barcodes.Add(data);

               // And select it
               pageBarcodes.SelectedIndex = pageBarcodes.Barcodes.Count - 1;
               _viewerControl.RasterImageViewer.Invalidate();
               
               _barcodeControl.Populate();
            }

            return true;
         }
         catch(BarcodeException ex)
         {
            string message = string.Format(
               DemosGlobalization.GetResxString(GetType(), "Resx_BarcodeError"),
               Environment.NewLine, ex.Code, ex.Message);
            Messager.ShowError(this, message);
            return false;
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
            return false;
         }
      }

      public static string IsValidNumber(string OrgStr, float minVal, float maxVal)
      {
         string str = "";

         foreach (char c1 in OrgStr)
            if (char.IsNumber(c1))
               str += c1.ToString();
         if (str != "")
         {
            if (float.Parse(str) < minVal)
               str = minVal.ToString();

            if (float.Parse(str) > maxVal)
               str = maxVal.ToString();
         }

         return str;
      }

      private void ChangingBoundingType()
      {
         if (_viewerControl.RasterImageViewer.Image == null) return;

         int xResolution = _viewerControl.RasterImageViewer.Image.XResolution > 0 ? _viewerControl.RasterImageViewer.Image.XResolution : 96;
         int yResolution = _viewerControl.RasterImageViewer.Image.YResolution > 0 ? _viewerControl.RasterImageViewer.Image.YResolution : 96;
         if (_viewerControl.FourPoints == true)
         {
            foreach (PageBarcodes pageBarcodes in _documentBarcodes.Pages)
            {
               foreach (BarcodeData data in pageBarcodes.Barcodes)
               {
                  if(data.Symbology == BarcodeSymbology.Aztec || data.Symbology == BarcodeSymbology.Maxi || data.Symbology == BarcodeSymbology.MicroQR)
                  {
                     continue;
                  }

                  LeadRect rect = data.Bounds;
                  LeadRectD rc = new LeadRectD(rect.X, rect.Y, rect.Width, rect.Height);

                  rect.Left   = ((int)rc.Top << 16) + (int)rc.Left;
                  rect.Top  = ((int)rc.Top << 16) + (int)rc.Right;
                  rect.Width  = ((int)rc.Bottom << 16) + (int)rc.Right;
                  rect.Height = ((int)rc.Bottom << 16) + (int)rc.Left;
                  data.Bounds = rect;
               }
            }
         }
         else
         {
            foreach (PageBarcodes pageBarcodes in _documentBarcodes.Pages)
            {
               foreach (BarcodeData data in pageBarcodes.Barcodes)
               {
                  if (data.Symbology == BarcodeSymbology.Aztec || data.Symbology == BarcodeSymbology.Maxi || data.Symbology == BarcodeSymbology.MicroQR)
                  {
                     continue;
                  }

                  LeadPointD[] pointsL = new LeadPointD[4];
                  LeadRect rect = data.Bounds;
                  LeadRectD rc = new LeadRectD(rect.X, rect.Y, rect.Width, rect.Height);

                  pointsL[0].X = ((int)rc.Left & 0xffff);      pointsL[0].Y = ((int)rc.Left >> 16);
                  pointsL[1].X = ((int)rc.Top & 0xffff);       pointsL[1].Y = ((int)rc.Top >> 16);
                  pointsL[2].X = ((int)rc.Width & 0xffff);     pointsL[2].Y = ((int)rc.Width >> 16);
                  pointsL[3].X = ((int)rc.Height & 0xffff);    pointsL[3].Y = ((int)rc.Height >> 16);

                  rect.Left   = (int)Math.Min(Math.Min(pointsL[0].X, pointsL[1].X), Math.Min(pointsL[2].X, pointsL[3].X));
                  rect.Right  = (int)Math.Max(Math.Max(pointsL[0].X, pointsL[1].X), Math.Max(pointsL[2].X, pointsL[3].X));
                  rect.Top    = (int)Math.Min(Math.Min(pointsL[0].Y, pointsL[1].Y), Math.Min(pointsL[2].Y, pointsL[3].Y));
                  rect.Bottom = (int)Math.Max(Math.Max(pointsL[0].Y, pointsL[1].Y), Math.Max(pointsL[2].Y, pointsL[3].Y));
                  data.Bounds = rect;
               }
            }
         }
         
      }
   }
}
