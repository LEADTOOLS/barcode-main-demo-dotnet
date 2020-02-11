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

namespace BarcodeMainDemo
{
   public partial class GotoPageDialog : Form
   {
      public GotoPageDialog()
      {
         InitializeComponent();
      }

      public int DocumentPage;
      public int DocumentPageCount;

      protected override void OnLoad(EventArgs e)
      {
         if(!DesignMode)
         {
            _pageCountLabel.Text = _pageCountLabel.Text.Replace("##", DocumentPageCount.ToString());
            _pageNumericUpDown.Maximum = DocumentPageCount;
            _pageNumericUpDown.Value = DocumentPage;
         }

         base.OnLoad(e);
      }

      private void _okButton_Click(object sender, EventArgs e)
      {
         DocumentPage = (int)_pageNumericUpDown.Value;
      }
   }
}
