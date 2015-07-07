using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Transactions;
//DAO Reference
using Spencer.DAO;
//Microsoft Enterprise Library 4.0
using Microsoft.Practices.EnterpriseLibrary.Data;
//Database Reference
using Spencer.DatabaseService;
//Utility Reference
using Spencer.Utility;

namespace Spencer.DBLL
{
    /// <summary>
    /// Created by: Anandhan S
    /// Created on: 23/12/2010
    /// </summary>
    public class TransactionDetailDBLL:ITransactionDetailDatabaseService
    {
        #region ITransactionDetailDatabaseService Members
        /// <summary>
        /// inserts user ordered products in DB
        /// </summary>
        /// <param name="userOrderList">List<TransactionDetailDAO></param>
        /// <returns></returns>
        public int InsertOrders(ref List<TransactionDetailDAO> userOrderList)
        {
            using (TransactionScope tranScope = new TransactionScope())
            {
                Database database = null;
                DbCommand insertCommand = null;                
                try
                {
                    database = DatabaseFactory.CreateDatabase();
                    int count = userOrderList.Count;
                    DataTable orderDetailsTable = new DataTable();
                    foreach (TransactionDetailDAO orderList in userOrderList)
                    {
                        insertCommand = database.GetStoredProcCommand("uspInserBulktOrders");
                        database.AddInParameter(insertCommand, "@orderId", DbType.String, orderList.OrderId);
                        database.AddInParameter(insertCommand, "@productId", DbType.String, orderList.ProductId);
                        int result = database.ExecuteNonQuery(insertCommand);

                    }
                    tranScope.Complete();
                    return 1;
                }
                catch (Exception ex)
                {
                    SpencerLogger.Error("UserDetailsDatabaseService->InsertOrder()", ex);
                    throw new BaseException("DBInsert");
                }
                finally
                {
                    if (insertCommand.Connection.State == ConnectionState.Open)
                        insertCommand.Connection.Close();
                    insertCommand = null;
                    database = null;
                }
            }
        }

        #endregion        
    }
}


/*
 * public int InsertOrders(ref List<TransactionDetailDAO> userOrderList)
        {
            using (TransactionScope tranScope = new TransactionScope())
            {
                Database database = null;
                DbCommand insertCommand = null;                
                try
                {
                    database = DatabaseFactory.CreateDatabase();
                    int count = userOrderList.Count;
                    foreach (TransactionDetailDAO orderList in userOrderList)
                    {
                        insertCommand = database.GetStoredProcCommand("uspInsertOrders");
                        database.AddInParameter(insertCommand, "orderId", DbType.String, orderList.OrderId);
                        database.AddInParameter(insertCommand, "productId", DbType.String, orderList.ProductId);
                        database.AddInParameter(insertCommand, "unitPrice", DbType.Decimal, orderList.UnitPrice);
                        database.AddInParameter(insertCommand, "quantity", DbType.Int16, orderList.Quantity);
                        int result = database.ExecuteNonQuery(insertCommand);

                        //if (result > 0 && count <= userOrderList.Count)
                        //    userOrderList.Remove(orderList);
                    }
                    tranScope.Complete();
                    return 1;
                }
                catch (Exception ex)
                {
                    SpencerLogger.Error("UserDetailsDatabaseService->InsertOrder()", ex);
                    throw new BaseException("DBInsert");
                }
                finally
                {
                    if (insertCommand.Connection.State == ConnectionState.Open)
                        insertCommand.Connection.Close();
                    insertCommand = null;
                    database = null;
                }
            }
        }
*/