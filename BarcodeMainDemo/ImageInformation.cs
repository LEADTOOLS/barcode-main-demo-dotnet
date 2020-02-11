// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;

using Leadtools;

namespace Leadtools.Demos
{
   public class ImageInformation
   {
      public RasterImage Image;
      public string Name;

      public ImageInformation( )
      {
         Image = null;
         Name = string.Empty;
      }

      public ImageInformation(RasterImage image, string name)
      {
         Image = image;
         Name = name;
      }

      public ImageInformation(RasterImage image)
      {
         Image = image;
         Name = "Untitled";
      }
   }
}
