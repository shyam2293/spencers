/*
    Name         : Default.aspx
    Author       : Anandhan
    Purpose      : Login the user in website
    Date Created : 09/12/2010
 
    Revision History :
 
        Modified by   :
        Date Modified :
*/

using System;
using System.Data;
using System.Web.UI;

public partial class Modules_aspx_Home : Basepage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            LoadCategories();
    }

    private void LoadCategories()
    {
        try
        {
            CategoryItemsDataList.DataSource = Cache["Categories"];
            CategoryItemsDataList.DataBind();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message, MessageInfo.Error);
        }
    }
}
