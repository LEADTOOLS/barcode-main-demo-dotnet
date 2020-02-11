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
using System.Diagnostics;
using System.Reflection;

using Leadtools;
using Leadtools.Demos;
using Leadtools.Barcode;

namespace BarcodeMainDemo.BarcodeControls
{
   public partial class ReadBarcodesDialogBox : Form
   {
      private BarcodeEngine _barcodeEngine;
      private BarcodeSymbology[] _userSelectedSymbologies;
      private BarcodeSymbology[] _symbologies;
      private RasterImage _rasterImage;
      private bool _currentPageOnly;
      private LeadRect _bounds;
      private bool _extraUseAllSymbologies = true;
      private bool _extraUseBothDirections = true;
      private bool _extraUseDoublePass = true;
      private bool _extraUsePreprocessing = true;

      private bool _isAborted;
      private bool _isWorking;

      private DocumentBarcodes _documentBarcodes;
      public DocumentBarcodes DocumentBarcodes
      {
         get { return _documentBarcodes; }
      }

      private bool _showReadBarcodeOptions;
      public bool ShowReadBarcodeOptions
      {
         get { return _showReadBarcodeOptions; }
      }

      public ReadBarcodesDialogBox(BarcodeEngine barcodeEngine, BarcodeSymbology[] symbologies, RasterImage image, bool currentPageOnly, LeadRect bounds)
      {
         InitializeComponent();

         _barcodeEngine = barcodeEngine;
         _symbologies = symbologies;
         _userSelectedSymbologies = symbologies;
         _rasterImage = image;
         _currentPageOnly = currentPageOnly;
         _bounds = bounds;
         _showReadBarcodeOptions = false;
      }

      protected override void OnLoad(EventArgs e)
      {
         if(!DesignMode)
         {
            _isWorking = true;

            BeginInvoke(new MethodInvoker(DoReadBarcodes));
         }

         base.OnLoad(e);
      }

      // Stop watch to use in timing
      private Stopwatch _stopWatch;
      private int _currentPageNumber;
      private int _lastPageNumber;

      private void DoReadBarcodes()
      {
         _documentBarcodes = new DocumentBarcodes();
         _barcodesListView.Groups.Clear();
         _barcodesListView.Items.Clear();

         _infoLabel.Text = DemosGlobalization.GetResxString(GetType(), "Resx_SearchingForBarcode");
         _retryLinkLabel.Visible = false;
         _retryLinkLabel.Enabled = false;
         _messageLabel.Visible = true;
         _messageLabel.Text = string.Empty;
         _showReadOptionsDialogCheckBox.Visible = false;
         _stopButton.DialogResult = DialogResult.None;
         _stopButton.Text = "&Stop";
         this.AcceptButton = null;
         this.CancelButton = null;
         _isWorking = true;

         Application.DoEvents();

         int firstPageNumber;
         int lastPageNumber;

         if(_currentPageOnly)
         {
            firstPageNumber = _rasterImage.Page;
            lastPageNumber = _rasterImage.Page;
         }
         else
         {
            firstPageNumber = 1;
            lastPageNumber = _rasterImage.PageCount;
         }

         Exception error = null;
         _stopWatch = new Stopwatch();

         _lastPageNumber = lastPageNumber;

         for(int pageNumber = firstPageNumber; pageNumber <= lastPageNumber && !_isAborted && error == null; pageNumber++)
         {
            _currentPageNumber = pageNumber;
            UpdateMessageLabel(null);
            Application.DoEvents();

            int savePageNumber = -1;

            if(_rasterImage.Page != pageNumber)
            {
               _rasterImage.DisableEvents();
               savePageNumber = _rasterImage.Page;
               _rasterImage.Page = pageNumber;
            }

            // Continue on errors
            _barcodeEngine.Reader.ErrorMode = BarcodeReaderErrorMode.IgnoreAll;
            _barcodeEngine.Reader.ReadSymbology += new EventHandler<BarcodeReadSymbologyEventArgs>(Reader_ReadSymbology);

            try
            {
               BarcodeData[] barcodes = _barcodeEngine.Reader.ReadBarcodes(_rasterImage, _bounds, 0, _symbologies, null);

               PageBarcodes pageBarcodes = new PageBarcodes();
               foreach(BarcodeData barcode in barcodes)
               {
                  pageBarcodes.Barcodes.Add(barcode);
               }

               _documentBarcodes.Pages.Add(pageBarcodes);
            }
            catch(Exception ex)
            {
               error = ex;
            }
            finally
            {
               if(savePageNumber != -1)
               {
                  _rasterImage.EnableEvents();
                  _rasterImage.Page = savePageNumber;
               }

               _barcodeEngine.Reader.ReadSymbology -= new EventHandler<BarcodeReadSymbologyEventArgs>(Reader_ReadSymbology);
               _barcodeEngine.Reader.ErrorMode = BarcodeReaderErrorMode.Default;
            }
         }

         _messageLabel.Visible = false;
         _retryLinkLabel.Visible = true;
         _retryLinkLabel.Enabled = true;

         int count = 0;
         foreach(PageBarcodes pageBarcodes in _documentBarcodes.Pages)
         {
            count += pageBarcodes.Barcodes.Count;
         }

         if(count > 0)
         {
             _infoLabel.Text = string.Format(DemosGlobalization.GetResxString(GetType(), "Resx_DoneBarcode"), count);
         }
         else
         {
             _infoLabel.Text = string.Format(DemosGlobalization.GetResxString(GetType(), "Resx_DoneNoBarcode"));
         }

         if(error != null)
         {
            _stopButton.DialogResult = DialogResult.Cancel;
            MessageBox.Show(this, error.Message, DemosGlobalization.GetResxString(GetType(), "Resx_Error"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }

         if(count == 0 && error == null)
         {
            _showReadOptionsDialogCheckBox.Visible = true;
         }

         _stopButton.Text = "C&lose";
         _stopButton.DialogResult = DialogResult.OK;
         this.AcceptButton = _stopButton;
         this.CancelButton = _stopButton;
         _isWorking = false;
         _stopButton.Focus();
      }

      private void UpdateMessageLabel(BarcodeReadOptions readOptions)
      {
         if(readOptions != null)
         {
             _messageLabel.Text = string.Format(DemosGlobalization.GetResxString(GetType(), "Resx_ReadingBarcode"), readOptions.FriendlyName, _currentPageNumber, _lastPageNumber);
         }
         else
         {
             _messageLabel.Text = string.Format(DemosGlobalization.GetResxString(GetType(), "Resx_ReadingBarcodes"), _currentPageNumber, _lastPageNumber);
         }
      }

      private void Reader_ReadSymbology(object sender, BarcodeReadSymbologyEventArgs e)
      {
         bool firstInGroup;
         double ms = 0;

         switch(e.Operation)
         {
            case BarcodeReadSymbologyOperation.PreRead:
               UpdateMessageLabel(e.Options);
               _stopWatch.Start();
               break;

            case BarcodeReadSymbologyOperation.PostRead:
               if(_stopWatch.IsRunning)
               {
                  _stopWatch.Stop();
                  ms = _stopWatch.ElapsedMilliseconds;
                  _stopWatch.Reset();
                   firstInGroup = true;
               }
               else
               {
                  firstInGroup = false;
               }

               // Add this item to the list
               if(e.Data != null)
               {
                  if(firstInGroup)
                  {
                      ListViewGroup group = new ListViewGroup(string.Format(DemosGlobalization.GetResxString(GetType(), "Resx_GroupRead"), ms));
                     _barcodesListView.Groups.Add(group);
                  }

                  ListViewItem item = new ListViewItem();
                  item.Text = _currentPageNumber.ToString();
                  item.SubItems.Add(BarcodeEngine.GetSymbologyFriendlyName(e.Data.Symbology));

                  string value = string.Empty;
                  string location = string.Empty;

                  BarcodeData data = e.Data;
                  if(data != null)
                  {
                     value = data.Value;
                     if(value == null)
                     {
                        value = string.Empty;
                     }

                     location = string.Format("{0}, {1}, {2}, {3}", data.Bounds.Left, data.Bounds.Top, data.Bounds.Right, data.Bounds.Bottom);
                  }
                  else if(e.Error != null)
                  {
                     value = e.Error.Message;
                  }

                  // Parse the QR barcodes for ECI data
                  string eciData = null;
                  if (data.Symbology == BarcodeSymbology.QR || data.Symbology == BarcodeSymbology.MicroQR)
                     eciData = BarcodeData.ParseECIData(data.GetData());

                  if (!string.IsNullOrEmpty(eciData))
                     item.SubItems.Add(eciData);
                  else
                     item.SubItems.Add(value);

                  item.SubItems.Add(location);

                  item.Group = _barcodesListView.Groups[_barcodesListView.Groups.Count - 1];
                  _barcodesListView.Items.Add(item);
               }
               break;
         }

         Application.DoEvents();

         if(_isAborted)
         {
            e.Status = BarcodeReadSymbologyStatus.Abort;
         }
      }

      protected override void OnFormClosing(FormClosingEventArgs e)
      {
         if(_isWorking)
         {
            e.Cancel = true;
         }

         base.OnFormClosing(e);
      }

      private void _stopButton_Click(object sender, EventArgs e)
      {
         if(_isWorking)
         {
            _isAborted = true;
         }
      }

      protected override void OnFormClosed(FormClosedEventArgs e)
      {
         if(_showReadOptionsDialogCheckBox.Visible)
         {
            _showReadBarcodeOptions = _showReadOptionsDialogCheckBox.Checked;
         }

         base.OnFormClosed(e);
      }

      private void _retryLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
      {
         using(ReadBarcodeExtraDialogBox dlg = new ReadBarcodeExtraDialogBox())
         {
            dlg.UseAllSymbologies = _extraUseAllSymbologies;
            dlg.UseBothDirections = _extraUseBothDirections;
            dlg.UseDoublePass = _extraUseDoublePass;
            dlg.UsePreprocessing = _extraUsePreprocessing;

            if(dlg.ShowDialog(this) == DialogResult.OK)
            {
               _extraUseAllSymbologies = dlg.UseAllSymbologies;
               _extraUseBothDirections = dlg.UseBothDirections;
               _extraUseDoublePass = dlg.UseDoublePass;
               _extraUsePreprocessing = dlg.UsePreprocessing;

               if (_extraUseAllSymbologies)
                  _symbologies = _barcodeEngine.Reader.GetAvailableSymbologies();
               else
                  _symbologies = _userSelectedSymbologies;

               BarcodeSearchDirection searchDirection = (_extraUseBothDirections) ? BarcodeSearchDirection.HorizontalAndVertical : BarcodeSearchDirection.Horizontal;
               bool useDoublePass = (_extraUseDoublePass) ? true : false;
               bool usePreprocessing = (_extraUsePreprocessing) ? true : false;

               if(_extraUseBothDirections || _extraUseDoublePass || _extraUsePreprocessing)
               {
                  BarcodeReadOptions[] allReadOptions = _barcodeEngine.Reader.GetAllDefaultOptions();

                  foreach(BarcodeReadOptions readOptions in allReadOptions)
                  {
                     Type type = readOptions.GetType();

                     if(type == typeof(OneDBarcodeReadOptions))
                     {
                        (readOptions as OneDBarcodeReadOptions).SearchDirection = searchDirection;
                        (readOptions as OneDBarcodeReadOptions).EnableDoublePass = useDoublePass;
                        (readOptions as OneDBarcodeReadOptions).EnablePreprocessing = usePreprocessing;
                     }
                     else if(type == typeof(FourStateBarcodeReadOptions))
                     {
                        (readOptions as FourStateBarcodeReadOptions).SearchDirection = searchDirection;
                     }
                     else if(type == typeof(GS1DatabarStackedBarcodeReadOptions))
                     {
                        (readOptions as GS1DatabarStackedBarcodeReadOptions).SearchDirection = searchDirection;
                     }
                     else if(type == typeof(PatchCodeBarcodeReadOptions))
                     {
                        (readOptions as PatchCodeBarcodeReadOptions).SearchDirection = searchDirection;
                     }
                     else if(type == typeof(PostNetPlanetBarcodeReadOptions))
                     {
                        (readOptions as PostNetPlanetBarcodeReadOptions).SearchDirection = searchDirection;
                     }
                     else if (type == typeof(PharmaCodeBarcodeReadOptions))
                     {
                        (readOptions as PharmaCodeBarcodeReadOptions).SearchDirection = searchDirection;
                     }
                     else if (type == typeof(MicroPDF417BarcodeReadOptions))
                     {
                        (readOptions as MicroPDF417BarcodeReadOptions).EnableDoublePassIfSuccess = useDoublePass;
                        (readOptions as MicroPDF417BarcodeReadOptions).SearchDirection = searchDirection;
                        (readOptions as MicroPDF417BarcodeReadOptions).EnablePreprocessing = usePreprocessing;
                     }
                     else if(type == typeof(PDF417BarcodeReadOptions))
                     {
                        (readOptions as PDF417BarcodeReadOptions).EnableDoublePassIfSuccess = useDoublePass;
                        (readOptions as PDF417BarcodeReadOptions).SearchDirection = searchDirection;
                        (readOptions as PDF417BarcodeReadOptions).EnablePreprocessing = usePreprocessing;
                     }
                     else if(type == typeof(DatamatrixBarcodeReadOptions))
                     {
                        (readOptions as DatamatrixBarcodeReadOptions).EnableDoublePassIfSuccess = useDoublePass;
                        (readOptions as DatamatrixBarcodeReadOptions).EnablePreprocessing = usePreprocessing;
                     }
                     else if(type == typeof(QRBarcodeReadOptions))
                     {
                        (readOptions as QRBarcodeReadOptions).EnableDoublePassIfSuccess = useDoublePass;
                        (readOptions as QRBarcodeReadOptions).EnablePreprocessing = usePreprocessing;
                     }
                  }
               }

               // Ret-try reading using these options
               BeginInvoke(new MethodInvoker(DoReadBarcodes));
            }
         }
      }
   }
}
