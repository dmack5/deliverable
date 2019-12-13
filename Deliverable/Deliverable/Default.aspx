<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Deliverable._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>A15 Rentals</h1>
      
    </div>
	<asp:Image ID="ClassDiagram1" runat="server" ImageUrl="~/Images/ClassDiagram1.png" />
	<asp:Image ID="ClassDiagram2" runat="server" ImageUrl="~/Images/ClassDiagram2.png" />
	<asp:Image ID="RentalsERD" runat="server" ImageUrl="~/Images/A15.6b0b2dd3.png" />


    <div class="row">
        <div class="col-md-4">
			<h1>Madison Perron</h1>
            <h2>Stored Procedures</h2>
			<p>Rentals_FindByLandlord - Returns zero or more Rentals records for the supplied landlord id</p>
			<p>	Addresses_FindByPartialStreetAddress - Returns zero or more Addresses whos Number and Street contains the supplied values.</p>
			<p>Rentals_FindByMontlyRateRange - Returns zero or more Rentals whos MonthlyRent is within a specified range. </p>
			<p> Code does not run, i renamed the controllers to something else and this covered my code in errors</p>
			<p>Project does not open </p>
			<p></p>
        </div>
    </div>

</asp:Content>
