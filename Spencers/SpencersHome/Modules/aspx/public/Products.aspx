<%@ Page Title="" Language="C#" MasterPageFile="~/Master/SpencersHome.master" AutoEventWireup="true"
    CodeFile="Products.aspx.cs" Inherits="Modules_aspx_Products" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder1" runat="Server">
    <div>
        <asp:DataList ID="ProductDataList" runat="server" CellPadding="3" RepeatDirection="Horizontal"
            BackColor="#FFFBD6" BorderColor="#660066" BorderStyle="None" BorderWidth="2px"
            GridLines="Both" RepeatColumns="3" DataKeyField="ProductId" OnItemCommand="ProductDataList_ItemCommand"
            CellSpacing="6" Font-Size="Medium" ShowFooter="true" ShowHeader="true">
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <ItemStyle ForeColor="#003399" />
            <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <HeaderTemplate>
            <asp:Label ID="ProductSearchLabel" runat="server" Text="Search Product: "></asp:Label>
                <asp:TextBox ID="ProductNameTextBox" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="ProductNameTextBox_AutoCompleteExtender" runat="server"
                    DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList" ServicePath=""
                    TargetControlID="ProductNameTextBox" UseContextKey="True" CompletionListCssClass="productAutoComplete">
                </cc1:AutoCompleteExtender>
                <asp:Button ID="ProductSearchButton" runat="server" Text="Go" 
                    onclick="ProductSearchButton_Click" />
            </HeaderTemplate>
            <ItemTemplate>
                <asp:HyperLink ID="ProductDetailLink" runat="server" Text='<%# Eval("ProductName") %>'
                    NavigateUrl='<%# Eval("productId","~/Modules/aspx/public/ProductDetail.aspx?prodId={0}") %>'></asp:HyperLink>
                <br />
                <asp:Label Text="UnitPrice:" runat="server" Font-Bold="true"></asp:Label>
                <asp:Label CssClass="unitprice" ID="UnitPriceLabel" runat="server" Text='<%# Eval("UnitPrice") %>' />
                <br />
                <asp:Label Text="UnitsInStock:" runat="server" Font-Bold="true"></asp:Label>
                <asp:Label ID="UnitsInStockLabel" runat="server" Text='<%# Eval("UnitsInStock") %>' />
                <br />
                <asp:Label Font-Bold="true" Text="Quantity:" runat="server"></asp:Label>
                <asp:TextBox runat="server" ID="QuantityTextBox" Columns="3"></asp:TextBox>
                <br />
                <asp:LinkButton ID="AddToCartLink" runat="server" Text="AddToCart" CommandName="AddToCartcmd"></asp:LinkButton>
                <br />
                <asp:LinkButton ID="AddToWishListLink" runat="server" Text="AddToWishList" CommandName="WishListcmd"></asp:LinkButton>
                <br />
                <asp:HyperLink ID="CommentsLink" runat="server" Text="Comments"
                NavigateUrl='<%# Eval("productId","~/Modules/aspx/Feedback.aspx?prodId={0}") %>'></asp:HyperLink>
            </ItemTemplate>
            <FooterTemplate>
            </FooterTemplate>
        </asp:DataList>
    </div>
    <!-- Piwik -->

<noscript><p><img src="//impc1523/piwik/piwik.php?idsite=3" style="border:0;" alt="" /></p></noscript>
<!-- End Piwik Code -->
</asp:Content>
