using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_aspx_MyCart : Basepage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)        
            LoadData();        
    }

    private void LoadData()
    {
        if (Session["MyCart"] != null)
        {
            MyCartGridView.DataSource = (Session["MyCart"] as MyCart).MyCartList;
            MyCartGridView.DataBind();
        }
    }

    protected void ContinueShopping_Click(object sender, EventArgs e)
    {
        Server.Transfer("~/Modules/aspx/public/Products.aspx");
    }

    decimal total = 0;
    protected void MyCartGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal totalValue = decimal.Parse((e.Row.FindControl("TotalLabel") as Label).Text);
            total += totalValue;
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            (e.Row.FindControl("CheckOutLabel") as Label).Text = total.ToString();
        }
    }

    protected void UpdateMyCart_Click(object sender, EventArgs e)
    {
        MyCart myCart = Session["MyCart"] as MyCart;

        if (myCart != null)
        {
            List<ShoppingCartItem> list = myCart.MyCartList;

            for (int i = 0; i < MyCartGridView.Rows.Count; i++)
            {               
                CheckBox checkBox = MyCartGridView.Rows[i].FindControl("DeleteCheckBox") as CheckBox;
                string productId = MyCartGridView.DataKeys[i].Value.ToString();
                if (checkBox.Checked == true)
                    list.Remove(new ShoppingCartItem { ProductId = productId });
            }
            Session["MyCart"] = myCart;
            LoadData();
        }
    }

    protected void QuantityTextBox_TextChanged(object sender, EventArgs e)
    {
        GridViewRow row = ((Control)(sender)).NamingContainer as GridViewRow;
        GridView grid = row.NamingContainer as GridView;
        string productId = grid.DataKeys[row.RowIndex].Value.ToString();

        MyCart myCart = Session["MyCart"] as MyCart;
        if (myCart != null)
        {
            List<ShoppingCartItem> list = myCart.MyCartList;
            int index = list.IndexOf(new ShoppingCartItem { ProductId = productId });
            list[index].Quantity = int.Parse((row.FindControl("QuantityTextBox") as TextBox).Text);
            list[index].Total = list[index].UnitPrice * list[index].Quantity;
            Session["MyCart"] = myCart;
            LoadData();
        }
    }

    protected void CheckOutButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Modules/aspx/Payment.aspx");
    }
}
