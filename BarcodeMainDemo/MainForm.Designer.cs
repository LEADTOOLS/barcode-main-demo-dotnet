namespace BarcodeMainDemo
{
   partial class MainForm
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
          this._mainMenuStrip = new System.Windows.Forms.MenuStrip();
          this._fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._fileSep1toolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
          this._scanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._selectSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._acquireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._fileSep2ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
          this._exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._copyImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._pasteImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._zoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._editSep1ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
          this._fitWidthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._fitPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._pageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._previousPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._nextPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._gotoPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._interactiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._selectModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._panModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._zoomToModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._drawRegionModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._readBarcodeModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._writeBarcodeModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._interactiveSep1ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
          this._deleteRegionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._preprocessingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._preprocessAllPagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._preprocessingSep1ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
          this._flipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._reverseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._rotate90ClockwiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._rotate90CounterclockwiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._noiseFiltersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem(); 
          this._noiseMinFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._noiseMedianFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._noiseMaxFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._lineRemoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._imageDeskewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._segmentationPerspectiveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._perspectiveDeskewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._barcodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._readBarcodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._readBarcodeOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._barcodeImageTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._scannedDocumentImageTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._pictureImageTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._unknownImageTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._barcodeReturnBoundariesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._returnBoundingRectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._returnFourPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._writeBarcodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._barcodeSep1ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
          this._showBarcodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._barcodeSep2ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
          this._saveCurrentReadOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._loadReadOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._saveCurrentWriteOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._loadWriteOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._barcodeSep3ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
          this._deleteSelectedBarcodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._zoomToSelectedBarcodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._exportBarcodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._clearAllBarcodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this._mainToolStrip = new System.Windows.Forms.ToolStrip();
          this._newToolStripButton = new System.Windows.Forms.ToolStripButton();
          this._openToolStripButton = new System.Windows.Forms.ToolStripButton();
          this._saveToolStripButton = new System.Windows.Forms.ToolStripButton();
          this._toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
          this._readBarcodesToolStripButton = new System.Windows.Forms.ToolStripButton();
          this._readBarcodeOptionsToolStripButton = new System.Windows.Forms.ToolStripButton();
          this._writeBarcodeToolStripButton = new System.Windows.Forms.ToolStripButton();
          this._mainStatusStrip = new System.Windows.Forms.StatusStrip();
          this._viewerSplitter = new System.Windows.Forms.Splitter();
          this._viewerControl = new BarcodeMainDemo.ViewerControl.ViewerControl();
          this._barcodeControl = new BarcodeMainDemo.BarcodeControls.BarcodeControl();
          this._pagesControl = new BarcodeMainDemo.PagesControl.PagesControl();
          this._mainMenuStrip.SuspendLayout();
          this._mainToolStrip.SuspendLayout();
          this.SuspendLayout();
          // 
          // _mainMenuStrip
          // 
          this._mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileToolStripMenuItem,
            this._editToolStripMenuItem,
            this._viewToolStripMenuItem,
            this._pageToolStripMenuItem,
            this._interactiveToolStripMenuItem,
            this._preprocessingToolStripMenuItem,
            this._barcodeToolStripMenuItem,
            this._helpToolStripMenuItem});
          resources.ApplyResources(this._mainMenuStrip, "_mainMenuStrip");
          this._mainMenuStrip.Name = "_mainMenuStrip";
          // 
          // _fileToolStripMenuItem
          // 
          this._fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._newToolStripMenuItem,
            this._openToolStripMenuItem,
            this._saveToolStripMenuItem,
            this._closeToolStripMenuItem,
            this._fileSep1toolStripMenuItem,
            this._scanToolStripMenuItem,
            this._fileSep2ToolStripMenuItem,
            this._exitToolStripMenuItem});
          this._fileToolStripMenuItem.Name = "_fileToolStripMenuItem";
          resources.ApplyResources(this._fileToolStripMenuItem, "_fileToolStripMenuItem");
          this._fileToolStripMenuItem.DropDownOpening += new System.EventHandler(this._fileToolStripMenuItem_DropDownOpening);
          // 
          // _newToolStripMenuItem
          // 
          this._newToolStripMenuItem.Image = global::BarcodeMainDemo.Properties.Resources.NewDocument;
          this._newToolStripMenuItem.Name = "_newToolStripMenuItem";
          resources.ApplyResources(this._newToolStripMenuItem, "_newToolStripMenuItem");
          this._newToolStripMenuItem.Click += new System.EventHandler(this._newToolStripMenuItem_Click);
          // 
          // _openToolStripMenuItem
          // 
          this._openToolStripMenuItem.Image = global::BarcodeMainDemo.Properties.Resources.OpenDocument;
          this._openToolStripMenuItem.Name = "_openToolStripMenuItem";
          resources.ApplyResources(this._openToolStripMenuItem, "_openToolStripMenuItem");
          this._openToolStripMenuItem.Click += new System.EventHandler(this._openToolStripMenuItem_Click);
          // 
          // _saveToolStripMenuItem
          // 
          this._saveToolStripMenuItem.Image = global::BarcodeMainDemo.Properties.Resources.SaveDocument;
          this._saveToolStripMenuItem.Name = "_saveToolStripMenuItem";
          resources.ApplyResources(this._saveToolStripMenuItem, "_saveToolStripMenuItem");
          this._saveToolStripMenuItem.Click += new System.EventHandler(this._saveToolStripMenuItem_Click);
          // 
          // _closeToolStripMenuItem
          // 
          this._closeToolStripMenuItem.Name = "_closeToolStripMenuItem";
          resources.ApplyResources(this._closeToolStripMenuItem, "_closeToolStripMenuItem");
          this._closeToolStripMenuItem.Click += new System.EventHandler(this._closeToolStripMenuItem_Click);
          // 
          // _fileSep1toolStripMenuItem
          // 
          this._fileSep1toolStripMenuItem.Name = "_fileSep1toolStripMenuItem";
          resources.ApplyResources(this._fileSep1toolStripMenuItem, "_fileSep1toolStripMenuItem");
          // 
          // _scanToolStripMenuItem
          // 
          this._scanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._selectSourceToolStripMenuItem,
            this._acquireToolStripMenuItem});
          this._scanToolStripMenuItem.Name = "_scanToolStripMenuItem";
          resources.ApplyResources(this._scanToolStripMenuItem, "_scanToolStripMenuItem");
          // 
          // _selectSourceToolStripMenuItem
          // 
          this._selectSourceToolStripMenuItem.Name = "_selectSourceToolStripMenuItem";
          resources.ApplyResources(this._selectSourceToolStripMenuItem, "_selectSourceToolStripMenuItem");
          this._selectSourceToolStripMenuItem.Click += new System.EventHandler(this._selectSourceToolStripMenuItem_Click);
          // 
          // _acquireToolStripMenuItem
          // 
          this._acquireToolStripMenuItem.Name = "_acquireToolStripMenuItem";
          resources.ApplyResources(this._acquireToolStripMenuItem, "_acquireToolStripMenuItem");
          this._acquireToolStripMenuItem.Click += new System.EventHandler(this._acquireToolStripMenuItem_Click);
          // 
          // _fileSep2ToolStripMenuItem
          // 
          this._fileSep2ToolStripMenuItem.Name = "_fileSep2ToolStripMenuItem";
          resources.ApplyResources(this._fileSep2ToolStripMenuItem, "_fileSep2ToolStripMenuItem");
          // 
          // _exitToolStripMenuItem
          // 
          this._exitToolStripMenuItem.Name = "_exitToolStripMenuItem";
          resources.ApplyResources(this._exitToolStripMenuItem, "_exitToolStripMenuItem");
          this._exitToolStripMenuItem.Click += new System.EventHandler(this._exitToolStripMenuItem_Click);
          // 
          // _editToolStripMenuItem
          // 
          this._editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._copyImageToolStripMenuItem,
            this._pasteImageToolStripMenuItem});
          this._editToolStripMenuItem.Name = "_editToolStripMenuItem";
          resources.ApplyResources(this._editToolStripMenuItem, "_editToolStripMenuItem");
          this._editToolStripMenuItem.DropDownOpening += new System.EventHandler(this._editToolStripMenuItem_DropDownOpening);
          // 
          // _copyImageToolStripMenuItem
          // 
          this._copyImageToolStripMenuItem.Name = "_copyImageToolStripMenuItem";
          resources.ApplyResources(this._copyImageToolStripMenuItem, "_copyImageToolStripMenuItem");
          this._copyImageToolStripMenuItem.Click += new System.EventHandler(this._copyImageToolStripMenuItem_Click);
          // 
          // _pasteImageToolStripMenuItem
          // 
          this._pasteImageToolStripMenuItem.Name = "_pasteImageToolStripMenuItem";
          resources.ApplyResources(this._pasteImageToolStripMenuItem, "_pasteImageToolStripMenuItem");
          this._pasteImageToolStripMenuItem.Click += new System.EventHandler(this._pasteImageToolStripMenuItem_Click);
          // 
          // _viewToolStripMenuItem
          // 
          this._viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._zoomOutToolStripMenuItem,
            this._zoomInToolStripMenuItem,
            this._editSep1ToolStripMenuItem,
            this._fitWidthToolStripMenuItem,
            this._fitPageToolStripMenuItem});
          this._viewToolStripMenuItem.Name = "_viewToolStripMenuItem";
          resources.ApplyResources(this._viewToolStripMenuItem, "_viewToolStripMenuItem");
          this._viewToolStripMenuItem.DropDownOpening += new System.EventHandler(this._viewToolStripMenuItem_DropDownOpening);
          // 
          // _zoomOutToolStripMenuItem
          // 
          this._zoomOutToolStripMenuItem.Image = global::BarcodeMainDemo.Properties.Resources.ZoomOut;
          this._zoomOutToolStripMenuItem.Name = "_zoomOutToolStripMenuItem";
          resources.ApplyResources(this._zoomOutToolStripMenuItem, "_zoomOutToolStripMenuItem");
          this._zoomOutToolStripMenuItem.Click += new System.EventHandler(this._zoomOutToolStripMenuItem_Click);
          // 
          // _zoomInToolStripMenuItem
          // 
          this._zoomInToolStripMenuItem.Image = global::BarcodeMainDemo.Properties.Resources.ZoomIn;
          this._zoomInToolStripMenuItem.Name = "_zoomInToolStripMenuItem";
          resources.ApplyResources(this._zoomInToolStripMenuItem, "_zoomInToolStripMenuItem");
          this._zoomInToolStripMenuItem.Click += new System.EventHandler(this._zoomInToolStripMenuItem_Click);
          // 
          // _editSep1ToolStripMenuItem
          // 
          this._editSep1ToolStripMenuItem.Name = "_editSep1ToolStripMenuItem";
          resources.ApplyResources(this._editSep1ToolStripMenuItem, "_editSep1ToolStripMenuItem");
          // 
          // _fitWidthToolStripMenuItem
          // 
          this._fitWidthToolStripMenuItem.Image = global::BarcodeMainDemo.Properties.Resources.FitPageWidth;
          this._fitWidthToolStripMenuItem.Name = "_fitWidthToolStripMenuItem";
          resources.ApplyResources(this._fitWidthToolStripMenuItem, "_fitWidthToolStripMenuItem");
          this._fitWidthToolStripMenuItem.Click += new System.EventHandler(this._fitWidthToolStripMenuItem_Click);
          // 
          // _fitPageToolStripMenuItem
          // 
          this._fitPageToolStripMenuItem.Image = global::BarcodeMainDemo.Properties.Resources.FitPage;
          this._fitPageToolStripMenuItem.Name = "_fitPageToolStripMenuItem";
          resources.ApplyResources(this._fitPageToolStripMenuItem, "_fitPageToolStripMenuItem");
          this._fitPageToolStripMenuItem.Click += new System.EventHandler(this._fitPageToolStripMenuItem_Click);
          // 
          // _pageToolStripMenuItem
          // 
          this._pageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._previousPageToolStripMenuItem,
            this._nextPageToolStripMenuItem,
            this._gotoPageToolStripMenuItem});
          this._pageToolStripMenuItem.Name = "_pageToolStripMenuItem";
          resources.ApplyResources(this._pageToolStripMenuItem, "_pageToolStripMenuItem");
          this._pageToolStripMenuItem.DropDownOpening += new System.EventHandler(this._pageToolStripMenuItem_DropDownOpening);
          // 
          // _previousPageToolStripMenuItem
          // 
          this._previousPageToolStripMenuItem.Image = global::BarcodeMainDemo.Properties.Resources.PreviousPage;
          this._previousPageToolStripMenuItem.Name = "_previousPageToolStripMenuItem";
          resources.ApplyResources(this._previousPageToolStripMenuItem, "_previousPageToolStripMenuItem");
          this._previousPageToolStripMenuItem.Click += new System.EventHandler(this._previousPageToolStripMenuItem_Click);
          // 
          // _nextPageToolStripMenuItem
          // 
          this._nextPageToolStripMenuItem.Image = global::BarcodeMainDemo.Properties.Resources.NextPage;
          this._nextPageToolStripMenuItem.Name = "_nextPageToolStripMenuItem";
          resources.ApplyResources(this._nextPageToolStripMenuItem, "_nextPageToolStripMenuItem");
          this._nextPageToolStripMenuItem.Click += new System.EventHandler(this._nextPageToolStripMenuItem_Click);
          // 
          // _gotoPageToolStripMenuItem
          // 
          this._gotoPageToolStripMenuItem.Name = "_gotoPageToolStripMenuItem";
          resources.ApplyResources(this._gotoPageToolStripMenuItem, "_gotoPageToolStripMenuItem");
          this._gotoPageToolStripMenuItem.Click += new System.EventHandler(this._gotoPageToolStripMenuItem_Click);
          // 
          // _interactiveToolStripMenuItem
          // 
          this._interactiveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._selectModeToolStripMenuItem,
            this._panModeToolStripMenuItem,
            this._zoomToModeToolStripMenuItem,
            this._drawRegionModeToolStripMenuItem,
            this._readBarcodeModeToolStripMenuItem,
            this._writeBarcodeModeToolStripMenuItem,
            this._interactiveSep1ToolStripMenuItem,
            this._deleteRegionToolStripMenuItem});
          this._interactiveToolStripMenuItem.Name = "_interactiveToolStripMenuItem";
          resources.ApplyResources(this._interactiveToolStripMenuItem, "_interactiveToolStripMenuItem");
          this._interactiveToolStripMenuItem.DropDownOpening += new System.EventHandler(this._interactiveToolStripMenuItem_DropDownOpening);
          // 
          // _selectModeToolStripMenuItem
          // 
          this._selectModeToolStripMenuItem.Image = global::BarcodeMainDemo.Properties.Resources.SelectMode;
          this._selectModeToolStripMenuItem.Name = "_selectModeToolStripMenuItem";
          resources.ApplyResources(this._selectModeToolStripMenuItem, "_selectModeToolStripMenuItem");
          this._selectModeToolStripMenuItem.Click += new System.EventHandler(this._selectModeToolStripMenuItem_Click);
          // 
          // _panModeToolStripMenuItem
          // 
          this._panModeToolStripMenuItem.Image = global::BarcodeMainDemo.Properties.Resources.PanMode;
          this._panModeToolStripMenuItem.Name = "_panModeToolStripMenuItem";
          resources.ApplyResources(this._panModeToolStripMenuItem, "_panModeToolStripMenuItem");
          this._panModeToolStripMenuItem.Click += new System.EventHandler(this._panModeToolStripMenuItem_Click);
          // 
          // _zoomToModeToolStripMenuItem
          // 
          this._zoomToModeToolStripMenuItem.Image = global::BarcodeMainDemo.Properties.Resources.ZoomSelection;
          this._zoomToModeToolStripMenuItem.Name = "_zoomToModeToolStripMenuItem";
          resources.ApplyResources(this._zoomToModeToolStripMenuItem, "_zoomToModeToolStripMenuItem");
          this._zoomToModeToolStripMenuItem.Click += new System.EventHandler(this._zoomToModeToolStripMenuItem_Click);
          // 
          // _drawRegionModeToolStripMenuItem
          // 
          this._drawRegionModeToolStripMenuItem.Image = global::BarcodeMainDemo.Properties.Resources.RegionMode;
          this._drawRegionModeToolStripMenuItem.Name = "_drawRegionModeToolStripMenuItem";
          resources.ApplyResources(this._drawRegionModeToolStripMenuItem, "_drawRegionModeToolStripMenuItem");
          this._drawRegionModeToolStripMenuItem.Click += new System.EventHandler(this._drawRegionModeToolStripMenuItem_Click);
          // 
          // _readBarcodeModeToolStripMenuItem
          // 
          this._readBarcodeModeToolStripMenuItem.Image = global::BarcodeMainDemo.Properties.Resources.ReadBarcodes;
          this._readBarcodeModeToolStripMenuItem.Name = "_readBarcodeModeToolStripMenuItem";
          resources.ApplyResources(this._readBarcodeModeToolStripMenuItem, "_readBarcodeModeToolStripMenuItem");
          this._readBarcodeModeToolStripMenuItem.Click += new System.EventHandler(this._readBarcodeToolStripMenuItem_Click);
          // 
          // _writeBarcodeModeToolStripMenuItem
          // 
          this._writeBarcodeModeToolStripMenuItem.Image = global::BarcodeMainDemo.Properties.Resources.WriteBarcodeMode;
          this._writeBarcodeModeToolStripMenuItem.Name = "_writeBarcodeModeToolStripMenuItem";
          resources.ApplyResources(this._writeBarcodeModeToolStripMenuItem, "_writeBarcodeModeToolStripMenuItem");
          this._writeBarcodeModeToolStripMenuItem.Click += new System.EventHandler(this._writeBarcodeModeToolStripMenuItem_Click);
          // 
          // _interactiveSep1ToolStripMenuItem
          // 
          this._interactiveSep1ToolStripMenuItem.Name = "_interactiveSep1ToolStripMenuItem";
          resources.ApplyResources(this._interactiveSep1ToolStripMenuItem, "_interactiveSep1ToolStripMenuItem");
          // 
          // _deleteRegionToolStripMenuItem
          // 
          this._deleteRegionToolStripMenuItem.Image = global::BarcodeMainDemo.Properties.Resources.DeleteRegion;
          this._deleteRegionToolStripMenuItem.Name = "_deleteRegionToolStripMenuItem";
          resources.ApplyResources(this._deleteRegionToolStripMenuItem, "_deleteRegionToolStripMenuItem");
          this._deleteRegionToolStripMenuItem.Click += new System.EventHandler(this._deleteRegionToolStripMenuItem_Click);
          // 
          // _preprocessingToolStripMenuItem
          // 
          this._preprocessingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._preprocessAllPagesToolStripMenuItem,
            this._preprocessingSep1ToolStripMenuItem,
            this._flipToolStripMenuItem,
            this._reverseToolStripMenuItem,
            this._rotate90ClockwiseToolStripMenuItem,
            this._rotate90CounterclockwiseToolStripMenuItem,
            this._noiseFiltersToolStripMenuItem,
            this._lineRemoveToolStripMenuItem,
            this._imageDeskewToolStripMenuItem,
            this._segmentationPerspectiveMenuItem,
            this._perspectiveDeskewToolStripMenuItem,});
          this._preprocessingToolStripMenuItem.Name = "_preprocessingToolStripMenuItem";
          resources.ApplyResources(this._preprocessingToolStripMenuItem, "_preprocessingToolStripMenuItem");
          this._preprocessingToolStripMenuItem.DropDownOpening += new System.EventHandler(this._preprocessingToolStripMenuItem_DropDownOpening);
          // 
          // _preprocessAllPagesToolStripMenuItem
          // 
          this._preprocessAllPagesToolStripMenuItem.Checked = true;
          this._preprocessAllPagesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
          this._preprocessAllPagesToolStripMenuItem.Name = "_preprocessAllPagesToolStripMenuItem";
          resources.ApplyResources(this._preprocessAllPagesToolStripMenuItem, "_preprocessAllPagesToolStripMenuItem");
          this._preprocessAllPagesToolStripMenuItem.Click += new System.EventHandler(this._preprocessAllPagesToolStripMenuItem_Click);
          // 
          // _preprocessingSep1ToolStripMenuItem
          // 
          this._preprocessingSep1ToolStripMenuItem.Name = "_preprocessingSep1ToolStripMenuItem";
          resources.ApplyResources(this._preprocessingSep1ToolStripMenuItem, "_preprocessingSep1ToolStripMenuItem");
          // 
          // _flipToolStripMenuItem
          // 
          this._flipToolStripMenuItem.Name = "_flipToolStripMenuItem";
          resources.ApplyResources(this._flipToolStripMenuItem, "_flipToolStripMenuItem");
          this._flipToolStripMenuItem.Click += new System.EventHandler(this._flipToolStripMenuItem_Click);
          // 
          // _reverseToolStripMenuItem
          // 
          this._reverseToolStripMenuItem.Name = "_reverseToolStripMenuItem";
          resources.ApplyResources(this._reverseToolStripMenuItem, "_reverseToolStripMenuItem");
          this._reverseToolStripMenuItem.Click += new System.EventHandler(this._reverseToolStripMenuItem_Click);
          // 
          // _rotate90ClockwiseToolStripMenuItem
          // 
          this._rotate90ClockwiseToolStripMenuItem.Name = "_rotate90ClockwiseToolStripMenuItem";
          resources.ApplyResources(this._rotate90ClockwiseToolStripMenuItem, "_rotate90ClockwiseToolStripMenuItem");
          this._rotate90ClockwiseToolStripMenuItem.Click += new System.EventHandler(this._rotate90ClockwiseToolStripMenuItem_Click);
          // 
          // _rotate90CounterclockwiseToolStripMenuItem
          // 
          this._rotate90CounterclockwiseToolStripMenuItem.Name = "_rotate90CounterclockwiseToolStripMenuItem";
          resources.ApplyResources(this._rotate90CounterclockwiseToolStripMenuItem, "_rotate90CounterclockwiseToolStripMenuItem");
          this._rotate90CounterclockwiseToolStripMenuItem.Click += new System.EventHandler(this._rotate90CounterclockwiseToolStripMenuItem_Click);
          // 
          // _noiseFiltersToolStripMenuItem
          // 
          this._noiseFiltersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._noiseMinFilterToolStripMenuItem,
            this._noiseMedianFilterToolStripMenuItem,
            this._noiseMaxFilterToolStripMenuItem});
          this._noiseFiltersToolStripMenuItem.Name = "_noiseFiltersToolStripMenuItem";
          resources.ApplyResources(this._noiseFiltersToolStripMenuItem, "_noiseFiltersToolStripMenuItem");
          // 
          // _noiseMinFilterToolStripMenuItem
          // 
          this._noiseMinFilterToolStripMenuItem.Name = "_noiseMinFilterToolStripMenuItem";
          resources.ApplyResources(this._noiseMinFilterToolStripMenuItem, "_noiseMinFilterToolStripMenuItem");
          this._noiseMinFilterToolStripMenuItem.Click += new System.EventHandler(this._noiseMinFilterToolStripMenuItem_Click);
          // 
          // _noiseMedianFilterToolStripMenuItem
          // 
          this._noiseMedianFilterToolStripMenuItem.Name = "_noiseMedianFilterToolStripMenuItem";
          resources.ApplyResources(this._noiseMedianFilterToolStripMenuItem, "_noiseMedianFilterToolStripMenuItem");
          this._noiseMedianFilterToolStripMenuItem.Click += new System.EventHandler(this._noiseMedianFilterToolStripMenuItem_Click);
          // 
          // _noiseMaxFilterToolStripMenuItem
          // 
          this._noiseMaxFilterToolStripMenuItem.Name = "_noiseMaxFilterToolStripMenuItem";
          resources.ApplyResources(this._noiseMaxFilterToolStripMenuItem, "_noiseMaxFilterToolStripMenuItem");
          this._noiseMaxFilterToolStripMenuItem.Click += new System.EventHandler(this._noiseMaxFilterToolStripMenuItem_Click);
          // 
          // _lineRemoveToolStripMenuItem
          // 
          this._lineRemoveToolStripMenuItem.Name = "_lineRemoveToolStripMenuItem";
          resources.ApplyResources(this._lineRemoveToolStripMenuItem, "_lineRemoveToolStripMenuItem");
          this._lineRemoveToolStripMenuItem.Click += new System.EventHandler(this._lineRemoveToolStripMenuItem_Click);
          // 
          // _imageDeskewToolStripMenuItem
          // 
          this._imageDeskewToolStripMenuItem.Name = "_imageDeskewToolStripMenuItem";
          resources.ApplyResources(this._imageDeskewToolStripMenuItem, "_imageDeskewToolStripMenuItem");
          this._imageDeskewToolStripMenuItem.Click += new System.EventHandler(this._imageDeskewToolStripMenuItem_Click);
          // 
          // _segmentationPerspectiveMenuItem
          // 
          this._segmentationPerspectiveMenuItem.Name = "_segmentationPerspectiveMenuItem";
          resources.ApplyResources(this._segmentationPerspectiveMenuItem, "_segmentationPerspectiveMenuItem");
          this._segmentationPerspectiveMenuItem.Click += new System.EventHandler(this._segmentationPerspectiveMenuItem_Click);
          // 
          // _perspectiveDeskewToolStripMenuItem
          // 
          this._perspectiveDeskewToolStripMenuItem.Name = "_perspectiveDeskewToolStripMenuItem";
          resources.ApplyResources(this._perspectiveDeskewToolStripMenuItem, "_perspectiveDeskewToolStripMenuItem");
          this._perspectiveDeskewToolStripMenuItem.Click += new System.EventHandler(this._perspectiveDeskewToolStripMenuItem_Click);
          // 
          // _barcodeToolStripMenuItem
          // 
          this._barcodeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._readBarcodesToolStripMenuItem,
            this._readBarcodeOptionsToolStripMenuItem,
            this._barcodeImageTypeToolStripMenuItem,
            this._barcodeReturnBoundariesToolStripMenuItem,
            this._writeBarcodeToolStripMenuItem,
            this._barcodeSep1ToolStripMenuItem,
            this._showBarcodesToolStripMenuItem,
            this._barcodeSep2ToolStripMenuItem,
            this._saveCurrentReadOptionsToolStripMenuItem,
            this._loadReadOptionsToolStripMenuItem,
            this._saveCurrentWriteOptionsToolStripMenuItem,
            this._loadWriteOptionsToolStripMenuItem,
            this._barcodeSep3ToolStripMenuItem,
            this._deleteSelectedBarcodeToolStripMenuItem,
            this._zoomToSelectedBarcodeToolStripMenuItem,
            this._exportBarcodesToolStripMenuItem,
            this._clearAllBarcodesToolStripMenuItem});
          this._barcodeToolStripMenuItem.Name = "_barcodeToolStripMenuItem";
          resources.ApplyResources(this._barcodeToolStripMenuItem, "_barcodeToolStripMenuItem");
          this._barcodeToolStripMenuItem.DropDownOpening += new System.EventHandler(this._barcodeToolStripMenuItem_DropDownOpening);
          // 
          // _readBarcodesToolStripMenuItem
          // 
          this._readBarcodesToolStripMenuItem.Image = global::BarcodeMainDemo.Properties.Resources.ReadBarcodes;
          this._readBarcodesToolStripMenuItem.Name = "_readBarcodesToolStripMenuItem";
          resources.ApplyResources(this._readBarcodesToolStripMenuItem, "_readBarcodesToolStripMenuItem");
          this._readBarcodesToolStripMenuItem.Click += new System.EventHandler(this._readBarcodesToolStripMenuItem_Click);
          // 
          // _readBarcodeOptionsToolStripMenuItem
          // 
          this._readBarcodeOptionsToolStripMenuItem.Image = global::BarcodeMainDemo.Properties.Resources.ReadBarcodeOptions;
          this._readBarcodeOptionsToolStripMenuItem.Name = "_readBarcodeOptionsToolStripMenuItem";
          resources.ApplyResources(this._readBarcodeOptionsToolStripMenuItem, "_readBarcodeOptionsToolStripMenuItem");
          this._readBarcodeOptionsToolStripMenuItem.Click += new System.EventHandler(this._readBarcodeOptionsToolStripMenuItem_Click);
          // 
          // _barcodeImageTypeToolStripMenuItem
          // 
          this._barcodeImageTypeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._scannedDocumentImageTypeToolStripMenuItem,
            this._pictureImageTypeToolStripMenuItem,
            this._unknownImageTypeToolStripMenuItem});
          this._barcodeImageTypeToolStripMenuItem.Name = "_barcodeImageTypeToolStripMenuItem";
          resources.ApplyResources(this._barcodeImageTypeToolStripMenuItem, "_barcodeImageTypeToolStripMenuItem");
          this._barcodeImageTypeToolStripMenuItem.DropDownOpening += new System.EventHandler(this._barcodeImageTypeToolStripMenuItem_DropDownOpening);
          // 
          // _scannedDocumentImageTypeToolStripMenuItem
          // 
          this._scannedDocumentImageTypeToolStripMenuItem.Name = "_scannedDocumentImageTypeToolStripMenuItem";
          resources.ApplyResources(this._scannedDocumentImageTypeToolStripMenuItem, "_scannedDocumentImageTypeToolStripMenuItem");
          this._scannedDocumentImageTypeToolStripMenuItem.Click += new System.EventHandler(this._scannedDocumentImageTypeToolStripMenuItem_Click);
          // 
          // _pictureImageTypeToolStripMenuItem
          // 
          this._pictureImageTypeToolStripMenuItem.Name = "_pictureImageTypeToolStripMenuItem";
          resources.ApplyResources(this._pictureImageTypeToolStripMenuItem, "_pictureImageTypeToolStripMenuItem");
          this._pictureImageTypeToolStripMenuItem.Click += new System.EventHandler(this._pictureImageTypeToolStripMenuItem_Click);
          // 
          // _unknownImageTypeToolStripMenuItem
          // 
          this._unknownImageTypeToolStripMenuItem.Name = "_unknownImageTypeToolStripMenuItem";
          resources.ApplyResources(this._unknownImageTypeToolStripMenuItem, "_unknownImageTypeToolStripMenuItem");
          this._unknownImageTypeToolStripMenuItem.Click += new System.EventHandler(this._unknownImageTypeToolStripMenuItem_Click);
          // 
          // _barcodeReturnBoundariesToolStripMenuItem
          // 
          this._barcodeReturnBoundariesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._returnBoundingRectToolStripMenuItem,
            this._returnFourPointsToolStripMenuItem});
          this._barcodeReturnBoundariesToolStripMenuItem.Name = "_barcodeReturnBoundariesToolStripMenuItem";
          resources.ApplyResources(this._barcodeReturnBoundariesToolStripMenuItem, "_barcodeReturnBoundariesToolStripMenuItem");
          this._barcodeReturnBoundariesToolStripMenuItem.DropDownOpening += new System.EventHandler(this._barcodeReturnBoundariesToolStripMenuItem_DropDownOpening);
          // 
          // _returnBoundingRectToolStripMenuItem
          // 
          this._returnBoundingRectToolStripMenuItem.Name = "_returnBoundingRectToolStripMenuItem";
          resources.ApplyResources(this._returnBoundingRectToolStripMenuItem, "_returnBoundingRectToolStripMenuItem");
          this._returnBoundingRectToolStripMenuItem.Click += new System.EventHandler(this._returnBoundingRectToolStripMenuItem_Click);
          // 
          // _returnFourPointsToolStripMenuItem
          // 
          this._returnFourPointsToolStripMenuItem.Name = "_returnFourPointsToolStripMenuItem";
          resources.ApplyResources(this._returnFourPointsToolStripMenuItem, "_returnFourPointsToolStripMenuItem");
          this._returnFourPointsToolStripMenuItem.Click += new System.EventHandler(this._returnFourPointsToolStripMenuItem_Click);
          // 
          // _writeBarcodeToolStripMenuItem
          // 
          this._writeBarcodeToolStripMenuItem.Name = "_writeBarcodeToolStripMenuItem";
          resources.ApplyResources(this._writeBarcodeToolStripMenuItem, "_writeBarcodeToolStripMenuItem");
          this._writeBarcodeToolStripMenuItem.Click += new System.EventHandler(this._writeBarcodeToolStripMenuItem_Click);
          // 
          // _barcodeSep1ToolStripMenuItem
          // 
          this._barcodeSep1ToolStripMenuItem.Name = "_barcodeSep1ToolStripMenuItem";
          resources.ApplyResources(this._barcodeSep1ToolStripMenuItem, "_barcodeSep1ToolStripMenuItem");
          // 
          // _showBarcodesToolStripMenuItem
          // 
          this._showBarcodesToolStripMenuItem.Image = global::BarcodeMainDemo.Properties.Resources.ShowBarcodes;
          this._showBarcodesToolStripMenuItem.Name = "_showBarcodesToolStripMenuItem";
          resources.ApplyResources(this._showBarcodesToolStripMenuItem, "_showBarcodesToolStripMenuItem");
          this._showBarcodesToolStripMenuItem.Click += new System.EventHandler(this._showBarcodesToolStripMenuItem_Click);
          // 
          // _barcodeSep2ToolStripMenuItem
          // 
          this._barcodeSep2ToolStripMenuItem.Name = "_barcodeSep2ToolStripMenuItem";
          resources.ApplyResources(this._barcodeSep2ToolStripMenuItem, "_barcodeSep2ToolStripMenuItem");
          // 
          // _saveCurrentReadOptionsToolStripMenuItem
          // 
          this._saveCurrentReadOptionsToolStripMenuItem.Name = "_saveCurrentReadOptionsToolStripMenuItem";
          resources.ApplyResources(this._saveCurrentReadOptionsToolStripMenuItem, "_saveCurrentReadOptionsToolStripMenuItem");
          this._saveCurrentReadOptionsToolStripMenuItem.Click += new System.EventHandler(this._saveCurrentReadOptionsToolStripMenuItem_Click);
          // 
          // _loadReadOptionsToolStripMenuItem
          // 
          this._loadReadOptionsToolStripMenuItem.Name = "_loadReadOptionsToolStripMenuItem";
          resources.ApplyResources(this._loadReadOptionsToolStripMenuItem, "_loadReadOptionsToolStripMenuItem");
          this._loadReadOptionsToolStripMenuItem.Click += new System.EventHandler(this._loadReadOptionsToolStripMenuItem_Click);
          // 
          // _saveCurrentWriteOptionsToolStripMenuItem
          // 
          this._saveCurrentWriteOptionsToolStripMenuItem.Name = "_saveCurrentWriteOptionsToolStripMenuItem";
          resources.ApplyResources(this._saveCurrentWriteOptionsToolStripMenuItem, "_saveCurrentWriteOptionsToolStripMenuItem");
          this._saveCurrentWriteOptionsToolStripMenuItem.Click += new System.EventHandler(this._saveCurrentWriteOptionsToolStripMenuItem_Click);
          // 
          // _loadWriteOptionsToolStripMenuItem
          // 
          this._loadWriteOptionsToolStripMenuItem.Name = "_loadWriteOptionsToolStripMenuItem";
          resources.ApplyResources(this._loadWriteOptionsToolStripMenuItem, "_loadWriteOptionsToolStripMenuItem");
          this._loadWriteOptionsToolStripMenuItem.Click += new System.EventHandler(this._loadWriteOptionsToolStripMenuItem_Click);
          // 
          // _barcodeSep3ToolStripMenuItem
          // 
          this._barcodeSep3ToolStripMenuItem.Name = "_barcodeSep3ToolStripMenuItem";
          resources.ApplyResources(this._barcodeSep3ToolStripMenuItem, "_barcodeSep3ToolStripMenuItem");
          // 
          // _deleteSelectedBarcodeToolStripMenuItem
          // 
          this._deleteSelectedBarcodeToolStripMenuItem.Name = "_deleteSelectedBarcodeToolStripMenuItem";
          resources.ApplyResources(this._deleteSelectedBarcodeToolStripMenuItem, "_deleteSelectedBarcodeToolStripMenuItem");
          this._deleteSelectedBarcodeToolStripMenuItem.Click += new System.EventHandler(this._deleteSelectedBarcodeToolStripMenuItem_Click);
          // 
          // _zoomToSelectedBarcodeToolStripMenuItem
          // 
          this._zoomToSelectedBarcodeToolStripMenuItem.Name = "_zoomToSelectedBarcodeToolStripMenuItem";
          resources.ApplyResources(this._zoomToSelectedBarcodeToolStripMenuItem, "_zoomToSelectedBarcodeToolStripMenuItem");
          this._zoomToSelectedBarcodeToolStripMenuItem.Click += new System.EventHandler(this._zoomToSelectedBarcodeToolStripMenuItem_Click);
          // 
          // _exportBarcodesToolStripMenuItem
          // 
          this._exportBarcodesToolStripMenuItem.Name = "_exportBarcodesToolStripMenuItem";
          resources.ApplyResources(this._exportBarcodesToolStripMenuItem, "_exportBarcodesToolStripMenuItem");
          this._exportBarcodesToolStripMenuItem.Click += new System.EventHandler(this._exportBarcodesToolStripMenuItem_Click);
          // 
          // _clearAllBarcodesToolStripMenuItem
          // 
          this._clearAllBarcodesToolStripMenuItem.Name = "_clearAllBarcodesToolStripMenuItem";
          resources.ApplyResources(this._clearAllBarcodesToolStripMenuItem, "_clearAllBarcodesToolStripMenuItem");
          this._clearAllBarcodesToolStripMenuItem.Click += new System.EventHandler(this._clearAllBarcodesToolStripMenuItem_Click);
          // 
          // _helpToolStripMenuItem
          // 
          this._helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._aboutToolStripMenuItem});
          this._helpToolStripMenuItem.Name = "_helpToolStripMenuItem";
          resources.ApplyResources(this._helpToolStripMenuItem, "_helpToolStripMenuItem");
          // 
          // _aboutToolStripMenuItem
          // 
          this._aboutToolStripMenuItem.Name = "_aboutToolStripMenuItem";
          resources.ApplyResources(this._aboutToolStripMenuItem, "_aboutToolStripMenuItem");
          this._aboutToolStripMenuItem.Click += new System.EventHandler(this._aboutToolStripMenuItem_Click);
          // 
          // _mainToolStrip
          // 
          this._mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._newToolStripButton,
            this._openToolStripButton,
            this._saveToolStripButton,
            this._toolStripSeparator1,
            this._readBarcodesToolStripButton,
            this._readBarcodeOptionsToolStripButton,
            this._writeBarcodeToolStripButton});
          resources.ApplyResources(this._mainToolStrip, "_mainToolStrip");
          this._mainToolStrip.Name = "_mainToolStrip";
          // 
          // _newToolStripButton
          // 
          this._newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this._newToolStripButton.Image = global::BarcodeMainDemo.Properties.Resources.NewDocument;
          resources.ApplyResources(this._newToolStripButton, "_newToolStripButton");
          this._newToolStripButton.Name = "_newToolStripButton";
          this._newToolStripButton.Click += new System.EventHandler(this._newToolStripButton_Click);
          // 
          // _openToolStripButton
          // 
          this._openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this._openToolStripButton.Image = global::BarcodeMainDemo.Properties.Resources.OpenDocument;
          resources.ApplyResources(this._openToolStripButton, "_openToolStripButton");
          this._openToolStripButton.Name = "_openToolStripButton";
          this._openToolStripButton.Click += new System.EventHandler(this._openToolStripButton_Click);
          // 
          // _saveToolStripButton
          // 
          this._saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this._saveToolStripButton.Image = global::BarcodeMainDemo.Properties.Resources.SaveDocument;
          resources.ApplyResources(this._saveToolStripButton, "_saveToolStripButton");
          this._saveToolStripButton.Name = "_saveToolStripButton";
          this._saveToolStripButton.Click += new System.EventHandler(this._saveToolStripButton_Click);
          // 
          // _toolStripSeparator1
          // 
          this._toolStripSeparator1.Name = "_toolStripSeparator1";
          resources.ApplyResources(this._toolStripSeparator1, "_toolStripSeparator1");
          // 
          // _readBarcodesToolStripButton
          // 
          this._readBarcodesToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this._readBarcodesToolStripButton.Image = global::BarcodeMainDemo.Properties.Resources.ReadBarcodes;
          resources.ApplyResources(this._readBarcodesToolStripButton, "_readBarcodesToolStripButton");
          this._readBarcodesToolStripButton.Name = "_readBarcodesToolStripButton";
          this._readBarcodesToolStripButton.Click += new System.EventHandler(this._readBarcodesToolStripButton_Click);
          // 
          // _readBarcodeOptionsToolStripButton
          // 
          this._readBarcodeOptionsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this._readBarcodeOptionsToolStripButton.Image = global::BarcodeMainDemo.Properties.Resources.ReadBarcodeOptions;
          resources.ApplyResources(this._readBarcodeOptionsToolStripButton, "_readBarcodeOptionsToolStripButton");
          this._readBarcodeOptionsToolStripButton.Name = "_readBarcodeOptionsToolStripButton";
          this._readBarcodeOptionsToolStripButton.Click += new System.EventHandler(this._readBarcodeOptionsToolStripButton_Click);
          // 
          // _writeBarcodeToolStripButton
          // 
          this._writeBarcodeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this._writeBarcodeToolStripButton.Image = global::BarcodeMainDemo.Properties.Resources.WriteBarcode;
          resources.ApplyResources(this._writeBarcodeToolStripButton, "_writeBarcodeToolStripButton");
          this._writeBarcodeToolStripButton.Name = "_writeBarcodeToolStripButton";
          this._writeBarcodeToolStripButton.Click += new System.EventHandler(this._writeBarcodeToolStripButton_Click);
          // 
          // _mainStatusStrip
          // 
          resources.ApplyResources(this._mainStatusStrip, "_mainStatusStrip");
          this._mainStatusStrip.Name = "_mainStatusStrip";
          // 
          // _viewerSplitter
          // 
          resources.ApplyResources(this._viewerSplitter, "_viewerSplitter");
          this._viewerSplitter.Name = "_viewerSplitter";
          this._viewerSplitter.TabStop = false;
          // 
          // _viewerControl
          // 
          resources.ApplyResources(this._viewerControl, "_viewerControl");
          this._viewerControl.Name = "_viewerControl";
          this._viewerControl.Action += new System.EventHandler<BarcodeMainDemo.ActionEventArgs>(this._viewerControl_Action);
          // 
          // _barcodeControl
          // 
          resources.ApplyResources(this._barcodeControl, "_barcodeControl");
          this._barcodeControl.Name = "_barcodeControl";
          this._barcodeControl.Action += new System.EventHandler<BarcodeMainDemo.ActionEventArgs>(this._barcodeControl_Action);
          // 
          // _pagesControl
          // 
          resources.ApplyResources(this._pagesControl, "_pagesControl");
          this._pagesControl.Name = "_pagesControl";
          this._pagesControl.Action += new System.EventHandler<BarcodeMainDemo.ActionEventArgs>(this._pagesControl_Action);
          // 
          // MainForm
          // 
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.Controls.Add(this._viewerControl);
          this.Controls.Add(this._viewerSplitter);
          this.Controls.Add(this._barcodeControl);
          this.Controls.Add(this._pagesControl);
          this.Controls.Add(this._mainStatusStrip);
          this.Controls.Add(this._mainToolStrip);
          this.Controls.Add(this._mainMenuStrip);
          this.MainMenuStrip = this._mainMenuStrip;
          this.Name = "MainForm";
          this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
          this._mainMenuStrip.ResumeLayout(false);
          this._mainMenuStrip.PerformLayout();
          this._mainToolStrip.ResumeLayout(false);
          this._mainToolStrip.PerformLayout();
          this.ResumeLayout(false);
          this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.MenuStrip _mainMenuStrip;
      private System.Windows.Forms.ToolStripMenuItem _fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _newToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _openToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _saveToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _closeToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _fileSep1toolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _scanToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _selectSourceToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _acquireToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _fileSep2ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _exitToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _editToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _copyImageToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _pasteImageToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _viewToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _zoomOutToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _zoomInToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _editSep1ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _fitWidthToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _fitPageToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _pageToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _previousPageToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _nextPageToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _helpToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _aboutToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _gotoPageToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _interactiveToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _selectModeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _panModeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _zoomToModeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _drawRegionModeToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _interactiveSep1ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _deleteRegionToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _writeBarcodeModeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _barcodeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _showBarcodesToolStripMenuItem;
      private System.Windows.Forms.ToolStrip _mainToolStrip;
      private System.Windows.Forms.ToolStripButton _newToolStripButton;
      private System.Windows.Forms.ToolStripButton _openToolStripButton;
      private System.Windows.Forms.ToolStripButton _saveToolStripButton;
      private System.Windows.Forms.ToolStripSeparator _toolStripSeparator1;
      private System.Windows.Forms.StatusStrip _mainStatusStrip;
      private BarcodeMainDemo.PagesControl.PagesControl _pagesControl;
      private BarcodeMainDemo.BarcodeControls.BarcodeControl _barcodeControl;
      private BarcodeMainDemo.ViewerControl.ViewerControl _viewerControl;
      private System.Windows.Forms.ToolStripMenuItem _readBarcodesToolStripMenuItem;
      private System.Windows.Forms.ToolStripButton _readBarcodesToolStripButton;
      private System.Windows.Forms.ToolStripMenuItem _readBarcodeModeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _readBarcodeOptionsToolStripMenuItem;
      private System.Windows.Forms.ToolStripButton _readBarcodeOptionsToolStripButton;
      private System.Windows.Forms.ToolStripSeparator _barcodeSep2ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _saveCurrentReadOptionsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _loadReadOptionsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _saveCurrentWriteOptionsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _loadWriteOptionsToolStripMenuItem;
      private System.Windows.Forms.Splitter _viewerSplitter;
      private System.Windows.Forms.ToolStripButton _writeBarcodeToolStripButton;
      private System.Windows.Forms.ToolStripMenuItem _writeBarcodeToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _barcodeSep3ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _deleteSelectedBarcodeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _zoomToSelectedBarcodeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _exportBarcodesToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _clearAllBarcodesToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _barcodeSep1ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _preprocessingToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _preprocessAllPagesToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _preprocessingSep1ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _flipToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _reverseToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _rotate90ClockwiseToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _rotate90CounterclockwiseToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _noiseFiltersToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _noiseMinFilterToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _noiseMedianFilterToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _noiseMaxFilterToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _lineRemoveToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _imageDeskewToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _segmentationPerspectiveMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _perspectiveDeskewToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _barcodeImageTypeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _scannedDocumentImageTypeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _pictureImageTypeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _unknownImageTypeToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _barcodeReturnBoundariesToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _returnBoundingRectToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _returnFourPointsToolStripMenuItem;
   }
}