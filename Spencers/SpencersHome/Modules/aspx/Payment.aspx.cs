using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spencer.BussinessService;
using Spencer.DAO;

public partial class Modules_aspx_Payment : Basepage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            RetreivePersonalDetails();
            RetreiveMyCart();
        }
    }

    private void RetreiveMyCart()
    {
        if (Session["MyCart"] != null && Session["UserName"] != null)
        {
            MyCart mycart = Session["MyCart"] as MyCart;
            MyCartGridView.DataSource = mycart.MyCartList;
            MyCartGridView.DataBind();
        }
        else
            MyCartGridView.DataBind();
    }

    private void RetreivePersonalDetails()
    {
        IUserDetailBussinessService userDetailsBussinessService = null;
        try
        {
            if (Session["MyCart"] != null && Session["UserName"] != null)
            {
                string userId = Session["UserName"].ToString();
                userDetailsBussinessService = BizDelegateFactory.Current.UserDetailBussinessService;
                PersonalDetailsView.DataSource = userDetailsBussinessService.PersonalDetails(userId);
                PersonalDetailsView.DataBind();
            }
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

    protected void BuyButton_Click(object sender, EventArgs e)
    {
        if (Session["MyCart"] != null && Session["UserName"] != null)
        {
            MyCart myCart = Session["MyCart"] as MyCart;
            List<ShoppingCartItem> myCartList = myCart.MyCartList;
            try
            {
                int orderId = GetOrderId();

                int result = InsertOrderedProduct(ref myCartList,orderId);

                if (result > 0)
                {
                    string resultMessage = string.Format("Order ID:{0}\nOrdered products will be delivered soon", orderId);
                    ShowMessage(resultMessage, MessageInfo.Information);
                }

                #region Pending Transaction

                //if (myCartList.Count != 0)
                //    ProcessPendingProducts(ref myCartList);

                #endregion

                Session["MyCart"] = null;
                RetreiveMyCart();
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageInfo.Error);
            }
        }
    }

    private void ProcessPendingProducts(ref List<ShoppingCartItem> myCartList)
    {
        StringBuilder pendingProductNames = null;        
        decimal pendingRefund = 0; 
       
        try
        {
            pendingProductNames = new StringBuilder();
            pendingProductNames.Append("ProductId's not having enough Qty <br/>");

            foreach (ShoppingCartItem item in myCartList)
            {
                pendingProductNames.Append(item.ProductName + ",");
                pendingRefund += item.Total;
            }
            pendingProductNames.Append("<br/> Refund Total:" + pendingRefund.ToString());
            PendingProductLabel.Text = Server.HtmlDecode(pendingProductNames.ToString());
        }
        finally
        {
            pendingProductNames = null;
        }                        
    }

    private static int InsertOrderedProduct(ref List<ShoppingCartItem> myCartList, int orderId)
    {
        List<TransactionDetailDAO> userOrderList = null;
        ITransactionDetailBussinessService transactionDetailBussinessService = null;
        int result = 0;
        try
        {
            transactionDetailBussinessService = BizDelegateFactory.Current.TransactionDetailBussinessService;
            userOrderList = new List<TransactionDetailDAO>();
            foreach (ShoppingCartItem cartItem in myCartList)
            {
                userOrderList.Add(new TransactionDetailDAO
                {
                    OrderId = orderId,
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity,
                    UnitPrice = cartItem.UnitPrice
                });
            }

            result = transactionDetailBussinessService.InsertOrders(ref userOrderList);
        }
        finally
        {
            transactionDetailBussinessService = null;
            myCartList = null;
        }
        return result;
    }

    private int GetOrderId()
    {
        ITransactionBussinessService transactionBussinessService = null;
        string userId = Session["UserName"].ToString();
        string address = (PersonalDetailsView.FindControl("AddressTextBox") as TextBox).Text;
        transactionBussinessService = BizDelegateFactory.Current.TransactionBussinessService;

        int orderId = int.Parse(transactionBussinessService.GetOrderId(new TransactionDAO
        {
            //UserID = userId,
            UserID=userId,
            DeliveryAddress = address
        }));
        return orderId;
    }

    protected void CancelButton_Click(object sender, EventArgs e)
    {
        if (Session["MyCart"] != null && Session["UserName"] != null)
            Session["MyCart"] = null;
        Server.Transfer("~/Modules/aspx/public/Default.aspx");
    }
}
