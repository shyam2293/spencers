using System.Data;
//DAO Reference
using Spencer.DAO;

namespace Spencer.DatabaseService
{
    public interface ICategoryDatabaseService
    {
        /// <summary>
        /// retreives single category image from DB
        /// </summary>
        /// <param name="categoryId">string</param>
        /// <returns></returns>
        byte[] RetreiveCategoryImage(string categoryId);

        /// <summary>
        /// retreives all category information
        /// </summary>
        /// <returns>table</returns>
        DataTable RetreiveAllCategory();        
    }
}
