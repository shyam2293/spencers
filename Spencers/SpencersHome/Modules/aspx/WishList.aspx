<%@ Page Title="" Language="C#" MasterPageFile="~/Master/SpencersHome.master" AutoEventWireup="true"
    CodeFile="WishList.aspx.cs" Inherits="Modules_aspx_WishList" Debug="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder1" runat="Server">
    <asp:GridView ID="WishListGridView" runat="server" AutoGenerateColumns="False" CellPadding="4"
        DataKeyNames="productId" ForeColor="#333333" GridLines="None" ShowFooter="true" Height="220px"
        Width="527px">
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <Columns>
            <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:CheckBox ID="WishListCheckBox" runat="server" />
                </ItemTemplate>
                <FooterTemplate>
                <asp:Button ID="DeleteButton" runat="server" Text="Delete" 
                        onclick="DeleteButton_Click" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Product">
                <ItemTemplate>
                    <asp:Label ID="ProductLabel" runat="server" Text='<%#Eval("productName")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Category">
                <ItemTemplate>
                    <asp:Label ID="CategoryLabel" Text='<%#Eval("categoryName") %>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Unit Price">
                <ItemTemplate>
                    <asp:Label ID="UnitPriceLabel" runat="server" Text='<%#Eval("unitPrice") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Added Date">
                <ItemTemplate>
                    <asp:Label ID="DateLabel" runat="server" Text='<%#Eval("date") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Add to Cart">
                <ItemTemplate>
                    <asp:LinkButton ID="AddToCartLinkButton" runat="server" Text="Add To cart" OnClick="AddToCartLinkButton_Click"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
</asp:Content>
