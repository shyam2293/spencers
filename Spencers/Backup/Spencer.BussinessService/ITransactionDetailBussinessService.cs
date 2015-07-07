using System.Collections.Generic;
//DAO Reference
using Spencer.DAO;

namespace Spencer.BussinessService
{
    public interface ITransactionDetailBussinessService
    {
        /// <summary>
        /// inserts user ordered products in DB
        /// </summary>
        /// <param name="userOrderList">List<TransactionDetailDAO></param>
        /// <returns></returns>
        int InsertOrders(ref List<TransactionDetailDAO> userOrderList);        
    }
}
