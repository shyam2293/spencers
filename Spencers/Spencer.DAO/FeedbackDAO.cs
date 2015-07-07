using System;

namespace Spencer.DAO
{
    /// <summary>
    /// DAO For the Feedback Class.
    /// Uses the Feature of C# 3.0 (Automatic Properties)
    /// </summary>
    [Serializable]
    public class FeedbackDAO :  IDisposable
    {
        #region Properties

        /// <summary>
        /// Gets & Sets the value of productId
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// Gets & Sets the value of Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets & Sets the value of UserId
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// Gets & Sets the value of Date
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
