using System;
using System.Configuration;

namespace Spencer.DatabaseService
{
    public abstract class DBDelegateFactory
    {
        #region Member Declaration
        private static DBDelegateFactory _gCurrent;
        private static string _namespace = "Spencer.DBLL";
        private static string _flock = "DBLLFactory"; 
        #endregion

        #region GetCurrentInstance
        public static DBDelegateFactory Current
        {
            get
            {
                if (_gCurrent == null)
                {
                    lock (_flock)
                    {
                        string typename = ConfigurationSettings.AppSettings["DBLLFactoryType"];

                        if (typename == null || typename.Length == 0)
                            throw new ApplicationException("DBLLFactoryType parameter is not set in the AppSettings section");

                        Type factoryType = Type.GetType(typename + "," + _namespace);

                        if (factoryType == null)
                            throw new ApplicationException("DBLLFactoryType parameter is set to non-existent class in the AppSettings section");

                        _gCurrent = Activator.CreateInstance(factoryType) as DBDelegateFactory;
                    }
                }
                return _gCurrent;
            }
        } 
        #endregion

        #region GetDelegate
        /// <summary>
        /// abstract method to be override in the DBLLFactory
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        protected abstract object GetDBLL(string typeName); 
        #endregion

        #region Properties
        /// <summary>
        /// Gets a reference to the UserDetailDBLL
        /// </summary>
        public IUserDetailDatabaseService UserDetailDatabaseService
        {
            get
            {
                return GetDBLL("UserDetailDBLL") as IUserDetailDatabaseService;
            }
        }

        /// <summary>
        /// Gets a reference to the ProductDBLL
        /// </summary>
        public IProductDatabaseService ProductDatabaseService
        {
            get
            {
                return GetDBLL("ProductDBLL") as IProductDatabaseService;

            }
        }

        /// <summary>
        /// Gets a reference to the CategoryDBLL
        /// </summary>
        public ICategoryDatabaseService CategoryDatabaseService
        {
            get
            {
                return GetDBLL("CategoryDBLL") as ICategoryDatabaseService;

            }
        }

        /// <summary>
        /// Gets a reference to the FeedbackDBLL
        /// </summary>
        public IFeedbackDatabaseService FeedbackDatabaseService
        {
            get
            {
                return GetDBLL("FeedbackDBLL") as IFeedbackDatabaseService;
            }
        }

        /// <summary>
        /// Gets a reference to the TransactionDBLL
        /// </summary>
        public ITransactionDatabaseService TransactionDatabaseService
        {
            get
            {
                return GetDBLL("TransactionDBLL") as ITransactionDatabaseService;
            }
        }

        /// <summary>
        /// Gets a reference to the TransactionDetailDBLL
        /// </summary>
        public ITransactionDetailDatabaseService TransactionDetailDatabaseService
        {
            get
            {
                return GetDBLL("TransactionDetailDBLL") as ITransactionDetailDatabaseService;
            }
        }

        /// <summary>
        /// Gets a reference to the WishListDBLL
        /// </summary>
        public IWishListDatabaseService WishListDatabaseService
        {
            get
            {
                return GetDBLL("WishListDBLL") as IWishListDatabaseService;
            }
        } 
        #endregion
    }
}
