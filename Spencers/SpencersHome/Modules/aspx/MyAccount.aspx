<%@ Page Title="" Language="C#" MasterPageFile="~/Master/SpencersHome.master" AutoEventWireup="true"
    CodeFile="MyAccount.aspx.cs" Inherits="Modules_aspx_MyAccount" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder1" runat="Server">
    <asp:UpdatePanel ID="UpadtePanel" UpdateMode="Always" runat="server">
        <ContentTemplate>
            <asp:LinkButton ID="LinkButton1" Text="Personal Details" runat="server">
            </asp:LinkButton>
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <asp:Image ID="Image1" runat="server" />
            <asp:Panel ID="PersonalDetailsPanel" runat="server">
                <asp:DetailsView ID="PersonalDetailsView" runat="server" AutoGenerateRows="False"
                    OnDataBound="PersonalDetailsView_DataBound"
                    CellPadding="4" ForeColor="#333333" GridLines="None" OnModeChanging="PersonalDetailsView_ModeChanging"
                    Width="371px"
                    onitemupdating="PersonalDetailsView_ItemUpdating">
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <Fields>
                        <asp:CommandField ShowEditButton="True" />
                        <asp:BoundField DataField="userId" HeaderText="UserID" ReadOnly="true" />
                        <asp:TemplateField HeaderText="Photo">
                            <ItemTemplate>
                                <asp:Image ID="userImage" ImageUrl='<%#Eval("userId","~/Images/{0}"+".jpeg") %>'
                                    runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:FileUpload ID="ImageUpload" runat="server" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="firstName" HeaderText="First Name" />
                        <asp:BoundField DataField="lastName" HeaderText="Last Name" />
                        <asp:BoundField DataField="address" HeaderText="Address" />
                        <asp:BoundField DataField="mobileNo" HeaderText="Mobile No" />
                        <asp:BoundField DataField="email" HeaderText="Email" />
                        <asp:BoundField DataField="registrationDate" HeaderText="Registered Date" ReadOnly="True" />
                    </Fields>
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:DetailsView>
            </asp:Panel>
            <cc1:CollapsiblePanelExtender ID="PersonalDetailsPanelExtender" runat="server" TargetControlID="PersonalDetailsPanel"
                CollapsedSize="0" ExpandedSize="300" Collapsed="True" ExpandControlID="LinkButton1"
                CollapseControlID="LinkButton1" AutoCollapse="False" AutoExpand="False" ScrollContents="True"
                TextLabelID="Label1" CollapsedText="Show Details..." ExpandedText="Hide Details"
                ImageControlID="Image1" ExpandedImage="~/Images/collapse.jpg" CollapsedImage="~/Images/expand.jpg"
                ExpandDirection="Vertical">
            </cc1:CollapsiblePanelExtender>
            <cc1:RoundedCornersExtender ID="PersonalDetails_RoundedCorner" runat="server" Radius="6"
                TargetControlID="PersonalDetailsPanel" Corners="All">
            </cc1:RoundedCornersExtender>
            <br />
            <asp:LinkButton ID="LinkButton2" Text="My Transactions" runat="server">
            </asp:LinkButton>
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <asp:Image ID="Image2" runat="server" />
            <asp:Panel ID="MyTransactionsPanel" runat="server">
                <asp:GridView ID="MyTransactionsGridView" runat="server" CellPadding="4" ForeColor="#333333"
                    GridLines="None" Width="374px">
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </asp:Panel>
            <cc1:CollapsiblePanelExtender ID="MyTransactionsPanelExtender" runat="server" TargetControlID="MyTransactionsPanel"
                CollapsedSize="0" ExpandedSize="300" Collapsed="True" ExpandControlID="LinkButton2"
                CollapseControlID="LinkButton2" AutoCollapse="False" AutoExpand="False" ScrollContents="True"
                TextLabelID="Label2" CollapsedText="Show Details..." ExpandedText="Hide Details"
                ImageControlID="Image2" ExpandedImage="~/Images/collapse.jpg" CollapsedImage="~/Images/expand.jpg"
                ExpandDirection="Vertical">
            </cc1:CollapsiblePanelExtender>
            <cc1:RoundedCornersExtender ID="MyTransactionPanel_RoundedCorner" runat="server"
                TargetControlID="MyTransactionsPanel" Radius="6" Corners="All">
            </cc1:RoundedCornersExtender>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
