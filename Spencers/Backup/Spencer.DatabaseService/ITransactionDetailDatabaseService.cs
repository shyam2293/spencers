using System.Collections.Generic;
//DAO Reference
using Spencer.DAO;

namespace Spencer.DatabaseService
{
    public interface ITransactionDetailDatabaseService
    {
        /// <summary>
        /// inserts user ordered products in DB
        /// </summary>
        /// <param name="userOrderList">List<TransactionDetailDAO></param>
        /// <returns></returns>
        int InsertOrders(ref List<TransactionDetailDAO> userOrderList);        
    }
}
