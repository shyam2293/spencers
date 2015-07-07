using System;

namespace Spencer.DAO
{
    /// <summary>
    /// DAO For the Product Class.
    /// Uses the Feature of C# 3.0 (Automatic Properties)
    /// </summary>
    [Serializable]
    public class ProductDAO : IDisposable
    {
        #region Properties

        /// <summary>
        /// Gets & Sets the value of productId
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// Gets & Sets the value of productName
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets & Sets the value of Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets & Sets the value of unitPrice
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets & Sets the value of stock
        /// </summary>
        public int UnitsInStock { get; set; }

        /// <summary>
        /// Gets & Sets the value of categoryId
        /// </summary>
        public string CategoryId { get; set; }

        /// <summary>
        /// Gets & Sets the value of picture
        /// </summary>
        public byte[] Picture { get; set; } 
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
