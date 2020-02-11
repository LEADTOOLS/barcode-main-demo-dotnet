// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;

using Leadtools.Barcode;

namespace BarcodeMainDemo
{
   // Each page has a list of barcodes and a current selected barcode index
   public class PageBarcodes
   {
      public PageBarcodes()
      {
         _barcodes = new List<BarcodeData>();
         _selectedIndex = -1;
      }

      private IList<BarcodeData> _barcodes;
      public IList<BarcodeData> Barcodes
      {
         get { return _barcodes; }
      }

      private int _selectedIndex;
      public int SelectedIndex
      {
         get { return _selectedIndex; }
         set { _selectedIndex = value; }
      }
   }

   // A document has a list of PageBarcodes
   public class DocumentBarcodes
   {
      public DocumentBarcodes()
      {
         _pages = new List<PageBarcodes>();
      }

      private IList<PageBarcodes> _pages;
      public IList<PageBarcodes> Pages
      {
         get { return _pages; }
      }
   }
}
