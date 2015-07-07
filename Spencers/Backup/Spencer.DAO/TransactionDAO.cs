using System;

namespace Spencer.DAO
{
    /// <summary>
    /// DAO For the Transaction Class.
    /// Uses the Feature of C# 3.0 (Automatic Properties)
    /// </summary>
    [Serializable]
    public class TransactionDAO : IDisposable
    {
        #region Properties

        /// <summary>
        /// Gets & Sets the value of orderId
        /// </summary>
        //public int OrderId { get; set; }

        /// <summary>
        /// Gets & Sets the value of userID
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// Gets & Sets the value of DeliveryAddress
        /// </summary>
        public string DeliveryAddress { get; set; }

        //public DateTime DeliveryDate { get; set; }
        //public char DeliveryStatus { get; set; }
        //public DateTime OrderDate { get; set; } 
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
