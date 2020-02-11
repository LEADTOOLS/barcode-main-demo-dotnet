namespace BarcodeMainDemo.BarcodeControls
{
   partial class ReadBarcodeOptionsDialogBox
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReadBarcodeOptionsDialogBox));
          this._okButton = new System.Windows.Forms.Button();
          this._cancelButton = new System.Windows.Forms.Button();
          this._helpButton = new System.Windows.Forms.Button();
          this._mainPanel = new System.Windows.Forms.Panel();
          this._bottomPanel = new System.Windows.Forms.Panel();
          this._selectedPanel = new System.Windows.Forms.Panel();
          this._addAllSupportedSymbologiesButton = new System.Windows.Forms.Button();
          this._removeAllButton = new System.Windows.Forms.Button();
          this._removeButton = new System.Windows.Forms.Button();
          this._toReadSymbologyListBox = new BarcodeMainDemo.BarcodeControls.SymbologyListBox();
          this._toReadLabel = new System.Windows.Forms.Label();
          this._availablePanel = new System.Windows.Forms.Panel();
          this._allGroupSymbologesAddedLabel = new System.Windows.Forms.Label();
          this._addAllButton = new System.Windows.Forms.Button();
          this._addButton = new System.Windows.Forms.Button();
          this._availableSymbologyListBox = new BarcodeMainDemo.BarcodeControls.SymbologyListBox();
          this._availableLabel = new System.Windows.Forms.Label();
          this._mainSplitter = new System.Windows.Forms.Splitter();
          this._topPanel = new System.Windows.Forms.Panel();
          this._groupOptionsResetToDefaultsButton = new System.Windows.Forms.Button();
          this._groupPropertyGrid = new System.Windows.Forms.PropertyGrid();
          this._groupOptionsLabel = new System.Windows.Forms.Label();
          this._groupsLabel = new System.Windows.Forms.Label();
          this._groupsListBox = new System.Windows.Forms.ListBox();
          this._readBarcodesWhenDialogClosesCheckBox = new System.Windows.Forms.CheckBox();
          this._mainPanel.SuspendLayout();
          this._bottomPanel.SuspendLayout();
          this._selectedPanel.SuspendLayout();
          this._availablePanel.SuspendLayout();
          this._topPanel.SuspendLayout();
          this.SuspendLayout();
          // 
          // _okButton
          // 
          resources.ApplyResources(this._okButton, "_okButton");
          this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
          this._okButton.Name = "_okButton";
          this._okButton.UseVisualStyleBackColor = true;
          this._okButton.Click += new System.EventHandler(this._okButton_Click);
          // 
          // _cancelButton
          // 
          resources.ApplyResources(this._cancelButton, "_cancelButton");
          this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          this._cancelButton.Name = "_cancelButton";
          this._cancelButton.UseVisualStyleBackColor = true;
          // 
          // _helpButton
          // 
          resources.ApplyResources(this._helpButton, "_helpButton");
          this._helpButton.Name = "_helpButton";
          this._helpButton.UseVisualStyleBackColor = true;
          this._helpButton.Click += new System.EventHandler(this._helpButton_Click);
          // 
          // _mainPanel
          // 
          resources.ApplyResources(this._mainPanel, "_mainPanel");
          this._mainPanel.Controls.Add(this._bottomPanel);
          this._mainPanel.Controls.Add(this._mainSplitter);
          this._mainPanel.Controls.Add(this._topPanel);
          this._mainPanel.Name = "_mainPanel";
          // 
          // _bottomPanel
          // 
          this._bottomPanel.Controls.Add(this._selectedPanel);
          this._bottomPanel.Controls.Add(this._availablePanel);
          resources.ApplyResources(this._bottomPanel, "_bottomPanel");
          this._bottomPanel.Name = "_bottomPanel";
          // 
          // _selectedPanel
          // 
          this._selectedPanel.Controls.Add(this._addAllSupportedSymbologiesButton);
          this._selectedPanel.Controls.Add(this._removeAllButton);
          this._selectedPanel.Controls.Add(this._removeButton);
          this._selectedPanel.Controls.Add(this._toReadSymbologyListBox);
          this._selectedPanel.Controls.Add(this._toReadLabel);
          resources.ApplyResources(this._selectedPanel, "_selectedPanel");
          this._selectedPanel.Name = "_selectedPanel";
          // 
          // _addAllSupportedSymbologiesButton
          // 
          resources.ApplyResources(this._addAllSupportedSymbologiesButton, "_addAllSupportedSymbologiesButton");
          this._addAllSupportedSymbologiesButton.Name = "_addAllSupportedSymbologiesButton";
          this._addAllSupportedSymbologiesButton.UseVisualStyleBackColor = true;
          this._addAllSupportedSymbologiesButton.Click += new System.EventHandler(this._addAllSupportedSymbologiesButton_Click);
          // 
          // _removeAllButton
          // 
          resources.ApplyResources(this._removeAllButton, "_removeAllButton");
          this._removeAllButton.Name = "_removeAllButton";
          this._removeAllButton.UseVisualStyleBackColor = true;
          this._removeAllButton.Click += new System.EventHandler(this._removeAllButton_Click);
          // 
          // _removeButton
          // 
          resources.ApplyResources(this._removeButton, "_removeButton");
          this._removeButton.Name = "_removeButton";
          this._removeButton.UseVisualStyleBackColor = true;
          this._removeButton.Click += new System.EventHandler(this._removeButton_Click);
          // 
          // _toReadSymbologyListBox
          // 
          resources.ApplyResources(this._toReadSymbologyListBox, "_toReadSymbologyListBox");
          this._toReadSymbologyListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
          this._toReadSymbologyListBox.FormattingEnabled = true;
          this._toReadSymbologyListBox.MultiColumn = true;
          this._toReadSymbologyListBox.Name = "_toReadSymbologyListBox";
          this._toReadSymbologyListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
          this._toReadSymbologyListBox.ItemDoubleClicked += new System.EventHandler<BarcodeMainDemo.BarcodeControls.SymbologyListBoxItemDoubleClickedEventArgs>(this._toReadSymbologyListBox_ItemDoubleClicked);
          this._toReadSymbologyListBox.SelectedIndexChanged += new System.EventHandler(this._toReadSymbologyListBox_SelectedIndexChanged);
          // 
          // _toReadLabel
          // 
          resources.ApplyResources(this._toReadLabel, "_toReadLabel");
          this._toReadLabel.Name = "_toReadLabel";
          // 
          // _availablePanel
          // 
          this._availablePanel.Controls.Add(this._allGroupSymbologesAddedLabel);
          this._availablePanel.Controls.Add(this._addAllButton);
          this._availablePanel.Controls.Add(this._addButton);
          this._availablePanel.Controls.Add(this._availableSymbologyListBox);
          this._availablePanel.Controls.Add(this._availableLabel);
          resources.ApplyResources(this._availablePanel, "_availablePanel");
          this._availablePanel.Name = "_availablePanel";
          // 
          // _allGroupSymbologesAddedLabel
          // 
          resources.ApplyResources(this._allGroupSymbologesAddedLabel, "_allGroupSymbologesAddedLabel");
          this._allGroupSymbologesAddedLabel.Name = "_allGroupSymbologesAddedLabel";
          // 
          // _addAllButton
          // 
          resources.ApplyResources(this._addAllButton, "_addAllButton");
          this._addAllButton.Name = "_addAllButton";
          this._addAllButton.UseVisualStyleBackColor = true;
          this._addAllButton.Click += new System.EventHandler(this._addAllButton_Click);
          // 
          // _addButton
          // 
          resources.ApplyResources(this._addButton, "_addButton");
          this._addButton.Name = "_addButton";
          this._addButton.UseVisualStyleBackColor = true;
          this._addButton.Click += new System.EventHandler(this._addButton_Click);
          // 
          // _availableSymbologyListBox
          // 
          resources.ApplyResources(this._availableSymbologyListBox, "_availableSymbologyListBox");
          this._availableSymbologyListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
          this._availableSymbologyListBox.FormattingEnabled = true;
          this._availableSymbologyListBox.Name = "_availableSymbologyListBox";
          this._availableSymbologyListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
          this._availableSymbologyListBox.ItemDoubleClicked += new System.EventHandler<BarcodeMainDemo.BarcodeControls.SymbologyListBoxItemDoubleClickedEventArgs>(this._availableSymbologyListBox_ItemDoubleClicked);
          this._availableSymbologyListBox.SelectedIndexChanged += new System.EventHandler(this._availableSymbologyListBox_SelectedIndexChanged);
          // 
          // _availableLabel
          // 
          resources.ApplyResources(this._availableLabel, "_availableLabel");
          this._availableLabel.Name = "_availableLabel";
          // 
          // _mainSplitter
          // 
          resources.ApplyResources(this._mainSplitter, "_mainSplitter");
          this._mainSplitter.Name = "_mainSplitter";
          this._mainSplitter.TabStop = false;
          // 
          // _topPanel
          // 
          this._topPanel.Controls.Add(this._groupOptionsResetToDefaultsButton);
          this._topPanel.Controls.Add(this._groupPropertyGrid);
          this._topPanel.Controls.Add(this._groupOptionsLabel);
          this._topPanel.Controls.Add(this._groupsLabel);
          this._topPanel.Controls.Add(this._groupsListBox);
          resources.ApplyResources(this._topPanel, "_topPanel");
          this._topPanel.Name = "_topPanel";
          // 
          // _groupOptionsResetToDefaultsButton
          // 
          resources.ApplyResources(this._groupOptionsResetToDefaultsButton, "_groupOptionsResetToDefaultsButton");
          this._groupOptionsResetToDefaultsButton.Name = "_groupOptionsResetToDefaultsButton";
          this._groupOptionsResetToDefaultsButton.UseVisualStyleBackColor = true;
          this._groupOptionsResetToDefaultsButton.Click += new System.EventHandler(this._groupOptionsResetToDefaultsButton_Click);
          // 
          // _groupPropertyGrid
          // 
          resources.ApplyResources(this._groupPropertyGrid, "_groupPropertyGrid");
          this._groupPropertyGrid.Name = "_groupPropertyGrid";
          this._groupPropertyGrid.ToolbarVisible = false;
          // 
          // _groupOptionsLabel
          // 
          resources.ApplyResources(this._groupOptionsLabel, "_groupOptionsLabel");
          this._groupOptionsLabel.Name = "_groupOptionsLabel";
          // 
          // _groupsLabel
          // 
          resources.ApplyResources(this._groupsLabel, "_groupsLabel");
          this._groupsLabel.Name = "_groupsLabel";
          // 
          // _groupsListBox
          // 
          resources.ApplyResources(this._groupsListBox, "_groupsListBox");
          this._groupsListBox.FormattingEnabled = true;
          this._groupsListBox.Name = "_groupsListBox";
          this._groupsListBox.SelectedIndexChanged += new System.EventHandler(this._groupsListBox_SelectedIndexChanged);
          // 
          // _readBarcodesWhenDialogClosesCheckBox
          // 
          resources.ApplyResources(this._readBarcodesWhenDialogClosesCheckBox, "_readBarcodesWhenDialogClosesCheckBox");
          this._readBarcodesWhenDialogClosesCheckBox.Name = "_readBarcodesWhenDialogClosesCheckBox";
          this._readBarcodesWhenDialogClosesCheckBox.UseVisualStyleBackColor = true;
          // 
          // ReadBarcodeOptionsDialogBox
          // 
          this.AcceptButton = this._okButton;
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._cancelButton;
          this.Controls.Add(this._readBarcodesWhenDialogClosesCheckBox);
          this.Controls.Add(this._mainPanel);
          this.Controls.Add(this._helpButton);
          this.Controls.Add(this._cancelButton);
          this.Controls.Add(this._okButton);
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "ReadBarcodeOptionsDialogBox";
          this.ShowIcon = false;
          this.ShowInTaskbar = false;
          this._mainPanel.ResumeLayout(false);
          this._bottomPanel.ResumeLayout(false);
          this._selectedPanel.ResumeLayout(false);
          this._selectedPanel.PerformLayout();
          this._availablePanel.ResumeLayout(false);
          this._availablePanel.PerformLayout();
          this._topPanel.ResumeLayout(false);
          this._topPanel.PerformLayout();
          this.ResumeLayout(false);
          this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button _okButton;
      private System.Windows.Forms.Button _cancelButton;
      private System.Windows.Forms.Button _helpButton;
      private System.Windows.Forms.Panel _mainPanel;
      private System.Windows.Forms.Panel _topPanel;
      private System.Windows.Forms.Label _groupOptionsLabel;
      private System.Windows.Forms.Label _groupsLabel;
      private System.Windows.Forms.ListBox _groupsListBox;
      private System.Windows.Forms.PropertyGrid _groupPropertyGrid;
      private System.Windows.Forms.Splitter _mainSplitter;
      private System.Windows.Forms.Panel _bottomPanel;
      private System.Windows.Forms.Panel _availablePanel;
      private System.Windows.Forms.Button _addAllButton;
      private System.Windows.Forms.Button _addButton;
      private SymbologyListBox _availableSymbologyListBox;
      private System.Windows.Forms.Label _availableLabel;
      private System.Windows.Forms.Panel _selectedPanel;
      private System.Windows.Forms.Button _removeAllButton;
      private System.Windows.Forms.Button _removeButton;
      private SymbologyListBox _toReadSymbologyListBox;
      private System.Windows.Forms.Label _toReadLabel;
      private System.Windows.Forms.Button _groupOptionsResetToDefaultsButton;
      private System.Windows.Forms.Label _allGroupSymbologesAddedLabel;
      private System.Windows.Forms.Button _addAllSupportedSymbologiesButton;
      private System.Windows.Forms.CheckBox _readBarcodesWhenDialogClosesCheckBox;
   }
}