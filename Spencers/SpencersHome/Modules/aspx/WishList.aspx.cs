/*
    Name         : WishList.aspx
    Author       : Anandhan
    Purpose      : Displays user wish list
    Date Created : 15/12/2010
 
    Revision History :
 
        Modified by   :
        Date Modified :
*/

using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spencer.BussinessService;
using Spencer.DAO;

public partial class Modules_aspx_WishList : Basepage
{
    MyCart myCart = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        myCart = Session["MyCart"] as MyCart;
        if (myCart == null)
        {
            myCart = new MyCart();
            Session["MyCart"] = myCart;
        }

        if (!Page.IsPostBack)
            RetreiveWishList();
    }

    private void RetreiveWishList()
    {
        string userId = Session["UserName"].ToString();
        IWishListBussinessService wishListBussinessService = null;
        try
        {
            wishListBussinessService = BizDelegateFactory.Current.WishListBussinessService;
            WishListGridView.DataSource = wishListBussinessService.MyWishList(userId);
            WishListGridView.DataBind();
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

    /// <summary>
    /// items to be added to database
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AddToCartLinkButton_Click(object sender, EventArgs e)
    {
        //RetreiveWishList();
        ShoppingCartItem cart = new ShoppingCartItem();
        GridViewRow row = ((Control)sender).NamingContainer as GridViewRow;
        GridView grid = row.NamingContainer as GridView;
        //LOADCATEGORIES
        cart.ProductId = grid.DataKeys[row.RowIndex].Value.ToString();
        cart.ProductName = (row.FindControl("ProductLabel") as Label).Text;
        cart.UnitPrice = decimal.Parse((row.FindControl("UnitPriceLabel") as Label).Text);
        cart.Quantity = 1;
        cart.Total = cart.UnitPrice * cart.Quantity;

        ShoppingCartItem temp = new ShoppingCartItem { ProductId = cart.ProductId, Quantity = cart.Quantity };
        if (!myCart.FindProduct(temp))
            myCart.AddCart(cart);

        Server.Transfer("~/Modules/aspx/MyCart.aspx");
    }

    /// <summary>
    /// items to be deleted from database
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DeleteButton_Click(object sender, EventArgs e)
    {
        IWishListBussinessService wishListBussinessService = null;
        string userId = Session["UserName"].ToString();
        string productId = string.Empty;
        try
        {
            wishListBussinessService = BizDelegateFactory.Current.WishListBussinessService;
            for (int i = 0; i < WishListGridView.Rows.Count; i++)
            {
                CheckBox checkBox = WishListGridView.Rows[i].FindControl("WishListCheckBox") as CheckBox;
                if (checkBox.Checked)
                    productId = productId + WishListGridView.DataKeys[i].Value.ToString() + ",";
            }

            if (productId != string.Empty)
            {
                productId = productId.Substring(0, productId.Length - 1);
                int result = wishListBussinessService.DeleteWishList(new WishListDAO
                {
                    UserId = userId,
                    ProductId = productId
                });

                if (result > 0)
                {
                    ShowMessage("Record deleted successfully!!", MessageInfo.Information);
                    RetreiveWishList();
                }
                else
                    ShowMessage("Error in deletion", MessageInfo.Error);
            }
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
}
