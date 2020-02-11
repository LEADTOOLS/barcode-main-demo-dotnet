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

using Leadtools.Demos;
using Leadtools.ImageProcessing;
using Leadtools.ImageProcessing.Color;
using Leadtools.ImageProcessing.Effects;

namespace BarcodeMainDemo
{
   public partial class ValueDialog : Form
   {
      public int Value;
      private TypeConstants _type;
      public enum TypeConstants
      {
         ScaleFactor,
         PaintIntensity,
         PaintContrast,
         PaintGamma,
         AutoCrop,
         Average,
         Gaussian,
         Median,
         Mosaic,
         Oilify,
         Posterize,
         Sharpen,
         Min,
         Max,
         HistoContrast,
         Hue,
         Solarize,
         Temperature
      }


      private struct TypeProp
      {
         public TypeConstants Type;
         public string CaptionName;
         public string ValueName;
         public int InitialValue;
         public bool ReadInitialValue;
         public int Min;
         public int Max;
         public int MultiplyBy;

         public TypeProp(TypeConstants type, string captionName, string valueName, int initialValue, bool readInitialValue, int min, int max, int multiplyBy)
         {
            Type = type;
            CaptionName = captionName;
            ValueName = valueName;
            InitialValue = initialValue;
            ReadInitialValue = readInitialValue;
            Min = min;
            Max = max;
            MultiplyBy = multiplyBy;
         }
      }

      private TypeProp[] _typeProp; 


      public ValueDialog(TypeConstants type)
      {
         //
         // Required for Windows Form Designer support
         //
         _typeProp = new TypeProp[]
         {
            new TypeProp(TypeConstants.ScaleFactor,      DemosGlobalization.GetResxString(GetType(), "Resx_ScaleFactorPercent"),  DemosGlobalization.GetResxString(GetType(), "Resx_ScaleFactor"),       0, true,       1,   1000,   1),
            new TypeProp(TypeConstants.PaintIntensity,   DemosGlobalization.GetResxString(GetType(), "Resx_PaintIntensity"),     DemosGlobalization.GetResxString(GetType(), "Resx_PaintIntensity"),   0, true,    -100,    100,  10),
            new TypeProp(TypeConstants.PaintContrast,    DemosGlobalization.GetResxString(GetType(), "Resx_PaintContrast"),      DemosGlobalization.GetResxString(GetType(), "Resx_PaintContrast"),    0, true,    -100,    100,  10),
            new TypeProp(TypeConstants.PaintGamma,       DemosGlobalization.GetResxString(GetType(), "Resx_PaintGamma"),         DemosGlobalization.GetResxString(GetType(), "Resx_PaintGamma"),       0, true,      10,    500,   1),
            new TypeProp(TypeConstants.AutoCrop,         DemosGlobalization.GetResxString(GetType(), "Resx_AutoCrop"),           DemosGlobalization.GetResxString(GetType(), "Resx_Threshold"),        0, true,       0,    244,   1),
            new TypeProp(TypeConstants.Average,          DemosGlobalization.GetResxString(GetType(), "Resx_Average"),            DemosGlobalization.GetResxString(GetType(), "Resx_Dimension"),        3, false,      3,    255,   1),
            new TypeProp(TypeConstants.Gaussian,         DemosGlobalization.GetResxString(GetType(), "Resx_Gaussian"),           DemosGlobalization.GetResxString(GetType(), "Resx_Radius"),           0, false,      1,   1000,   1),
            new TypeProp(TypeConstants.Median,           DemosGlobalization.GetResxString(GetType(), "Resx_Median"),             DemosGlobalization.GetResxString(GetType(), "Resx_Dimension"),        2, false,      2,     64,   1),
            new TypeProp(TypeConstants.Mosaic,           DemosGlobalization.GetResxString(GetType(), "Resx_Mosac"),              DemosGlobalization.GetResxString(GetType(), "Resx_Dimension"),        2, false,      2,     64,   1),
            new TypeProp(TypeConstants.Oilify,           DemosGlobalization.GetResxString(GetType(), "Resx_Oilify"),             DemosGlobalization.GetResxString(GetType(), "Resx_Dimension"),        2, false,      2,    255,   1),
            new TypeProp(TypeConstants.Posterize,        DemosGlobalization.GetResxString(GetType(), "Resx_Posterize"),          DemosGlobalization.GetResxString(GetType(), "Resx_Levels"),           2, false,      2,     64,   1),
            new TypeProp(TypeConstants.Sharpen,          DemosGlobalization.GetResxString(GetType(), "Resx_Sharpen"),            DemosGlobalization.GetResxString(GetType(), "Resx_Sharpness"),        0, false,   -100,    100,  10),
            new TypeProp(TypeConstants.Min,              DemosGlobalization.GetResxString(GetType(), "Resx_MinFilter"),          DemosGlobalization.GetResxString(GetType(), "Resx_SampleSize"),       1, false,      1,     32,   1),
            new TypeProp(TypeConstants.Max,              DemosGlobalization.GetResxString(GetType(), "Resx_MaxFilter"),          DemosGlobalization.GetResxString(GetType(), "Resx_SampleSize"),       1, false,      1,     32,   1),
            new TypeProp(TypeConstants.HistoContrast,    DemosGlobalization.GetResxString(GetType(), "Resx_HistoContrast"),      DemosGlobalization.GetResxString(GetType(), "Resx_Contrast"),         0, false,   -100,    100,  10),
            new TypeProp(TypeConstants.Hue,              DemosGlobalization.GetResxString(GetType(), "Resx_Hue"),                DemosGlobalization.GetResxString(GetType(), "Resx_Angle"),            0, false,   -360,    360,   1),
            new TypeProp(TypeConstants.Solarize,         DemosGlobalization.GetResxString(GetType(), "Resx_Solarize"),           DemosGlobalization.GetResxString(GetType(), "Resx_Threshold"),        0, false,      0,    255,   1),
            new TypeProp(TypeConstants.Temperature,      DemosGlobalization.GetResxString(GetType(), "Resx_Temperature"),        DemosGlobalization.GetResxString(GetType(), "Resx_Threshold"),        0, false,   -1000,   1000,   1)
         };
         InitializeComponent();

         //
         // TODO: Add any constructor code after InitializeComponent call
         //
         _type = type;
      }

      private void ValueDialog_Load(object sender, System.EventArgs e)
      {
         TypeProp prop = _typeProp[(int)_type];
         Text = prop.CaptionName;
         _gbOptions.Text = prop.ValueName;
         _numValue.Minimum = prop.Min;
         _numValue.Maximum = prop.Max;
         if(prop.ReadInitialValue)
            prop.InitialValue = Value;
         else
            Value = prop.InitialValue;

         DialogUtilities.SetNumericValue(_numValue, Value / prop.MultiplyBy);
      }

      private void _num_Leave(object sender, System.EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         int index = (int)_type;
         Value = (int)_numValue.Value * _typeProp[index].MultiplyBy;
         _typeProp[index].InitialValue = Value;
      }
   }
}
