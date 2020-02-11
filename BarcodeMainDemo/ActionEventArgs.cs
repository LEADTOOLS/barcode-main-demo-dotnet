// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace BarcodeMainDemo
{
   /// <summary>
   /// Arguments for the Action event used in the viewer and pages control
   /// </summary>
   public class ActionEventArgs : EventArgs
   {
      private string _action; // String identifying the action
      private object _data; // The data for this action

      private ActionEventArgs()
      {
         // No default ctor
      }

      public ActionEventArgs(string action, object data)
      {
         _action = action;
         _data = data;
      }

      public string Action
      {
         get
         {
            return _action;
         }
      }

      public object Data
      {
         get
         {
            return _data;
         }
      }
   }
}
