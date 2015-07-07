using System.Data;
//BusinessService Reference
using Spencer.BussinessService;
//DAO Reference
using Spencer.DAO;
////Database Reference
using Spencer.DatabaseService;

namespace Spencer.BLL
{
    /// <summary>
    /// Created by: Anandhan S
    /// Created on: 23/12/2010
    /// </summary>
    public class WishListBLL : IWishListBussinessService
    {
        #region IWishListBussinessService Members

        /// <summary>
        /// retreives user's wish list
        /// </summary>
        /// <param name="userId">string</param>
        /// <returns></returns>
        public DataTable MyWishList(string userId)
        {
            IWishListDatabaseService wishListDatabaseService = null;
            try
            {
                wishListDatabaseService = DBDelegateFactory.Current.WishListDatabaseService;
                return wishListDatabaseService.MyWishList(userId);
            }
            finally
            {
                wishListDatabaseService = null;
            }
        }

        /// <summary>
        /// insert user wish list
        /// </summary>
        /// <param name="userWishList">WishListDAO</param>
        /// <returns></returns>
        public int AddToWishList(WishListDAO userWishList)
        {
            IWishListDatabaseService wishListDatabaseService = null;
            try
            {
                wishListDatabaseService = DBDelegateFactory.Current.WishListDatabaseService;
                return wishListDatabaseService.AddToWishList(userWishList);
            }
            finally
            {
                wishListDatabaseService = null;
            }
        }

        /// <summary>
        /// delete user wish list
        /// </summary>
        /// <param name="userWishList">WishListDAO</param>
        /// <returns></returns>
        public int DeleteWishList(WishListDAO userWishList)
        {
            IWishListDatabaseService wishListDatabaseService = null;
            try
            {
                wishListDatabaseService = DBDelegateFactory.Current.WishListDatabaseService;
                return wishListDatabaseService.DeleteWishList(userWishList);
            }
            finally
            {
                wishListDatabaseService = null;
            }
        }

        #endregion
    }
}
