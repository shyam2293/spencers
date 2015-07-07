/*
    Name         : Product.aspx
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
using System.Web.UI.WebControls;
using Spencer.BussinessService;
using Spencer.DAO;

public partial class Modules_aspx_Products : Basepage
{
    string categoryId;
    MyCart myCart = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        myCart = Session["MyCart"] as MyCart;
        if (myCart == null)
        {
            myCart = new MyCart();
            Session["MyCart"] = myCart;
        }

        if (Request.QueryString["catId"] != null)
        {
            categoryId = Request.QueryString["catId"].ToString();
        }
        else
            categoryId = "1";

        if (!Page.IsPostBack)
        {
            LoadProducts(categoryId);
        }
    }

    private void LoadProducts(string categoryId)
    {
        try
        {
            DataView view = (Cache["Products"] as DataTable).DefaultView;
            view.RowFilter = "categoryId="+"'" + categoryId + "'";
            ProductDataList.DataSource = view;
            ProductDataList.DataBind();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message, MessageInfo.Error);
        }
    }

    /// <summary>
    /// e-event retains its value, hence we are able to get quantity text box value
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void ProductDataList_ItemCommand(object source, DataListCommandEventArgs e)
    {
        ShoppingCartItem cart = new ShoppingCartItem();
        if (Session["UserName"] != null)
        {
            if (e.CommandName == "AddToCartcmd")
            {
                AddToCart(e, cart);
            }

            if (e.CommandName == "WishListcmd")            
                InsertWishList(e);            
        }
    }

    private void AddToCart(DataListCommandEventArgs e, ShoppingCartItem cart)
    {
        LoadProducts(categoryId);

        cart.ProductId = ProductDataList.DataKeys[e.Item.ItemIndex].ToString();
        cart.ProductName = (e.Item.FindControl("ProductDetailLink") as HyperLink).Text;
        cart.UnitPrice = decimal.Parse((e.Item.FindControl("UnitPriceLabel") as Label).Text);
        TextBox quantityTextBox = (e.Item.FindControl("QuantityTextBox") as TextBox);
        if (quantityTextBox.Text.Equals(string.Empty))
            cart.Quantity = 1;
        else
            cart.Quantity = int.Parse(quantityTextBox.Text);
        cart.Total = cart.UnitPrice * cart.Quantity;

        ShoppingCartItem temp = new ShoppingCartItem { ProductId = cart.ProductId, Quantity = cart.Quantity };
        if (!myCart.FindProduct(temp))
            myCart.AddCart(cart);

        //added additionally
        Session["MyCart"] = myCart;

        Server.Transfer("~/Modules/aspx/MyCart.aspx");
    }

    private void InsertWishList(DataListCommandEventArgs e)
    {
        LoadProducts(categoryId);
        IWishListBussinessService wishListBussinessService = null;
        string userId = Session["UserName"].ToString(); ;
        string productId = ProductDataList.DataKeys[e.Item.ItemIndex].ToString();

        try
        {
            wishListBussinessService = BizDelegateFactory.Current.WishListBussinessService;
            int result = wishListBussinessService.AddToWishList(new WishListDAO
            {
                ProductId = productId,
                UserId = userId
            });

            if (result > 0)
                ShowMessage("Details added to wish list", MessageInfo.Information);
            else
                ShowMessage("Error in updation", MessageInfo.Error);
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message, MessageInfo.Error);
        }
        finally
        {
            wishListBussinessService = null;
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

    protected void ProductSearchButton_Click(object sender, EventArgs e)
    {
        string productName = ((sender as Control).NamingContainer.FindControl("ProductNameTextBox") as TextBox).Text;
        if (productName != string.Empty)
            Server.Transfer("~/Modules/aspx/public/ProductDetail.aspx?prodName=" + productName);
    }
}
