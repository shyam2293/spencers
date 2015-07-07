/*
    Name         : SpencerHome.master
    Author       : Anandhan
    Purpose      : Product Feedback display & insert
    Date Created : 22/11/2010
 
    Revision History :
 
        Modified by   :
        Date Modified :
*/

using System;
using System.Data;
using System.Web.UI.WebControls;
//DAO Reference
using Spencer.DAO;
//BussinessService Reference
using Spencer.BussinessService;

public partial class Modules_aspx_Feedback : Basepage
{
    #region Page Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["prodId"] != null)
            {
                LoadProduct(Request.QueryString["prodId"].ToString());
                LoadComments(Request.QueryString["prodId"].ToString());
            }
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        ProductDetailsView.DataBind();
        ProductListView.DataBind();
    } 
    #endregion
        
    #region ListView Events
    protected void ProductListView_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "insert")
        {
            TextBox commentTextBox = e.Item.FindControl("CommentsTextBox") as TextBox;
            string userId = Session["UserName"].ToString();
            string productId = ProductDetailsView.DataKey[0].ToString();
            IFeedbackBussinessService feedbackBussinessService = null;

            try
            {
                feedbackBussinessService = BizDelegateFactory.Current.FeedbackBussinessService;

                int result = feedbackBussinessService.InsertProductComment(new FeedbackDAO
                {
                    ProductId = productId,
                    Description = commentTextBox.Text,
                    UserID = userId
                });

                if (result > 0)
                    ShowMessage("Comments inserted", MessageInfo.Information);
                else
                    ShowMessage("Error in insertion", MessageInfo.Error);

                LoadComments(productId);
                LoadProduct(productId);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageInfo.Error);
            }
            finally
            {
                feedbackBussinessService = null;
            }
        }
    }

    protected void ProductListView_ItemInserting(object sender, ListViewInsertEventArgs e)
    {

    }

    protected void ProductListView_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        DataPager pager = ProductListView.FindControl("pager") as DataPager;
        pager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        string productId = ProductDetailsView.DataKey[0].ToString();
        LoadComments(productId);
        LoadProduct(productId);                
    }
    #endregion

    #region Private Methods
    private void LoadProduct(string productId)
    {
        DataTable productsTable = Cache["Products"] as DataTable;
        DataView view = productsTable.DefaultView;
        view.RowFilter = "productId = " + "'" + productId + "'";
        ProductDetailsView.DataSource = view;
    }

    private void LoadComments(string productId)
    {
        IFeedbackBussinessService feedbackBussinessService = null;
        try
        {
            feedbackBussinessService = BizDelegateFactory.Current.FeedbackBussinessService;
            ProductListView.DataSource = feedbackBussinessService.RetreiveProductComments(productId);
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message, MessageInfo.Error);
        }
        finally
        {
            feedbackBussinessService = null;
        }
    }
    #endregion

    protected void ProductSearchButton_Click(object sender, EventArgs e)
    {
        if (ProductNameTextBox.Text.Trim() != string.Empty)
        {
            string productName = ProductNameTextBox.Text.Trim();
            DataTable productsTable = Cache["Products"] as DataTable;
            DataView view = productsTable.DefaultView;
            view.RowFilter = "productName = " + "'" + productName + "'";

            string productId = view.Table.Rows[0]["productId"].ToString();

            LoadComments(productId);
            ProductDetailsView.DataSource = view;
        }
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count)
    {
        IProductBussinessService productBussinessService = null;
        try
        {
            productBussinessService = BizDelegateFactory.Current.ProductBussinessService;
            return productBussinessService.RetreiveAllProduct(prefixText, count);
        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {
            productBussinessService = null;
        }
    }    
}
