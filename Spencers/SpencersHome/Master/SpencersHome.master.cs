/*
    Name         : SpencerHome.master
    Author       : Anandhan
    Purpose      : Template for all webpages
    Date Created : 22/11/2010
 
    Revision History :
 
        Modified by   :
        Date Modified :
*/

using System;
using System.Data;
using System.Drawing;
using System.Web.Security;
using Spencer.BussinessService;
using System.Web.Caching;

public partial class Master_SpencersMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] != null)
        {
            LoginLink.Text = "Sign Out";
            RegisterLink.Visible = false;
            WelcomeLabel.Text = "Welcome " + Session["UserName"].ToString() + " !";
        }

        if (!Page.IsPostBack)
        {
            LoadCategories();
            loadProducts();
        }
    }

    private void loadProducts()
    {
        IProductBussinessService productBussinessService = null;
        DataTable productTable = null;
        try
        {
            if (Cache["Products"] == null)
            {
                productBussinessService = BizDelegateFactory.Current.ProductBussinessService;
                productTable = productBussinessService.RetreiveAllProducts();                
                SqlCacheDependency productCache = new SqlCacheDependency("SpencersDB", "Products");
                Cache.Insert("Products", productTable,productCache);
            }
        }
        catch (Exception ex)
        {
            CommonLabel.Text = ex.Message;
            CommonLabel.ForeColor = Color.Red;
        }
        finally
        {
            productBussinessService = null;
        }
    }

    private void LoadCategories()
    {
        ICategoryBussinessService categoryBussinessService = null;
        DataTable categoryTable = null;
        try
        {            
            if (Cache["Categories"] == null)
            {
                categoryBussinessService = BizDelegateFactory.Current.CategoryBussinessService;
                categoryTable = categoryBussinessService.RetreiveAllCategory();
                SqlCacheDependency categoryCache = new SqlCacheDependency("SpencersDB", "Products");
                Cache.Insert("Categories", categoryTable, categoryCache);
            }
            CategoryIdDataList.DataSource = Cache["Categories"];
            CategoryIdDataList.DataBind();

        }
        catch (Exception ex)
        {
            CommonLabel.Text = ex.Message;
            CommonLabel.ForeColor = Color.Red;
        }
        finally
        {
            categoryBussinessService = null;
        }
    }

    protected void LoginLink_Click1(object sender, EventArgs e)
    {
        if (Session["UserName"] != null)
        {
            LoginLink.Text = "Login";
            FormsAuthentication.SignOut();
            RegisterLink.Visible = true;
            Session["UserName"] = null;
            WelcomeLabel.Text = "";
            Session.Abandon();
            Server.Transfer("~/Modules/aspx/public/Default.aspx");
        }
        else
            Server.Transfer("~/Modules/aspx/public/Login.aspx");//Server.Mappath - for path only        }        
    }
}
