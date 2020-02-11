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

namespace Leadtools.Demos
{
   public partial class ImageFileLoaderPagesDialog : Form
   {
      private int _pages;
      private bool _loadOnlyOnePage;

      public int FirstPage;
      public int LastPage;

      public ImageFileLoaderPagesDialog(int pages, bool loadOnlyOnePage)
      {
         InitializeComponent();

         _pages = pages;
         _loadOnlyOnePage = loadOnlyOnePage;
      }

      private void ImageFileLoaderPagesDialog_Load(object sender, System.EventArgs e)
      {
         FirstPage = 1;
         LastPage = _pages;

         string text = _lblInfo.Text;
         text = text.Replace("###", _pages.ToString());

         if(_loadOnlyOnePage)
         {
            _rbLoadSinglePage.Checked = true;
            text = text.Replace("$$$", DemosGlobalization.GetResxString(GetType(), "Resx_page"));
         }
         else
         {
            _rbLoadMultiPages.Checked = true;
            text = text.Replace("$$$", DemosGlobalization.GetResxString(GetType(), "Resx_pages"));
         }

         _lblInfo.Text = text;
         _tbPageNumber.Text = FirstPage.ToString();
         _tbFirstPage.Text = FirstPage.ToString();
         _tbLastPage.Text = LastPage.ToString();
         UpdateControls();
      }

      private void _rbLoadSinglePage_Click(object sender, EventArgs e)
      {
         UpdateControls();
         _tbPageNumber.SelectAll();
         _tbPageNumber.Focus();
      }

      private void _rbLoadMultiPages_Click(object sender, EventArgs e)
      {
         UpdateControls();
         _tbLastPage.SelectAll();
         _tbLastPage.Focus();
      }

      private void UpdateControls( )
      {
         _lblPageNumber.Enabled = _rbLoadSinglePage.Checked;
         _tbPageNumber.Enabled = _rbLoadSinglePage.Checked;

         _lblFirstPage.Enabled = _rbLoadMultiPages.Checked;
         _tbFirstPage.Enabled = _rbLoadMultiPages.Checked;
         _lblLastPage.Enabled = _rbLoadMultiPages.Checked;
         _tbLastPage.Enabled = _rbLoadMultiPages.Checked;
      }

      private void _tb_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
      {
         if(!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
            e.Handled = true;
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         if(_rbLoadSinglePage.Checked) // Load single page
         {
             if (!DialogUtilities.ParseInteger(_tbPageNumber, DemosGlobalization.GetResxString(GetType(), "Resx_PageNum"), 1, true, _pages, true, true, out FirstPage))
            {
               _tbPageNumber.SelectAll();
               _tbPageNumber.Focus();
               return;
            }

            LastPage = FirstPage;
         }
         else
         {
            if (!DialogUtilities.ParseInteger(_tbFirstPage, DemosGlobalization.GetResxString(GetType(), "Resx_FirstPage"), 1, true, _pages, true, true, out FirstPage))
            {
               _tbFirstPage.SelectAll();
               _tbFirstPage.Focus();
               return;
            }

            if (!DialogUtilities.ParseInteger(_tbLastPage, DemosGlobalization.GetResxString(GetType(), "Resx_LastPage"), FirstPage, true, _pages, true, true, out LastPage))
            {
               _tbLastPage.SelectAll();
               _tbLastPage.Focus();
               return;
            }
         }
      }
   }
}
