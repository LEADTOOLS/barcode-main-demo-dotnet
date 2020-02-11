namespace BarcodeMainDemo.PagesControl
{
   partial class PagesControl
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PagesControl));
          this._titleLabel = new System.Windows.Forms.Label();
          this._rasterImageList = new Leadtools.Controls.ImageViewer(new Leadtools.Controls.ImageViewerVerticalViewLayout() { Columns = 1 });
          this._toolStrip = new System.Windows.Forms.ToolStrip();
          this.SuspendLayout();
          // 
          // _titleLabel
          // 
          resources.ApplyResources(this._titleLabel, "_titleLabel");
          this._titleLabel.Name = "_titleLabel";
          // 
          // _rasterImageList
          // 
          this._rasterImageList.BackColor = System.Drawing.SystemColors.AppWorkspace;
          this._rasterImageList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          resources.ApplyResources(this._rasterImageList, "_rasterImageList");
          this._rasterImageList.ItemSizeMode = Leadtools.Controls.ControlSizeMode.Fit;
          this._rasterImageList.ItemSize = new Leadtools.LeadSize(180, 200);
          this._rasterImageList.Name = "_rasterImageList";
          this._rasterImageList.UseDpi = true;
          this._rasterImageList.SelectedItemsChanged += new System.EventHandler(this._rasterImageList_SelectedIndexChanged);
          this._rasterImageList.ViewHorizontalAlignment = Leadtools.Controls.ControlAlignment.Center;
          this._rasterImageList.ItemSpacing = new Leadtools.LeadSize(20, 20);
          this._rasterImageList.ItemBorderThickness = 2;
          this._rasterImageList.SelectedItemBorderColor = System.Drawing.Color.Blue;
          this._rasterImageList.Dock = System.Windows.Forms.DockStyle.Left;
          this._rasterImageList.Location = new System.Drawing.Point(0, 93);
          this._rasterImageList.Size = new System.Drawing.Size(197, 475);
          this._rasterImageList.InteractiveModes.Add(new Leadtools.Controls.ImageViewerSelectItemsInteractiveMode() { SelectionMode = Leadtools.Controls.ImageViewerSelectionMode.Single });
          // 
          // _toolStrip
          // 
          resources.ApplyResources(this._toolStrip, "_toolStrip");
          this._toolStrip.Name = "_toolStrip";
          // 
          // PagesControl
          // 
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.Controls.Add(this._rasterImageList);
          this.Controls.Add(this._toolStrip);
          this.Controls.Add(this._titleLabel);
          this.Name = "PagesControl";
          this.ResumeLayout(false);
          this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label _titleLabel;
      private Leadtools.Controls.ImageViewer _rasterImageList;
      private System.Windows.Forms.ToolStrip _toolStrip;
   }
}
