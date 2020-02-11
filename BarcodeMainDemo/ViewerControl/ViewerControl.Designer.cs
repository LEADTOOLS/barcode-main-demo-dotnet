namespace BarcodeMainDemo.ViewerControl
{
   partial class ViewerControl
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewerControl));
          this._pageInfoLabel = new System.Windows.Forms.Label();
          this._toolStrip = new System.Windows.Forms.ToolStrip();
          this._previousPageToolStripButton = new System.Windows.Forms.ToolStripButton();
          this._nextPageToolStripButton = new System.Windows.Forms.ToolStripButton();
          this._pageToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
          this._pageToolStripLabel = new System.Windows.Forms.ToolStripLabel();
          this._toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
          this._zoomOutToolStripButton = new System.Windows.Forms.ToolStripButton();
          this._zoomInToolStripButton = new System.Windows.Forms.ToolStripButton();
          this._zoomToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
          this._fitPageWidthToolStripButton = new System.Windows.Forms.ToolStripButton();
          this._fitPageToolStripButton = new System.Windows.Forms.ToolStripButton();
          this._toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
          this._selectModeToolStripButton = new System.Windows.Forms.ToolStripButton();
          this._panModeToolStripButton = new System.Windows.Forms.ToolStripButton();
          this._zoomToSelectionModeToolStripButton = new System.Windows.Forms.ToolStripButton();
          this._regionModeToolStripButton = new System.Windows.Forms.ToolStripButton();
          this._deleteRegionToolStripButton = new System.Windows.Forms.ToolStripButton();
          this._readBarcodeModeToolStripButton = new System.Windows.Forms.ToolStripButton();
          this._writeBarcodeModeToolStripButton = new System.Windows.Forms.ToolStripButton();
          this._toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
          this._showBarcodesToolStripButton = new System.Windows.Forms.ToolStripButton();
          this._mousePositionLabel = new System.Windows.Forms.Label();
          this._rasterImageViewer = new Leadtools.Controls.ImageViewer();
          this._toolStrip.SuspendLayout();
          this.SuspendLayout();
          // 
          // _pageInfoLabel
          // 
          resources.ApplyResources(this._pageInfoLabel, "_pageInfoLabel");
          this._pageInfoLabel.Name = "_pageInfoLabel";
          // 
          // _toolStrip
          // 
          this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._previousPageToolStripButton,
            this._nextPageToolStripButton,
            this._pageToolStripTextBox,
            this._pageToolStripLabel,
            this._toolStripSeparator1,
            this._zoomOutToolStripButton,
            this._zoomInToolStripButton,
            this._zoomToolStripComboBox,
            this._fitPageWidthToolStripButton,
            this._fitPageToolStripButton,
            this._toolStripSeparator2,
            this._selectModeToolStripButton,
            this._panModeToolStripButton,
            this._zoomToSelectionModeToolStripButton,
            this._regionModeToolStripButton,
            this._deleteRegionToolStripButton,
            this._readBarcodeModeToolStripButton,
            this._writeBarcodeModeToolStripButton,
            this._toolStripSeparator3,
            this._showBarcodesToolStripButton});
          resources.ApplyResources(this._toolStrip, "_toolStrip");
          this._toolStrip.Name = "_toolStrip";
          // 
          // _previousPageToolStripButton
          // 
          this._previousPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this._previousPageToolStripButton.Image = global::BarcodeMainDemo.Properties.Resources.PreviousPage;
          resources.ApplyResources(this._previousPageToolStripButton, "_previousPageToolStripButton");
          this._previousPageToolStripButton.Name = "_previousPageToolStripButton";
          this._previousPageToolStripButton.Click += new System.EventHandler(this._previousPageToolStripButton_Click);
          // 
          // _nextPageToolStripButton
          // 
          this._nextPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this._nextPageToolStripButton.Image = global::BarcodeMainDemo.Properties.Resources.NextPage;
          resources.ApplyResources(this._nextPageToolStripButton, "_nextPageToolStripButton");
          this._nextPageToolStripButton.Name = "_nextPageToolStripButton";
          this._nextPageToolStripButton.Click += new System.EventHandler(this._nextPageToolStripButton_Click);
          // 
          // _pageToolStripTextBox
          // 
          this._pageToolStripTextBox.Name = "_pageToolStripTextBox";
          resources.ApplyResources(this._pageToolStripTextBox, "_pageToolStripTextBox");
          this._pageToolStripTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._pageToolStripTextBox_KeyPress);
          // 
          // _pageToolStripLabel
          // 
          this._pageToolStripLabel.Name = "_pageToolStripLabel";
          resources.ApplyResources(this._pageToolStripLabel, "_pageToolStripLabel");
          // 
          // _toolStripSeparator1
          // 
          this._toolStripSeparator1.Name = "_toolStripSeparator1";
          resources.ApplyResources(this._toolStripSeparator1, "_toolStripSeparator1");
          // 
          // _zoomOutToolStripButton
          // 
          this._zoomOutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this._zoomOutToolStripButton.Image = global::BarcodeMainDemo.Properties.Resources.ZoomOut;
          resources.ApplyResources(this._zoomOutToolStripButton, "_zoomOutToolStripButton");
          this._zoomOutToolStripButton.Name = "_zoomOutToolStripButton";
          this._zoomOutToolStripButton.Click += new System.EventHandler(this._zoomOutToolStripButton_Click);
          // 
          // _zoomInToolStripButton
          // 
          this._zoomInToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this._zoomInToolStripButton.Image = global::BarcodeMainDemo.Properties.Resources.ZoomIn;
          resources.ApplyResources(this._zoomInToolStripButton, "_zoomInToolStripButton");
          this._zoomInToolStripButton.Name = "_zoomInToolStripButton";
          this._zoomInToolStripButton.Click += new System.EventHandler(this._zoomInToolStripButton_Click);
          // 
          // _zoomToolStripComboBox
          // 
          this._zoomToolStripComboBox.DropDownWidth = 80;
          this._zoomToolStripComboBox.Items.AddRange(new object[] {
            resources.GetString("_zoomToolStripComboBox.Items"),
            resources.GetString("_zoomToolStripComboBox.Items1"),
            resources.GetString("_zoomToolStripComboBox.Items2"),
            resources.GetString("_zoomToolStripComboBox.Items3"),
            resources.GetString("_zoomToolStripComboBox.Items4"),
            resources.GetString("_zoomToolStripComboBox.Items5"),
            resources.GetString("_zoomToolStripComboBox.Items6"),
            resources.GetString("_zoomToolStripComboBox.Items7"),
            resources.GetString("_zoomToolStripComboBox.Items8"),
            resources.GetString("_zoomToolStripComboBox.Items9"),
            resources.GetString("_zoomToolStripComboBox.Items10"),
            resources.GetString("_zoomToolStripComboBox.Items11"),
            resources.GetString("_zoomToolStripComboBox.Items12"),
            resources.GetString("_zoomToolStripComboBox.Items13"),
            resources.GetString("_zoomToolStripComboBox.Items14"),
            resources.GetString("_zoomToolStripComboBox.Items15")});
          this._zoomToolStripComboBox.Name = "_zoomToolStripComboBox";
          resources.ApplyResources(this._zoomToolStripComboBox, "_zoomToolStripComboBox");
          this._zoomToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this._zoomToolStripComboBox_SelectedIndexChanged);
          this._zoomToolStripComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._zoomToolStripComboBox_KeyPress);
          // 
          // _fitPageWidthToolStripButton
          // 
          this._fitPageWidthToolStripButton.CheckOnClick = true;
          this._fitPageWidthToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this._fitPageWidthToolStripButton.Image = global::BarcodeMainDemo.Properties.Resources.FitPageWidth;
          resources.ApplyResources(this._fitPageWidthToolStripButton, "_fitPageWidthToolStripButton");
          this._fitPageWidthToolStripButton.Name = "_fitPageWidthToolStripButton";
          this._fitPageWidthToolStripButton.Click += new System.EventHandler(this._fitPageWidthToolStripButton_Click);
          // 
          // _fitPageToolStripButton
          // 
          this._fitPageToolStripButton.CheckOnClick = true;
          this._fitPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this._fitPageToolStripButton.Image = global::BarcodeMainDemo.Properties.Resources.FitPage;
          resources.ApplyResources(this._fitPageToolStripButton, "_fitPageToolStripButton");
          this._fitPageToolStripButton.Name = "_fitPageToolStripButton";
          this._fitPageToolStripButton.Click += new System.EventHandler(this._fitPageToolStripButton_Click);
          // 
          // _toolStripSeparator2
          // 
          this._toolStripSeparator2.Name = "_toolStripSeparator2";
          resources.ApplyResources(this._toolStripSeparator2, "_toolStripSeparator2");
          // 
          // _selectModeToolStripButton
          // 
          this._selectModeToolStripButton.CheckOnClick = true;
          this._selectModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this._selectModeToolStripButton.Image = global::BarcodeMainDemo.Properties.Resources.SelectMode;
          resources.ApplyResources(this._selectModeToolStripButton, "_selectModeToolStripButton");
          this._selectModeToolStripButton.Name = "_selectModeToolStripButton";
          this._selectModeToolStripButton.Click += new System.EventHandler(this._selectModeToolStripButton_Click);
          // 
          // _panModeToolStripButton
          // 
          this._panModeToolStripButton.CheckOnClick = true;
          this._panModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this._panModeToolStripButton.Image = global::BarcodeMainDemo.Properties.Resources.PanMode;
          resources.ApplyResources(this._panModeToolStripButton, "_panModeToolStripButton");
          this._panModeToolStripButton.Name = "_panModeToolStripButton";
          this._panModeToolStripButton.Click += new System.EventHandler(this._panModeToolStripButton_Click);
          // 
          // _zoomToSelectionModeToolStripButton
          // 
          this._zoomToSelectionModeToolStripButton.CheckOnClick = true;
          this._zoomToSelectionModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this._zoomToSelectionModeToolStripButton.Image = global::BarcodeMainDemo.Properties.Resources.ZoomSelection;
          resources.ApplyResources(this._zoomToSelectionModeToolStripButton, "_zoomToSelectionModeToolStripButton");
          this._zoomToSelectionModeToolStripButton.Name = "_zoomToSelectionModeToolStripButton";
          this._zoomToSelectionModeToolStripButton.Click += new System.EventHandler(this._zoomToSelectionModeToolStripButton_Click);
          // 
          // _regionModeToolStripButton
          // 
          this._regionModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this._regionModeToolStripButton.Image = global::BarcodeMainDemo.Properties.Resources.RegionMode;
          resources.ApplyResources(this._regionModeToolStripButton, "_regionModeToolStripButton");
          this._regionModeToolStripButton.Name = "_regionModeToolStripButton";
          this._regionModeToolStripButton.Click += new System.EventHandler(this._regionModeToolStripButton_Click);
          // 
          // _deleteRegionToolStripButton
          // 
          this._deleteRegionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this._deleteRegionToolStripButton.Image = global::BarcodeMainDemo.Properties.Resources.DeleteRegion;
          resources.ApplyResources(this._deleteRegionToolStripButton, "_deleteRegionToolStripButton");
          this._deleteRegionToolStripButton.Name = "_deleteRegionToolStripButton";
          this._deleteRegionToolStripButton.Click += new System.EventHandler(this._deleteRegionToolStripButton_Click);
          // 
          // _readBarcodeModeToolStripButton
          // 
          this._readBarcodeModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this._readBarcodeModeToolStripButton.Image = global::BarcodeMainDemo.Properties.Resources.ReadBarcodes;
          resources.ApplyResources(this._readBarcodeModeToolStripButton, "_readBarcodeModeToolStripButton");
          this._readBarcodeModeToolStripButton.Name = "_readBarcodeModeToolStripButton";
          this._readBarcodeModeToolStripButton.Click += new System.EventHandler(this._readBarcodeModeToolStripButton_Click);
          // 
          // _writeBarcodeModeToolStripButton
          // 
          this._writeBarcodeModeToolStripButton.CheckOnClick = true;
          this._writeBarcodeModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this._writeBarcodeModeToolStripButton.Image = global::BarcodeMainDemo.Properties.Resources.WriteBarcodeMode;
          resources.ApplyResources(this._writeBarcodeModeToolStripButton, "_writeBarcodeModeToolStripButton");
          this._writeBarcodeModeToolStripButton.Name = "_writeBarcodeModeToolStripButton";
          this._writeBarcodeModeToolStripButton.Click += new System.EventHandler(this._writeBarcodeModeToolStripButton_Click);
          // 
          // _toolStripSeparator3
          // 
          this._toolStripSeparator3.Name = "_toolStripSeparator3";
          resources.ApplyResources(this._toolStripSeparator3, "_toolStripSeparator3");
          // 
          // _showBarcodesToolStripButton
          // 
          this._showBarcodesToolStripButton.Checked = true;
          this._showBarcodesToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
          this._showBarcodesToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this._showBarcodesToolStripButton.Image = global::BarcodeMainDemo.Properties.Resources.ShowBarcodes;
          resources.ApplyResources(this._showBarcodesToolStripButton, "_showBarcodesToolStripButton");
          this._showBarcodesToolStripButton.Name = "_showBarcodesToolStripButton";
          this._showBarcodesToolStripButton.Click += new System.EventHandler(this._showBarcodesToolStripButton_Click);
          // 
          // _mousePositionLabel
          // 
          resources.ApplyResources(this._mousePositionLabel, "_mousePositionLabel");
          this._mousePositionLabel.Name = "_mousePositionLabel";
          // 
          // _rasterImageViewer
          // 
          this._rasterImageViewer.ImageRegionRenderMode = Leadtools.Controls.ControlRegionRenderMode.None;
          this._rasterImageViewer.BackColor = System.Drawing.SystemColors.AppWorkspace;
          this._rasterImageViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          resources.ApplyResources(this._rasterImageViewer, "_rasterImageViewer");
          this._rasterImageViewer.AutoScroll = true;
          this._rasterImageViewer.ViewHorizontalAlignment= Leadtools.Controls.ControlAlignment.Center;
          this._rasterImageViewer.Name = "_rasterImageViewer";
          this._rasterImageViewer.Zoom(Leadtools.Controls.ControlSizeMode.FitAlways,_rasterImageViewer.ScaleFactor,_rasterImageViewer.DefaultZoomOrigin);
          this._rasterImageViewer.UseDpi = true;
          this._rasterImageViewer.ViewVerticalAlignment = Leadtools.Controls.ControlAlignment.Center;
          this._rasterImageViewer.PostRender += new System.EventHandler<Leadtools.Controls.ImageViewerRenderEventArgs>(_rasterImageViewer_PostImagePaint); //+= new System.Windows.Forms.PaintEventHandler(_rasterImageViewer_PostImagePaint); 
          this._rasterImageViewer.TransformChanged += new System.EventHandler(this._rasterImageViewer_TransformChanged);
          this._rasterImageViewer.MouseClick += new System.Windows.Forms.MouseEventHandler(this._rasterImageViewer_MouseClick);
          this._rasterImageViewer.MouseMove += new System.Windows.Forms.MouseEventHandler(this._rasterImageViewer_MouseMove);
          // 
          // ViewerControl
          // 
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.Controls.Add(this._rasterImageViewer);
          this.Controls.Add(this._mousePositionLabel);
          this.Controls.Add(this._toolStrip);
          this.Controls.Add(this._pageInfoLabel);
          this.Name = "ViewerControl";
          this._toolStrip.ResumeLayout(false);
          this._toolStrip.PerformLayout();
          this.ResumeLayout(false);
          this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label _pageInfoLabel;
      public System.Windows.Forms.ToolStrip _toolStrip;
      private System.Windows.Forms.ToolStripButton _previousPageToolStripButton;
      private System.Windows.Forms.ToolStripButton _nextPageToolStripButton;
      private System.Windows.Forms.ToolStripTextBox _pageToolStripTextBox;
      private System.Windows.Forms.ToolStripLabel _pageToolStripLabel;
      private System.Windows.Forms.ToolStripSeparator _toolStripSeparator1;
      private System.Windows.Forms.ToolStripButton _zoomOutToolStripButton;
      private System.Windows.Forms.ToolStripButton _zoomInToolStripButton;
      private System.Windows.Forms.ToolStripComboBox _zoomToolStripComboBox;
      private System.Windows.Forms.ToolStripButton _fitPageWidthToolStripButton;
      private System.Windows.Forms.ToolStripButton _fitPageToolStripButton;
      private System.Windows.Forms.ToolStripSeparator _toolStripSeparator2;
      private System.Windows.Forms.ToolStripButton _selectModeToolStripButton;
      private System.Windows.Forms.ToolStripButton _panModeToolStripButton;
      private System.Windows.Forms.ToolStripButton _zoomToSelectionModeToolStripButton;
      private System.Windows.Forms.ToolStripButton _regionModeToolStripButton;
      private System.Windows.Forms.ToolStripButton _deleteRegionToolStripButton;
      private System.Windows.Forms.ToolStripButton _writeBarcodeModeToolStripButton;
      private System.Windows.Forms.ToolStripSeparator _toolStripSeparator3;
      private System.Windows.Forms.ToolStripButton _showBarcodesToolStripButton;
      private System.Windows.Forms.Label _mousePositionLabel;
      private Leadtools.Controls.ImageViewer _rasterImageViewer;
      private System.Windows.Forms.ToolStripButton _readBarcodeModeToolStripButton;
   }
}
