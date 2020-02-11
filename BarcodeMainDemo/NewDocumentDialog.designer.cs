namespace BarcodeMainDemo
{
   partial class NewDocumentDialog
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
         if(disposing && (components != null))
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewDocumentDialog));
          this._okButton = new System.Windows.Forms.Button();
          this._cancelButton = new System.Windows.Forms.Button();
          this._sizeGroupBox = new System.Windows.Forms.GroupBox();
          this._resolutionComboBox = new System.Windows.Forms.ComboBox();
          this._resolutionLabel = new System.Windows.Forms.Label();
          this._heightTextBox = new System.Windows.Forms.TextBox();
          this._heightLabel = new System.Windows.Forms.Label();
          this._widthTextBox = new System.Windows.Forms.TextBox();
          this._widthLabel = new System.Windows.Forms.Label();
          this._pagesGroupBox = new System.Windows.Forms.GroupBox();
          this._pagesNumericUpDown = new System.Windows.Forms.NumericUpDown();
          this._bitsPerPixelGroupBox = new System.Windows.Forms.GroupBox();
          this._bitsPerPixelComboBox = new System.Windows.Forms.ComboBox();
          this._sizeGroupBox.SuspendLayout();
          this._pagesGroupBox.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this._pagesNumericUpDown)).BeginInit();
          this._bitsPerPixelGroupBox.SuspendLayout();
          this.SuspendLayout();
          // 
          // _okButton
          // 
          this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
          resources.ApplyResources(this._okButton, "_okButton");
          this._okButton.Name = "_okButton";
          this._okButton.UseVisualStyleBackColor = true;
          this._okButton.Click += new System.EventHandler(this._okButton_Click);
          // 
          // _cancelButton
          // 
          this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          resources.ApplyResources(this._cancelButton, "_cancelButton");
          this._cancelButton.Name = "_cancelButton";
          this._cancelButton.UseVisualStyleBackColor = true;
          // 
          // _sizeGroupBox
          // 
          this._sizeGroupBox.Controls.Add(this._resolutionComboBox);
          this._sizeGroupBox.Controls.Add(this._resolutionLabel);
          this._sizeGroupBox.Controls.Add(this._heightTextBox);
          this._sizeGroupBox.Controls.Add(this._heightLabel);
          this._sizeGroupBox.Controls.Add(this._widthTextBox);
          this._sizeGroupBox.Controls.Add(this._widthLabel);
          resources.ApplyResources(this._sizeGroupBox, "_sizeGroupBox");
          this._sizeGroupBox.Name = "_sizeGroupBox";
          this._sizeGroupBox.TabStop = false;
          // 
          // _resolutionComboBox
          // 
          this._resolutionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this._resolutionComboBox.FormattingEnabled = true;
          resources.ApplyResources(this._resolutionComboBox, "_resolutionComboBox");
          this._resolutionComboBox.Name = "_resolutionComboBox";
          // 
          // _resolutionLabel
          // 
          resources.ApplyResources(this._resolutionLabel, "_resolutionLabel");
          this._resolutionLabel.Name = "_resolutionLabel";
          // 
          // _heightTextBox
          // 
          resources.ApplyResources(this._heightTextBox, "_heightTextBox");
          this._heightTextBox.Name = "_heightTextBox";
          // 
          // _heightLabel
          // 
          resources.ApplyResources(this._heightLabel, "_heightLabel");
          this._heightLabel.Name = "_heightLabel";
          // 
          // _widthTextBox
          // 
          resources.ApplyResources(this._widthTextBox, "_widthTextBox");
          this._widthTextBox.Name = "_widthTextBox";
          // 
          // _widthLabel
          // 
          resources.ApplyResources(this._widthLabel, "_widthLabel");
          this._widthLabel.Name = "_widthLabel";
          // 
          // _pagesGroupBox
          // 
          this._pagesGroupBox.Controls.Add(this._pagesNumericUpDown);
          resources.ApplyResources(this._pagesGroupBox, "_pagesGroupBox");
          this._pagesGroupBox.Name = "_pagesGroupBox";
          this._pagesGroupBox.TabStop = false;
          // 
          // _pagesNumericUpDown
          // 
          resources.ApplyResources(this._pagesNumericUpDown, "_pagesNumericUpDown");
          this._pagesNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
          this._pagesNumericUpDown.Name = "_pagesNumericUpDown";
          this._pagesNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
          // 
          // _bitsPerPixelGroupBox
          // 
          this._bitsPerPixelGroupBox.Controls.Add(this._bitsPerPixelComboBox);
          resources.ApplyResources(this._bitsPerPixelGroupBox, "_bitsPerPixelGroupBox");
          this._bitsPerPixelGroupBox.Name = "_bitsPerPixelGroupBox";
          this._bitsPerPixelGroupBox.TabStop = false;
          // 
          // _bitsPerPixelComboBox
          // 
          this._bitsPerPixelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this._bitsPerPixelComboBox.FormattingEnabled = true;
          this._bitsPerPixelComboBox.Items.AddRange(new object[] {
            resources.GetString("_bitsPerPixelComboBox.Items"),
            resources.GetString("_bitsPerPixelComboBox.Items1"),
            resources.GetString("_bitsPerPixelComboBox.Items2"),
            resources.GetString("_bitsPerPixelComboBox.Items3")});
          resources.ApplyResources(this._bitsPerPixelComboBox, "_bitsPerPixelComboBox");
          this._bitsPerPixelComboBox.Name = "_bitsPerPixelComboBox";
          // 
          // NewDocumentDialog
          // 
          this.AcceptButton = this._okButton;
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._cancelButton;
          this.Controls.Add(this._bitsPerPixelGroupBox);
          this.Controls.Add(this._pagesGroupBox);
          this.Controls.Add(this._sizeGroupBox);
          this.Controls.Add(this._cancelButton);
          this.Controls.Add(this._okButton);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "NewDocumentDialog";
          this.ShowInTaskbar = false;
          this._sizeGroupBox.ResumeLayout(false);
          this._sizeGroupBox.PerformLayout();
          this._pagesGroupBox.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this._pagesNumericUpDown)).EndInit();
          this._bitsPerPixelGroupBox.ResumeLayout(false);
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _okButton;
      private System.Windows.Forms.Button _cancelButton;
      private System.Windows.Forms.GroupBox _sizeGroupBox;
      private System.Windows.Forms.Label _resolutionLabel;
      private System.Windows.Forms.TextBox _heightTextBox;
      private System.Windows.Forms.Label _heightLabel;
      private System.Windows.Forms.TextBox _widthTextBox;
      private System.Windows.Forms.Label _widthLabel;
      private System.Windows.Forms.GroupBox _pagesGroupBox;
      private System.Windows.Forms.NumericUpDown _pagesNumericUpDown;
      private System.Windows.Forms.GroupBox _bitsPerPixelGroupBox;
      private System.Windows.Forms.ComboBox _bitsPerPixelComboBox;
      private System.Windows.Forms.ComboBox _resolutionComboBox;
   }
}