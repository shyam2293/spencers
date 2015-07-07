using System;

namespace Spencer.DAO
{
    /// <summary>
    /// DAO For the wishList Class.
    /// Uses the Feature of C# 3.0 (Automatic Properties)
    /// </summary>
    [Serializable]
    public class WishListDAO : IDisposable
    {
        #region Properties

        /// <summary>
        /// Gets & Sets the value of ProductId
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// Gets & Sets the value of userId
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Gets & Sets the value of date
        /// </summary>
        //public DateTime Date { get; set; } 

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
