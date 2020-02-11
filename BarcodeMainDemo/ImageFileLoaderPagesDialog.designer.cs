namespace Leadtools.Demos
{
   partial class ImageFileLoaderPagesDialog
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
      private void InitializeComponent( )
      {
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageFileLoaderPagesDialog));
          this._tbFirstPage = new System.Windows.Forms.TextBox();
          this._lblInfo = new System.Windows.Forms.Label();
          this._gbPages = new System.Windows.Forms.GroupBox();
          this._tbPageNumber = new System.Windows.Forms.TextBox();
          this._lblPageNumber = new System.Windows.Forms.Label();
          this._rbLoadMultiPages = new System.Windows.Forms.RadioButton();
          this._rbLoadSinglePage = new System.Windows.Forms.RadioButton();
          this._tbLastPage = new System.Windows.Forms.TextBox();
          this._lblLastPage = new System.Windows.Forms.Label();
          this._lblFirstPage = new System.Windows.Forms.Label();
          this._btnCancel = new System.Windows.Forms.Button();
          this._btnOk = new System.Windows.Forms.Button();
          this._gbPages.SuspendLayout();
          this.SuspendLayout();
          // 
          // _tbFirstPage
          // 
          resources.ApplyResources(this._tbFirstPage, "_tbFirstPage");
          this._tbFirstPage.Name = "_tbFirstPage";
          this._tbFirstPage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._tb_KeyPress);
          // 
          // _lblInfo
          // 
          this._lblInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._lblInfo, "_lblInfo");
          this._lblInfo.Name = "_lblInfo";
          // 
          // _gbPages
          // 
          this._gbPages.Controls.Add(this._tbPageNumber);
          this._gbPages.Controls.Add(this._lblPageNumber);
          this._gbPages.Controls.Add(this._rbLoadMultiPages);
          this._gbPages.Controls.Add(this._rbLoadSinglePage);
          this._gbPages.Controls.Add(this._tbLastPage);
          this._gbPages.Controls.Add(this._lblLastPage);
          this._gbPages.Controls.Add(this._tbFirstPage);
          this._gbPages.Controls.Add(this._lblInfo);
          this._gbPages.Controls.Add(this._lblFirstPage);
          this._gbPages.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gbPages, "_gbPages");
          this._gbPages.Name = "_gbPages";
          this._gbPages.TabStop = false;
          // 
          // _tbPageNumber
          // 
          resources.ApplyResources(this._tbPageNumber, "_tbPageNumber");
          this._tbPageNumber.Name = "_tbPageNumber";
          // 
          // _lblPageNumber
          // 
          resources.ApplyResources(this._lblPageNumber, "_lblPageNumber");
          this._lblPageNumber.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblPageNumber.Name = "_lblPageNumber";
          // 
          // _rbLoadMultiPages
          // 
          resources.ApplyResources(this._rbLoadMultiPages, "_rbLoadMultiPages");
          this._rbLoadMultiPages.Name = "_rbLoadMultiPages";
          this._rbLoadMultiPages.UseVisualStyleBackColor = true;
          this._rbLoadMultiPages.Click += new System.EventHandler(this._rbLoadMultiPages_Click);
          // 
          // _rbLoadSinglePage
          // 
          resources.ApplyResources(this._rbLoadSinglePage, "_rbLoadSinglePage");
          this._rbLoadSinglePage.Name = "_rbLoadSinglePage";
          this._rbLoadSinglePage.UseVisualStyleBackColor = true;
          this._rbLoadSinglePage.Click += new System.EventHandler(this._rbLoadSinglePage_Click);
          // 
          // _tbLastPage
          // 
          resources.ApplyResources(this._tbLastPage, "_tbLastPage");
          this._tbLastPage.Name = "_tbLastPage";
          this._tbLastPage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._tb_KeyPress);
          // 
          // _lblLastPage
          // 
          resources.ApplyResources(this._lblLastPage, "_lblLastPage");
          this._lblLastPage.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblLastPage.Name = "_lblLastPage";
          // 
          // _lblFirstPage
          // 
          resources.ApplyResources(this._lblFirstPage, "_lblFirstPage");
          this._lblFirstPage.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblFirstPage.Name = "_lblFirstPage";
          // 
          // _btnCancel
          // 
          this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          resources.ApplyResources(this._btnCancel, "_btnCancel");
          this._btnCancel.Name = "_btnCancel";
          // 
          // _btnOk
          // 
          this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
          resources.ApplyResources(this._btnOk, "_btnOk");
          this._btnOk.Name = "_btnOk";
          this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
          // 
          // ImageFileLoaderPagesDialog
          // 
          this.AcceptButton = this._btnOk;
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btnCancel;
          this.Controls.Add(this._gbPages);
          this.Controls.Add(this._btnCancel);
          this.Controls.Add(this._btnOk);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "ImageFileLoaderPagesDialog";
          this.ShowInTaskbar = false;
          this.Load += new System.EventHandler(this.ImageFileLoaderPagesDialog_Load);
          this._gbPages.ResumeLayout(false);
          this._gbPages.PerformLayout();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TextBox _tbFirstPage;
      private System.Windows.Forms.Label _lblInfo;
      private System.Windows.Forms.GroupBox _gbPages;
      private System.Windows.Forms.TextBox _tbLastPage;
      private System.Windows.Forms.Label _lblLastPage;
      private System.Windows.Forms.Label _lblFirstPage;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.TextBox _tbPageNumber;
      private System.Windows.Forms.Label _lblPageNumber;
      private System.Windows.Forms.RadioButton _rbLoadMultiPages;
      private System.Windows.Forms.RadioButton _rbLoadSinglePage;
   }
}