<%@ Page Title="" Language="C#" MasterPageFile="~/Master/SpencersHome.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Modules_aspx_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder1" runat="Server">
    <script src="../../js/jquery-1.8.0.min.js" type="text/javascript"></script>
    <asp:DataList ID="CategoryItemsDataList" CssClass="active" runat="server" CellPadding="3"
        RepeatDirection="Horizontal" RepeatColumns="3" BackColor="#FFFBD6" 
    BorderWidth="1px" GridLines="Both" CellSpacing="6" DataKeyField="categoryId">
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <ItemStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <SeparatorStyle BackColor="Aqua" Font-Bold="False" Font-Italic="False" Font-Overline="False"
            Font-Strikeout="False" Font-Underline="False" ForeColor="Aqua" />
        <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <HeaderTemplate>
            <center>
                Products</center>
        </HeaderTemplate>
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
        <ItemTemplate>
            <asp:HyperLink ID="ProductsLink" runat="server" Text='<%# Eval("CategoryName") %>'
                NavigateUrl='<%# Eval("CategoryId","Products.aspx?catId={0}") %>'></asp:HyperLink>
            <br />
            <br />
            <asp:Image ID="CategoryImage" runat="server" ImageUrl='<%# Eval("CategoryId","Images.aspx?catId={0}") %>' />
            <br />            
        </ItemTemplate>                
    </asp:DataList>
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
