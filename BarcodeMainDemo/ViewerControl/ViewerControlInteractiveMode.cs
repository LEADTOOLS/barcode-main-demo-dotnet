// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace BarcodeMainDemo.ViewerControl
{
   /// <summary>
   /// The current interactive mode (using the mouse on) of the viewer control
   /// </summary>
   public enum ViewerControlInteractiveMode
   {
      /// <summary>
      /// None
      /// </summary>
      SelectMode,
      /// <summary>
      /// Pan mode
      /// </summary>
      PanMode,
      /// <summary>
      /// Zoom to selection mode
      /// </summary>
      ZoomToSelectionMode,
      /// <summary>
      /// Select the region of interest in the image
      /// </summary>
      RegionMode,
      /// <summary>
      /// Reads a barcode with current options
      /// </summary>
      ReadBarcodeMode,
      /// <summary>
      /// Write new barcode mode
      /// </summary>
      WriteBarcodeMode
   }
}
