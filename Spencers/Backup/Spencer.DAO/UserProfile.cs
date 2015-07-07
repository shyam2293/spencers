using System;

namespace Spencer.DAO
{
    /// <summary>
    /// DAO For the UserProfile Class.
    /// Uses the Feature of C# 3.0 (Automatic Properties)
    /// </summary>
    [Serializable]
    public class UserProfile : IDisposable
    {
        #region Properties

        /// <summary>
        /// Gets & Sets the value of UserId
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Gets & Sets the value of PropertyName
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// Gets & Sets the value of PropertyValue
        /// </summary>
        public string PropertyValue { get; set; }

        /// <summary>
        /// Gets & Sets the value of LastUpdate
        /// </summary>
        public DateTime LastUpdate { get; set; } 

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
