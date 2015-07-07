using System.Data;
//BussinessService Reference
using Spencer.BussinessService;
//DAO Reference
using Spencer.DAO;
//Database Reference
using Spencer.DatabaseService;

namespace Spencer.BLL
{
    /// <summary>
    /// Created by: Anandhan S
    /// Created on: 23/12/2010
    /// </summary>
    public class ProductBLL:IProductBussinessService
    {
        #region IProductBussinessService Members

        /// <summary>
        /// retreives product based on word matches
        /// </summary>
        /// <param name="productName">string</param>
        /// <param name="count">int</param>
        /// <returns></returns>
        public string[] RetreiveAllProduct(string productName, int count)
        {
            IProductDatabaseService productDatabaseService = null;
            try
            {
                productDatabaseService = DBDelegateFactory.Current.ProductDatabaseService;
                return productDatabaseService.RetreiveAllProduct(productName,count);
            }
            finally
            {
                productDatabaseService = null;
            }
        }

        /// <summary>
        /// retreives all product informations
        /// </summary>
        /// <returns></returns>
        public DataTable RetreiveAllProducts()
        {
            IProductDatabaseService productDatabaseService = null;
            try
            {
                productDatabaseService = DBDelegateFactory.Current.ProductDatabaseService;
                return productDatabaseService.RetreiveAllProducts();
            }
            finally
            {
                productDatabaseService = null;
            }
        }                

        #endregion
    }
}
