namespace BarcodeMainDemo.BarcodeControls
{
   partial class AAMVADialogBox
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
         this._listViewRawDataElements = new System.Windows.Forms.ListView();
         this._dataElementsLabel = new System.Windows.Forms.Label();
         this._listViewCommonFields = new System.Windows.Forms.ListView();
         this._commonFieldsLabel = new System.Windows.Forms.Label();
         this._btnCloseAAMVA = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // _listViewRawDataElements
         // 
         this._listViewRawDataElements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._listViewRawDataElements.Location = new System.Drawing.Point(12, 266);
         this._listViewRawDataElements.Name = "_listViewRawDataElements";
         this._listViewRawDataElements.Size = new System.Drawing.Size(760, 231);
         this._listViewRawDataElements.TabIndex = 0;
         this._listViewRawDataElements.UseCompatibleStateImageBehavior = false;
         // 
         // _dataElementsLabel
         // 
         this._dataElementsLabel.AutoSize = true;
         this._dataElementsLabel.Location = new System.Drawing.Point(12, 250);
         this._dataElementsLabel.Name = "_dataElementsLabel";
         this._dataElementsLabel.Size = new System.Drawing.Size(101, 13);
         this._dataElementsLabel.TabIndex = 1;
         this._dataElementsLabel.Text = "Raw Data Elements";
         // 
         // _listViewCommonFields
         // 
         this._listViewCommonFields.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._listViewCommonFields.Location = new System.Drawing.Point(12, 25);
         this._listViewCommonFields.Name = "_listViewCommonFields";
         this._listViewCommonFields.Size = new System.Drawing.Size(757, 197);
         this._listViewCommonFields.TabIndex = 2;
         this._listViewCommonFields.UseCompatibleStateImageBehavior = false;
         // 
         // _commonFieldsLabel
         // 
         this._commonFieldsLabel.AutoSize = true;
         this._commonFieldsLabel.Location = new System.Drawing.Point(12, 9);
         this._commonFieldsLabel.Name = "_commonFieldsLabel";
         this._commonFieldsLabel.Size = new System.Drawing.Size(78, 13);
         this._commonFieldsLabel.TabIndex = 3;
         this._commonFieldsLabel.Text = "Common Fields";
         // 
         // _btnCloseAAMVA
         // 
         this._btnCloseAAMVA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this._btnCloseAAMVA.Location = new System.Drawing.Point(697, 526);
         this._btnCloseAAMVA.Name = "_btnCloseAAMVA";
         this._btnCloseAAMVA.Size = new System.Drawing.Size(75, 23);
         this._btnCloseAAMVA.TabIndex = 4;
         this._btnCloseAAMVA.Text = "Close";
         this._btnCloseAAMVA.UseVisualStyleBackColor = true;
         this._btnCloseAAMVA.Click += new System.EventHandler(this._btnCloseAAMVA_Click);
         // 
         // AAMVADialogBox
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(784, 561);
         this.Controls.Add(this._btnCloseAAMVA);
         this.Controls.Add(this._commonFieldsLabel);
         this.Controls.Add(this._listViewCommonFields);
         this.Controls.Add(this._dataElementsLabel);
         this.Controls.Add(this._listViewRawDataElements);
         this.MinimumSize = new System.Drawing.Size(800, 600);
         this.Name = "AAMVADialogBox";
         this.ShowIcon = false;
         this.Text = "AAMVA ID Data";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ListView _listViewRawDataElements;
      private System.Windows.Forms.Label _dataElementsLabel;
      private System.Windows.Forms.ListView _listViewCommonFields;
      private System.Windows.Forms.Label _commonFieldsLabel;
      private System.Windows.Forms.Button _btnCloseAAMVA;
   }
}