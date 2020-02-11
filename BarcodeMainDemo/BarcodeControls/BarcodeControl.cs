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

using Leadtools;
using Leadtools.Barcode;

namespace BarcodeMainDemo.BarcodeControls
{
   public partial class BarcodeControl : UserControl
   {
      private RasterImage _rasterImage;
      private DocumentBarcodes _documentBarcodes;
      private bool _ignoreAction;

      public BarcodeControl()
      {
         InitializeComponent();
      }

      /// <summary>
      /// Called from MainForm to set the barcodes and selected barcodes list
      /// </summary>
      public void SetDocument(RasterImage image, DocumentBarcodes documentBarcodes)
      {
         _rasterImage = image;
         _documentBarcodes = documentBarcodes;

         Populate();
      }

      /// <summary>
      /// Called by MainForm and internally whenever the document barcodes are updated
      /// </summary>
      public void Populate()
      {
         _barcodesListView.Items.Clear();

         if(_documentBarcodes != null && _rasterImage != null)
         {
            PageBarcodes pageBarcodes = _documentBarcodes.Pages[_rasterImage.Page - 1];
            foreach(BarcodeData data in pageBarcodes.Barcodes)
            {
               ListViewItem item = new ListViewItem();

               item.Text = BarcodeEngine.GetSymbologyFriendlyName(data.Symbology);
               LeadRect rc = data.Bounds;
               item.SubItems.Add(string.Format("{0}, {1}, {2}, {3}", rc.Left, rc.Top, rc.Right, rc.Bottom));

               string value = data.Value;
               if(!string.IsNullOrEmpty(value))
               {
                  // Parse the QR barcodes for ECI data
                  string eciData = null;
                  if (data.Symbology == BarcodeSymbology.QR || data.Symbology == BarcodeSymbology.MicroQR)
                     eciData = BarcodeData.ParseECIData(data.GetData());

                  if (!string.IsNullOrEmpty(eciData))
                     item.SubItems.Add(eciData);
                  else
                     item.SubItems.Add(value);
               }
               else
               {
                  item.SubItems.Add("<NO DATA>");
               }

               _barcodesListView.Items.Add(item);
            }

            if(pageBarcodes.SelectedIndex != -1)
            {
               _barcodesListView.Items[pageBarcodes.SelectedIndex].Selected = true;
               _barcodesListView.EnsureVisible(pageBarcodes.SelectedIndex);
            }
         }

         UpdateUIState();
      }

      /// <summary>
      /// Called by MainForm when the selected barcode has changed
      /// </summary>
      public void SelectedBarcodeChanged()
      {
         _ignoreAction = true;

         if(_documentBarcodes != null)
         {
            int selectedIndex = _documentBarcodes.Pages[_rasterImage.Page - 1].SelectedIndex;

            foreach(ListViewItem item in _barcodesListView.Items)
            {
               item.Selected = (item.Index == selectedIndex);
            }

            if(selectedIndex != -1)
            {
               _barcodesListView.EnsureVisible(selectedIndex);
            }
         }

         _ignoreAction = false;

         UpdateUIState();
      }

      public event EventHandler<ActionEventArgs> Action;

      private void DoAction(string action, object data)
      {
         if(Action != null)
         {
            Action(this, new ActionEventArgs(action, null));
         }
      }

      private void _barcodesListView_SelectedIndexChanged(object sender, EventArgs e)
      {
         if(!_ignoreAction && Action != null)
         {
            int selectedIndex;

            if(_barcodesListView.SelectedIndices.Count > 0)
            {
               selectedIndex = _barcodesListView.SelectedIndices[0];
            }
            else
            {
               selectedIndex = -1;
            }

            Action(this, new ActionEventArgs("SelectedBarcodeChanged", selectedIndex));

            UpdateUIState();
         }
      }

      private void _barcodesListView_DoubleClick(object sender, EventArgs e)
      {
         if(!_ignoreAction)
         {
            DoZoomTo();
         }
      }

      private void UpdateUIState()
      {
         bool itemSelected = _barcodesListView.SelectedItems.Count > 0;
         _deleteButton.Enabled = itemSelected;
         _zoomToButton.Enabled = itemSelected;

#if LEADTOOLS_V20_OR_LATER
         _aamvaButton.Enabled = false;
         if (_rasterImage != null)
         {
            PageBarcodes pageBarcodes = _documentBarcodes.Pages[_rasterImage.Page - 1];
            if (pageBarcodes.SelectedIndex > -1)
            {
               BarcodeData data = pageBarcodes.Barcodes[pageBarcodes.SelectedIndex];
               if (data.Symbology == BarcodeSymbology.PDF417)
               {
                  AAMVAID id = BarcodeData.ParseAAMVAData(data.GetData(), false);
                  if (id != null)
                  {
                     _aamvaButton.Enabled = true;
                     id.Dispose();
                  }
               }
            }
         }
#endif // #if LEADTOOLS_V20_OR_LATER
      }

      private void _deleteButton_Click(object sender, EventArgs e)
      {
         if(_barcodesListView.SelectedItems.Count > 0)
         {
            DoAction("DeleteSelectedBarcode", null);
         }
      }

      private void _zoomToButton_Click(object sender, EventArgs e)
      {
         DoZoomTo();
      }

      private void DoZoomTo()
      {
         if(_barcodesListView.SelectedItems.Count > 0)
         {
            DoAction("ZoomToSelectedBarcode", null);
         }
      }

      private void _aamvaButton_Click(object sender, EventArgs e)
      {
         if (_barcodesListView.SelectedItems.Count > 0)
         {
            DoAction("ViewSelectedBarcodeIDData", null);
         }
      }
   }
}
