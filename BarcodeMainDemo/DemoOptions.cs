// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

using Leadtools.Barcode;
using Leadtools.Demos;

namespace BarcodeMainDemo
{
   // Current demo options, we can load/save this to disk
   [Serializable]
   public struct DemoOptions
   {
      public int ReadOptionsGroupIndex;
      public BarcodeSymbology[] ReadOptionsSymbologies;
      public int WriteOptionsGroupIndex;
      public BarcodeSymbology WriteOptionsSymbology;
      public bool ReadBarcodesWhenOptionsDialogCloses;
      public string OpenCommonDialogFolder;
      public int NewDocumentPages;
      public int NewDocumentBitsPerPixel;
      public int NewDocumentWidth;
      public int NewDocumentHeight;
      public int NewDocumentResolution;

      public static DemoOptions Default
      {
         get
         {
            DemoOptions obj = new DemoOptions();
            obj.ReadOptionsGroupIndex = 0;
            obj.ReadOptionsSymbologies = BarcodeEngine.GetSupportedSymbologies();
            obj.WriteOptionsGroupIndex = 0;
            obj.WriteOptionsSymbology = BarcodeSymbology.EAN13;
            obj.ReadBarcodesWhenOptionsDialogCloses = true;
            obj.NewDocumentPages = 1;
            obj.NewDocumentBitsPerPixel = 1;
            obj.NewDocumentResolution = 300;
            obj.NewDocumentWidth = (int)(8.5 * obj.NewDocumentResolution);
            obj.NewDocumentHeight = (int)(11.0 * obj.NewDocumentResolution);
#if LT_CLICKONCE
            obj.OpenCommonDialogFolder = System.Environment.GetFolderPath( Environment.SpecialFolder.MyDocuments );
#else
            obj.OpenCommonDialogFolder = DemosGlobal.ImagesFolder;
#endif
            return obj;
         }
      }

      private static string DataFileName
      {
         get
         {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"BarcodeMainDemo.xml");
         }
      }

      private static XmlSerializer _serializer = new XmlSerializer(typeof(DemoOptions));

      public static DemoOptions Load()
      {
         try
         {
            if(File.Exists(DataFileName))
            {
               using(XmlTextReader reader = new XmlTextReader(DataFileName))
               {
                  return (DemoOptions)_serializer.Deserialize(reader);
               }
            }
            else
            {
               return DemoOptions.Default;
            }
         }
         catch
         {
            return DemoOptions.Default;
         }
      }

      public void Save()
      {
         try
         {
            using(XmlTextWriter writer = new XmlTextWriter(DataFileName, Encoding.Unicode))
            {
               writer.Formatting = Formatting.Indented;
               writer.Indentation = 2;
               _serializer.Serialize(writer, this);
            }
         }
         catch
         {
         }
      }
   }
}
