<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Query.aspx.cs" Inherits="Deliverable.Deliverable3.Query" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<asp:Label ID="Label1" runat="server" Text="LandLords"></asp:Label>
	<asp:DropDownList ID="LandLordID" runat="server"></asp:DropDownList>
	<asp:button runat="server" text="Rental Addres(es)?" />
	<div></div>
	<asp:Label ID="Label2" runat="server" Text="Address(es)"></asp:Label>
	<asp:DropDownList ID="Address" runat="server"></asp:DropDownList>
	<asp:RadioButton ID="Select" runat="server" />
	 CausesValidation="false" OnClick="Fetch_Click"/>
	<br /><br />

	<asp:GridView ID="ProductList" runat="server" 
            AutoGenerateColumns="False"
             CssClass="table table-striped" GridLines="Horizontal"
             BorderStyle="None" AllowPaging="True" OnPageIndexChanging="ProductList_PageIndexChanging" PageSize="5" OnSelectedIndexChanged="ProductList_SelectedIndexChanged">

            <Columns>
                <asp:CommandField SelectText="View" ShowSelectButton="True" 
                    ButtonType="Button" CausesValidation="false"></asp:CommandField>
                <asp:TemplateField HeaderText="ID" Visible="False">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="ProductID" runat="server" 
                            Text='<%# Eval("ProductID") %>'></asp:Label>
                        
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Product">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    <ItemTemplate>
                        <%-- this is where your reference to the data on your
                              record is placed--%>
                        <asp:Label ID="ProductName" runat="server" 
                            Text='<%# Eval("ProductName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Qty/Per">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                     <ItemTemplate>
                        <asp:Label ID="QuantityPerUnit" runat="server" 
                            Text='<%# Eval("QuantityPerUnit") == null ? "each" : Eval("QuantityPerUnit") %>'></asp:Label>
                        
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Price ($)">
                    <HeaderStyle HorizontalAlign="Right"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                     <ItemTemplate>
                        <asp:Label ID="UnitPrice" runat="server" 
                            Text='<%# string.Format("{0:0.00}",Eval("UnitPrice"))%>'></asp:Label>
                        
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Disc">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                     <ItemTemplate>
                         <asp:CheckBox ID="Discontinued" runat="server" 
                              Checked='<%# Eval("Discontinued") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                whatever message string you use is printed if there is no data to display
            </EmptyDataTemplate>
            <PagerSettings FirstPageText="Start" LastPageText="End" Mode="NumericFirstLast" PageButtonCount="3" />
        </asp:GridView>
    </div>






















</asp:Content>
