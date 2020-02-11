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
using Leadtools.Demos;
namespace BarcodeMainDemo
{
   public partial class NewDocumentDialog : Form
   {
      public NewDocumentDialog()
      {
         InitializeComponent();
      }

      public int DocumentPages;
      public int DocumentBitsPerPixel;
      public int DocumentWidth;
      public int DocumentHeight;
      public int DocumentResolution;

      private const int _minimumSize = 10;
      private const int _maximumSize = 100000;

      protected override void OnLoad(EventArgs e)
      {
         if(!DesignMode)
         {
            int[] commonResolutions =
            {
               96,
               150,
               200,
               300,
               600
            };

            foreach(int commonResolution in commonResolutions)
            {
               _resolutionComboBox.Items.Add(commonResolution);
            }

            // Sanity
            int index = _resolutionComboBox.Items.IndexOf(DocumentResolution);
            if(index == -1)
            {
               DocumentResolution = 300;
            }

            if(DocumentWidth < _minimumSize || DocumentWidth > _maximumSize)
            {
               DocumentWidth = (int)(8.5 * DocumentResolution);
            }

            if(DocumentHeight < _minimumSize || DocumentHeight > _maximumSize)
            {
               DocumentHeight = (int)(11.0 * DocumentResolution);
            }

            if(DocumentPages < 1 || DocumentPages > 1000)
            {
               DocumentPages = 1;
            }

            _widthTextBox.Text = DocumentWidth.ToString();
            _heightTextBox.Text = DocumentHeight.ToString();
            _resolutionComboBox.SelectedItem = DocumentResolution;
            _pagesNumericUpDown.Value = DocumentPages;
            _bitsPerPixelComboBox.SelectedIndex = 0;
         }

         base.OnLoad(e);
      }

      private void _okButton_Click(object sender, EventArgs e)
      {
         if(!GetValue(_widthTextBox, _minimumSize, _maximumSize, out DocumentWidth) ||
            !GetValue(_heightTextBox, _minimumSize, _maximumSize, out DocumentHeight))
         {
            DialogResult = DialogResult.None;
            return;
         }

         DocumentResolution = (int)_resolutionComboBox.SelectedItem;

         DocumentPages = (int)_pagesNumericUpDown.Value;
         if(DocumentPages < 1 || DocumentPages > 100)
         {
            MessageBox.Show(this, DemosGlobalization.GetResxString(GetType(), "Resx_ErrorMessage"), DemosGlobalization.GetResxString(GetType(), "Resx_Error"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            DialogResult = DialogResult.None;
            return;
         }

         switch(_bitsPerPixelComboBox.SelectedIndex)
         {
            case 1:
               DocumentBitsPerPixel = 8;
               break;

            case 2:
               DocumentBitsPerPixel = 24;
               break;

            case 3:
               DocumentBitsPerPixel = 32;
               break;

            case 0:
            default:
               DocumentBitsPerPixel = 1;
               break;
         }
      }

      private bool GetValue(TextBox tb, int minimumValue, int maximumValue, out int value)
      {
         if(!int.TryParse(tb.Text, out value) || value < minimumValue || value > maximumValue)
         {
            tb.SelectAll();
            tb.Focus();
            MessageBox.Show(this, string.Format(DemosGlobalization.GetResxString(GetType(), "Resx_ErrorMessageValue"), minimumValue, maximumValue), DemosGlobalization.GetResxString(GetType(), "Resx_Error"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return false;
         }

         return true;
      }
   }
}
