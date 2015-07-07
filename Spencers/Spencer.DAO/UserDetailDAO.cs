using System;

namespace Spencer.DAO
{
    /// <summary>
    /// DAO For the UserDetail Class.
    /// Uses the Feature of C# 3.0 (Automatic Properties)
    /// </summary>
    [Serializable]
    public class UserDetailDAO:IDisposable
    {
        #region Properties

        /// <summary>
        /// Gets & Sets the value of userId
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Gets & Sets the value of RoleId
        /// </summary>
        //public string RoleId { get; set; }

        /// <summary>
        /// Gets & Sets the value of password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets & Sets the value of securityQuestion
        /// </summary>
        public string SecurityQuestion { get; set; }

        /// <summary>
        /// Gets & Sets the value of answer
        /// </summary>
        public string Answer { get; set; }

        /// <summary>
        /// Gets & Sets the value of firstName
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets & Sets the value of lastName
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets & Sets the value of gender
        /// </summary>
       

        /// <summary>
        /// Gets & Sets the value of address
        /// </summary>
        public string Address { get; set; }  
        
        /// <summary>
        /// Gets & Sets the value of mobileNo
        /// </summary>
        public string MobileNo { get; set; }



        /// <summary>
        /// Gets & Sets the value of email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets & Sets the value of registrationDate
        /// </summary>
        //public DateTime RegistrationDate { get; set; }

       
        #endregion

        #region IDisposable Members

        /// <summary>
        /// Diposing object by overriding Dispose()
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
