using System.Data;
//DAO Reference
using Spencer.DAO;

namespace Spencer.DatabaseService
{
    public interface IProductDatabaseService
    {
        /// <summary>
        /// retreives product based on word matches
        /// </summary>
        /// <param name="productName">string</param>
        /// <param name="count">int</param>
        /// <returns></returns>
        string[] RetreiveAllProduct(string productName, int count);

        /// <summary>
        /// retreives all product informations
        /// </summary>
        /// <returns></returns>
        DataTable RetreiveAllProducts();
    }
}
