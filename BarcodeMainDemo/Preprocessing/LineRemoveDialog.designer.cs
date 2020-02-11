namespace BarcodeMainDemo
{
   partial class LineRemoveDialog
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LineRemoveDialog));
         this._gb1 = new System.Windows.Forms.GroupBox();
         this._tbDPI = new System.Windows.Forms.TextBox();
         this._cbUseDPI = new System.Windows.Forms.CheckBox();
         this._gb2 = new System.Windows.Forms.GroupBox();
         this._rbVerticalLines = new System.Windows.Forms.RadioButton();
         this._rbHorizontalLines = new System.Windows.Forms.RadioButton();
         this._gb3 = new System.Windows.Forms.GroupBox();
         this._lbl7 = new System.Windows.Forms.Label();
         this._lbl6 = new System.Windows.Forms.Label();
         this._lbl5 = new System.Windows.Forms.Label();
         this._tbMaximumWallPercent = new System.Windows.Forms.TextBox();
         this._lblMaxWallPercent = new System.Windows.Forms.Label();
         this._tbWallHeight = new System.Windows.Forms.TextBox();
         this._lblWallHeight = new System.Windows.Forms.Label();
         this._tbMaximumLineWidth = new System.Windows.Forms.TextBox();
         this._lblMaximumWidth = new System.Windows.Forms.Label();
         this._tbMinimumLineLength = new System.Windows.Forms.TextBox();
         this._lblMinimumLength = new System.Windows.Forms.Label();
         this._gb4 = new System.Windows.Forms.GroupBox();
         this._lbl9 = new System.Windows.Forms.Label();
         this._lbl8 = new System.Windows.Forms.Label();
         this._tbGapLength = new System.Windows.Forms.TextBox();
         this._tbVariance = new System.Windows.Forms.TextBox();
         this._cbRemoveEntireLine = new System.Windows.Forms.CheckBox();
         this._cbMaximumGap = new System.Windows.Forms.CheckBox();
         this._cbLineVariance = new System.Windows.Forms.CheckBox();
         this._btnOk = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._gb1.SuspendLayout();
         this._gb2.SuspendLayout();
         this._gb3.SuspendLayout();
         this._gb4.SuspendLayout();
         this.SuspendLayout();
         // 
         // _gb1
         // 
         this._gb1.Controls.Add(this._tbDPI);
         this._gb1.Controls.Add(this._cbUseDPI);
         resources.ApplyResources(this._gb1, "_gb1");
         this._gb1.Name = "_gb1";
         this._gb1.TabStop = false;
         // 
         // _tbDPI
         // 
         resources.ApplyResources(this._tbDPI, "_tbDPI");
         this._tbDPI.Name = "_tbDPI";
         // 
         // _cbUseDPI
         // 
         resources.ApplyResources(this._cbUseDPI, "_cbUseDPI");
         this._cbUseDPI.Name = "_cbUseDPI";
         this._cbUseDPI.UseVisualStyleBackColor = true;
         // 
         // _gb2
         // 
         this._gb2.Controls.Add(this._rbVerticalLines);
         this._gb2.Controls.Add(this._rbHorizontalLines);
         resources.ApplyResources(this._gb2, "_gb2");
         this._gb2.Name = "_gb2";
         this._gb2.TabStop = false;
         // 
         // _rbVerticalLines
         // 
         resources.ApplyResources(this._rbVerticalLines, "_rbVerticalLines");
         this._rbVerticalLines.Name = "_rbVerticalLines";
         this._rbVerticalLines.TabStop = true;
         this._rbVerticalLines.UseVisualStyleBackColor = true;
         // 
         // _rbHorizontalLines
         // 
         resources.ApplyResources(this._rbHorizontalLines, "_rbHorizontalLines");
         this._rbHorizontalLines.Name = "_rbHorizontalLines";
         this._rbHorizontalLines.TabStop = true;
         this._rbHorizontalLines.UseVisualStyleBackColor = true;
         // 
         // _gb3
         // 
         this._gb3.Controls.Add(this._lbl7);
         this._gb3.Controls.Add(this._lbl6);
         this._gb3.Controls.Add(this._lbl5);
         this._gb3.Controls.Add(this._tbMaximumWallPercent);
         this._gb3.Controls.Add(this._lblMaxWallPercent);
         this._gb3.Controls.Add(this._tbWallHeight);
         this._gb3.Controls.Add(this._lblWallHeight);
         this._gb3.Controls.Add(this._tbMaximumLineWidth);
         this._gb3.Controls.Add(this._lblMaximumWidth);
         this._gb3.Controls.Add(this._tbMinimumLineLength);
         this._gb3.Controls.Add(this._lblMinimumLength);
         resources.ApplyResources(this._gb3, "_gb3");
         this._gb3.Name = "_gb3";
         this._gb3.TabStop = false;
         // 
         // _lbl7
         // 
         resources.ApplyResources(this._lbl7, "_lbl7");
         this._lbl7.Name = "_lbl7";
         // 
         // _lbl6
         // 
         resources.ApplyResources(this._lbl6, "_lbl6");
         this._lbl6.Name = "_lbl6";
         // 
         // _lbl5
         // 
         resources.ApplyResources(this._lbl5, "_lbl5");
         this._lbl5.Name = "_lbl5";
         // 
         // _tbMaximumWallPercent
         // 
         resources.ApplyResources(this._tbMaximumWallPercent, "_tbMaximumWallPercent");
         this._tbMaximumWallPercent.Name = "_tbMaximumWallPercent";
         this._tbMaximumWallPercent.TextChanged += new System.EventHandler(this._tbMaximumWallPercent_TextChanged);
         // 
         // _lblMaxWallPercent
         // 
         resources.ApplyResources(this._lblMaxWallPercent, "_lblMaxWallPercent");
         this._lblMaxWallPercent.Name = "_lblMaxWallPercent";
         // 
         // _tbWallHeight
         // 
         resources.ApplyResources(this._tbWallHeight, "_tbWallHeight");
         this._tbWallHeight.Name = "_tbWallHeight";
         this._tbWallHeight.TextChanged += new System.EventHandler(this._tbWallHeight_TextChanged);
         // 
         // _lblWallHeight
         // 
         resources.ApplyResources(this._lblWallHeight, "_lblWallHeight");
         this._lblWallHeight.Name = "_lblWallHeight";
         // 
         // _tbMaximumLineWidth
         // 
         resources.ApplyResources(this._tbMaximumLineWidth, "_tbMaximumLineWidth");
         this._tbMaximumLineWidth.Name = "_tbMaximumLineWidth";
         this._tbMaximumLineWidth.TextChanged += new System.EventHandler(this._tbMaximumLineWidth_TextChanged);
         // 
         // _lblMaximumWidth
         // 
         resources.ApplyResources(this._lblMaximumWidth, "_lblMaximumWidth");
         this._lblMaximumWidth.Name = "_lblMaximumWidth";
         // 
         // _tbMinimumLineLength
         // 
         resources.ApplyResources(this._tbMinimumLineLength, "_tbMinimumLineLength");
         this._tbMinimumLineLength.Name = "_tbMinimumLineLength";
         this._tbMinimumLineLength.TextChanged += new System.EventHandler(this._tbMinimumLineLength_TextChanged);
         // 
         // _lblMinimumLength
         // 
         resources.ApplyResources(this._lblMinimumLength, "_lblMinimumLength");
         this._lblMinimumLength.Name = "_lblMinimumLength";
         // 
         // _gb4
         // 
         this._gb4.Controls.Add(this._lbl9);
         this._gb4.Controls.Add(this._lbl8);
         this._gb4.Controls.Add(this._tbGapLength);
         this._gb4.Controls.Add(this._tbVariance);
         this._gb4.Controls.Add(this._cbRemoveEntireLine);
         this._gb4.Controls.Add(this._cbMaximumGap);
         this._gb4.Controls.Add(this._cbLineVariance);
         resources.ApplyResources(this._gb4, "_gb4");
         this._gb4.Name = "_gb4";
         this._gb4.TabStop = false;
         // 
         // _lbl9
         // 
         resources.ApplyResources(this._lbl9, "_lbl9");
         this._lbl9.Name = "_lbl9";
         // 
         // _lbl8
         // 
         resources.ApplyResources(this._lbl8, "_lbl8");
         this._lbl8.Name = "_lbl8";
         // 
         // _tbGapLength
         // 
         resources.ApplyResources(this._tbGapLength, "_tbGapLength");
         this._tbGapLength.Name = "_tbGapLength";
         this._tbGapLength.TextChanged += new System.EventHandler(this._tbGapLength_TextChanged);
         // 
         // _tbVariance
         // 
         resources.ApplyResources(this._tbVariance, "_tbVariance");
         this._tbVariance.Name = "_tbVariance";
         this._tbVariance.TextChanged += new System.EventHandler(this._tbVariance_TextChanged);
         // 
         // _cbRemoveEntireLine
         // 
         resources.ApplyResources(this._cbRemoveEntireLine, "_cbRemoveEntireLine");
         this._cbRemoveEntireLine.Name = "_cbRemoveEntireLine";
         this._cbRemoveEntireLine.UseVisualStyleBackColor = true;
         // 
         // _cbMaximumGap
         // 
         resources.ApplyResources(this._cbMaximumGap, "_cbMaximumGap");
         this._cbMaximumGap.Name = "_cbMaximumGap";
         this._cbMaximumGap.UseVisualStyleBackColor = true;
         this._cbMaximumGap.CheckedChanged += new System.EventHandler(this._cbMaximumGap_CheckedChanged);
         // 
         // _cbLineVariance
         // 
         resources.ApplyResources(this._cbLineVariance, "_cbLineVariance");
         this._cbLineVariance.Name = "_cbLineVariance";
         this._cbLineVariance.UseVisualStyleBackColor = true;
         this._cbLineVariance.CheckedChanged += new System.EventHandler(this._cbLineVariance_CheckedChanged);
         // 
         // _btnOk
         // 
         resources.ApplyResources(this._btnOk, "_btnOk");
         this._btnOk.Name = "_btnOk";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         resources.ApplyResources(this._btnCancel, "_btnCancel");
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // LineRemoveDialog
         // 
         this.AcceptButton = this._btnOk;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._gb2);
         this.Controls.Add(this._gb3);
         this.Controls.Add(this._gb4);
         this.Controls.Add(this._gb1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "LineRemoveDialog";
         this._gb1.ResumeLayout(false);
         this._gb1.PerformLayout();
         this._gb2.ResumeLayout(false);
         this._gb2.PerformLayout();
         this._gb3.ResumeLayout(false);
         this._gb3.PerformLayout();
         this._gb4.ResumeLayout(false);
         this._gb4.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gb1;
      private System.Windows.Forms.CheckBox _cbUseDPI;
      private System.Windows.Forms.GroupBox _gb2;
      private System.Windows.Forms.RadioButton _rbVerticalLines;
      private System.Windows.Forms.RadioButton _rbHorizontalLines;
      private System.Windows.Forms.GroupBox _gb3;
      private System.Windows.Forms.Label _lbl7;
      private System.Windows.Forms.Label _lbl6;
      private System.Windows.Forms.Label _lbl5;
      private System.Windows.Forms.TextBox _tbMaximumWallPercent;
      private System.Windows.Forms.Label _lblMaxWallPercent;
      private System.Windows.Forms.TextBox _tbWallHeight;
      private System.Windows.Forms.Label _lblWallHeight;
      private System.Windows.Forms.TextBox _tbMaximumLineWidth;
      private System.Windows.Forms.Label _lblMaximumWidth;
      private System.Windows.Forms.TextBox _tbMinimumLineLength;
      private System.Windows.Forms.Label _lblMinimumLength;
      private System.Windows.Forms.GroupBox _gb4;
      private System.Windows.Forms.Label _lbl9;
      private System.Windows.Forms.Label _lbl8;
      private System.Windows.Forms.TextBox _tbGapLength;
      private System.Windows.Forms.TextBox _tbVariance;
      private System.Windows.Forms.CheckBox _cbRemoveEntireLine;
      private System.Windows.Forms.CheckBox _cbMaximumGap;
      private System.Windows.Forms.CheckBox _cbLineVariance;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.TextBox _tbDPI;
   }
}