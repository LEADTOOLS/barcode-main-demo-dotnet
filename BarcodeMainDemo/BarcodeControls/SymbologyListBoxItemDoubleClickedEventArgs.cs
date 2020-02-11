// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace BarcodeMainDemo.BarcodeControls
{
   public class SymbologyListBoxItemDoubleClickedEventArgs : EventArgs
   {
      private SymbologyListBoxItemDoubleClickedEventArgs()
      {
      }

      public SymbologyListBoxItemDoubleClickedEventArgs(int index)
      {
         _index = index;
      }

      private int _index;
      public int Index
      {
         get { return _index; }
      }
   }
}
