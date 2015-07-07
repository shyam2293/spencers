using System.Data;
//DAO Reference
using Spencer.DAO;

namespace Spencer.BussinessService
{
    public interface IWishListBussinessService
    {
        /// <summary>
        /// retreives user's wish list
        /// </summary>
        /// <param name="userId">string</param>
        /// <returns></returns>
        DataTable MyWishList(string userId);

        /// <summary>
        /// insert user wish list
        /// </summary>
        /// <param name="userWishList">WishListDAO</param>
        /// <returns></returns>
        int AddToWishList(WishListDAO userWishList);

        /// <summary>
        /// delete user wish list
        /// </summary>
        /// <param name="userWishList">WishListDAO</param>
        /// <returns></returns>
        int DeleteWishList(WishListDAO userWishList);
    }
}
