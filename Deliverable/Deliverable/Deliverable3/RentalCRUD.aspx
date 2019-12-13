<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RentalCRUD.aspx.cs" Inherits="Deliverable.Deliverable3.CRUD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="col-md-12">
        <div class="alert alert-warning">
        </div>
    </div>

<%-- I'm commenting this stuff because it's in the way
    

 <asp:RequiredFieldValidator ID="RequiredLandLords" runat="server"
        ErrorMessage="LandLord is required" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
         ControlToValidate="LandLordID"> </asp:RequiredFieldValidator>

<asp:RequiredFieldValidator ID="RequiredAddress" runat="server"
        ErrorMessage="Address is required" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
         ControlToValidate="AddressID"> </asp:RequiredFieldValidator>

	<asp:RequiredFieldValidator ID="RequiredNumber" runat="server"
        ErrorMessage="Number is required" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
         ControlToValidate="Number"> </asp:RequiredFieldValidator>
	
	<asp:RequiredFieldValidator ID="RequiredStreet" runat="server"
        ErrorMessage="Street is required" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
         ControlToValidate="Street"> </asp:RequiredFieldValidator>--%>
    
    <%--The dropdownlist below this line is the one used for the BindPropertyOwnerList in the codebehind that I wrote for an example

    <asp:DropDownList runat="server" Width="200px" ID="PropertyOwnerList"></asp:DropDownList>

    Remember, the ID is important. It's what you use to tell the codebehind (aka RentalCRUD.aspx.cs) which dropdownlist to fill with what data--%>



	 <div class="col-md-12"> 
             <asp:Label ID="LandLordLabel" runat="server" Text="LandLords"></asp:Label>&nbsp;&nbsp;
             <asp:DropDownList ID="LandLordIDList" runat="server"></asp:DropDownList>&nbsp;&nbsp;
		 <asp:LinkButton ID="Search" runat="server" Font-Size="X-Large" 
                 OnClick="Search_Click"  CausesValidation="false">Rental Address(es)?</asp:LinkButton>&nbsp;&nbsp;
		 </div>
	 <div class="col-md-12"> 
             <asp:Label ID="Address" runat="server" Text="Address(es)"></asp:Label>&nbsp;&nbsp;
             <asp:DropDownList ID="AddressList" runat="server"></asp:DropDownList>&nbsp;&nbsp;
		<asp:LinkButton ID="LinkButton1" runat="server" Font-Size="X-Large" 
               OnClick="Search_Click"  CausesValidation="false">Select</asp:LinkButton>&nbsp;&nbsp;
		 <br /><br />
		 <asp:Label ID="NumberAddress" runat="server" Text="Number"></asp:Label>
		<asp:TextBox ID="Number" runat="server"></asp:TextBox>
		 <br /><br /> 
		 <asp:Label ID="StreetAddress" runat="server" Text="Street"></asp:Label>
		 <asp:TextBox ID="Street" runat="server"></asp:TextBox>
		 <asp:LinkButton ID="LinkButton2" runat="server" Font-Size="X-Large" 
             OnClick="Search_Click"  CausesValidation="false">Address?</asp:LinkButton>&nbsp;&nbsp;
			<br /><br />
		 </div>
		 <div class="col-md-12"> 
             <asp:Label ID="FullAddress" runat="server" Text="Address(es)"></asp:Label>&nbsp;&nbsp;
             <asp:DropDownList ID="FullAddressList" runat="server"></asp:DropDownList>&nbsp;&nbsp;
		<asp:LinkButton ID="LinkButton3" runat="server" Font-Size="X-Large" 
              OnClick="Search_Click"  CausesValidation="false">Select</asp:LinkButton>&nbsp;&nbsp;

			 <br /><br />
            
             <asp:LinkButton ID="LinkButton4" runat="server" Font-Size="X-Large" 
                 OnClick="Search_Click"  CausesValidation="false">Search</asp:LinkButton>&nbsp;&nbsp;
             <asp:LinkButton ID="Clear" runat="server" Font-Size="X-Large" 
                 OnClick="Clear_Click"  CausesValidation="false">Clear</asp:LinkButton>&nbsp;&nbsp;
             <asp:LinkButton ID="AddProduct" runat="server" Font-Size="X-Large" 
                 OnClick="AddProduct_Click" >Add</asp:LinkButton>&nbsp;&nbsp;
             <asp:LinkButton ID="UpdateProduct" runat="server" Font-Size="X-Large" 
                 OnClick="UpdateProduct_Click" >Update</asp:LinkButton>&nbsp;&nbsp;
             <asp:LinkButton ID="RemoveProduct" runat="server" Font-Size="X-Large" 
                 OnClick="RemoveProduct_Click"  CausesValidation="false" 
                  OnClientClick="return confirm('Are you sure you wish to discontinue this item?')">
                 Remove</asp:LinkButton>&nbsp;&nbsp;
 <br /><br />
             <asp:DataList ID="Message" runat="server">
                <ItemTemplate>
                    <%# Container.DataItem %>
                </ItemTemplate>
             </asp:DataList>
			 </div>
</asp:Content>
