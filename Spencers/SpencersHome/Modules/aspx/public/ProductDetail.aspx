<%@ Page Title="" Language="C#" MasterPageFile="~/Master/SpencersHome.master" AutoEventWireup="true"
    CodeFile="ProductDetail.aspx.cs" Inherits="Modules_aspx_public_ProductDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder1" runat="Server">
    <asp:FormView ID="ProductFormView" runat="server" OnItemCommand="ProductFormView_ItemCommand"
        DataKeyNames="productId" Width="365px" Font-Bold="False" BorderColor="#663300"
        BorderStyle="Inset" BorderWidth="2px">
        <HeaderStyle BackColor="#663300" Font-Bold="True" Font-Italic="True" Font-Underline="True"
            ForeColor="White" />
        <HeaderTemplate>
            <h3>
                <asp:Label ID="ProductLabel" runat="server" Text='<%# Eval("ProductName") %>' />
            </h3>
        </HeaderTemplate>
        <FooterStyle BackColor="Silver" />
        <ItemTemplate>
            <asp:Image ID="ProductImage" AlternateText="To be uploaded" runat="server" />
            <br />
            <asp:Label ID="Label1" Text="Description:" runat="server" />
            <p>
                <asp:Label ID="DescriptionLabel" Text='<%#Eval("Description") %>' runat="server" />
            </p>
            <br />
            <asp:Label Text="UnitPrice:" runat="server" Font-Bold="true" />
            <asp:Label ID="UnitPriceLabel" runat="server" Text='<%# Eval("UnitPrice") %>' />
            <br />
            <asp:Label Text="UnitsInStock:" runat="server" Font-Bold="true" />
            <asp:Label ID="UnitsInStockLabel" runat="server" Text='<%# Eval("UnitsInStock") %>' />
            <br />
            <asp:Label Font-Bold="true" Text="Quantity:" runat="server" />
            <asp:TextBox runat="server" ID="QuantityTextBox" Columns="3" />
        </ItemTemplate>
        <FooterTemplate>
            &nbsp;&nbsp;
            <asp:LinkButton ID="AddToCartLink" runat="server" Text="AddToCart" CommandName="AddToCartcmd" />
            &nbsp;&nbsp;
            <asp:LinkButton ID="AddToWishListLink" runat="server" Text="AddToWishList" CommandName="WishListcmd" />
            &nbsp;&nbsp;
            <asp:HyperLink ID="Feedback" runat="server" text="Comments"
             NavigateUrl='<%#Eval("productId","~/Modules/aspx/Feedback.aspx?prodId={0}") %>'></asp:HyperLink>
        </FooterTemplate>
    </asp:FormView>
    <!-- Piwik -->
<script type="text/javascript">
    var _paq = _paq || [];
    _paq.push(['addEcommerceItem',
                "2", // (required) SKU: Product unique identifier
                "Chang", // (optional) Product name
                "Condiments",
                19.0,
                1]);
    _paq.push(['trackEcommerceOrder',
                        "28", // (required) Unique Order ID
                        90, // (required) Order Revenue grand total (includes tax, shipping, and subtracted discount)
                        30, // (optional) Order sub total (excludes shipping)

        ]);
    _paq.push(['trackPageView']);
   
    _paq.push(['enableLinkTracking']);
    (function () {
        var u = "//impc1523/piwik/";
        _paq.push(['setTrackerUrl', u + 'piwik.php']);
        _paq.push(['setSiteId', 3]);
        var d = document, g = d.createElement('script'), s = d.getElementsByTagName('script')[0];
        g.type = 'text/javascript'; g.async = true; g.defer = true; g.src = u + 'piwik.js'; s.parentNode.insertBefore(g, s);
    })();
</script>
<noscript><p><img src="//impc1523/piwik/piwik.php?idsite=3" style="border:0;" alt="" /></p></noscript>
<!-- End Piwik Code -->
</asp:Content>
