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
using Leadtools.Demos;
using Leadtools.Barcode;

namespace BarcodeMainDemo.BarcodeControls
{
   public partial class ReadBarcodeOptionsDialogBox : Form
   {
      private BarcodeEngine _barcodeEngine;

      private int _selectedGroupIndex;
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public int SelectedGroupIndex
      {
         get { return _selectedGroupIndex; }
      }

      private BarcodeSymbology[] _selectedSymbologies;
      public BarcodeSymbology[] GetSelectedSymbologies()
      {
         return _selectedSymbologies;
      }

      private bool _readBarcodesWhenDialogCloses;
      public bool ReadBarcodesWhenDialogCloses
      {
         get { return _readBarcodesWhenDialogCloses; }
      }

      private int _totalSymbologiesCount;

      public ReadBarcodeOptionsDialogBox(BarcodeEngine barcodeEngine, RasterImage sampleSymbologiesRasterImage, int selectedGroupIndex, BarcodeSymbology[] selectedSymbologies, bool readBarcodesWhenDialogCloses)
      {
         InitializeComponent();

         _availableSymbologyListBox.SampleSymbologiesRasterImage = sampleSymbologiesRasterImage;
         _toReadSymbologyListBox.SampleSymbologiesRasterImage = sampleSymbologiesRasterImage;

         _barcodeEngine = barcodeEngine;

         _selectedGroupIndex = selectedGroupIndex;
         _selectedSymbologies = selectedSymbologies;

         _readBarcodesWhenDialogClosesCheckBox.Checked = readBarcodesWhenDialogCloses;
      }

      private class SymbologyGroup
      {
         public SymbologyGroup(BarcodeReadOptions readOptions)
         {
            _readOptions = readOptions;
         }

         private BarcodeReadOptions _readOptions;
         public BarcodeReadOptions ReadOptions
         {
            get { return _readOptions; }
            set { _readOptions = value; }
         }

         public override string ToString()
         {
            return ReadOptions.FriendlyName;
         }
      }

      protected override void OnLoad(EventArgs e)
      {
         if(!DesignMode)
         {
            _totalSymbologiesCount = _barcodeEngine.Reader.GetAvailableSymbologies().Length;

            foreach(BarcodeReadOptions readOptions in _barcodeEngine.Reader.GetAllDefaultOptions())
            {
               _groupsListBox.Items.Add(new SymbologyGroup(readOptions.Clone() as BarcodeReadOptions));
            }

            _toReadSymbologyListBox.BeginUpdate();
            foreach(BarcodeSymbology symbology in _selectedSymbologies)
            {
               _toReadSymbologyListBox.Items.Add(symbology);
            }
            _toReadSymbologyListBox.EndUpdate();

            _groupsListBox.SelectedIndex = _selectedGroupIndex;

            _groupPropertyGrid.ExpandAllGridItems();

            UpdateUIState();
         }

         base.OnLoad(e);
      }

      private void _groupOptionsResetToDefaultsButton_Click(object sender, EventArgs e)
      {
         SymbologyGroup group = _groupsListBox.SelectedItem as SymbologyGroup;
         group.ReadOptions = Activator.CreateInstance(group.ReadOptions.GetType()) as BarcodeReadOptions;
         _groupPropertyGrid.SelectedObject = group.ReadOptions;
      }

      private void _groupsListBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         SymbologyGroup group = _groupsListBox.SelectedItem as SymbologyGroup;

         _groupPropertyGrid.SelectedObject = group.ReadOptions;

         UpdateAvailableSymbologies();
      }

      private void UpdateAvailableSymbologies()
      {
         SymbologyGroup group = _groupsListBox.SelectedItem as SymbologyGroup;

         // Clear the extra symbologies box and add the new ones not found in the right pane
         _availableSymbologyListBox.BeginUpdate();

         _availableSymbologyListBox.Items.Clear();

         BarcodeSymbology[] groupSymbologies = group.ReadOptions.GetSupportedSymbologies();
         foreach(BarcodeSymbology groupSymbology in groupSymbologies)
         {
            bool found = false;

            foreach(BarcodeSymbology toReadSymbology in _toReadSymbologyListBox.Items)
            {
               if(groupSymbology == toReadSymbology)
               {
                  found = true;
                  break;
               }
            }

            if(!found)
            {
               _availableSymbologyListBox.Items.Add(groupSymbology);
            }
         }

         _availableSymbologyListBox.EndUpdate();

         UpdateUIState();
      }

      private void _removeButton_Click(object sender, EventArgs e)
      {
         _toReadSymbologyListBox.BeginUpdate();

         while(_toReadSymbologyListBox.SelectedItems.Count > 0)
         {
            _toReadSymbologyListBox.Items.Remove(_toReadSymbologyListBox.SelectedItem);
         }

         _toReadSymbologyListBox.EndUpdate();

         UpdateAvailableSymbologies();
      }

      private void _removeAllButton_Click(object sender, EventArgs e)
      {
         _toReadSymbologyListBox.Items.Clear();
         UpdateAvailableSymbologies();
      }

      private void _addAllSupportedSymbologiesButton_Click(object sender, EventArgs e)
      {
         _toReadSymbologyListBox.Items.Clear();
         _toReadSymbologyListBox.BeginUpdate();
         BarcodeSymbology[] symbologies = _barcodeEngine.Reader.GetAvailableSymbologies();
         foreach(BarcodeSymbology symbology in symbologies)
         {
            _toReadSymbologyListBox.Items.Add(symbology);
         }
         _toReadSymbologyListBox.EndUpdate();

         UpdateAvailableSymbologies();
      }

      private void _addButton_Click(object sender, EventArgs e)
      {
         _toReadSymbologyListBox.BeginUpdate();
         foreach(BarcodeSymbology symbology in _availableSymbologyListBox.SelectedItems)
         {
            _toReadSymbologyListBox.Items.Add(symbology);
         }
         _toReadSymbologyListBox.EndUpdate();

         UpdateAvailableSymbologies();
      }

      private void _addAllButton_Click(object sender, EventArgs e)
      {
         _toReadSymbologyListBox.BeginUpdate();
         foreach(BarcodeSymbology symbology in _availableSymbologyListBox.Items)
         {
            _toReadSymbologyListBox.Items.Add(symbology);
         }
         _toReadSymbologyListBox.EndUpdate();

         UpdateAvailableSymbologies();
      }

      private void _helpButton_Click(object sender, EventArgs e)
      {
         StringBuilder sb = new StringBuilder();

         sb.AppendLine(DemosGlobalization.GetResxString(GetType(), "Resx_Help1stLine"));
         sb.AppendLine();
         sb.AppendLine(DemosGlobalization.GetResxString(GetType(), "Resx_Help2ndLine"));
         sb.AppendLine();
         sb.AppendLine(DemosGlobalization.GetResxString(GetType(), "Resx_Help3rdLine"));
         sb.AppendLine(DemosGlobalization.GetResxString(GetType(), "Resx_Help4thLine"));
         sb.AppendLine();
         sb.AppendLine(DemosGlobalization.GetResxString(GetType(), "Resx_Help5thLine"));

         MessageBox.Show(this, sb.ToString(), DemosGlobalization.GetResxString(GetType(), "Resx_HelpMsg"), MessageBoxButtons.OK, MessageBoxIcon.Information);
      }

      private void _availableSymbologyListBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         UpdateUIState();
      }

      private void _availableSymbologyListBox_ItemDoubleClicked(object sender, SymbologyListBoxItemDoubleClickedEventArgs e)
      {
         _toReadSymbologyListBox.BeginUpdate();
         BarcodeSymbology symbology = (BarcodeSymbology)_availableSymbologyListBox.Items[e.Index];
         _toReadSymbologyListBox.Items.Add(symbology);
         _toReadSymbologyListBox.EndUpdate();

         UpdateAvailableSymbologies();
      }

      private void _toReadSymbologyListBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         UpdateUIState();
      }

      private void _toReadSymbologyListBox_ItemDoubleClicked(object sender, SymbologyListBoxItemDoubleClickedEventArgs e)
      {
         _toReadSymbologyListBox.BeginUpdate();
         _toReadSymbologyListBox.Items.RemoveAt(e.Index);
         _toReadSymbologyListBox.EndUpdate();

         UpdateAvailableSymbologies();
      }

      private void UpdateUIState()
      {
         _addButton.Enabled = _availableSymbologyListBox.SelectedItems.Count > 0;
         _addAllButton.Enabled = _availableSymbologyListBox.Items.Count > 0;
         _removeButton.Enabled = _toReadSymbologyListBox.SelectedItems.Count > 0;
         _removeAllButton.Enabled = _toReadSymbologyListBox.Items.Count > 0;
         _okButton.Enabled = _toReadSymbologyListBox.Items.Count > 0;
         _addAllSupportedSymbologiesButton.Enabled = _toReadSymbologyListBox.Items.Count != _totalSymbologiesCount;

         _allGroupSymbologesAddedLabel.Visible = _availableSymbologyListBox.Items.Count == 0;
      }

      private void _okButton_Click(object sender, EventArgs e)
      {
         // Set all the options to the engine
         BarcodeReadOptions[] defaultOptions = _barcodeEngine.Reader.GetAllDefaultOptions();

         foreach(SymbologyGroup group in _groupsListBox.Items)
         {
            foreach(BarcodeReadOptions defaultOption in defaultOptions)
            {
               if(defaultOption.GetType() == group.ReadOptions.GetType())
               {
                  group.ReadOptions.CopyTo(defaultOption);
               }
            }
         }

         _selectedGroupIndex = _groupsListBox.SelectedIndex;
         _selectedSymbologies = new BarcodeSymbology[_toReadSymbologyListBox.Items.Count];
         for(int i = 0; i < _toReadSymbologyListBox.Items.Count; i++)
         {
            _selectedSymbologies[i] = (BarcodeSymbology)_toReadSymbologyListBox.Items[i];
         }

         _readBarcodesWhenDialogCloses = _readBarcodesWhenDialogClosesCheckBox.Checked;
      }
   }
}
