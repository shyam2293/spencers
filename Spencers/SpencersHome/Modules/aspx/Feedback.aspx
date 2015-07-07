<%@ Page Title="" Language="C#" MasterPageFile="~/Master/SpencersHome.master" AutoEventWireup="true"
    CodeFile="Feedback.aspx.cs" Inherits="Modules_aspx_Feedback" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder1" runat="Server">
    <asp:Label ID="ProductSearchLabel" runat="server" Text="Search Product: "></asp:Label>
    <asp:TextBox ID="ProductNameTextBox" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
    <asp:Button ID="ProductSearchButton" runat="server" Text="Go" OnClick="ProductSearchButton_Click" />
    <cc1:AutoCompleteExtender ID="ProductNameTextBox_AutoCompleteExtender" runat="server"
        DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList" ServicePath=""
        TargetControlID="ProductNameTextBox" UseContextKey="True" CompletionListCssClass="productAutoComplete">
    </cc1:AutoCompleteExtender>
    <asp:DetailsView ID="ProductDetailsView" runat="server" Height="50px" Width="409px"
        AutoGenerateRows="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None"
        BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" DataKeyNames="productId">
        <FooterStyle BackColor="#CCCC99" />
        <RowStyle BackColor="#F7F7DE" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <HeaderTemplate>
            <asp:Label ID="ProductNameLabel" Text='<%#Eval("productName") %>' runat="server"></asp:Label>
        </HeaderTemplate>
        <Fields>
            <asp:BoundField DataField="description" HeaderText="Description" />
            <asp:BoundField DataField="unitPrice" HeaderText="Unit Price" />
            <asp:ImageField DataAlternateTextField="image not available" HeaderText="Product Imge">
            </asp:ImageField>
        </Fields>
        <EditRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
        <EmptyDataTemplate>
            No product Details found
        </EmptyDataTemplate>
    </asp:DetailsView>
    <br />
    <asp:ListView ID="ProductListView" runat="server" InsertItemPosition="FirstItem"
        OnItemCommand="ProductListView_ItemCommand" OnItemInserting="ProductListView_ItemInserting"
        OnPagePropertiesChanging="ProductListView_PagePropertiesChanging">
        <LayoutTemplate>
            <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
            <asp:DataPager ID="pager" runat="server" EnableViewState="true" PageSize="5">
                <Fields>
                    <asp:NumericPagerField ButtonType="Button" />
                </Fields>
            </asp:DataPager>
        </LayoutTemplate>
        <InsertItemTemplate>
            <asp:Label ID="InsertCommentLabel" runat="server" Text="Write Comments" /><br />
            <asp:TextBox ID="CommentsTextBox" runat="server" TextMode="MultiLine" Columns="50"
                Rows="7" /><br />
            <asp:Button ID="SubmitButton" CommandName="insert" runat="server" Text="Post Comments" />
        </InsertItemTemplate>
        <ItemTemplate>
            <table width="75%">
                <tr>
                    <td>
                        <asp:Label ID="UserIdLabel" runat="server" Text='<%#Eval("userId")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Image ID="UserImage" runat="server" ImageAlign="Left" ImageUrl='<%#Eval("image","~/images/{0}"+".jpeg") %>' />
                    </td>
                    <td>
                        <asp:Label ID="DateLabel" runat="server" Text='<%#Eval("date")%>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="DexcriptionLabel" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
        <EmptyDataTemplate>
            No comments yet
        </EmptyDataTemplate>
        <ItemSeparatorTemplate>
            <hr style="background-color: Maroon; border: thin solid #000000;">
        </ItemSeparatorTemplate>
    </asp:ListView>
</asp:Content>
