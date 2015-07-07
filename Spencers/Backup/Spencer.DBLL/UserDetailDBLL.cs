using System;
using System.Collections.Generic;
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
    public class UserDetailDBLL:IUserDetailDatabaseService
    {
        #region IUserDetailsDatabaseService Members
        /// <summary>
        /// Inserts new user info into DB
        /// </summary>
        /// <param name="userDetailsDAO">UserDetailDAO</param>
        /// <returns></returns>
        public int CreateUser(UserDetailDAO userDetailsDAO)
        {
            Database database = null;
            DbCommand insertCommand = null;
            try
            {
                database = DatabaseFactory.CreateDatabase();
                insertCommand = database.GetStoredProcCommand("uspCreateUser");
                database.AddInParameter(insertCommand, "userId", DbType.String, userDetailsDAO.UserId);
                database.AddInParameter(insertCommand, "password", DbType.String, userDetailsDAO.Password);
                database.AddInParameter(insertCommand, "securityQuestion", DbType.String, userDetailsDAO.SecurityQuestion);
                database.AddInParameter(insertCommand, "answer", DbType.String, userDetailsDAO.Answer);
                database.AddInParameter(insertCommand, "firstName", DbType.String, userDetailsDAO.FirstName);
                database.AddInParameter(insertCommand, "lastName", DbType.String, userDetailsDAO.LastName);
                database.AddInParameter(insertCommand, "address", DbType.String, userDetailsDAO.Address);
                database.AddInParameter(insertCommand, "mobileNo", DbType.String, userDetailsDAO.MobileNo);
                database.AddInParameter(insertCommand, "email", DbType.String, userDetailsDAO.Email);
                database.AddInParameter(insertCommand, "imageType", DbType.String, userDetailsDAO.ImageType);
                database.AddInParameter(insertCommand, "image", DbType.Binary, userDetailsDAO.Image);
                return database.ExecuteNonQuery(insertCommand);
            }
            catch (SqlException ex)
            {
                SpencerLogger.Error("UserDetailsDatabaseService->CreateUser()", ex);
                throw new BaseException("DBInsert");
            }
            catch (Exception ex)
            {
                SpencerLogger.Error("UserDetailsDatabaseService->CreateUser()", ex);
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
        /// Validates the userId in the DB
        /// </summary>
        /// <param name="userId">string</param>
        /// <returns></returns>
        public bool ValidateUserId(string userId)
        {
            Database database = null;
            DbCommand insertCommand = null;
            try
            {
                database = DatabaseFactory.CreateDatabase();
                insertCommand = database.GetStoredProcCommand("uspValidateUser");
                database.AddInParameter(insertCommand, "userId", DbType.String, userId);
                return (int)database.ExecuteScalar(insertCommand) > 0;
            }
            catch (SqlException ex)
            {
                SpencerLogger.Error("UserDetailsDatabaseService->ValidateUser()", ex);
                throw new BaseException("DBSelect");
            }
            catch (Exception ex)
            {
                SpencerLogger.Error("UserDetailsDatabaseService->ValidateUser()", ex);
                throw new BaseException("DBSelect");
            }
            finally
            {
                if (insertCommand.Connection.State == System.Data.ConnectionState.Open)
                    insertCommand.Connection.Close();
                database = null;
            }
        }

        /// <summary>
        /// validationg userId & password
        /// </summary>
        /// <param name="userId">string</param>
        /// <param name="password">string</param>
        /// <returns></returns>
        public bool AuthenticateUser(string userId, string password)
        {
            Database database = null;
            DbCommand boolCommand = null;
            try
            {
                database = DatabaseFactory.CreateDatabase();
                boolCommand = database.GetStoredProcCommand("uspAuthenticateUser");
                database.AddInParameter(boolCommand, "userId", DbType.String, userId);
                database.AddInParameter(boolCommand, "password", DbType.String, password);
                return (int)database.ExecuteScalar(boolCommand) > 0;
            }
            catch (SqlException ex)
            {
                SpencerLogger.Error("UserDetailsDatabaseService->AuthenticateUser()", ex);
                throw new BaseException("DBSelect");
            }
            catch (Exception ex)
            {
                SpencerLogger.Error("UserDetailsDatabaseService->AuthenticateUser()", ex);
                throw new BaseException("DBSelect");
            }
            finally
            {
                if (boolCommand.Connection.State == System.Data.ConnectionState.Open)
                    boolCommand.Connection.Close();
                database = null;
            }
        }

        public string RetreiveSecurityQuestion(string userId)
        {
            return null;
        }

        public string RetreivePassword(string userId, string securityQuestion, string securityAnswer)
        {
            return null;
        }

        /// <summary>
        /// retreives personal details
        /// </summary>
        /// <param name="userId">string</param>
        /// <returns></returns>
        public DataTable PersonalDetails(string userId)
        {
            Database database = null;
            DbCommand selectCommand = null;
            try
            {
                database = DatabaseFactory.CreateDatabase();
                selectCommand = database.GetStoredProcCommand("uspPersonalDetails");
                database.AddInParameter(selectCommand, "userId", DbType.String, userId);
                return database.ExecuteDataSet(selectCommand).Tables[0];

            }
            catch (SqlException ex)
            {
                SpencerLogger.Error("UserDetailsDBLL->PersonalDetails()", ex);
                throw new BaseException("DBSelect");
            }
            catch (Exception ex)
            {
                SpencerLogger.Error("UserDetailsDBLL->PersonalDetails()", ex);
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
        /// updates userInformation into database
        /// </summary>
        /// <param name="userDetailsDAO"></param>
        /// <returns></returns>
        public int UpdatePersonalDetails(UserDetailDAO userDetailsDAO)
        {
            Database database = null;
            DbCommand insertCommand = null;
            try
            {
                database = DatabaseFactory.CreateDatabase();
                insertCommand = database.GetStoredProcCommand("uspCreateUser");
                database.AddInParameter(insertCommand, "userId", DbType.String, userDetailsDAO.UserId);
                database.AddInParameter(insertCommand, "firstName", DbType.String, userDetailsDAO.FirstName);
                database.AddInParameter(insertCommand, "lastName", DbType.String, userDetailsDAO.LastName);
                database.AddInParameter(insertCommand, "address", DbType.String, userDetailsDAO.Address);
                database.AddInParameter(insertCommand, "mobileNo", DbType.String, userDetailsDAO.MobileNo);
                database.AddInParameter(insertCommand, "email", DbType.String, userDetailsDAO.Email);
                database.AddInParameter(insertCommand, "imageType", DbType.String, userDetailsDAO.ImageType);
                database.AddInParameter(insertCommand, "image", DbType.Binary, userDetailsDAO.Image);
                return database.ExecuteNonQuery(insertCommand);
            }
            catch (SqlException ex)
            {
                SpencerLogger.Error("UserDetailsDatabaseService->UpdatePersonalDetails()", ex);
                throw new BaseException("DBInsert");
            }
            catch (Exception ex)
            {
                SpencerLogger.Error("UserDetailsDatabaseService->UpdatePersonalDetails()", ex);
                throw new BaseException("DBInsert");
            }
            finally
            {
                if (insertCommand.Connection.State == System.Data.ConnectionState.Open)
                    insertCommand.Connection.Close();
                database = null;
            }
        }

        #endregion
    }
}
