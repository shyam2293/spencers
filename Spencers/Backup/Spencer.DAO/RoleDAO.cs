using System;

namespace Spencer.DAO
{
    /// <summary>
    /// DAO For the Role Class.
    /// Uses the Feature of C# 3.0 (Automatic Properties)
    /// </summary>
    [Serializable]
    public class RoleDAO : IDisposable
    {
        #region Properties

        /// <summary>
        /// Gets & Sets the value of RoleId
        /// </summary>
        public string RoleId { get; set; }

        /// <summary>
        /// Gets & Sets the value of RoleName
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// Gets & Sets the value of RoleDescription
        /// </summary>
        public string RoleDescription { get; set; } 
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
