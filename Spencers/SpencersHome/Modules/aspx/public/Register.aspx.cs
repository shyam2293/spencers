/*
    Name         : Register.aspx
    Author       : Anandhan
    Purpose      : Inserts the registration information into database  
    Date Created : 06/12/2010
 
    Revision History :
 
        Modified by   :
        Date Modified :
*/

using System;
using System.IO;
using System.Threading;
using System.Web.Security;
using System.Web.UI;
using Spencer.BussinessService;
using Spencer.DAO;

public partial class Modules_aspx_Register : Basepage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            UserIdTextBox.Attributes.Add("onBeforeDeactivate",
                "return checkTextBox('" + UserIdTextBox.ClientID + "','" + UserIdSpan.ClientID + "')");
            PasswordTextBox.Attributes.Add("onBeforeDeactivate",
                "return checkTextBox('" + PasswordTextBox.ClientID + "','" + PasswordSpan.ClientID + "')");
            ConfirmPasswordTextBox.Attributes.Add("onBeforeDeactivate",
                "return checkConfirmPassword('" + PasswordTextBox.ClientID + "','" + ConfirmPasswordTextBox.ClientID + "','" + ConfirmPasswordSpan.ClientID + "')");
            SecurityQuestionList.Attributes.Add("onBeforeDeactivate",
                "return checkSecurityQuestion('" + SecurityQuestionList.ClientID + "','" + SecurityQuestionSpan.ClientID + "')");
            SecurityAnswerTextBox.Attributes.Add("onBeforeDeactivate",
                "return checkTextBox('" + SecurityAnswerTextBox.ClientID + "','" + SecurityAnswerSpan.ClientID + "')");
            FirstNameTextBox.Attributes.Add("onBeforeDeactivate",
                "return checkTextBox('" + FirstNameTextBox.ClientID + "','" + FirstNameSpan.ClientID + "')");
            LastNameTextBox.Attributes.Add("onBeforeDeactivate",
                "return checkTextBox('" + LastNameTextBox.ClientID + "','" + LastNameSpan.ClientID + "')");
            AddressTextBox.Attributes.Add("onBeforeDeactivate",
                "return checkTextBox('" + AddressTextBox.ClientID + "','" + AddressSpan.ClientID + "')");
            TelephoneTextBox.Attributes.Add("onBeforeDeactivate",
                "return checkTelephone('" + TelephoneTextBox.ClientID + "','" + TelephoneSpan.ClientID + "')");
            EmailTextBox.Attributes.Add("onBeforeDeactivate",
                "return checkEmail('" + EmailTextBox.ClientID + "','" + EmailSpan.ClientID + "')");
            LicenceAgreementCheckBox.Attributes.Add("onClick",
                "return checkLicenceAgreement('" + LicenceAgreementCheckBox.ClientID + "','" + LicenceSpan.ClientID + "')");
        }
    }

    protected void RegisterButton_Click(object sender, EventArgs e)
    {
        string userId = UserIdTextBox.Text.Trim();
        string password = PasswordTextBox.Text.Trim();

        if (ValidateForm())
        {
            UserDetailDAO userDetails = new UserDetailDAO
            {
                UserId = userId,
                SecurityQuestion = SecurityQuestionList.SelectedItem.Text,
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                MobileNo = TelephoneTextBox.Text,
                Answer = SecurityAnswerTextBox.Text,
                Address = AddressTextBox.Text,
                Email = EmailTextBox.Text
            };

            try
            {
                //password encryption
                password = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");
                userDetails.Password = password;

                //adding images
               

                //contacting BLL to DB
                IUserDetailBussinessService userDetailsBussinessService = BizDelegateFactory.Current.UserDetailBussinessService;
                int result = userDetailsBussinessService.CreateUser(userDetails);
                if (result > 0)
                {
                    Session["userName"] = userId; //User.Identity.Name;
                    FormsAuthentication.RedirectFromLoginPage(userId, true);
                }
                else
                    ShowMessage("Error in insertion", MessageInfo.Information);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageInfo.Error);
            }
            finally
            {
                userDetails = null;
            }
        }
        else
        {
            ShowMessage("Please fill the mandatory fields", MessageInfo.Error);
            UserIdTextBox.Focus();
        }
    }

    private bool ValidateForm()
    {
        bool isValid = false;        
        string firstName, lastName, address, telephone, email, aggrement,
                userId, password, confirmPassword, securityAnswer, securityQuestion;
        userId = UserIdTextBox.Text.Trim();
        password = PasswordTextBox.Text.Trim();
        confirmPassword = ConfirmPasswordTextBox.Text.Trim();
        securityQuestion = SecurityQuestionList.SelectedItem.Text;//--Select a security question
        securityAnswer = SecurityAnswerTextBox.Text;
        firstName = FirstNameTextBox.Text;
        lastName = LastNameTextBox.Text;
        address = AddressTextBox.Text;
        email = EmailTextBox.Text;
        telephone = TelephoneTextBox.Text;
        aggrement = LicenceAgreementCheckBox.Checked.ToString();//False

        if (firstName != "" && lastName != "" && address != "" && address != "" && telephone != "" 
            && email != ""  && aggrement != "False" && userId != "" && password != ""
            && confirmPassword != "" && securityAnswer != "" && securityQuestion != "Select a security question")
            isValid = true;

        return isValid;
    }
    /// <summary>
    /// Inserts image info ito DAO class
    /// </summary>
    /// <param name="userDetails"></param>
   
    protected void UserIdTextBox_TextChanged(object sender, EventArgs e)
    {
        try
        {
            IUserDetailBussinessService userDetailsBussinessService = BizDelegateFactory.Current.UserDetailBussinessService;
            bool isValid = userDetailsBussinessService.ValidateUserId(UserIdTextBox.Text);
            Thread.Sleep(6000);
            if (!isValid)
                AvailabilityLabel.Text = "User Id available";
            else
            {
                AvailabilityLabel.Text = "User Id already taken";
                UserIdTextBox.Focus();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message, MessageInfo.Error);
        }
    }
}
