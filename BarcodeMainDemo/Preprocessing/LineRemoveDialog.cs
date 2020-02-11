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
using Leadtools.ImageProcessing;
using Leadtools.ImageProcessing.Core;

namespace BarcodeMainDemo
{
   public partial class LineRemoveDialog : Form
   {
      // The LineRemoveCommand Class is part of our LEAD Document Imaging functions. This class will remove horizontal and vertical lines in a 1-bit black and white image.
      // This dialog will update the following members of this class:
      // LineRemoveCommand.GapLength, this member will be used to setthe maximum length of a break or a hole in a line.   
      // LineRemoveCommand.MaximumLineWidth, this member will be used to setthe maximum average width of a line that is considered for removal.   
      // LineRemoveCommand.MaximumWallPercent, this member will be used to setthe maximum number of wall slices (expressed as a percent of the total length of the line) that are allowed.   
      // LineRemoveCommand.MinimumLineLength, this member will be used to setthe minimum length of a line considered for removal.   
      // LineRemoveCommand.Type Flag that indicates which lines to remove. (horizontal or vertical lines)   
      // LineRemoveCommand.Variance, this member will be used to setthe amount of width change that is tolerated between adjacent line slices.   
      // LineRemoveCommand.Wall, this member will be used to setthe height of a wall. Walls are slices of a line that are too wide to be considered part of the line.  
      
      private LineRemoveCommand _LineRemoveCommand = null;
      private double _MinimumLineLength = 0.0;
      private double _MaximumLineWidth = 0.0;
      private double _WallHeight = 0.0;
      private double _Variance = 0.0;
      private double _GapLength = 0.0;
      public int XResolution = 150;
      public int YResolution = 150;

      public LineRemoveDialog()
      {
         InitializeComponent();
         _LineRemoveCommand = new LineRemoveCommand();
         InitializeUI();
      }

      public LineRemoveDialog(LineRemoveCommand lineRemoveCommand, int XResolution, int YResolution)
      {
         InitializeComponent();
         _LineRemoveCommand = lineRemoveCommand;
         this.XResolution = XResolution;
         this.YResolution = YResolution;
         InitializeUI();
      }

      public LineRemoveCommand LineRemoveCommand
      {
         get
         {
            UpdateCommand();
            return _LineRemoveCommand;
         }
         set
         {
            _LineRemoveCommand = value;
            InitializeUI();
         }
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         UpdateCommand();
         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
      }
      private void InitializeUI()
      {
         // Initialize the LineRemoveCommand Dialog with default values
         if ((_LineRemoveCommand.Flags & LineRemoveCommandFlags.UseDpi) == LineRemoveCommandFlags.UseDpi)
         {
            // If true, the measure for all properties of the LineRemoveCommand is thousandths of an inch
            _Variance = (double)_LineRemoveCommand.Variance / 1000;
            _GapLength = (double)_LineRemoveCommand.GapLength / 1000;
            _MaximumLineWidth = (double)_LineRemoveCommand.MaximumLineWidth / 1000;
            _MinimumLineLength = (double)_LineRemoveCommand.MinimumLineLength / 1000;
            _WallHeight = (double)_LineRemoveCommand.Wall / 1000;

            _tbVariance.Text = _Variance.ToString();
            _tbGapLength.Text = _GapLength.ToString();
            _tbMaximumLineWidth.Text = _MaximumLineWidth.ToString();
            _tbMinimumLineLength.Text = _MinimumLineLength.ToString();
            _tbWallHeight.Text = _WallHeight.ToString();
            _tbMaximumWallPercent.Text = _LineRemoveCommand.MaximumWallPercent.ToString();


            _cbUseDPI.Checked = true;
            _lbl5.Text = _lbl6.Text = _lbl7.Text = _lbl8.Text = _lbl9.Text = "inches";
         }
         else
         {
            _tbVariance.Text = _LineRemoveCommand.Variance.ToString();
            _tbGapLength.Text = _LineRemoveCommand.GapLength.ToString();
            _tbMaximumLineWidth.Text = _LineRemoveCommand.MaximumLineWidth.ToString();
            _tbMinimumLineLength.Text = _LineRemoveCommand.MinimumLineLength.ToString();
            _tbMaximumWallPercent.Text = _LineRemoveCommand.MaximumWallPercent.ToString();
            _tbWallHeight.Text = _LineRemoveCommand.Wall.ToString();
            // Converts the used unit to inches
            ConvertToInches();
            _cbUseDPI_CheckedChanged(this, null);
         }
         this._cbUseDPI.CheckedChanged += new System.EventHandler(this._cbUseDPI_CheckedChanged);

         if ((_LineRemoveCommand.Type & LineRemoveCommandType.Horizontal) == LineRemoveCommandType.Horizontal)
            _rbHorizontalLines.Checked = true;
         else
            _rbVerticalLines.Checked = true;

         if ((_LineRemoveCommand.Flags & LineRemoveCommandFlags.UseGap) == LineRemoveCommandFlags.UseGap)
            _cbMaximumGap.Checked = true;

         if ((_LineRemoveCommand.Flags & LineRemoveCommandFlags.UseVariance) == LineRemoveCommandFlags.UseVariance)
            _cbLineVariance.Checked = true;

         if ((_LineRemoveCommand.Flags & LineRemoveCommandFlags.RemoveEntire) == LineRemoveCommandFlags.RemoveEntire)
            _cbRemoveEntireLine.Checked = true;

         _tbDPI.Text = "dpi: " + this.XResolution.ToString() + ", " + this.YResolution.ToString();
      }
      private void UpdateCommand()
      {
         // Determine how the LineRemoveCommand will work by setting the values to its members and flags
         _LineRemoveCommand.Flags = LineRemoveCommandFlags.None;
         _LineRemoveCommand.Flags =
            (_cbUseDPI.Checked ? LineRemoveCommandFlags.UseDpi : LineRemoveCommandFlags.None) |
            (_cbMaximumGap.Checked ? LineRemoveCommandFlags.UseGap : LineRemoveCommandFlags.None) |
            (_cbRemoveEntireLine.Checked ? LineRemoveCommandFlags.RemoveEntire : LineRemoveCommandFlags.None) |
            (_cbLineVariance.Checked ? LineRemoveCommandFlags.UseVariance : LineRemoveCommandFlags.None);
         if (_LineRemoveCommand.Flags == LineRemoveCommandFlags.None)
            _LineRemoveCommand.Flags = (new LineRemoveCommand()).Flags;

         if (_cbUseDPI.Checked)
         {
            _LineRemoveCommand.GapLength = Convert.ToInt32(_GapLength * 1000);
            _LineRemoveCommand.MaximumLineWidth = Convert.ToInt32(_MaximumLineWidth * 1000);
            _LineRemoveCommand.MinimumLineLength = Convert.ToInt32(_MinimumLineLength * 1000);
            _LineRemoveCommand.Variance = Convert.ToInt32(_Variance * 1000);
            _LineRemoveCommand.Wall = Convert.ToInt32(_WallHeight * 1000);
         }
         else
         {
            if (_tbGapLength.Text != "")
               _LineRemoveCommand.GapLength = Convert.ToInt32(_tbGapLength.Text);
            if (_tbMaximumLineWidth.Text != "")
               _LineRemoveCommand.MaximumLineWidth = Convert.ToInt32(_tbMaximumLineWidth.Text);
            if (_tbMinimumLineLength.Text != "")
               _LineRemoveCommand.MinimumLineLength = Convert.ToInt32(_tbMinimumLineLength.Text);
            if (_tbVariance.Text != "")
               _LineRemoveCommand.Variance = Convert.ToInt32(_tbVariance.Text);
            if (_tbWallHeight.Text != "")
               _LineRemoveCommand.Wall = Convert.ToInt32(_tbWallHeight.Text);
         }

         if (_tbMaximumWallPercent.Text != "")
         {
            int nWallPercent = Convert.ToInt32(_tbMaximumWallPercent.Text);
            if (nWallPercent < 0)
               nWallPercent = 0;
            if (nWallPercent > 100)
               nWallPercent = 100;
            _LineRemoveCommand.MaximumWallPercent = nWallPercent;
         }

         if (_rbHorizontalLines.Checked)
            _LineRemoveCommand.Type = LineRemoveCommandType.Horizontal;
         else
            _LineRemoveCommand.Type = LineRemoveCommandType.Vertical;
      }

      private void _cbUseDPI_CheckedChanged(object sender, EventArgs e)
      {
         if (_cbUseDPI.Checked)
         {
            // Converts the used unit to inches
            ConvertToInches();
            _lbl5.Text = _lbl6.Text = _lbl7.Text = _lbl8.Text = _lbl9.Text = "inches";
         }
         else
         {
            //Converts the used unit to pixels
            ConvertToPixels();
            _lbl5.Text = _lbl6.Text = _lbl7.Text = _lbl8.Text = _lbl9.Text = "pixels";
         }
      }

      private void _cbLineVariance_CheckedChanged(object sender, EventArgs e)
      {
         _tbVariance.Enabled = _cbLineVariance.Checked;
      }

      private void _cbMaximumGap_CheckedChanged(object sender, EventArgs e)
      {
         _tbGapLength.Enabled = _cbMaximumGap.Checked;
      }
      private void ConvertToInches()
      {
         if (_tbVariance.Text != "")
            _Variance = Convert.ToDouble(_tbVariance.Text) / this.XResolution;
         if (_tbGapLength.Text != "")
            _GapLength = Convert.ToDouble(_tbGapLength.Text) / this.XResolution;
         if (_tbMinimumLineLength.Text != "")
            _MinimumLineLength = Convert.ToDouble(_tbMinimumLineLength.Text) / this.XResolution;
         if (_tbMaximumLineWidth.Text != "")
            _MaximumLineWidth = Convert.ToDouble(_tbMaximumLineWidth.Text) / this.XResolution;
         if (_tbWallHeight.Text != "")
            _WallHeight = Convert.ToDouble(_tbWallHeight.Text) / this.XResolution;

         _tbVariance.Text = _Variance.ToString();
         _tbGapLength.Text = _GapLength.ToString();
         _tbMaximumLineWidth.Text = _MaximumLineWidth.ToString();
         _tbMinimumLineLength.Text = _MinimumLineLength.ToString();
         _tbWallHeight.Text = _WallHeight.ToString();
      }
      private void ConvertToPixels()
      {
         _tbVariance.Text = Convert.ToInt32((this.XResolution * _Variance)).ToString();
         _tbGapLength.Text = Convert.ToInt32((this.XResolution * _GapLength)).ToString();
         _tbMinimumLineLength.Text = Convert.ToInt32((this.XResolution * _MinimumLineLength)).ToString();
         _tbMaximumLineWidth.Text = Convert.ToInt32((this.XResolution * _MaximumLineWidth)).ToString();
         _tbWallHeight.Text = Convert.ToInt32((this.XResolution * _WallHeight)).ToString();
      }

      private void _tbMinimumLineLength_TextChanged(object sender, EventArgs e)
      {
         _tbMinimumLineLength.Text = MainForm.IsValidNumber(_tbMinimumLineLength.Text, 0, 10000);

      }

      private void _tbMaximumLineWidth_TextChanged(object sender, EventArgs e)
      {
         _tbMaximumLineWidth.Text = MainForm.IsValidNumber(_tbMaximumLineWidth.Text, 0, 10000);

      }

      private void _tbWallHeight_TextChanged(object sender, EventArgs e)
      {
         _tbWallHeight.Text = MainForm.IsValidNumber(_tbWallHeight.Text, 0, 10000);

      }

      private void _tbMaximumWallPercent_TextChanged(object sender, EventArgs e)
      {
         _tbMaximumWallPercent.Text = MainForm.IsValidNumber(_tbMaximumWallPercent.Text, 0, 100);

      }

      private void _tbVariance_TextChanged(object sender, EventArgs e)
      {
         _tbVariance.Text = MainForm.IsValidNumber(_tbVariance.Text, 0, 10000);
      }

      private void _tbGapLength_TextChanged(object sender, EventArgs e)
      {
         _tbGapLength.Text = MainForm.IsValidNumber(_tbGapLength.Text, 0, 10000);
      }
   }
}
