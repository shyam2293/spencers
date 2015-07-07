using System;
using System.IO;
using System.Web.UI;
using Spencer.BussinessService;

public partial class Modules_aspx_Images1 : Basepage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string categoryId = Request.QueryString["catId"].ToString();
        if (!Page.IsPostBack)
        {
            if (categoryId != null)
                LoadImage(categoryId);
        }
    }

    private void LoadImage(string categoryId)
    {
        ICategoryBussinessService categoryBussinessService = null;
        try
        {
            categoryBussinessService = BizDelegateFactory.Current.CategoryBussinessService;
            byte[] byteArray = categoryBussinessService.RetreiveCategoryImage(categoryId);
            MemoryStream stream = new MemoryStream(byteArray, 78, byteArray.Length-78);
            Response.ContentType = "image/jpeg";
            Response.BinaryWrite(stream.ToArray());
        }
        catch (Exception ex)
        {
            CommonLabel.Text = ex.Message;   
        }
        finally
        {
            categoryBussinessService = null;
        }
    }
}
