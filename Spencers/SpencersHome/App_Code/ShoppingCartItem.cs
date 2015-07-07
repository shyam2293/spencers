using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ShoppingCart
/// </summary>
public class ShoppingCartItem
{
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public decimal Total { get; set; }

    public override bool Equals(object obj)
    {
        ShoppingCartItem sCart = obj as ShoppingCartItem;
        return this.ProductId.Equals(sCart.ProductId);
    }
}
