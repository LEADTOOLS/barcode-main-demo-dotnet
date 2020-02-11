namespace BarcodeMainDemo.BarcodeControls
{
   partial class ReadBarcodeExtraDialogBox
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReadBarcodeExtraDialogBox));
         this._okButton = new System.Windows.Forms.Button();
         this._cancelButton = new System.Windows.Forms.Button();
         this._titleLabel = new System.Windows.Forms.Label();
         this._allSymbologiesCheckBox = new System.Windows.Forms.CheckBox();
         this._allSymbologiesLabel = new System.Windows.Forms.Label();
         this._directionLabel = new System.Windows.Forms.Label();
         this._directionCheckBox = new System.Windows.Forms.CheckBox();
         this.label1 = new System.Windows.Forms.Label();
         this._doublePassCheckBox = new System.Windows.Forms.CheckBox();
         this.label2 = new System.Windows.Forms.Label();
         this._imagePreprocessingCheckBox = new System.Windows.Forms.CheckBox();
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
         // _titleLabel
         // 
         resources.ApplyResources(this._titleLabel, "_titleLabel");
         this._titleLabel.Name = "_titleLabel";
         // 
         // _allSymbologiesCheckBox
         // 
         resources.ApplyResources(this._allSymbologiesCheckBox, "_allSymbologiesCheckBox");
         this._allSymbologiesCheckBox.Name = "_allSymbologiesCheckBox";
         this._allSymbologiesCheckBox.UseVisualStyleBackColor = true;
         // 
         // _allSymbologiesLabel
         // 
         resources.ApplyResources(this._allSymbologiesLabel, "_allSymbologiesLabel");
         this._allSymbologiesLabel.Name = "_allSymbologiesLabel";
         // 
         // _directionLabel
         // 
         resources.ApplyResources(this._directionLabel, "_directionLabel");
         this._directionLabel.Name = "_directionLabel";
         // 
         // _directionCheckBox
         // 
         resources.ApplyResources(this._directionCheckBox, "_directionCheckBox");
         this._directionCheckBox.Name = "_directionCheckBox";
         this._directionCheckBox.UseVisualStyleBackColor = true;
         // 
         // label1
         // 
         resources.ApplyResources(this.label1, "label1");
         this.label1.Name = "label1";
         // 
         // _doublePassCheckBox
         // 
         resources.ApplyResources(this._doublePassCheckBox, "_doublePassCheckBox");
         this._doublePassCheckBox.Name = "_doublePassCheckBox";
         this._doublePassCheckBox.UseVisualStyleBackColor = true;
         // 
         // label2
         // 
         resources.ApplyResources(this.label2, "label2");
         this.label2.Name = "label2";
         // 
         // _imagePreprocessingCheckBox
         // 
         resources.ApplyResources(this._imagePreprocessingCheckBox, "_imagePreprocessingCheckBox");
         this._imagePreprocessingCheckBox.Name = "_imagePreprocessingCheckBox";
         this._imagePreprocessingCheckBox.UseVisualStyleBackColor = true;
         // 
         // ReadBarcodeExtraDialogBox
         // 
         this.AcceptButton = this._okButton;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._cancelButton;
         this.Controls.Add(this.label2);
         this.Controls.Add(this._imagePreprocessingCheckBox);
         this.Controls.Add(this.label1);
         this.Controls.Add(this._doublePassCheckBox);
         this.Controls.Add(this._directionLabel);
         this.Controls.Add(this._directionCheckBox);
         this.Controls.Add(this._allSymbologiesLabel);
         this.Controls.Add(this._allSymbologiesCheckBox);
         this.Controls.Add(this._titleLabel);
         this.Controls.Add(this._cancelButton);
         this.Controls.Add(this._okButton);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ReadBarcodeExtraDialogBox";
         this.ShowInTaskbar = false;
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button _okButton;
      private System.Windows.Forms.Button _cancelButton;
      private System.Windows.Forms.Label _titleLabel;
      private System.Windows.Forms.CheckBox _allSymbologiesCheckBox;
      private System.Windows.Forms.Label _allSymbologiesLabel;
      private System.Windows.Forms.Label _directionLabel;
      private System.Windows.Forms.CheckBox _directionCheckBox;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.CheckBox _doublePassCheckBox;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.CheckBox _imagePreprocessingCheckBox;
   }
}