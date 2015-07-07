using System.Data;
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
    public class UserDetailBLL:IUserDetailBussinessService
    {
        #region IUserDetailsBussinessService Members

        /// <summary>
        /// Inserts new user info into DB
        /// </summary>
        /// <param name="userDetailsDAO">UserDetailDAO</param>
        /// <returns></returns>
        public int CreateUser(UserDetailDAO userDetailsDAO)
        {
            IUserDetailDatabaseService userDetailsDatabaseService = null;
            try
            {
                userDetailsDatabaseService = DBDelegateFactory.Current.UserDetailDatabaseService;
                return userDetailsDatabaseService.CreateUser(userDetailsDAO);
            }
            finally
            {
                userDetailsDatabaseService = null;
            }
        }

        /// <summary>
        /// Validates the userId in the DB
        /// </summary>
        /// <param name="userId">string</param>
        /// <returns></returns>
        public bool ValidateUserId(string userId)
        {
            IUserDetailDatabaseService userDetailsDatabaseService = null;
            try
            {
                userDetailsDatabaseService = DBDelegateFactory.Current.UserDetailDatabaseService;
                return userDetailsDatabaseService.ValidateUserId(userId);
            }
            finally
            {
                userDetailsDatabaseService = null;
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
            IUserDetailDatabaseService userDetailsDatabaseService = null;
            try
            {
                userDetailsDatabaseService = DBDelegateFactory.Current.UserDetailDatabaseService;
                return userDetailsDatabaseService.AuthenticateUser(userId, password);
            }
            finally
            {
                userDetailsDatabaseService = null;
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
            IUserDetailDatabaseService userDetailsDatabaseService = null;
            try
            {
                userDetailsDatabaseService = DBDelegateFactory.Current.UserDetailDatabaseService;
                return userDetailsDatabaseService.PersonalDetails(userId);
            }
            finally
            {
                userDetailsDatabaseService = null;
            }
        }

        /// <summary>
        /// updates userInformation into database
        /// </summary>
        /// <param name="userDetailsDAO"></param>
        /// <returns></returns>
        public int UpdatePersonalDetails(UserDetailDAO userDetailsDAO)
        {
            IUserDetailDatabaseService userDetailsDatabaseService = null;
            try
            {
                userDetailsDatabaseService = DBDelegateFactory.Current.UserDetailDatabaseService;
                return userDetailsDatabaseService.UpdatePersonalDetails(userDetailsDAO);
            }
            finally
            {
                userDetailsDatabaseService = null;
            }
        }

        #endregion
    }
}
