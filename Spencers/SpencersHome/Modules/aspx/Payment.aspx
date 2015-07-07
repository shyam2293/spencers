<%@ Page Title="" Language="C#" MasterPageFile="~/Master/SpencersHome.master" AutoEventWireup="true"
    CodeFile="Payment.aspx.cs" Inherits="Modules_aspx_Payment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder1" runat="Server">
    <asp:DetailsView ID="PersonalDetailsView" runat="server" Height="50px" Width="393px"
        AutoGenerateRows="False" CellPadding="4" ForeColor="#333333" 
        GridLines="None">
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderTemplate>
            <asp:Label Text="Personal Details" runat="server"></asp:Label>
        </HeaderTemplate>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <CommandRowStyle BackColor="#FFFFC0" Font-Bold="True" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <FieldHeaderStyle BackColor="#FFFF99" Font-Bold="True" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <Fields>
            <asp:BoundField DataField="userId" HeaderText="UserID" />
            <asp:BoundField DataField="firstName" HeaderText="FirstName" />
            <asp:BoundField DataField="lastName" HeaderText="LastName" />
            <asp:TemplateField HeaderText="Address">
                <ItemTemplate>
                    <asp:TextBox ID="AddressTextBox" Text='<%#Eval("address") %>' runat="server" 
                        TextMode="MultiLine" Width="215px"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="mobileNo" HeaderText="Mobile Num" />
        </Fields>
        <AlternatingRowStyle BackColor="White" />
    </asp:DetailsView>
    <br />
    <asp:GridView ID="MyCartGridView" runat="server" CellPadding="4" 
        ForeColor="#333333" GridLines="None" Width="365px">
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
        <EmptyDataTemplate></EmptyDataTemplate>
    </asp:GridView>
    <br />
    <asp:Button ID="BuyButton" runat="server" OnClick="BuyButton_Click" Text="Buy" />
    <cc1:ConfirmButtonExtender ID="BuyButton_ConfirmButtonExtender" runat="server" ConfirmText="Are you sure to made payment"
        Enabled="True" TargetControlID="BuyButton">
    </cc1:ConfirmButtonExtender>
    &nbsp;
    <asp:Button ID="CancelButton" runat="server" OnClick="CancelButton_Click" Text="Cancel" />
    <br />
    <asp:Label ID="PendingProductLabel" runat="server" ForeColor="Red"></asp:Label>
    <cc1:ConfirmButtonExtender ID="CancelButton_ConfirmButtonExtender" runat="server"
        ConfirmText="Are you sure to delete MyCart" Enabled="True" TargetControlID="CancelButton">
    </cc1:ConfirmButtonExtender>
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
