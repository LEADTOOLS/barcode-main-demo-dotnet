namespace BarcodeMainDemo.BarcodeControls
{
   partial class BarcodeControl
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BarcodeControl));
         this._titleGroupBox = new System.Windows.Forms.GroupBox();
         this._barcodesListView = new System.Windows.Forms.ListView();
         this._symbologyColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._locationColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._valueColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._bottomPanel = new System.Windows.Forms.Panel();
         this._aamvaButton = new System.Windows.Forms.Button();
         this._zoomToButton = new System.Windows.Forms.Button();
         this._deleteButton = new System.Windows.Forms.Button();
         this._titleGroupBox.SuspendLayout();
         this._bottomPanel.SuspendLayout();
         this.SuspendLayout();
         // 
         // _titleGroupBox
         // 
         this._titleGroupBox.Controls.Add(this._barcodesListView);
         this._titleGroupBox.Controls.Add(this._bottomPanel);
         resources.ApplyResources(this._titleGroupBox, "_titleGroupBox");
         this._titleGroupBox.Name = "_titleGroupBox";
         this._titleGroupBox.TabStop = false;
         // 
         // _barcodesListView
         // 
         this._barcodesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._symbologyColumnHeader,
            this._locationColumnHeader,
            this._valueColumnHeader});
         resources.ApplyResources(this._barcodesListView, "_barcodesListView");
         this._barcodesListView.FullRowSelect = true;
         this._barcodesListView.HideSelection = false;
         this._barcodesListView.MultiSelect = false;
         this._barcodesListView.Name = "_barcodesListView";
         this._barcodesListView.UseCompatibleStateImageBehavior = false;
         this._barcodesListView.View = System.Windows.Forms.View.Details;
         this._barcodesListView.SelectedIndexChanged += new System.EventHandler(this._barcodesListView_SelectedIndexChanged);
         this._barcodesListView.DoubleClick += new System.EventHandler(this._barcodesListView_DoubleClick);
         // 
         // _symbologyColumnHeader
         // 
         resources.ApplyResources(this._symbologyColumnHeader, "_symbologyColumnHeader");
         // 
         // _locationColumnHeader
         // 
         resources.ApplyResources(this._locationColumnHeader, "_locationColumnHeader");
         // 
         // _valueColumnHeader
         // 
         resources.ApplyResources(this._valueColumnHeader, "_valueColumnHeader");
         // 
         // _bottomPanel
         // 
         this._bottomPanel.Controls.Add(this._aamvaButton);
         this._bottomPanel.Controls.Add(this._zoomToButton);
         this._bottomPanel.Controls.Add(this._deleteButton);
         resources.ApplyResources(this._bottomPanel, "_bottomPanel");
         this._bottomPanel.Name = "_bottomPanel";
         // 
         // _aamvaButton
         // 
         resources.ApplyResources(this._aamvaButton, "_aamvaButton");
         this._aamvaButton.Name = "_aamvaButton";
         this._aamvaButton.UseVisualStyleBackColor = true;
         this._aamvaButton.Click += new System.EventHandler(this._aamvaButton_Click);
         // 
         // _zoomToButton
         // 
         resources.ApplyResources(this._zoomToButton, "_zoomToButton");
         this._zoomToButton.Name = "_zoomToButton";
         this._zoomToButton.UseVisualStyleBackColor = true;
         this._zoomToButton.Click += new System.EventHandler(this._zoomToButton_Click);
         // 
         // _deleteButton
         // 
         resources.ApplyResources(this._deleteButton, "_deleteButton");
         this._deleteButton.Name = "_deleteButton";
         this._deleteButton.UseVisualStyleBackColor = true;
         this._deleteButton.Click += new System.EventHandler(this._deleteButton_Click);
         // 
         // BarcodeControl
         // 
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._titleGroupBox);
         this.Name = "BarcodeControl";
         this._titleGroupBox.ResumeLayout(false);
         this._bottomPanel.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _titleGroupBox;
      private System.Windows.Forms.Panel _bottomPanel;
      private System.Windows.Forms.Button _deleteButton;
      private System.Windows.Forms.ListView _barcodesListView;
      private System.Windows.Forms.ColumnHeader _symbologyColumnHeader;
      private System.Windows.Forms.ColumnHeader _locationColumnHeader;
      private System.Windows.Forms.ColumnHeader _valueColumnHeader;
      private System.Windows.Forms.Button _zoomToButton;
      private System.Windows.Forms.Button _aamvaButton;
   }
}
