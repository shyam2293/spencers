using System;

namespace Spencer.DAO
{
    /// <summary>
    /// DAO For the TransactionDetail Class.
    /// Uses the Feature of C# 3.0 (Automatic Properties)
    /// </summary>
    [Serializable]
    public class TransactionDetailDAO : IDisposable
    {
        #region Properties

        /// <summary>
        /// Gets & Sets the value of OrderId
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Gets & Sets the value of productId
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// Gets & Sets the value of UnitPrice
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets & Sets the value of Quantity
        /// </summary>
        public int Quantity { get; set; }
 
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
