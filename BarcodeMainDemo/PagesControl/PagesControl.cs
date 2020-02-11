// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Leadtools;
using Leadtools.Demos;
using Leadtools.WinForms;
using Leadtools.Controls;

namespace BarcodeMainDemo.PagesControl
{
   /// <summary>
   /// This control contains an instance of RasterImageList
   /// </summary>
   public partial class PagesControl : UserControl
   {
      public PagesControl()
      {
         InitializeComponent();
      }

      #region Public
      /// <summary>
      /// The instance of RasterImageList used in this viewer
      /// </summary>
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public ImageViewer RasterImageList
      {
         get
         {
            return _rasterImageList;
         }
      }

      /// <summary>
      /// Populate the control with thumbnails of the pages in the image
      /// </summary>
      public void SetDocument(RasterImage image)
      {
         _rasterImageList.BeginUpdate();
         _rasterImageList.Items.Clear();

         // Only add the thumbnails if the image has more than 1 page
         if(image != null && image.PageCount > 1)
         {
            image.DisableEvents();
            int originalImagePageNumber = image.Page;

            try
            {
               LeadSize thumbSize = _rasterImageList.ItemSize;

               for(int page = 1; page <= image.PageCount; page++)
               {
                  image.Page = page;
                  RasterImage thumbnailImage = image.CreateThumbnail(thumbSize.Width, thumbSize.Height, 24, RasterViewPerspective.TopLeft, RasterSizeFlags.Resample);

                  ImageViewerItem item = new ImageViewerItem();
                  item.Image = thumbnailImage;
                  item.PageNumber = 1;
                  item.Text = DemosGlobalization.GetResxString(GetType(), "Resx_Page") + page.ToString();

                  if(page == originalImagePageNumber)
                  {
                     item.IsSelected = true;
                  }
                  _rasterImageList.Items.Insert(page - 1, item);
               }
            }
            finally
            {
               image.Page = originalImagePageNumber;
               image.EnableEvents();
            }
         }

         _rasterImageList.EndUpdate();
      }

      /// <summary>
      /// Called from the main form when the user changes the page number
      /// from outside this control (main menu or the viewer control)
      /// </summary>
      public void SetCurrentPageNumber(int pageNumber)
      {
         if(pageNumber != CurrentPageNumber)
         {
            int pageIndex = pageNumber - 1;

            // De-select all items but 'pageIndex'

            _rasterImageList.BeginUpdate();

            for(int i = 0; i < _rasterImageList.Items.Count; i++)
            {
               ImageViewerItem item = _rasterImageList.Items[i];

               if(i == pageIndex)
               {
                  item.IsSelected = true;
               }
               else
               {
                  item.IsSelected = false;
               }
            }

            _rasterImageList.EnsureItemVisibleByIndex(pageIndex);
            _rasterImageList.EndUpdate();
         }
      }

      /// <summary>
      /// Any action that happens in this control that must be handled by the owner
      /// For example, any of the tool strip buttons clicked
      /// </summary>
      public event EventHandler<ActionEventArgs> Action;
      #endregion Public

      #region Private
      private void DoAction(string action, object data)
      {
         // Raise the action event so the main form can handle it

         if(Action != null)
         {
            Action(this, new ActionEventArgs(action, data));
         }
      }

      private int CurrentPageNumber
      {
         get
         {
            // Find the first selected item in the image list, it is
            // a single selection control
            for(int i = 0; i < _rasterImageList.Items.Count; i++)
            {
               if(_rasterImageList.Items[i].IsSelected)
               {
                  return i + 1;
               }
            }

            // No items
            return 0;
         }
      }
      #endregion Private

      #region UI
      private void _rasterImageList_SelectedIndexChanged(object sender, EventArgs e)
      {
         int pageNumber = CurrentPageNumber;
         if(pageNumber !=0)
            DoAction("PageNumberChanged", pageNumber);
      }
      #endregion UI
   }
}
