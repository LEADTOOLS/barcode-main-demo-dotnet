namespace BarcodeMainDemo
{
   partial class GotoPageDialog
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GotoPageDialog));
          this._okButton = new System.Windows.Forms.Button();
          this._cancelButton = new System.Windows.Forms.Button();
          this._pageLabel = new System.Windows.Forms.Label();
          this._pageGroupBox = new System.Windows.Forms.GroupBox();
          this._pageCountLabel = new System.Windows.Forms.Label();
          this._pageNumericUpDown = new System.Windows.Forms.NumericUpDown();
          this._pageGroupBox.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this._pageNumericUpDown)).BeginInit();
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
          // _pageLabel
          // 
          resources.ApplyResources(this._pageLabel, "_pageLabel");
          this._pageLabel.Name = "_pageLabel";
          // 
          // _pageGroupBox
          // 
          this._pageGroupBox.Controls.Add(this._pageCountLabel);
          this._pageGroupBox.Controls.Add(this._pageNumericUpDown);
          this._pageGroupBox.Controls.Add(this._pageLabel);
          resources.ApplyResources(this._pageGroupBox, "_pageGroupBox");
          this._pageGroupBox.Name = "_pageGroupBox";
          this._pageGroupBox.TabStop = false;
          // 
          // _pageCountLabel
          // 
          resources.ApplyResources(this._pageCountLabel, "_pageCountLabel");
          this._pageCountLabel.Name = "_pageCountLabel";
          // 
          // _pageNumericUpDown
          // 
          resources.ApplyResources(this._pageNumericUpDown, "_pageNumericUpDown");
          this._pageNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
          this._pageNumericUpDown.Name = "_pageNumericUpDown";
          this._pageNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
          // 
          // GotoPageDialog
          // 
          this.AcceptButton = this._okButton;
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._cancelButton;
          this.Controls.Add(this._pageGroupBox);
          this.Controls.Add(this._cancelButton);
          this.Controls.Add(this._okButton);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "GotoPageDialog";
          this.ShowInTaskbar = false;
          this._pageGroupBox.ResumeLayout(false);
          this._pageGroupBox.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this._pageNumericUpDown)).EndInit();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _okButton;
      private System.Windows.Forms.Button _cancelButton;
      private System.Windows.Forms.Label _pageLabel;
      private System.Windows.Forms.GroupBox _pageGroupBox;
      private System.Windows.Forms.Label _pageCountLabel;
      private System.Windows.Forms.NumericUpDown _pageNumericUpDown;
   }
}