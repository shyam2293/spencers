<%@ Page Title="" Language="C#" MasterPageFile="~/Master/SpencersHome.master" AutoEventWireup="true"
    CodeFile="Register.aspx.cs" Inherits="Modules_aspx_Register" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="Stylesheet" type="text/css" href="../../../Common/CSS/Registration.css" />

    <script type="text/javascript" src="../../js/RegistrationScript.js"></script>

    <style type="text/css">
        .style1
        {
            width: 125px;
        }
        .style2
        {
            width: 97px;
        }
        .style3
        {
            width: 205px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder1" runat="Server">
    <asp:Label Text="Account Registration" runat="server" CssClass="hStyle"></asp:Label>
    <asp:Panel ID="AccountInfoPanel" runat="server" GroupingText="Account Information"
        CssClass="panelAccountInfo" Width="366px">
        <table>
            <tr>
                <td>
                    <asp:Label ID="UserIdLabel" Text="UserId" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:UpdatePanel ID="CheckUserIdPanel" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="UserIdTextBox" runat="server" CssClass="textbox" OnTextChanged="UserIdTextBox_TextChanged"
                                AutoPostBack="true"></asp:TextBox>
                            <sup class="superScript">*</sup>
                            <cc1:TextBoxWatermarkExtender ID="UserIdTextBox_TextBoxWatermarkExtender" runat="server"
                                Enabled="True" TargetControlID="UserIdTextBox" WatermarkText="Enter user id"
                                WatermarkCssClass="watermark">
                            </cc1:TextBoxWatermarkExtender>
                            <asp:Label ID="AvailabilityLabel" runat="server" ForeColor="BlueViolet" EnableViewState="False"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdateProgress ID="ProgressUpdate" AssociatedUpdatePanelID="CheckUserIdPanel"
                        runat="server">
                        <ProgressTemplate>
                            <asp:Image ID="ProgressImage" ImageUrl="~/Images/Progress2.gif" runat="server" CssClass="imageIcon" />
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </td>
                <td>
                    <span id="UserIdSpan" runat="server"></span>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="PasswordLabel" Text="Password" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="PasswordTextBox" TextMode="Password" runat="server" CssClass="textbox"></asp:TextBox>
                    <sup class="superScript">*</sup>
                    <cc1:PasswordStrength ID="PasswordTextBox_PasswordStrength" runat="server" Enabled="True"
                        PreferredPasswordLength="6" TargetControlID="PasswordTextBox" HelpHandlePosition="RightSide"
                        TextStrengthDescriptions="Weak;Average;Excellent;" TextStrengthDescriptionStyles="weak;average;excellent;"
                        DisplayPosition="BelowLeft" TextCssClass="">
                    </cc1:PasswordStrength>
                    <asp:Label ID="PasswordHelpLabel" runat="server"></asp:Label>
                </td>
                <td>
                    <span id="PasswordSpan" runat="server"></span>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="ConfirmPasswordLabel" Text="Confirm Password" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="ConfirmPasswordTextBox" TextMode="Password" runat="server" CssClass="textbox"></asp:TextBox>
                    <sup class="superScript">*</sup>
                </td>
                <td>
                    <span id="ConfirmPasswordSpan" runat="server"></span>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="SecurityQLabel" Text="Security Question" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="SecurityQuestionList" runat="server">
                        <asp:ListItem Text="--Select a security question" Value="none"></asp:ListItem>
                        <asp:ListItem Text="What is your first school?"></asp:ListItem>
                        <asp:ListItem Text="What is your favourite sport"></asp:ListItem>
                        <asp:ListItem Text="What is your favourite book?"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <span id="SecurityQuestionSpan" runat="server"></span>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="SecurityAnsLabel" Text="SecurityAnswer" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="SecurityAnswerTextBox" runat="server" CssClass="textbox"></asp:TextBox>
                    <cc1:TextBoxWatermarkExtender ID="SecurityAnswerTextBox_TextBoxWatermarkExtender"
                        runat="server" Enabled="True" TargetControlID="SecurityAnswerTextBox" WatermarkText="Enter security answer"
                        WatermarkCssClass="watermark">
                    </cc1:TextBoxWatermarkExtender>
                    <sup class="superScript">*</sup>
                </td>
                <td>
                    <span id="SecurityAnswerSpan" runat="server"></span>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <fieldset style="width: 5px; float: left;">
    </fieldset>
    <asp:Panel ID="PersonalInfoPanel" GroupingText="Personal Information" runat="server"
        CssClass="panelPersonalInfo" Width="384px">
        <table>
            <tr>
                <td class="style1">
                    <asp:Label ID="FirstNamelabel" Text="FirstName" runat="server"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="FirstNameTextBox" runat="server" CssClass="textbox"></asp:TextBox>
                    <cc1:TextBoxWatermarkExtender ID="FirstNameTextBox_TextBoxWatermarkExtender" runat="server"
                        Enabled="True" TargetControlID="FirstNameTextBox" WatermarkText="Enter first name"
                        WatermarkCssClass="watermark">
                    </cc1:TextBoxWatermarkExtender>
                    <sup class="superScript">*</sup>
                </td>
                <td class="style2">
                    <span id="FirstNameSpan" runat="server"></span>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="LastNameLabel" runat="server" Text="LastName"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="LastNameTextBox" runat="server" CssClass="textbox"></asp:TextBox>
                    <cc1:TextBoxWatermarkExtender ID="LastNameTextBox_TextBoxWatermarkExtender" runat="server"
                        Enabled="True" TargetControlID="LastNameTextBox" WatermarkText="Enter last name"
                        WatermarkCssClass="watermark">
                    </cc1:TextBoxWatermarkExtender>
                    <sup class="superScript">*</sup>
                </td>
                <td class="style2">
                    <span id="LastNameSpan" runat="server"></span>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="AddressLabel" Text="Address" runat="server"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="AddressTextBox" TextMode="MultiLine" runat="server"></asp:TextBox>
                    <cc1:TextBoxWatermarkExtender ID="AddressTextBox_TextBoxWatermarkExtender" runat="server"
                        Enabled="True" TargetControlID="AddressTextBox" WatermarkText="Enter address"
                        WatermarkCssClass="watermark">
                    </cc1:TextBoxWatermarkExtender>
                    <sup class="superScript">*</sup>
                </td>
                <td class="style2">
                    <span id="AddressSpan" runat="server"></span>
                </td>
            </tr>
          
            <tr>
                <td class="style1">
                    <asp:Label ID="TelephoneLabel" Text="Telephone" runat="server"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="TelephoneTextBox" runat="server" CssClass="textbox"></asp:TextBox>
                    <cc1:TextBoxWatermarkExtender ID="TelephoneTextBox_TextBoxWatermarkExtender" runat="server"
                        Enabled="True" TargetControlID="TelephoneTextBox" WatermarkText="Enter telephone number"
                        WatermarkCssClass="watermark">
                    </cc1:TextBoxWatermarkExtender>
                    <sup class="superScript">*</sup>
                </td>
                <td class="style2">
                    <span id="TelephoneSpan" runat="server"></span>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="EmailLabel" Text="Email" runat="server"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="EmailTextBox" runat="server" CssClass="textbox"></asp:TextBox>
                    <cc1:TextBoxWatermarkExtender ID="EmailTextBox_TextBoxWatermarkExtender" runat="server"
                        Enabled="True" TargetControlID="EmailTextBox" WatermarkText="Enter email" WatermarkCssClass="watermark">
                    </cc1:TextBoxWatermarkExtender>
                    <sup class="superScript">*</sup>
                </td>
                <td class="style2">
                    <span id="EmailSpan" runat="server"></span>
                </td>
            </tr>
           
            <tr>

                <td class="style3" colspan="2">
                    <asp:CheckBox ID="LicenceAgreementCheckBox" ToolTip="Licence" runat="server" Text=" " />
                    <asp:HyperLink ID="LicenceLink" Text="Terms & Conditions" NavigateUrl="~/Modules/aspx/public/TermsAndConditions.aspx"
                        runat="server"></asp:HyperLink>
                    <sup class="superScript">*</sup>
                </td>
                <td class="style2">
                    <span id="LicenceSpan" runat="server"></span>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="RegisterButton" Text="Register" runat="server" OnClick="RegisterButton_Click"
                        CssClass="button" />
                    <br />
                </td>
            </tr>
        </table>
    </asp:Panel>

    <script language="javascript" type="text/javascript">
        Sys.Application.add_init(application_init);

        function application_init() {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_beginRequest(handleRequest);
        }

        function handleRequest() {
            document.getElementById("ctl00_ContentHolder1_AvailabilityLabel").innerText = "";
        }
    </script>

</asp:Content>
