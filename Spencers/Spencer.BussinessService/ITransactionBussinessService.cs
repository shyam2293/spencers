﻿using System.Data;
//DAO Reference
using Spencer.DAO;

namespace Spencer.BussinessService
{
    public interface ITransactionBussinessService
    {
        /// <summary>
        /// retreives user transaction
        /// </summary>
        /// <param name="userId">string</param>
        /// <returns></returns>
        DataTable MyTransactions(string userId);

        /// <summary>
        /// inserts user details & retreives orderID
        /// </summary>
        /// <param name="userTransaction">TransactionDAO</param>
        /// <returns></returns>
        string GetOrderId(TransactionDAO userTransaction);
    }
}
