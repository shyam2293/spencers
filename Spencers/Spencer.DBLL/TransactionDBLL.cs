using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
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
    public class TransactionDBLL : ITransactionDatabaseService
    {
        #region ITransactionDatabaseService Members
        /// <summary>
        /// retreives user transaction
        /// </summary>
        /// <param name="userId">string</param>
        /// <returns></returns>
        public DataTable MyTransactions(string userId)
        {
            Database database = null;
            DbCommand selectCommand = null;
            try
            {
                database = DatabaseFactory.CreateDatabase();
                selectCommand = database.GetStoredProcCommand("uspMyTransactions");
                database.AddInParameter(selectCommand, "userId", DbType.String, userId);
                return database.ExecuteDataSet(selectCommand).Tables[0];

            }
            catch (SqlException ex)
            {
                SpencerLogger.Error("UserDetailsDBLL->MyTransactions()", ex);
                throw new BaseException("DBSelect");
            }
            catch (Exception ex)
            {
                SpencerLogger.Error("UserDetailsDBLL->MyTransactions()", ex);
                throw new BaseException("DBSelect");
            }
            finally
            {
                if (selectCommand.Connection.State == ConnectionState.Open)
                    selectCommand.Connection.Close();
                selectCommand = null;
            }
        }

        /// <summary>
        /// inserts user details & retreives orderID
        /// </summary>
        /// <param name="userTransaction">TransactionDAO</param>
        /// <returns></returns>
        public string GetOrderId(TransactionDAO userTransaction)
        {
            using (TransactionScope tranScope = new TransactionScope())
            {
                Database database = null;
                DbCommand insertCommand = null;
                DataSet dataset = null;
                try
                {
                    database = DatabaseFactory.CreateDatabase();
                    insertCommand = database.GetStoredProcCommand("uspGetOrderId");
                    database.AddInParameter(insertCommand, "@userId", DbType.String,userTransaction.UserID);
                    database.AddInParameter(insertCommand, "@address", DbType.String,userTransaction.DeliveryAddress);
                    dataset = database.ExecuteDataSet(insertCommand);
                    tranScope.Complete();
                    return dataset.Tables[0].Rows[0][0].ToString();
                }
                catch (SqlException ex)
                {
                    SpencerLogger.Error("UserDetailsDBLL->GetOrderId()", ex);
                    throw new BaseException("DBSelect");
                }
                catch (Exception ex)
                {
                    SpencerLogger.Error("UserDetailsDatabaseService->GetOrderId()", ex);
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
