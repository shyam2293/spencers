using System.Data;
//DAO Reference
using Spencer.DAO;

namespace Spencer.BussinessService
{
    public interface ICategoryBussinessService
    {
        /// <summary>
        /// retreives single category image from DB
        /// </summary>
        /// <param name="categoryId">string</param>
        /// <returns></returns>
        DataTable RetreiveAllCategory();

        /// <summary>
        /// retreives all category information
        /// </summary>
        /// <returns>table</returns>
        byte[] RetreiveCategoryImage(string categoryId);
    }
}
