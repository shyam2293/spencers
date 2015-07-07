using System.Data;
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
    public class TransactionBLL : ITransactionBussinessService
    {
        #region ITransactionBussinessService Members

        /// <summary>
        /// retreives user transaction
        /// </summary>
        /// <param name="userId">string</param>
        /// <returns></returns>
        public DataTable MyTransactions(string userId)
        {
            ITransactionDatabaseService transactionDatabaseService = null;
            try
            {
                transactionDatabaseService = DBDelegateFactory.Current.TransactionDatabaseService;
                return transactionDatabaseService.MyTransactions(userId);
            }
            finally
            {
                transactionDatabaseService = null;
            }
        }

        /// <summary>
        /// inserts user details & retreives orderID
        /// </summary>
        /// <param name="userTransaction">TransactionDAO</param>
        /// <returns></returns>
        public string GetOrderId(TransactionDAO userTransaction)
        {
            ITransactionDatabaseService transactionDatabaseService = null;
            try
            {
                transactionDatabaseService = DBDelegateFactory.Current.TransactionDatabaseService;
                return transactionDatabaseService.GetOrderId(userTransaction);
            }
            finally
            {
                transactionDatabaseService = null;
            }
        }

        #endregion
    }
}
