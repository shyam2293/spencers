using System.Collections.Generic;
//BussinessService Reference
using Spencer.BussinessService;
//DAO Reference
using Spencer.DAO;
//Database Reference
using Spencer.DatabaseService;

namespace Spencer.BLL
{
    /// <summary>
    /// Created by: Anandhan S
    /// Created on: 23/12/2010
    /// </summary>
    public class TransactionDetailBLL :ITransactionDetailBussinessService
    {
        #region ITransactionDetailBussinessService Members

        /// <summary>
        /// inserts user ordered products in DB
        /// </summary>
        /// <param name="userOrderList">List<TransactionDetailDAO></param>
        /// <returns></returns>
        public int InsertOrders(ref List<TransactionDetailDAO> userOrderList)
        {
            ITransactionDetailDatabaseService transactionDetailDatabaseService = null;
            try
            {
                transactionDetailDatabaseService = DBDelegateFactory.Current.TransactionDetailDatabaseService;
                return transactionDetailDatabaseService.InsertOrders(ref userOrderList);
            }
            finally
            {
                transactionDetailDatabaseService = null;
            }
        }

        #endregion        
    }
}
