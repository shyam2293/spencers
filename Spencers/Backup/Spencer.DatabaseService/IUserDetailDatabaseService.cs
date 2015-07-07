using System.Data;
//DAO Reference
using Spencer.DAO;

namespace Spencer.DatabaseService
{
    public interface IUserDetailDatabaseService
    {
        /// <summary>
        /// Inserts new user info into DB
        /// </summary>
        /// <param name="userDetailsDAO">UserDetailDAO</param>
        /// <returns></returns>
        int CreateUser(UserDetailDAO userDetails);

        /// <summary>
        /// Validates the userId in the DB
        /// </summary>
        /// <param name="userId">string</param>
        /// <returns></returns>
        bool ValidateUserId(string userId);

        /// <summary>
        /// validationg userId & password
        /// </summary>
        /// <param name="userId">string</param>
        /// <param name="password">string</param>
        /// <returns></returns>
        bool AuthenticateUser(string userId, string password);

        string RetreiveSecurityQuestion(string userId);

        string RetreivePassword(string userId, string securityQuestion, string securityAnswer);

        /// <summary>
        /// retreives personal details
        /// </summary>
        /// <param name="userId">string</param>
        /// <returns></returns>
        DataTable PersonalDetails(string userId);

        /// <summary>
        /// updates userInformation into database
        /// </summary>
        /// <param name="userDetailsDAO"></param>
        /// <returns></returns>
        int UpdatePersonalDetails(UserDetailDAO userDetailsDAO);      
    }
}
