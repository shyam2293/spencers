using System;

namespace Spencer.DAO
{
    /// <summary>
    /// DAO For the Category Class.
    /// Uses the Feature of C# 3.0 (Automatic Properties)
    /// </summary>
    [Serializable]
    public class CategoryDAO : IDisposable
    {
        #region Properties

        /// <summary>
        /// Gets & Sets the value of categoryId
        /// </summary>
        public string CategoryId { get; set; }

        /// <summary>
        /// Gets & Sets the value of categoryName
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Gets & Sets the value of Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets & Sets the value of picture
        /// </summary>
        public string Picture { get; set; } 

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
