<%@ Page Title="" Language="C#" MasterPageFile="~/Master/SpencersHome.master" AutoEventWireup="true"
    CodeFile="MyCart.aspx.cs" Inherits="Modules_aspx_MyCart" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder1" runat="Server">
    <asp:GridView ID="MyCartGridView" runat="server" AutoGenerateColumns="False" CellPadding="4"
        ForeColor="#333333" GridLines="None" ShowFooter="True" DataKeyNames="ProductId"
        OnRowDataBound="MyCartGridView_RowDataBound">
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <Columns>
            <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:CheckBox ID="DeleteCheckBox" runat="server" />
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Button ID="UpdateMyCart" runat="server" Width="52px" Text="Delete" 
                        OnClick="UpdateMyCart_Click" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ProductName">
                <ItemTemplate>
                    <asp:Label ID="ProductNameLabel" CssClass="prodname" runat="server" Text='<%#Eval("ProductName")%>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Button ID="ContinueShopping" runat="server" Text="Continue Shopping" OnClick="ContinueShopping_Click"
                        Width="119px" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="UnitPrice">
                <ItemTemplate>
                    <asp:Label ID="UnitPriceLabel"  CssClass="UnitPrice" runat="server" Text='<%#Eval("UnitPrice") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Button ID="CheckOutButton" runat="server" Text="Check Out" Width="77px" OnClick="CheckOutButton_Click" />
                    <cc1:ConfirmButtonExtender ID="CheckOutButton_ConfirmButtonExtender" runat="server"
                        ConfirmText="Are u sure to make payment" Enabled="True" TargetControlID="CheckOutButton">
                    </cc1:ConfirmButtonExtender>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="QuantityTextBox" Text='<%#Eval("Quantity") %>' runat="server" Columns="3"
                        OnTextChanged="QuantityTextBox_TextChanged" AutoPostBack="true"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total">
                <ItemTemplate>
                    <asp:Label ID="TotalLabel" CssClass="TotalPrice" runat="server" Text='<%#Eval("Total") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="Label1" runat="server" Text="Total Cost:"></asp:Label>
                    <asp:Label ID="CheckOutLabel" runat="server"></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>

</asp:Content>
