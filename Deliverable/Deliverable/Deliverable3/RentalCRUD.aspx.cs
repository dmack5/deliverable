using Rentals.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Rentals;
using Rentals.DAL;
using Rentals.BLL;

using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core;

//YOU NEED TO DESIGN THE CRUD PAGE FIRST!!

namespace Deliverable.Deliverable3
{
    public partial class CRUD : System.Web.UI.Page
    {
        List<string> errormsgs = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Message.DataSource = null;
            Message.DataBind();

            if (!Page.IsPostBack)
            {
                BindPropertyOwnerList();
                //BindStreetList();                         //there isn't really a Street list TO bind...
                BindAddressList();                          //you need to write a method called BindAddressList
            }
        }

        protected Exception GetInnerException(Exception ex)
        {

            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }

        protected void LoadMessageDisplay(List<string> errormsglist, string cssclass)
        {
            Message.CssClass = cssclass;
            Message.DataSource = errormsglist;
            Message.DataBind();
        }

        protected void BindPropertyOwner()
        {
            
            try
            {
                //in these bind methods, you're using a Controller to tell this page what data
                //to grab from the database and the classes.
                PropertyOwnersController sysmgr = new PropertyOwnersController();
                List<PropertyOwner> info = null;
                info = sysmgr.PropertyOwners_List(); //this is getting the data for the list from the list programmed in the PropertyOwnersController
                info.Sort((x, y) => x.name.CompareTo(y.name)); //on these lines, you need to use items from the class being used (in this case, items from PropertyOwners.cs)
                LandLordIDList.DataSource = info; //this binds the data to the dropdownlist on the CRUD page with the ID 'LandLordIDList'
                LandLordIDList.DataTextField = nameof(PropertyOwner.name);// same thing for these two
                LandLordIDList.DataValueField = nameof(PropertyOwner.landorlordID);
                LandLordIDList.DataBind();
                LandLordIDList.Items.Insert(0, "select...");

            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }
        protected void BindAddressList()
        {

            try
            {
                AddressController sysmgr = new AddressController(); //changed to AddressController
                List<Adress> info = null;   //changed to Adress
                info = sysmgr.Adress_List();        //changed to Adress_List
                info.Sort((x, y) => x.LandlordID.CompareTo(y.LandlordID)); //changed from LandLordID to LandlordID (yeah, it's that specific)
                AddressList.DataSource = info;  //tied to AddressList on CRUD page
                StreetList.DataTextField = nameof(Adress.FullAddress); //changed so that the dropdownlist lets you choose between the full addresses
                StreetList.DataValueField = nameof(Address.LandLordID);
                StreetList.DataBind();
                StreetList.Items.Insert(0, "select...");

            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }

        protected void BindStreetList()
        { 
            
            //like I said at the top, you don't really have a street list to bind

            //try
            //{
            //    Address_FindByPartialStreet sysmgr = new Address_FindByPartialStreet(); //can't use 
            //    List<> info = null;
            //    info = sysmgr.Address_List();
            //    info.Sort((x, y) => x.LandLordID.CompareTo(y.LandLordID));
            //    StreetList.DataSource = info;
            //    StreetList.DataTextField = nameof(Address.Name);
            //    StreetList.DataValueField = nameof(Address.LandLordID);
            //    StreetList.DataBind();
            //    StreetList.Items.Insert(0, "select...");

            //}
            //catch (Exception ex)
            //{
            //    errormsgs.Add(GetInnerException(ex).ToString());
            //    LoadMessageDisplay(errormsgs, "alert alert-danger");
            //}
        }
        protected void BindPropertyOwnerList()
        {
           
            try
            {
                PropertyOwnersController sysmgr = new PropertyOwnersController();
                List<PropertyOwner> info = null;
                info = sysmgr.PropertyOwners_List();
                info.Sort((x, y) => x.landorlordID.CompareTo(y.landorlordID));  //Yeah, so in your PropertyOwner.cs, you spelled LandLordID as "landorlordid" which
                                                                                // is the field that's supposed to be entered here...            

                //All the code below (in the BindPropertyOwnerList method) is meant to be used for dropdownlists on the crud page
                //You're supposed to put a dropdownlist with an ID of "PropertyOwnerList" in order to 
                //bind this data. Before you even begin to mess with the codebehind (this page) You should
                //go to your CRUD page (RentalCRUD.aspx), look at the CRUD page mockup you made (aka deliverable 2),
                //and use asp controls (things like <asp:label></asp:label>, <asp:dropdownlist></asp:dropdownlist>,
                //asp:Button></asp:Button> and whatnot) to make the RentalCRUD.aspx page look like your deliverable 2.

                PropertyOwnerList.DataSource = info;
                PropertyOwnerList.DataTextField = nameof(PropertyOwner.name);
                PropertyOwnerList.DataValueField = nameof(PropertyOwner.landorlordID);
                PropertyOwnerList.DataBind();
                PropertyOwnerList.Items.Insert(0, "select...");

                //I'll program this as a dropdownlist somewhere on your CRUD page so you have
                //an example to work from, but I can't write your entire CRUD and codebehind for you
                //Also, remember to delete these comments when you hand this in, otherwise it'll be
                //obvious that you didn't do this alone
            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            if (PropertyOwnerList.SelectedIndex == 0)
            {                                                          //this is meant to be a control check for the dropdownlist on the CRUD page. 
                errormsgs.Add("Select a LandLord");                    //Basically, this section of code says if nothing was selected on the dropdownlist
                LoadMessageDisplay(errormsgs, "alert alert-info");     //with the ID "PropertyOwnerList", the code in the else section shouldn't run and
            }                                                          //error messages should be displayed. Again, you need to pick and choose how these
            else                                                       //segments are written based on the lab specs. 
            {
                                                                                                                   
                                                                                                //You can't use the old controllers you had before, it won't
                                                                                                //work.you have to use the the new controllers I built for you.
                                                                                                //Replace all the instances of the old controllers on this page
                                                                                                //with the appropriate controllers. Use the lab specs as a guide to
                                                                                                //decide which controls and methods you need to build. For example,
                                                                                                //this Search_Click method would be good for the Rental_Addresses
                                                                                                //that is shown on the lab specs                                                                                                
                try                                                                         
                {
                    //Rentals_FindByLandLord sysmgr = new Rentals_FindByLandord();                  
                    RentalController sysmgr = new RentalController();                           //this part of the code is telling you that you are creating     
                    Rental info = null;                                                         //a new RentalController item (iI dunno what they're technically called)
                    info = sysmgr.LandLord_FindByID(int.Parse(PropertyOwnerList.SelectedValue));//and you're naming it 'sysmgr'. On the next line you're creating a new  
                    //You can't just type out whatever method you need to find your data. You   //Rental class named 'info', and it's values are null. So you
                    //need to go to the controller and type out these methods so they can       //now have a new RentalController, which is a list of Rental classes,
                    //actually be  used. In this case, you have to go to the RentalController   //and a new Rental class with empty data values (so the RentalID,
                    //and make a new item called LandLord_FindByID so you can use it.           //AddressID, RentalTypeID and whatnot are all null)        
                    //I'm going to write it for you as an example.
                    if (info == null)                                                            
                    {                                                                           
                        errormsgs.Add("LandLord is no longer available");                       
                        LoadMessageDisplay(errormsgs, "alert alert-info");     //pretty sure you don't actually need to trigger a clear event here, but it's up to you                 
                        Clear_Click(sender, e);     //you need to write a method on this page named Clear_Click (protected void Clear_Click)
                        LandLordList(); 

                    }
                    else
                    {
                        LandLordID.Text = info.LandLordID.ToString();     //this is the same problem as the dropdownlist. For these to work, something on the CRUD
                        PropertyOwnerName.Text = info.PropertyOwnerName;  //page HAS to have an ID that matches. So something on the CRUD page needs to have an ID
                                                                          //of LandLordID, and something else needs to have an ID of PropertyOwnerName.
                        if (info.LandLordID.HasValue)
                        {
                            PropertyOwnerList.SelectedValue = info.LandLordID.ToString();
                        }
                        else
                        {
                            LandLordIDList.SelectedIndex = 0;
                        }
                        if (info.Address.HasValue)
                        {
                            StreetList.SelectedValue = info.AddressID.ToString();
                        }
                        else
                        {
                            StreetList.SelectedIndex = 0;
                        }
                    }


                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
        }

        protected void AddLandLord_Click(object sender, EventArgs e)
        {
            
            if (Page.IsValid)
            {
                
                if (LandLordIDList.SelectedIndex == 0)
                {
                    errormsgs.Add("LandLord is required");
                }
              

                
                if (errormsgs.Count > 0)
                {
                    LoadMessageDisplay(errormsgs, "alert alert-info");
                }
                else
                {
                    
                    try
                    {
                        
                        Rentals_FindByLandLord sysmgr = new Rentals_FindByLandLord(); //Replace Rentals_FindByLandLord with RentalController
                       
                        LandLord item = new LandLord();             //Replace LandLord with PropertyOwner
                    
                        item.Name = Name.Text.Trim();
                        if (LanLordList.SelectedIndex == 0)
                        {
                            item.LandLordID = null;
                        }
                        else
                        {
                            item.LandLordID = int.Parse(LandLordList.SelectedValue); //something on the CRUD page needs an ID of LandLordList
                        }
                        if (StreetList.SelectedIndex == 0) //something on the CRUD page needs an ID of StreetList
                        {
                            item.Street = null;
                        }
                        else
                        {
                            item.Street = int.Parse(StreetList.SelectedValue);
                        }
                        item.QuantityPerUnit =
                            string.IsNullOrEmpty(QuantityPerUnit.Text) ? null : QuantityPerUnit.Text;
                        if (string.IsNullOrEmpty(UnitPrice.Text))
                        {
                            item.Number = null;
                        }
                        else
                        {
                            item.Number = decimal.Parse(Number.Text);
                        }
                       

                        item.Discontinued = false;
                       
                        int newLandLordID = sysmgr.LandLordID_Add(item);
                       
                        LandLordID.Text = newLandLordID.ToString();
                        errormsgs.Add("LandLord has been added");
                        LoadMessageDisplay(errormsgs, "alert alert-success");
                        
                        BindPropertyOwnerList(); 
                        LandLordIDList.SelectedValue = LandLordID.Text;
                    }
                    catch (DbUpdateException ex)
                    {
                        UpdateException updateException = (UpdateException)ex.InnerException;
                        if (updateException.InnerException != null)
                        {
                            errormsgs.Add(updateException.InnerException.Message.ToString());
                        }
                        else
                        {
                            errormsgs.Add(updateException.Message);
                        }
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (var entityValidationErrors in ex.EntityValidationErrors)
                        {
                            foreach (var validationError in entityValidationErrors.ValidationErrors)
                            {
                                errormsgs.Add(validationError.ErrorMessage);
                            }
                        }
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }
                    catch (Exception ex)
                    {
                        errormsgs.Add(GetInnerException(ex).ToString());
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }

                }
            }
        }


        protected void UpdateLandLord_Click(object sender, EventArgs e)
        {
            
            if (Page.IsValid)
            {
                
                if (LandLordIDList.SelectedIndex == 0)
                {
                    errormsgs.Add("LandLord is required");
                }



                int LandLordid = 0;
                if (string.IsNullOrEmpty(ProductID.Text))
                {
                    errormsgs.Add("Search for a LandLord to update ");
                }
                else if (!int.TryParse(LandLordID.Text, out LandLordid))
                {
                    errormsgs.Add("LandLord id is invalid");
                }
                else if (productid < 1)
                {
                    errormsgs.Add("LandLord id is invalid");
                }

               
                if (errormsgs.Count > 0)
                {
                    LoadMessageDisplay(errormsgs, "alert alert-info");
                }
                else
                {
                  
                    try
                    {
                        
                        Rentals_FindByLandlord sysmgr = new Rentals_FindByLandlord();
                     
                        Landlord item = new Landlord();
                       
                        item.LandLordID = LandLordid;
                        item.Name = Name.Text.Trim();
                        if (StreetList.SelectedIndex == 0)
                        {
                            item.Street = null;
                        }
                        else
                        {
                            item.Street = int.Parse(StreetList.SelectedValue);
                        }
                        if (StreetList.SelectedIndex == 0)
                        {
                            item.Street = null;
                        }
                        else
                        {
                            item.Street = int.Parse(StreetList.SelectedValue);
                        }
                        
                        
                        item.Discontinued = Discontinued.Checked;
                      
                        int rowsaffected = sysmgr.LandLord_Update(item);
                   
                        if (rowsaffected > 0)
                        {

                            errormsgs.Add("LandLord has been updated");
                            LoadMessageDisplay(errormsgs, "alert alert-success");
                            BindPropertyOwnerList(); 
                            LandLordIDList.SelectedValue = LandLordID.Text;
                        }
                        else
                        {
                            errormsgs.Add("landLord has not been updated. LandLord was not found");
                            LoadMessageDisplay(errormsgs, "alert alert-info");
                          
                            BindPropertyOwnerList(); 

                         
                        }

                    }
                    catch (DbUpdateException ex)
                    {
                        UpdateException updateException = (UpdateException)ex.InnerException;
                        if (updateException.InnerException != null)
                        {
                            errormsgs.Add(updateException.InnerException.Message.ToString());
                        }
                        else
                        {
                            errormsgs.Add(updateException.Message);
                        }
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (var entityValidationErrors in ex.EntityValidationErrors)
                        {
                            foreach (var validationError in entityValidationErrors.ValidationErrors)
                            {
                                errormsgs.Add(validationError.ErrorMessage);
                            }
                        }
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }
                    catch (Exception ex)
                    {
                        errormsgs.Add(GetInnerException(ex).ToString());
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }
                }
            }
        }

         protected void RemoveLandLord_Click(object sender, EventArgs e)
         {

            int LandLordid = 0;
            if (string.IsNullOrEmpty(LandLordID.Text))
            {
                    errormsgs.Add("Search for a LandLord to update");
            }
            else if (!int.TryParse(LandLordID.Text, out LandLordid))
            {
                errormsgs.Add("LandLord id is invalid");
            }
            else if (LandLordid < 1)
            {
                errormsgs.Add("LandLord id is invalid");
            }
         
         
            if (errormsgs.Count > 0)
            {
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }

            else
            {
         
                try
                {
         
                    Rentals_FindByLandlord sysmgr = new Rentals_FindByLandlord();
         
         
                    int rowsaffected = sysmgr.LandLord_Delete(LandLordid);
         
                    if (rowsaffected > 0)
                    {
         
                        errormsgs.Add("LandLord no longer exists");
                        LoadMessageDisplay(errormsgs, "alert alert-success");
                        BindPropertyOwnerList();
                        PropertyOwnerList.SelectedValue = LandLordID.Text;
                        Discontinued.Checked = true;
                    }
                    else
                    {
                        errormsgs.Add("Product has not been discontinued. Product was not found");
                        LoadMessageDisplay(errormsgs, "alert alert-warning");
         
                        BindPropertyOwnerList();
         
         
                    }
         
                }
                catch (DbUpdateException ex)
                {
                    UpdateException updateException = (UpdateException)ex.InnerException;
                    if (updateException.InnerException != null)
                    {
                        errormsgs.Add(updateException.InnerException.Message.ToString());
                    }
                    else
                    {
                        errormsgs.Add(updateException.Message);
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            errormsgs.Add(validationError.ErrorMessage);
                        }
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
         











         }

    }

}