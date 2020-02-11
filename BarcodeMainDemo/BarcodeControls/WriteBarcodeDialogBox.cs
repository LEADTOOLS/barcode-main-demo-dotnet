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

using Leadtools;
using Leadtools.Barcode;

namespace BarcodeMainDemo.BarcodeControls
{
   public partial class WriteBarcodeDialogBox : Form
   {
      private BarcodeEngine _barcodeEngine;
      private LeadRect _bounds;

      public delegate bool WriteBarcodeDelegate(BarcodeData data);
      private WriteBarcodeDelegate _writeBarcodeDelegate;

      private int _selectedGroupIndex;
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public int SelectedGroupIndex
      {
         get { return _selectedGroupIndex; }
      }

      private BarcodeSymbology _selectedSymbology;
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public BarcodeSymbology SelectedSymbology
      {
         get { return _selectedSymbology; }
      }

      public WriteBarcodeDialogBox(BarcodeEngine barcodeEngine, RasterImage sampleSymbologiesRasterImage, LeadRect bounds, int groupIndex, BarcodeSymbology symbology, WriteBarcodeDelegate writeBarcodeDelegate)
      {
         InitializeComponent();

         _availableSymbologyListBox.SampleSymbologiesRasterImage = sampleSymbologiesRasterImage;

         _barcodeEngine = barcodeEngine;
         _bounds = bounds;

         _selectedGroupIndex = groupIndex;
         _selectedSymbology = symbology;

         _writeBarcodeDelegate = writeBarcodeDelegate;
      }

      private class SymbologyGroup
      {
         public SymbologyGroup(BarcodeWriteOptions writeOptions)
         {
            _writeOptions = writeOptions;
         }

         private BarcodeWriteOptions _writeOptions;
         public BarcodeWriteOptions WriteOptions
         {
            get { return _writeOptions; }
            set { _writeOptions = value; }
         }

         public override string ToString()
         {
            return WriteOptions.FriendlyName;
         }
      }

      protected override void OnLoad(EventArgs e)
      {
         if(!DesignMode)
         {
            foreach(BarcodeWriteOptions writeOptions in _barcodeEngine.Writer.GetAllDefaultOptions())
            {
               _groupsListBox.Items.Add(new SymbologyGroup(writeOptions.Clone() as BarcodeWriteOptions));
            }

            _groupsListBox.SelectedIndex = _selectedGroupIndex;

            foreach(BarcodeSymbology symbology in _availableSymbologyListBox.Items)
            {
               if(symbology == _selectedSymbology)
               {
                  _availableSymbologyListBox.SelectedItem = symbology;
                  break;
               }
            }

            if(_availableSymbologyListBox.SelectedIndex == -1)
            {
               _availableSymbologyListBox.SelectedIndex = 0;
            }

            ResizePropertyGridFirstColumn(_dataPropertyGrid, 20);
            BarcodeData data = _dataPropertyGrid.SelectedObject as BarcodeData;
            data.Bounds = _bounds;

            _groupPropertyGrid.ExpandAllGridItems();
            _dataPropertyGrid.ExpandAllGridItems();

            UpdateUIState();
         }

         base.OnLoad(e);
      }

      private static void ResizePropertyGridFirstColumn(PropertyGrid thePropertyGrid, int percentage)
      {
         Type type = typeof(PropertyGrid);
         System.Reflection.FieldInfo fi = type.GetField("gridView", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
         object gridView = fi.GetValue(thePropertyGrid);
         Type gridViewType = gridView.GetType();
         int gridColWidth = (int)((double)thePropertyGrid.Width * percentage / 100.0);
         gridViewType.InvokeMember("MoveSplitterTo", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.InvokeMethod, null, gridView, new object[] { gridColWidth });
      }

      private void _groupOptionsResetToDefaultsButton_Click(object sender, EventArgs e)
      {
         SymbologyGroup group = _groupsListBox.SelectedItem as SymbologyGroup;
         group.WriteOptions = Activator.CreateInstance(group.WriteOptions.GetType()) as BarcodeWriteOptions;
         _groupPropertyGrid.SelectedObject = group.WriteOptions;
      }

      private void _groupsListBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         SymbologyGroup group = _groupsListBox.SelectedItem as SymbologyGroup;

         _groupPropertyGrid.SelectedObject = group.WriteOptions;

         UpdateAvailableSymbologies();
      }

      private void UpdateAvailableSymbologies()
      {
         SymbologyGroup group = _groupsListBox.SelectedItem as SymbologyGroup;

         // Clear the extra symbologies box and add the new ones not found in the right pane
         _availableSymbologyListBox.BeginUpdate();

         _availableSymbologyListBox.Items.Clear();

         BarcodeSymbology[] groupSymbologies = group.WriteOptions.GetSupportedSymbologies();
         foreach(BarcodeSymbology groupSymbology in groupSymbologies)
         {
            _availableSymbologyListBox.Items.Add(groupSymbology);
         }

         _availableSymbologyListBox.EndUpdate();

         _availableSymbologyListBox.SelectedIndex = 0;

         UpdateUIState();
      }

      private void _availableSymbologyListBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         BarcodeSymbology symbology = (BarcodeSymbology)_availableSymbologyListBox.SelectedItem;
         BarcodeData oldData = _dataPropertyGrid.SelectedObject as BarcodeData;
         BarcodeData newData = BarcodeData.CreateDefaultBarcodeData(symbology);
         // Get the old data bounds and set it into the new barcode
         if(oldData != null)
         {
            newData.Bounds = oldData.Bounds;
         }
         _dataPropertyGrid.SelectedObject = newData;
         UpdateUIState();
      }

      private void UpdateUIState()
      {
         bool validated = false;
         if(!validated)
         {
            validated = _availableSymbologyListBox.SelectedIndex != -1;
         }
         _okButton.Enabled = validated;
      }

      private void _okButton_Click(object sender, EventArgs e)
      {
         // Set all the options to the engine
         BarcodeWriteOptions[] defaultOptions = _barcodeEngine.Writer.GetAllDefaultOptions();
         foreach(SymbologyGroup group in _groupsListBox.Items)
         {
            foreach(BarcodeWriteOptions defaultOption in defaultOptions)
            {
               if(defaultOption.GetType() == group.WriteOptions.GetType())
               {
                  group.WriteOptions.CopyTo(defaultOption);
               }
            }
         }

         _selectedGroupIndex = _groupsListBox.SelectedIndex;
         _selectedSymbology = (BarcodeSymbology)_availableSymbologyListBox.SelectedItem;

         BarcodeData data = _dataPropertyGrid.SelectedObject as BarcodeData;
         if(!_writeBarcodeDelegate(data))
         {
            DialogResult = DialogResult.None;
         }
      }
   }
}
