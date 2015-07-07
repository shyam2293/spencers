/*
    Name         : Login.aspx
    Author       : Anandhan
    Purpose      : Login the user in website
    Date Created : 08/12/2010
 
    Revision History :
 
        Modified by   :
        Date Modified :
*/

using System;
using System.Web.Security;
using System.Web.UI;
using Spencer.BussinessService;
using System.Web.UI.WebControls;

public partial class Modules_aspx_Login : Basepage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            UserIdTextBox.Attributes.Add("onBeforeDeactivate",
                "return checkTextBox('" + UserIdTextBox.ClientID + "','" + UserIdSpan.ClientID + "')");
            PasswordTextBox.Attributes.Add("onBeforeDeactivate",
                "return checkTextBox('" + PasswordTextBox.ClientID + "','" + PasswordSpan.ClientID + "')");
        }
    }

    protected void Login_Click(object sender, EventArgs e)
    {
        string password = PasswordTextBox.Text.Trim();
        string username = UserIdTextBox.Text.Trim();
        if (username != string.Empty && password != string.Empty)
        {
            password = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");

            try
            {
                IUserDetailBussinessService userDetailsBussinessService = BizDelegateFactory.Current.UserDetailBussinessService;
                bool isValid = userDetailsBussinessService.AuthenticateUser(UserIdTextBox.Text, password);
                if (isValid)
                {
                    Session["UserName"] = UserIdTextBox.Text; //User.Identity.Name;
                    FormsAuthentication.RedirectFromLoginPage(UserIdTextBox.Text, true);
                }
                else
                    ShowMessage("Invalid username or password", MessageInfo.Error);

            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageInfo.Error);
            }
        }
        else
            ShowMessage("Please fill the required fields", MessageInfo.Error);
    }
}
