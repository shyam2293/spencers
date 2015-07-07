using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
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
    public class WishListDBLL : IWishListDatabaseService
    {
        #region IWishListDatabaseService Members
        /// <summary>
        /// retreives user's wish list
        /// </summary>
        /// <param name="userId">string</param>
        /// <returns></returns>
        public DataTable MyWishList(string userId)
        {
            Database database = null;
            DbCommand selectCommand = null;
            try
            {
                database = DatabaseFactory.CreateDatabase();
                selectCommand = database.GetStoredProcCommand("uspMyWishList");
                database.AddInParameter(selectCommand, "userId", DbType.String, userId);
                return database.ExecuteDataSet(selectCommand).Tables[0];

            }
            catch (SqlException ex)
            {
                SpencerLogger.Error("UserDetailsDBLL->MyWishList()", ex);
                throw new BaseException("DBSelect");
            }
            catch (Exception ex)
            {
                SpencerLogger.Error("UserDetailsDBLL->MyWishList()", ex);
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
        /// insert user wish list
        /// </summary>
        /// <param name="userWishList">WishListDAO</param>
        /// <returns></returns>
        public int AddToWishList(WishListDAO userWishList)
        {
            Database database = null;
            DbCommand insertCommand = null;
            try
            {
                database = DatabaseFactory.CreateDatabase();
                insertCommand = database.GetStoredProcCommand("uspAddToWishList");
                database.AddInParameter(insertCommand, "userId", DbType.String, userWishList.UserId);
                database.AddInParameter(insertCommand, "productId", DbType.String, userWishList.ProductId);
                return database.ExecuteNonQuery(insertCommand);
            }
            catch (SqlException ex)
            {
                SpencerLogger.Error("UserDetailsDatabaseService->AddToWishList()", ex);
                throw new BaseException("DBInsert");
            }
            catch (Exception ex)
            {
                SpencerLogger.Error("UserDetailsDatabaseService->AddToWishList()", ex);
                throw new BaseException("DBInsert");
            }
            finally
            {
                if (insertCommand.Connection.State == System.Data.ConnectionState.Open)
                    insertCommand.Connection.Close();
                database = null;
            }
        }

        /// <summary>
        /// delete user wish list
        /// </summary>
        /// <param name="userWishList">WishListDAO</param>
        /// <returns></returns>
        public int DeleteWishList(WishListDAO userWishList)
        {
            Database database = null;
            DbCommand deleteCommand = null;
            try
            {
                database = DatabaseFactory.CreateDatabase();
                deleteCommand = database.GetStoredProcCommand("uspDeleteWishList");
                database.AddInParameter(deleteCommand, "userId", DbType.String, userWishList.UserId);
                database.AddInParameter(deleteCommand, "productId", DbType.String, userWishList.ProductId);
                return database.ExecuteNonQuery(deleteCommand);
            }
            catch (SqlException ex)
            {
                SpencerLogger.Error("UserDetailsDatabaseService->DeleteWishList()", ex);
                throw new BaseException("DBDelete");
            }
            catch (Exception ex)
            {
                SpencerLogger.Error("UserDetailsDatabaseService->DeleteWishList()", ex);
                throw new BaseException("DBDelete");
            }
            finally
            {
                if (deleteCommand.Connection.State == System.Data.ConnectionState.Open)
                    deleteCommand.Connection.Close();
                database = null;
            }
        }

        #endregion
    }
}
