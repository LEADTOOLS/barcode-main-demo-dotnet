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

using Leadtools;
using Leadtools.Drawing;
using Leadtools.Barcode;

namespace BarcodeMainDemo.BarcodeControls
{
   public partial class SymbologyListBox : ListBox
   {
      public SymbologyListBox()
      {
         InitializeComponent();

         this.DrawMode = DrawMode.OwnerDrawFixed;
         this.ColumnWidth = 200;
         this.ItemHeight = 70;

         SetStyle(ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
      }

      private void CleanUp(bool disposing)
      {
         if(disposing)
         {
            if(_stringFormat != null)
            {
               _stringFormat.Dispose();
               _stringFormat = null;
            }

            if(_itemPen != null)
            {
               _itemPen.Dispose();
               _itemPen = null;
            }
         }
      }

      private RasterImage _sampleSymbologiesRasterImage;
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public RasterImage SampleSymbologiesRasterImage
      {
         get { return _sampleSymbologiesRasterImage; }
         set
         {
            _sampleSymbologiesRasterImage = value;
            Invalidate();
         }
      }

      private const int _delta = 5;
      private Pen _itemPen;
      private StringFormat _stringFormat;

      protected override void OnDrawItem(DrawItemEventArgs e)
      {
         if(_sampleSymbologiesRasterImage == null) return;

         if(e.Index == -1) return;

         Rectangle rc = new Rectangle(e.Bounds.X + _delta, e.Bounds.Y + _delta, e.Bounds.Width - 10, e.Bounds.Height - _delta);

         if(_stringFormat == null)
         {
            _stringFormat = new StringFormat();
            _stringFormat.Alignment = StringAlignment.Center;
            _stringFormat.LineAlignment = StringAlignment.Far;
         }

         BarcodeSymbology symbology = (BarcodeSymbology)Items[e.Index];
         string name = BarcodeEngine.GetSymbologyFriendlyName(symbology);
         _sampleSymbologiesRasterImage.Page = (int)symbology;

         if(_itemPen == null)
         {
            _itemPen = new Pen(Brushes.Black, 2);
         }

         e.Graphics.DrawRectangle(_itemPen, rc);
         e.Graphics.FillRectangle(Brushes.White, rc);

         RasterPaintProperties paintProperties = RasterPaintProperties.Default;
         
         if (RasterSupport.IsLocked(RasterSupportType.Document))
            paintProperties.PaintDisplayMode = RasterPaintDisplayModeFlags.Bicubic;
         else
            paintProperties.PaintDisplayMode = RasterPaintDisplayModeFlags.ScaleToGray;

         LeadRect imageRect = new LeadRect(rc.X + 2, rc.Y + 2, rc.Width - 4, rc.Height * 2 / 3);
         imageRect = RasterImage.CalculatePaintModeRectangle(
            _sampleSymbologiesRasterImage.ImageWidth,
            _sampleSymbologiesRasterImage.ImageHeight,
            imageRect,
            RasterPaintSizeMode.FitAlways,
            RasterPaintAlignMode.CenterAlways,
            RasterPaintAlignMode.CenterAlways);

         if((e.State & DrawItemState.Selected) == DrawItemState.Selected)
         {
            e.Graphics.FillRectangle(SystemBrushes.Highlight, rc);
            RasterImagePainter.Paint(_sampleSymbologiesRasterImage, e.Graphics, imageRect, paintProperties);
            e.Graphics.DrawRectangle(Pens.Black, imageRect.X, imageRect.Y, imageRect.Width, imageRect.Height);
            e.Graphics.DrawString(name, Font, SystemBrushes.HighlightText, rc, _stringFormat);
         }
         else
         {
            e.Graphics.FillRectangle(SystemBrushes.Control, rc);
            RasterImagePainter.Paint(_sampleSymbologiesRasterImage, e.Graphics, imageRect, paintProperties);
            e.Graphics.DrawRectangle(Pens.Black, imageRect.X, imageRect.Y, imageRect.Width, imageRect.Height);
            e.Graphics.DrawString(name, Font, SystemBrushes.ControlText, rc, _stringFormat);
         }
      }

      public event EventHandler<SymbologyListBoxItemDoubleClickedEventArgs> ItemDoubleClicked;

      protected override void OnDoubleClick(EventArgs e)
      {
         int index = IndexFromPoint(PointToClient(Cursor.Position));
         if(index != -1 && ItemDoubleClicked != null)
         {
            ItemDoubleClicked(this, new SymbologyListBoxItemDoubleClickedEventArgs(index));
         }

         base.OnDoubleClick(e);
      }
   }
}
