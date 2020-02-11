namespace BarcodeMainDemo.BarcodeControls
{
   partial class ReadBarcodesDialogBox
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReadBarcodesDialogBox));
          this._stopButton = new System.Windows.Forms.Button();
          this._messageLabel = new System.Windows.Forms.Label();
          this._infoLabel = new System.Windows.Forms.Label();
          this._showReadOptionsDialogCheckBox = new System.Windows.Forms.CheckBox();
          this._barcodesGroupBox = new System.Windows.Forms.GroupBox();
          this._barcodesListView = new System.Windows.Forms.ListView();
          this._pageColumnHeader = new System.Windows.Forms.ColumnHeader();
          this._symbologyColumnHeader = new System.Windows.Forms.ColumnHeader();
          this._valueColumnHeader = new System.Windows.Forms.ColumnHeader();
          this._locationColumnHeader = new System.Windows.Forms.ColumnHeader();
          this._retryLinkLabel = new System.Windows.Forms.LinkLabel();
          this._barcodesGroupBox.SuspendLayout();
          this.SuspendLayout();
          // 
          // _stopButton
          // 
          resources.ApplyResources(this._stopButton, "_stopButton");
          this._stopButton.Name = "_stopButton";
          this._stopButton.UseVisualStyleBackColor = true;
          this._stopButton.Click += new System.EventHandler(this._stopButton_Click);
          // 
          // _messageLabel
          // 
          resources.ApplyResources(this._messageLabel, "_messageLabel");
          this._messageLabel.Name = "_messageLabel";
          // 
          // _infoLabel
          // 
          resources.ApplyResources(this._infoLabel, "_infoLabel");
          this._infoLabel.Name = "_infoLabel";
          // 
          // _showReadOptionsDialogCheckBox
          // 
          resources.ApplyResources(this._showReadOptionsDialogCheckBox, "_showReadOptionsDialogCheckBox");
          this._showReadOptionsDialogCheckBox.Checked = true;
          this._showReadOptionsDialogCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
          this._showReadOptionsDialogCheckBox.Name = "_showReadOptionsDialogCheckBox";
          this._showReadOptionsDialogCheckBox.UseVisualStyleBackColor = true;
          // 
          // _barcodesGroupBox
          // 
          resources.ApplyResources(this._barcodesGroupBox, "_barcodesGroupBox");
          this._barcodesGroupBox.BackColor = System.Drawing.SystemColors.Control;
          this._barcodesGroupBox.Controls.Add(this._barcodesListView);
          this._barcodesGroupBox.Name = "_barcodesGroupBox";
          this._barcodesGroupBox.TabStop = false;
          // 
          // _barcodesListView
          // 
          this._barcodesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._pageColumnHeader,
            this._symbologyColumnHeader,
            this._valueColumnHeader,
            this._locationColumnHeader});
          resources.ApplyResources(this._barcodesListView, "_barcodesListView");
          this._barcodesListView.FullRowSelect = true;
          this._barcodesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
          this._barcodesListView.Name = "_barcodesListView";
          this._barcodesListView.UseCompatibleStateImageBehavior = false;
          this._barcodesListView.View = System.Windows.Forms.View.Details;
          // 
          // _pageColumnHeader
          // 
          resources.ApplyResources(this._pageColumnHeader, "_pageColumnHeader");
          // 
          // _symbologyColumnHeader
          // 
          resources.ApplyResources(this._symbologyColumnHeader, "_symbologyColumnHeader");
          // 
          // _valueColumnHeader
          // 
          resources.ApplyResources(this._valueColumnHeader, "_valueColumnHeader");
          // 
          // _locationColumnHeader
          // 
          resources.ApplyResources(this._locationColumnHeader, "_locationColumnHeader");
          // 
          // _retryLinkLabel
          // 
          resources.ApplyResources(this._retryLinkLabel, "_retryLinkLabel");
          this._retryLinkLabel.Name = "_retryLinkLabel";
          this._retryLinkLabel.TabStop = true;
          this._retryLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._retryLinkLabel_LinkClicked);
          // 
          // ReadBarcodesDialogBox
          // 
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.Controls.Add(this._retryLinkLabel);
          this.Controls.Add(this._barcodesGroupBox);
          this.Controls.Add(this._showReadOptionsDialogCheckBox);
          this.Controls.Add(this._infoLabel);
          this.Controls.Add(this._messageLabel);
          this.Controls.Add(this._stopButton);
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "ReadBarcodesDialogBox";
          this.ShowIcon = false;
          this.ShowInTaskbar = false;
          this._barcodesGroupBox.ResumeLayout(false);
          this.ResumeLayout(false);
          this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button _stopButton;
      private System.Windows.Forms.Label _messageLabel;
      private System.Windows.Forms.Label _infoLabel;
      private System.Windows.Forms.CheckBox _showReadOptionsDialogCheckBox;
      private System.Windows.Forms.GroupBox _barcodesGroupBox;
      private System.Windows.Forms.ListView _barcodesListView;
      private System.Windows.Forms.ColumnHeader _pageColumnHeader;
      private System.Windows.Forms.ColumnHeader _symbologyColumnHeader;
      private System.Windows.Forms.ColumnHeader _valueColumnHeader;
      private System.Windows.Forms.ColumnHeader _locationColumnHeader;
      private System.Windows.Forms.LinkLabel _retryLinkLabel;
   }
}