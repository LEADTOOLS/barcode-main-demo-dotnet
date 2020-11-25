// *************************************************************
// Copyright (c) 1991-2020 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Windows.Forms;
using System.Text;
using System.Drawing;
using System.Collections.Generic;

using Leadtools;
using Leadtools.Codecs;
using Leadtools.WinForms.CommonDialogs.File;

namespace Leadtools.Demos
{
   public class ImageFileLoader
   {
      private static int _filterIndex = 1;
      private string _fileName;
      private RasterOpenDialogLoadFormat[] _filters;
      private RasterImage _image;
      private bool _loadOnlyOnePage = false;
      private int _firstPage;
      private int _lastPage;
      private bool _showLoadPagesDialog = false;
      private bool _showPdfOptions = true;
      private bool _showXpsOptions = true;
      private bool _loadCorrupted = false;
      private bool _showXlsOptions = true;
      private bool _showRasterizeDocumentOptions = true;
      private bool _showVffOptions = true;
      private bool _showAnzOptions = true;
      private bool _showVectorOptions = true;
      private bool _multiSelect = false;
      private bool _useGdiPlus = false;
      private string _openDialogInitialPath;
      private bool _preferVector = false;

      private List<ImageInformation> _images = new List<ImageInformation>();

      public ImageFileLoader()
      {
      }

      public string FileName
      {
         get
         {
            return _fileName;
         }
         set
         {
            _fileName = value;
         }
      }

      public RasterImage Image
      {
         get
         {
            return _image;
         }
      }

      public List<ImageInformation> Images
      {
         get
         {
            return _images;
         }
      }

      public RasterOpenDialogLoadFormat[] Filters
      {
         get
         {
            return _filters;
         }
         set
         {
            _filters = value;
         }
      }

      public bool ShowLoadPagesDialog
      {
         get
         {
            return _showLoadPagesDialog;
         }
         set
         {
            _showLoadPagesDialog = value;
         }
      }

      public bool LoadOnlyOnePage
      {
         get
         {
            return _loadOnlyOnePage;
         }
         set
         {
            _loadOnlyOnePage = value;
         }
      }

      public static int FilterIndex
      {
         get
         {
            return _filterIndex;
         }
         set
         {
            _filterIndex = value;
         }
      }

      public int FirstPage
      {
         get
         {
            return _firstPage;
         }
      }

      public int LastPage
      {
         get
         {
            return _lastPage;
         }
      }

      public bool ShowPdfOptions
      {
         get
         {
            return _showPdfOptions;
         }
         set
         {
            _showPdfOptions = value;
         }
      }

      public bool ShowXpsOptions
      {
         get
         {
            return _showXpsOptions;
         }
         set
         {
            _showXpsOptions = value;
         }
      }

      public bool ShowXlsOptions
      {
         get
         {
            return _showXlsOptions;
         }
         set
         {
            _showXlsOptions = value;
         }
      }

      public bool ShowRasterizeDocumentOptions
      {
         get
         {
            return _showRasterizeDocumentOptions;
         }
         set
         {
            _showRasterizeDocumentOptions = value;
         }
      }

      public bool ShowVffOptions
      {
         get
         {
            return _showVffOptions;
         }
         set
         {
            _showVffOptions = value;
         }
      }

      public bool ShowAnzOptions
      {
         get
         {
            return _showAnzOptions;
         }
         set
         {
            _showAnzOptions = value;
         }
      }

      public bool ShowVectorOptions
      {
         get
         {
            return _showVectorOptions;
         }
         set
         {
            _showVectorOptions = value;
         }
      }

      public bool MultiSelect
      {
         get
         {
            return _multiSelect;
         }
         set
         {
            _multiSelect = value;
         }
      }

      public bool LoadCorrupted
      {
         get
         {
            return _loadCorrupted;
         }
         set
         {
            _loadCorrupted = value;
         }
      }

      public bool PreferVector
      {
         get
         {
            return _preferVector;
         }
         set
         {
            _preferVector = value;
         }
      }

      public bool UseGdiPlus
      {
         get { return _useGdiPlus; }
         set { _useGdiPlus = value; }
      }

      public string OpenDialogInitialPath
      {
         get
         {
            return _openDialogInitialPath;
         }
         set
         {
            _openDialogInitialPath = value;
         }
      }

      private bool Is64
      {
         get
         {
            return IntPtr.Size == 8;
         }
      }

      private int maxDocPages
      {
         get
         {
            if (Is64)
               return 200;
            else
               return 96;
         }
      }

      private const int maxDocResolution = 96;

      private bool SetDocumentLoadResultion(RasterCodecs codecs, CodecsImageInfo info, int firstPage, int lastPage)
      {
         if (!Is64) // No limit for x64
         {
            if (info.Document.IsDocumentFile) // if the file is a document file format
            {
               if (firstPage < 1)
                  firstPage = 1;

               if ((((lastPage == -1) && (info.TotalPages > maxDocPages)) || (lastPage - firstPage + 1 > maxDocPages)) && ((codecs.Options.RasterizeDocument.Load.XResolution > maxDocResolution) || (codecs.Options.RasterizeDocument.Load.YResolution > maxDocResolution)))
               {
                  string promptMessage = string.Format("You are trying to load a document file which has more than {0} pages at {1} dpi.{2}{2}", maxDocPages, codecs.Options.RasterizeDocument.Load.XResolution, Environment.NewLine);
                  promptMessage = string.Format("{0}This can cause performance issues on machines with limited resources.{1}{1}", promptMessage, Environment.NewLine);
                  promptMessage = string.Format("{0}Click 'Yes' to reduce the resolution and continue loading or click 'No' to continue loading with the current resolution.", promptMessage);
                  DialogResult result = MessageBox.Show(promptMessage, "Warning", MessageBoxButtons.YesNoCancel);
                  switch (result)
                  {
                     case DialogResult.Yes:
                        codecs.Options.RasterizeDocument.Load.XResolution = 96;
                        codecs.Options.RasterizeDocument.Load.YResolution = 96;
                        break;
                     case DialogResult.No:
                        break;
                     case DialogResult.Cancel:
                        return false;
                  }
               }
            }
         }
         return true;
      }

      //Use this load to load a specific image without showing the open dialog
      public bool Load(IWin32Window owner, string fileName, RasterCodecs codecs, int firstPage, int lastPage)
      {
         _fileName = fileName;
         _firstPage = firstPage;
         _lastPage = lastPage;

         using (WaitCursor wait = new WaitCursor())
         {
            using(CodecsImageInfo info = codecs.GetInformation(FileName, true))
            {
               if (!SetDocumentLoadResultion(codecs, info, firstPage, lastPage))
                  return false;
            }
            _image = codecs.Load(FileName, 0, CodecsLoadByteOrder.BgrOrGray, _firstPage, _lastPage);
         }

         return true;
      }

      //Use this load to load an image using the open dialog
      public int Load(IWin32Window owner, RasterCodecs codecs, bool autoLoad)
      {
         using(RasterOpenDialog ofd = new RasterOpenDialog(codecs))
         {
            ofd.DereferenceLinks = true;
            ofd.CheckFileExists = false;
            ofd.CheckPathExists = true;
            ofd.EnableSizing = true;
            ofd.Filter = Filters;
            ofd.FilterIndex = _filterIndex;
            ofd.LoadFileImage = false;
            ofd.LoadOptions = false;
            ofd.LoadRotated = true;
            ofd.LoadCompressed = true;
            ofd.LoadMultithreaded = codecs.Options.Jpeg.Load.Multithreaded;
            ofd.ShowLoadMultithreaded = true;
            ofd.Multiselect = _multiSelect;
            ofd.ShowGeneralOptions = true;
            ofd.ShowLoadCompressed = true;
            ofd.ShowLoadOptions = true;
            ofd.ShowLoadRotated = true;
            ofd.ShowMultipage = true;
            ofd.UseGdiPlus = UseGdiPlus;
            ofd.ShowPdfOptions = ShowPdfOptions;
            ofd.ShowXpsOptions = ShowXpsOptions;
            ofd.ShowXlsOptions = ShowXlsOptions;
            ofd.ShowRasterizeDocumentOptions = ShowRasterizeDocumentOptions;
            ofd.EnableFileInfoModeless = true;
            ofd.EnableFileInfoResizing = true;
            ofd.ShowVffOptions = ShowVffOptions;
            ofd.ShowAnzOptions = ShowAnzOptions;
            ofd.ShowVectorOptions = ShowVectorOptions;
            ofd.ShowPreview = true;
            ofd.ShowProgressive = true;
            ofd.ShowRasterOptions = true;
            ofd.ShowTotalPages = true;
            ofd.ShowDeletePage = true;
            ofd.ShowFileInformation = true;
            ofd.UseFileStamptoPreview = true;
            ofd.PreviewWindowVisible = true;
            ofd.Title = "LEADTOOLS Open Dialog";
            ofd.FileName = FileName;
            ofd.LoadCorrupted = LoadCorrupted;
            ofd.PreferVector = PreferVector;
            if (!String.IsNullOrEmpty(_openDialogInitialPath))
               ofd.InitialDirectory = _openDialogInitialPath;

            if(ofd.ShowDialog(owner) == DialogResult.OK)
            {
               foreach(RasterDialogFileData item in ofd.OpenedFileData)
               {
                  FileName = item.Name;

                  _filterIndex = ofd.FilterIndex;

                  // Set the RasterizeDocument load options before calling GetInformation
                  codecs.Options.RasterizeDocument.Load.PageWidth = item.Options.RasterizeDocumentOptions.PageWidth;
                  codecs.Options.RasterizeDocument.Load.PageHeight = item.Options.RasterizeDocumentOptions.PageHeight;
                  codecs.Options.RasterizeDocument.Load.LeftMargin = item.Options.RasterizeDocumentOptions.LeftMargin;
                  codecs.Options.RasterizeDocument.Load.TopMargin = item.Options.RasterizeDocumentOptions.TopMargin;
                  codecs.Options.RasterizeDocument.Load.RightMargin = item.Options.RasterizeDocumentOptions.RightMargin;
                  codecs.Options.RasterizeDocument.Load.BottomMargin = item.Options.RasterizeDocumentOptions.BottomMargin;
                  codecs.Options.RasterizeDocument.Load.Unit = item.Options.RasterizeDocumentOptions.Unit;
                  codecs.Options.RasterizeDocument.Load.XResolution = item.Options.RasterizeDocumentOptions.XResolution;
                  codecs.Options.RasterizeDocument.Load.YResolution = item.Options.RasterizeDocumentOptions.YResolution;
                  codecs.Options.RasterizeDocument.Load.SizeMode = item.Options.RasterizeDocumentOptions.SizeMode;

                  if (item.FileInfo.Format == RasterImageFormat.Afp || item.FileInfo.Format == RasterImageFormat.Ptoca)
                  {
                     codecs.Options.Ptoka.Load.Resolution = codecs.Options.RasterizeDocument.Load.XResolution;
                  }

                  // Set the user Options
                  codecs.Options.Load.Passes = item.Passes;
                  codecs.Options.Load.Rotated = item.LoadRotated;
                  codecs.Options.Load.Compressed = item.LoadCompressed;
                  codecs.Options.Load.LoadCorrupted = ofd.LoadCorrupted;
                  codecs.Options.Load.PreferVector = ofd.PreferVector;
                  codecs.Options.Jpeg.Load.Multithreaded = item.LoadMultithreaded;

                  switch(item.Options.FileType)
                  {
                     case RasterDialogFileOptionsType.Meta:
                        {
                           // Set the user options
                           codecs.Options.Wmf.Load.XResolution = item.Options.MetaOptions.XResolution;
                           codecs.Options.Wmf.Load.YResolution = item.Options.MetaOptions.XResolution;
                           break;
                        }

                     case RasterDialogFileOptionsType.Pdf:
                        {
                           if(codecs.Options.Pdf.Load.UsePdfEngine)
                           {
                              // Set the user options
                              codecs.Options.Pdf.Load.DisplayDepth = item.Options.PdfOptions.DisplayDepth;
                              codecs.Options.Pdf.Load.GraphicsAlpha = item.Options.PdfOptions.GraphicsAlpha;
                              codecs.Options.Pdf.Load.TextAlpha = item.Options.PdfOptions.TextAlpha;
                              codecs.Options.Pdf.Load.UseLibFonts = item.Options.PdfOptions.UseLibFonts;
                           }

                           break;
                        }

                     case RasterDialogFileOptionsType.Misc:
                        {
                           switch(item.FileInfo.Format)
                           {
                              case RasterImageFormat.Jbig:
                                 {
                                    // Set the user options
                                    codecs.Options.Jbig.Load.Resolution = new LeadSize(item.Options.MiscOptions.XResolution,
                                                                                    item.Options.MiscOptions.YResolution);
                                    break;
                                 }

                              case RasterImageFormat.Cmw:
                                 {
                                    // Set the user options
                                    codecs.Options.Jpeg2000.Load.CmwResolution = new LeadSize(item.Options.MiscOptions.XResolution,
                                                                                          item.Options.MiscOptions.YResolution);
                                    break;
                                 }

                              case RasterImageFormat.Jp2:
                                 {
                                    // Set the user options
                                    codecs.Options.Jpeg2000.Load.Jp2Resolution = new LeadSize(item.Options.MiscOptions.XResolution,
                                                                                          item.Options.MiscOptions.YResolution);
                                    break;
                                 }

                              case RasterImageFormat.J2k:
                                 {
                                    // Set the user options
                                    codecs.Options.Jpeg2000.Load.J2kResolution = new LeadSize(item.Options.MiscOptions.XResolution,
                                                                                          item.Options.MiscOptions.YResolution);
                                    break;
                                 }

                              case RasterImageFormat.TifJ2k:
                                 {
                                    // Set the user options
                                    codecs.Options.Tiff.Load.J2kResolution = new LeadSize(item.Options.MiscOptions.XResolution,
                                                                                          item.Options.MiscOptions.YResolution);
                                    break;
                                 }
                           }

                           break;
                        }
                     case RasterDialogFileOptionsType.Xls:
                        {
                           // Set the user options
                           codecs.Options.Xls.Load.MultiPageSheet = item.Options.XlsOptions.MultiPageSheet;
                           codecs.Options.Xls.Load.ShowHiddenSheet = item.Options.XlsOptions.ShowHiddenSheet;
#if LEADTOOLS_V20_OR_LATER
                           codecs.Options.Xls.Load.MultiPageUseSheetWidth = item.Options.XlsOptions.MultiPageUseSheetWidth;
                           codecs.Options.Xls.Load.PageOrderDownThenOver = item.Options.XlsOptions.PageOrderDownThenOver;
                           codecs.Options.Xls.Load.MultiPageEnableMargins = item.Options.XlsOptions.MultiPageEnableMargins;
#endif //#if LEADTOOLS_V20_OR_LATER
                        }
                        break;
                     case RasterDialogFileOptionsType.Vff:
                        {
                           codecs.Options.Vff.Load.View = item.Options.VffOptions.View;
                           break;
                        }
                     case RasterDialogFileOptionsType.Anz:
                        {
                           codecs.Options.Anz.Load.View = item.Options.AnzOptions.View;
                           break;
                        }
                     case RasterDialogFileOptionsType.Vector:
                        {
                           codecs.Options.Vector.Load.BackgroundColor = item.Options.VectorOptions.Options.BackgroundColor;
                           codecs.Options.Vector.Load.BitsPerPixel = item.Options.VectorOptions.Options.BitsPerPixel;
                           codecs.Options.Vector.Load.ForceBackgroundColor = item.Options.VectorOptions.Options.ForceBackgroundColor;
                           codecs.Options.Vector.Load.ViewHeight = item.Options.VectorOptions.Options.ViewHeight;
                           codecs.Options.Vector.Load.ViewMode = item.Options.VectorOptions.Options.ViewMode;
                           codecs.Options.Vector.Load.ViewWidth = item.Options.VectorOptions.Options.ViewWidth;
                           break;
                        }
                  }

                  int firstPage = 1;
                  int lastPage = 1;
                  int infoTotalPages;

                  CodecsImageInfo info = null;

                  using (WaitCursor wait = new WaitCursor())
                  {
                     info = codecs.GetInformation(FileName, true);
                     infoTotalPages = info.TotalPages;
                  }

                  if(_showLoadPagesDialog)
                  {
                     firstPage = 1;
                     lastPage = infoTotalPages;

                     if(firstPage != lastPage)
                     {
                        using(ImageFileLoaderPagesDialog dlg = new ImageFileLoaderPagesDialog(infoTotalPages, LoadOnlyOnePage))
                        {
                           if(dlg.ShowDialog(owner) == DialogResult.OK)
                           {
                              firstPage = dlg.FirstPage;
                              lastPage = dlg.LastPage;
                           }
                           else
                           {
                              if(info != null)
                                 info.Dispose();
                              return 0;
                           }
                        }
                     }
                  }
                  else
                  {
                     firstPage = item.PageNumber;
                     lastPage = item.PageNumber;
                  }

                  _firstPage = firstPage;
                  _lastPage = lastPage;

                  if (!SetDocumentLoadResultion(codecs, info, firstPage, lastPage))
                  {
                     info.Dispose();
                     return 0;
                  }

                  if(autoLoad)
                  {
                     using(WaitCursor wait = new WaitCursor())
                     {
                        _image = codecs.Load(FileName, 0, CodecsLoadByteOrder.BgrOrGray, firstPage, lastPage);
                        if (codecs.LoadStatus != RasterExceptionCode.Success)
                        {
                           String message = String.Format("The image was only partially loaded due to error: {0}", codecs.LoadStatus.ToString());
                           Messager.Show(null, message, MessageBoxIcon.Information, MessageBoxButtons.OK);
                        }
                        if (_image != null)
                        {
                           _image.CustomData.Add("IsBigTiff", info.Tiff.IsBigTiff);
                           _images.Add(new ImageInformation(_image, item.Name));
                        }
                     }
                  }
                  info.Dispose();
               }
            }

            return ofd.OpenedFileData.Count;
         }
      }
   }
}
