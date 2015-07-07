using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spencer.BussinessService;
using System.Data;
using Spencer.DAO;


public partial class Modules_aspx_public_ProductDetail : Basepage
{
    MyCart myCart = null;
    string productId = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        myCart = Session["MyCart"] as MyCart;
        if (myCart == null)
        {
            myCart = new MyCart();
            Session["MyCart"] = myCart;
        }

        if (Request.QueryString["prodId"] != null)        
            productId = Request.QueryString["prodId"].ToString();        
        else
            productId = "Chai";

        if (!Page.IsPostBack)        
            LoadProduct(productId);
        
    }

    private void LoadProduct(string productId)
    {
        try
        {
            DataView view = (Cache["Products"] as DataTable).DefaultView;
            view.RowFilter = "productId = '" + productId + "'";
            ProductFormView.DataSource = view;
            ProductFormView.DataBind();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message, MessageInfo.Error);
        }
    }

    protected void ProductFormView_ItemCommand(object sender, FormViewCommandEventArgs e)
    {
        ShoppingCartItem cart = new ShoppingCartItem();
        if (Session["UserName"] != null)
        {
            if (e.CommandName == "AddToCartcmd")            
                AddToCart(cart);
            
            if (e.CommandName == "WishListcmd")            
                AddToWishList();            
        }
    }

    private void AddToWishList()
    {
        IWishListBussinessService wishListBussinessService = null;
        string userId = Session["UserName"].ToString(); ;
        string productId = ProductFormView.DataKey[0].ToString();

        try
        {
            wishListBussinessService = BizDelegateFactory.Current.WishListBussinessService;
            int result = wishListBussinessService.AddToWishList(new WishListDAO
            {
                UserId = userId,
                ProductId = productId
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

    private void AddToCart(ShoppingCartItem cart)
    {
        cart.ProductId = ProductFormView.DataKey[0].ToString();
        cart.ProductName = (ProductFormView.Row.FindControl("ProductLabel") as Label).Text;
        cart.UnitPrice = decimal.Parse((ProductFormView.Row.FindControl("UnitPriceLabel") as Label).Text);
        TextBox quantityTextBox = ProductFormView.Row.FindControl("QuantityTextBox") as TextBox;
        if (quantityTextBox.Text.Equals(string.Empty))
            cart.Quantity = 1;
        else
            cart.Quantity = int.Parse(quantityTextBox.Text);
        cart.Total = cart.UnitPrice * cart.Quantity;

        ShoppingCartItem temp = new ShoppingCartItem { ProductId = cart.ProductId, Quantity = cart.Quantity };
        if (!myCart.FindProduct(temp))
            myCart.AddCart(cart);

        Session["MyCart"] = myCart;

        Server.Transfer("~/Modules/aspx/MyCart.aspx");
    }
}
