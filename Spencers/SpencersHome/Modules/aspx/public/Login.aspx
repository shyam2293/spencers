<%@ Page Title="" Language="C#" MasterPageFile="~/Master/SpencersHome.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="Modules_aspx_Login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="Stylesheet" href="../../../Common/CSS/Login.css" type="text/css" />

    <script type="text/javascript" src="../../js/LoginScript.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder1" runat="Server">
    <asp:Panel ID="LoginPanel1" runat="server" GroupingText="Login" Width="388px">
        <table>
            <tr>
                <th colspan="2" align="center">
                    <asp:Label Text="Account Login" runat="server" CssClass="hStyle"></asp:Label>
                </th>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="UserNameLabel" runat="server" Text="User Name"></asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="UserIdTextBox" runat="server" CssClass="textbox"></asp:TextBox>
                    <sup class="superScript">*</sup>
                    <asp:Label ID="UserIdSpan" runat="server"></asp:Label>
                    <cc1:TextBoxWatermarkExtender ID="UserIdText_TextBoxWatermarkExtender" runat="server"
                        Enabled="True" TargetControlID="UserIdTextBox" WatermarkCssClass="watermark"
                        WatermarkText="Enter user name">
                    </cc1:TextBoxWatermarkExtender>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="Passwordlabel" runat="server" Text="Password:"></asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="PasswordTextBox" runat="server" CssClass="textbox" TextMode="Password"></asp:TextBox>
                    <sup class="superScript">*</sup>
                    <asp:Label ID="PasswordSpan" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="Login" CssClass="button" Text="Login" runat="server" OnClick="Login_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:HyperLink ID="NewUserRegLink" runat="server" Text="New user?Register" NavigateUrl="~/Modules/aspx/Register.aspx"
                        CssClass="hyperLink"></asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Wizard ID="Wizard1" runat="server">
                        <WizardSteps>
                            <asp:WizardStep runat="server">
                                Forget Password. Click next to proceed</asp:WizardStep>
                            <asp:WizardStep runat="server">
                                <table>
                                    <tr>
                                        <th colspan="2" align="center">
                                            <asp:Label ID="Label1" Text="Forget Password" runat="server" CssClass="hStyle"></asp:Label>
                                        </th>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="InfoLabel" runat="server" Text="Please fill the following details"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="UserIdlabelForget" runat="server" Text="User Id"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="UserIdForgetTextBox" runat="server" CssClass="textbox"></asp:TextBox>
                                            <cc1:TextBoxWatermarkExtender ID="UserIdForgetTextBox_TextBoxWatermarkExtender" runat="server"
                                                WatermarkCssClass="watermark" WatermarkText="Enter userId" TargetControlID="UserIdForgetTextBox">
                                            </cc1:TextBoxWatermarkExtender>
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            <asp:WizardStep runat="server">
                                <table>
                                    <tr>
                                        <th colspan="2" align="center">
                                            <asp:Label ID="Label2" Text="Security Information" runat="server" CssClass="hStyle"></asp:Label>
                                        </th>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="InfoLabel1" runat="server" Text="Please fill the following details"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="SecurityQuestionLabel" runat="server" Text="SecurityQuestion"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ReadOnly="true" ID="SecurityQuestionTextBox" runat="server" CssClass="textbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="AnswerLabel" runat="server" Text="Answer"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="SecurityAnswerTextBox" runat="server" CssClass="textbox"></asp:TextBox>
                                            <cc1:TextBoxWatermarkExtender ID="SecurityAnswerTextBox_TextBoxWatermarkExtender"
                                                runat="server" Enabled="True" TargetControlID="SecurityAnswerTextBox" WatermarkCssClass="watermark"
                                                WatermarkText="Enter security answer">
                                            </cc1:TextBoxWatermarkExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:Button ID="Submit" runat="server" Text="Submit" CssClass="button" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                        </WizardSteps>
                    </asp:Wizard>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <!-- Piwik -->
<script type="text/javascript">
    var _paq = _paq || [];
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
