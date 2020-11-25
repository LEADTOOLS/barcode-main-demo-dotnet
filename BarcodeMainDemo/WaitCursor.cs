// *************************************************************
// Copyright (c) 1991-2020 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Windows.Forms;

namespace Leadtools.Demos
{
   public sealed class WaitCursor : IDisposable
   {
      private Cursor _cursor;

      public WaitCursor()
      {
         _cursor = Cursor.Current;
         Cursor.Current = Cursors.WaitCursor;
      }

      public void Dispose()
      {
         Dispose(true);
         GC.SuppressFinalize(this);
      }

      ~WaitCursor()
      {
         Dispose(false);
      }

      private void Dispose(bool disposing)
      {
         if (disposing)
         {
            if (_cursor != null)
            {
               Cursor.Current = _cursor;
               _cursor = null;
            }
         }
      }
   }
}
