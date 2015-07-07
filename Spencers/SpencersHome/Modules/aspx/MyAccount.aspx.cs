using System;
using System.Web.UI;
using Spencer.BussinessService;
using System.IO;
using System.Data;
using System.Web.UI.WebControls;
using Spencer.DAO;

public partial class Modules_aspx_MyAccount : Basepage
{
    DataTable personalDetailsTable = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            RetreiveMyTransactions();
            RetreiveMyDetails();
        }
    }

    private void RetreiveMyTransactions()
    {
        ITransactionBussinessService transactionBussinessService = null;
        string userId = Session["UserName"].ToString() ?? string.Empty;
        try
        {
            transactionBussinessService = BizDelegateFactory.Current.TransactionBussinessService;
            MyTransactionsGridView.DataSource = transactionBussinessService.MyTransactions(userId);
            MyTransactionsGridView.DataBind();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message, MessageInfo.Error);
        }
        finally
        {
            transactionBussinessService = null;
        }
    }

    private void RetreiveMyDetails()
    {
        IUserDetailBussinessService userDetailsBussinessService = null;
        string userId = Session["UserName"].ToString() ?? string.Empty;
        try
        {
            userDetailsBussinessService = BizDelegateFactory.Current.UserDetailBussinessService;
            personalDetailsTable = ViewState["DataTable"] as DataTable;
            if (personalDetailsTable == null)
            {
                personalDetailsTable = userDetailsBussinessService.PersonalDetails(userId);
                ViewState["DataTable"] = personalDetailsTable;
            }
            

            PersonalDetailsView.DataSource = personalDetailsTable;
            PersonalDetailsView.DataBind();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message, MessageInfo.Error);
        }
        finally
        {
            userDetailsBussinessService = null;
        }
    }

    private string GetTempFolderName()
    {
        string tempFolderName = Server.MapPath("~/Images/");
        if (Directory.Exists(tempFolderName))
            return tempFolderName;
        else
        {
            Directory.CreateDirectory(tempFolderName);
            return tempFolderName;
        }
    }

    protected void PersonalDetailsView_DataBound(object sender, EventArgs e)
    {
        byte[] photoByte = null;
        string photoExtn = ".jpeg";
        
        DataRow row = (ViewState["DataTable"] as DataTable).Rows[0];
        if (PersonalDetailsView.CurrentMode == DetailsViewMode.ReadOnly)
        {
            Label categoryLabel = PersonalDetailsView.Rows[0].FindControl("userIdLabel") as Label;
            Image img = PersonalDetailsView.Rows[0].FindControl("userImage") as Image;

            if (personalDetailsTable != null && categoryLabel != null)
            {
                photoByte = (byte[])row["image"];

                if (photoByte != null && photoByte.Length > 1)
                {
                    System.Drawing.Image newImage = null;
                    string fileName = GetTempFolderName() + categoryLabel.Text + photoExtn;
                    MemoryStream stream = new MemoryStream(photoByte);
                    newImage = System.Drawing.Image.FromStream(stream);
                    newImage.Save(fileName);
                    stream.Flush();
                    stream.Close();
                }
            }
        }
    }

    protected void PersonalDetailsView_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        if (e.NewMode == DetailsViewMode.Edit)
            PersonalDetailsView.ChangeMode(DetailsViewMode.Edit);
        if (e.NewMode == DetailsViewMode.ReadOnly)
            PersonalDetailsView.ChangeMode(DetailsViewMode.ReadOnly);
        PersonalDetailsView.DataSource = ViewState["DataTable"];
        PersonalDetailsView.DataBind();
    }

    protected void PersonalDetailsView_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        IUserDetailBussinessService userDetailBussinessService = null;
        UserDetailDAO userDetailsDAO = null; ;         

        try
        {
            userDetailsDAO = UpdateUserDetailsDAO();
            userDetailBussinessService = BizDelegateFactory.Current.UserDetailBussinessService;
            MyTransactionsGridView.DataSource = userDetailBussinessService.UpdatePersonalDetails(userDetailsDAO);
            MyTransactionsGridView.DataBind();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message, MessageInfo.Error);
        }
        finally
        {
            userDetailBussinessService = null;
            userDetailsDAO = null;
        }
    }

    private UserDetailDAO UpdateUserDetailsDAO()
    {
        UserDetailDAO usertailsDAO = new UserDetailDAO();
        string userId = Session["UserName"].ToString() ?? string.Empty;
        //string photo = (PersonalDetailsView.Rows[0].Cells[1].Controls[0] as TextBox).Text;
        //string firstName = (PersonalDetailsView.Rows[0].Cells[1].Controls[0] as TextBox).Text;
        //string lastName = (PersonalDetailsView.Rows[0].Cells[1].Controls[0] as TextBox).Text;
        //string address = (PersonalDetailsView.Rows[0].Cells[1].Controls[0] as TextBox).Text;
        //string mobileNo = (PersonalDetailsView.Rows[0].Cells[1].Controls[0] as TextBox).Text;
        //string email = (PersonalDetailsView.Rows[0].Cells[1].Controls[0] as TextBox).Text;      
        return usertailsDAO;
    }
}
