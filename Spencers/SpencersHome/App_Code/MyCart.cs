using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MyCartApp
/// </summary>
public class MyCart
{
    public List<ShoppingCartItem> MyCartList { get; private set; }
    public MyCart()
    {
        MyCartList = new List<ShoppingCartItem>();
    }

    public void AddCart(ShoppingCartItem myCart)
    {
        MyCartList.Add(myCart);        
    }

    public bool FindProduct(ShoppingCartItem cart)
    {
        int index = MyCartList.IndexOf(cart);
        if (index <0 )
            return false;
        else
        {
            MyCartList[index].Quantity += cart.Quantity;
            MyCartList[index].Total = (MyCartList[index].Quantity * MyCartList[index].UnitPrice);
            return true;
        }
    }
}
