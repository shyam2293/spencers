using System;
using System.Configuration;

namespace Spencer.BussinessService
{
    /// <summary>
    /// Created by: Anandhan S
    /// Created on: 23/12/2010
    /// </summary>    
    public abstract class BizDelegateFactory
    {
        #region Member Declaration
        private static BizDelegateFactory _gCurrent;
        private static string _nameSpace = "Spencer.BLL";
        #endregion        

        #region GetDelegate
        /// <summary>
        /// abstract method to be override in the BLLFactory
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        protected abstract object GetBLL(string typeName); 
        #endregion

        #region Get Current Instance
        public static BizDelegateFactory Current
        {
            get
            {
                if (_gCurrent != null)
                    return _gCurrent;
                else
                {
                    string typename = ConfigurationSettings.AppSettings["BLLFactoryType"];

                    if (typename == null || typename.Length == 0)
                        throw new ApplicationException("BLLFactoryType parameter is not set in the AppSettings section");

                    Type factoryType = Type.GetType(typename + "," + _nameSpace);

                    if (factoryType == null)
                        throw new ApplicationException("BLLFactoryType parameter is set to non-existent class in the AppSettings section");

                    _gCurrent = Activator.CreateInstance(factoryType) as BizDelegateFactory;
                    return _gCurrent;
                }
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets a reference to the UserDetailBLL
        /// </summary>
        public IUserDetailBussinessService UserDetailBussinessService
        {
            get
            {
                return GetBLL("UserDetailBLL") as IUserDetailBussinessService;
            }
        }

        /// <summary>
        /// Gets a reference to the ProductBLL
        /// </summary>
        public IProductBussinessService ProductBussinessService
        {
            get
            {
                return GetBLL("ProductBLL") as IProductBussinessService;
            }
        }

        /// <summary>
        /// Gets a reference to the CategoryBLL
        /// </summary>
        public ICategoryBussinessService CategoryBussinessService
        {
            get
            {
                return GetBLL("CategoryBLL") as ICategoryBussinessService;
            }
        }

        /// <summary>
        /// Gets a reference to the FeedbackBLL
        /// </summary>
        public IFeedbackBussinessService FeedbackBussinessService
        {
            get
            {
                return GetBLL("FeedbackBLL") as IFeedbackBussinessService;
            }
        }

        /// <summary>
        /// Gets a reference to the TransactionBLL
        /// </summary>
        public ITransactionBussinessService TransactionBussinessService
        {
            get
            {
                return GetBLL("TransactionBLL") as ITransactionBussinessService;
            }
        }

        /// <summary>
        /// Gets a reference to the TransactionDetailBLL
        /// </summary>
        public ITransactionDetailBussinessService TransactionDetailBussinessService
        {
            get
            {
                return GetBLL("TransactionDetailBLL") as ITransactionDetailBussinessService;
            }
        }

        /// <summary>
        /// Gets a reference to the WishListBLL
        /// </summary>
        public IWishListBussinessService WishListBussinessService
        {
            get
            {
                return GetBLL("WishListBLL") as IWishListBussinessService;
            }
        } 
        #endregion
    }
}
