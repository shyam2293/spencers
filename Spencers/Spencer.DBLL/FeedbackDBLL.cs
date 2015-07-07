using System;
using System.Data;
using System.Data.Common;
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
    public class FeedbackDBLL : IFeedbackDatabaseService
    {
        #region IFeedbackDatabaseService Members
        /// <summary>
        /// insertes user comments
        /// </summary>
        /// <param name="userFeedback">FeedbackDAO</param>
        /// <returns></returns>
        public int InsertProductComment(FeedbackDAO userFeedback)
        {
            Database database = null;
            DbCommand insertCommand = null;
            try
            {
                database = DatabaseFactory.CreateDatabase();
                insertCommand = database.GetStoredProcCommand("uspInsertProductComment");
                database.AddInParameter(insertCommand, "userId", DbType.String,userFeedback.UserID);
                database.AddInParameter(insertCommand, "productId", DbType.String, userFeedback.ProductId);
                database.AddInParameter(insertCommand, "description", DbType.String,userFeedback.Description);
                return database.ExecuteNonQuery(insertCommand);
            }
            catch (Exception ex)
            {
                SpencerLogger.Error("ProductDBLL->InsertProductComment()", ex);
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

        /// <summary>
        /// retreives users comments of a product
        /// </summary>
        /// <param name="productId">string</param>
        /// <returns></returns>
        public DataTable RetreiveProductComments(string productId)
        {
            Database database = null;
            DbCommand selectCommand = null;
            try
            {
                database = DatabaseFactory.CreateDatabase();
                selectCommand = database.GetStoredProcCommand("uspRetreiveProductComments");
                database.AddInParameter(selectCommand, "productId", DbType.String, productId);
                return database.ExecuteDataSet(selectCommand).Tables[0];
            }
            catch (Exception ex)
            {
                SpencerLogger.Error("ProductDBLL->RetreiveProductComments()", ex);
                throw new BaseException("DBSelect");
            }
            finally
            {
                if (selectCommand.Connection.State == ConnectionState.Open)
                    selectCommand.Connection.Close();
                selectCommand = null;
                database = null;
            }
        }

        #endregion
    }
}
