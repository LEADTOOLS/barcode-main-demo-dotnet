// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Leadtools;
using Leadtools.Barcode;

namespace BarcodeMainDemo.BarcodeControls
{

   
   public partial class AAMVADialogBox : Form
   {

      AAMVAID _id;
      Dictionary<string, AAMVADataElementInfo> _infoDictionary;

      public AAMVADialogBox(AAMVAID id)
      {
         InitializeComponent();
         _id = id;
         this.FormClosed += HandleClose;
         _infoDictionary = (Dictionary<string, AAMVADataElementInfo>)AAMVADataElementInfo.RetrieveAll(id.Version);
         Populate();
      }

      private void Populate()
      {
         _listViewRawDataElements.View = View.Details;
         _listViewRawDataElements.Columns.Add("ElementID", -2, HorizontalAlignment.Left);
         _listViewRawDataElements.Columns.Add("Friendly Name", -2, HorizontalAlignment.Left);
         _listViewRawDataElements.Columns.Add("Subfile Code", -2, HorizontalAlignment.Left);
         _listViewRawDataElements.Columns.Add("Value", -2, HorizontalAlignment.Left);
         _listViewRawDataElements.Columns.Add("Definition", -2, HorizontalAlignment.Left);
         _listViewRawDataElements.FullRowSelect = true;

         _listViewCommonFields.View = View.Details;
         _listViewCommonFields.Columns.Add("Field", -2, HorizontalAlignment.Left);
         _listViewCommonFields.Columns.Add("Value", -2, HorizontalAlignment.Left);
         _listViewCommonFields.FullRowSelect = true;

         PopulateCommon();
         PopulateRaw();
      }

      private void PopulateCommon()
      {

         _listViewCommonFields.Items.Clear();

         //First Name
         ListViewItem firstNameItem = new ListViewItem();
         firstNameItem.Text = "First Name";
         AAMVANameResult firstNameRes = _id.FirstName;
         firstNameItem.SubItems.Add(firstNameRes == null ? "" : firstNameRes.Value);
         _listViewCommonFields.Items.Add(firstNameItem);

         //LastName
         ListViewItem lastNameItem = new ListViewItem();
         lastNameItem.Text = "Last Name";
         AAMVANameResult lastNameRes = _id.LastName;
         lastNameItem.SubItems.Add(lastNameRes == null ? "" : lastNameRes.Value);
         _listViewCommonFields.Items.Add(lastNameItem);

         //DOB
         ListViewItem dobItem = new ListViewItem();
         dobItem.Text = "Date Of Birth (YYYYMMDD)";
         string dob = _id.DateOfBirth;
         dobItem.SubItems.Add(dob == null ? "" : dob);
         _listViewCommonFields.Items.Add(dobItem);


         AAMVARegion region = _id.AddressRegion;
         //OverXX depending on region
         if (_id.Over18Available)
         {
            ListViewItem item18 = new ListViewItem();
            item18.Text = "Over 18?";
            item18.SubItems.Add(_id.Over18.ToString());
            _listViewCommonFields.Items.Add(item18);
         }

         if((region == AAMVARegion.Canada && _id.Over19Available) ||
            (region == AAMVARegion.Unknown && _id.Over19Available))
         {
            ListViewItem item19 = new ListViewItem();
            item19.Text = "Over 19?";
            item19.SubItems.Add(_id.Over19.ToString());
            _listViewCommonFields.Items.Add(item19);
         }

         if ((region == AAMVARegion.UnitedStates && _id.Over21Available) ||
            (region == AAMVARegion.Unknown && _id.Over21Available))
         {
            ListViewItem item21 = new ListViewItem();
            item21.Text = "Over 21?";
            item21.SubItems.Add(_id.Over21.ToString());
            _listViewCommonFields.Items.Add(item21);
         }

         //ID Number
         ListViewItem numberItem = new ListViewItem();
         numberItem.Text = "ID Number";
         string number = _id.Number;
         numberItem.SubItems.Add(number == null ? "" : number);
         _listViewCommonFields.Items.Add(numberItem);

         //Address Street 1
         ListViewItem addressStreet1Item = new ListViewItem();
         addressStreet1Item.Text = "Address Street 1";
         string addressStreet1 = _id.AddressStreet1;
         addressStreet1Item.SubItems.Add(addressStreet1 == null ? "" : addressStreet1);
         _listViewCommonFields.Items.Add(addressStreet1Item);

         //Address Street 2
         ListViewItem addressStreet2Item = new ListViewItem();
         addressStreet2Item.Text = "Address Street 2";
         string addressStreet2 = _id.AddressStreet2;
         addressStreet2Item.SubItems.Add(addressStreet2 == null ? "" : addressStreet2);
         _listViewCommonFields.Items.Add(addressStreet2Item);

         //Address City
         ListViewItem addressCityItem = new ListViewItem();
         addressCityItem.Text = "Address City";
         string addressCity = _id.AddressCity;
         addressCityItem.SubItems.Add(addressCity == null ? "" : addressCity);
         _listViewCommonFields.Items.Add(addressCityItem);

         //Address State Abbreviation
         ListViewItem addressStateAbbrItem = new ListViewItem();
         addressStateAbbrItem.Text = "Address State Abbreviation";
         string addressStateAbbr = _id.AddressStateAbbreviation;
         addressStateAbbrItem.SubItems.Add(addressStateAbbr == null ? "" : addressStateAbbr);
         _listViewCommonFields.Items.Add(addressStateAbbrItem);

         //Address Postal Code
         ListViewItem addressPostalCodeItem = new ListViewItem();
         addressPostalCodeItem.Text = "Address Postal Code";
         string addressPostalCode = _id.AddressPostalCode;
         addressPostalCodeItem.SubItems.Add(addressPostalCode == null ? "" : addressPostalCode);
         _listViewCommonFields.Items.Add(addressPostalCodeItem);

         //Region
         ListViewItem addressRegionItem = new ListViewItem();
         addressRegionItem.Text = "Address Region";
         addressRegionItem.SubItems.Add(region.ToString());
         _listViewCommonFields.Items.Add(addressRegionItem);

         //Expiration Date
         ListViewItem expirationDateItem = new ListViewItem();
         expirationDateItem.Text = "Expiration Date (YYYYMMDD)";
         string expirationDate = _id.ExpirationDate;
         expirationDateItem.SubItems.Add(expirationDate == null ? "" : expirationDate);
         _listViewCommonFields.Items.Add(expirationDateItem);

         //Issue Date
         ListViewItem issueDateitem = new ListViewItem();
         issueDateitem.Text = "Issue Date (YYYYMMDD)";
         string issueDate = _id.IssueDate;
         issueDateitem.SubItems.Add(issueDate == null ? "" : issueDate);
         _listViewCommonFields.Items.Add(issueDateitem);

         //Expired
         if(_id.ExpirationAvailable)
         {
            ListViewItem itemExpired = new ListViewItem();
            itemExpired.Text = "Expired?";
            itemExpired.SubItems.Add(_id.Expired.ToString());
            _listViewCommonFields.Items.Add(itemExpired);
         }

         //EyeColor
         ListViewItem eyeColorItem = new ListViewItem();
         eyeColorItem.Text = "Eye Color";
         AAMVAEyeColor eyeColor = _id.EyeColor;
         eyeColorItem.SubItems.Add(eyeColor.ToString());
         _listViewCommonFields.Items.Add(eyeColorItem);

         //HairColor
         ListViewItem hairColorItem = new ListViewItem();
         hairColorItem.Text = "Hair Color";
         AAMVAHairColor hairColor = _id.HairColor;
         hairColorItem.SubItems.Add(hairColor.ToString());
         _listViewCommonFields.Items.Add(hairColorItem);

         //Sex
         ListViewItem sexItem = new ListViewItem();
         sexItem.Text = "Sex";
         AAMVASex sex = _id.Sex;
         sexItem.SubItems.Add(sex.ToString());
         _listViewCommonFields.Items.Add(sexItem);
      }

      private void PopulateRaw()
      {
         _listViewRawDataElements.Items.Clear();

         for(int i = 0; i < _id.NumberOfEntries; i++)
         {
            IDictionary<string, AAMVADataElement> dictionary = _id.Subfiles[i].DataElements;
            foreach(KeyValuePair<string, AAMVADataElement> kvp in dictionary)
            {
               bool containsKey = _infoDictionary.ContainsKey(kvp.Key);
               AAMVADataElementInfo info = containsKey ? _infoDictionary[kvp.Key] : null;

               string[] arr = new string[5];
               arr[0] = kvp.Key;
               arr[1] = containsKey ? info.FriendlyName : "";
               arr[2] = _id.Subfiles[i].SubfileTypeCode;
               arr[3] = kvp.Value.Value;
               arr[4] = containsKey ? info.Definition : "";
               ListViewItem item = new ListViewItem(arr);
               _listViewRawDataElements.Items.Add(item);
            }
         }
      }

      private void HandleClose(object s, EventArgs e)
      {
         if(_id != null)
         {
            _id.Dispose();
            _id = null;
         }
      }

      private void _btnCloseAAMVA_Click(object sender, EventArgs e)
      {
         this.Close();
      }
   }
}
