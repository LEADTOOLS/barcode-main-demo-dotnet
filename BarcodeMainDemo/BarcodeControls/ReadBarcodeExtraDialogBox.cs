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

namespace BarcodeMainDemo.BarcodeControls
{
   public partial class ReadBarcodeExtraDialogBox : Form
   {
      private bool _useAllSymbologies;
      public bool UseAllSymbologies
      {
         get { return _useAllSymbologies; }
         set { _useAllSymbologies = value; }
      }

      private bool _useBothDirections;
      public bool UseBothDirections
      {
         get { return _useBothDirections; }
         set { _useBothDirections = value; }
      }

      private bool _useDoublePass;
      public bool UseDoublePass
      {
         get { return _useDoublePass; }
         set { _useDoublePass = value; }
      }

      private bool _usePreprocessing;
      public bool UsePreprocessing
      {
         get { return _usePreprocessing; }
         set { _usePreprocessing = value; }
      }

      public ReadBarcodeExtraDialogBox()
      {
         InitializeComponent();
      }

      protected override void OnLoad(EventArgs e)
      {
         if(!DesignMode)
         {
            _allSymbologiesCheckBox.Checked = UseAllSymbologies;
            _directionCheckBox.Checked = UseBothDirections;
            _doublePassCheckBox.Checked = UseDoublePass;
            _imagePreprocessingCheckBox.Checked = UsePreprocessing;
         }

         base.OnLoad(e);
      }

      private void _okButton_Click(object sender, EventArgs e)
      {
         UseAllSymbologies = _allSymbologiesCheckBox.Checked;
         UseBothDirections = _directionCheckBox.Checked;
         UseDoublePass = _doublePassCheckBox.Checked;
         UsePreprocessing = _imagePreprocessingCheckBox.Checked;
      }
   }
}
