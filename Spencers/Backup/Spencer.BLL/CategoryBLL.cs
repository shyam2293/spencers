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
    public class CategoryBLL:ICategoryBussinessService
    {
        #region ICategoryBussinessService Members
        /// <summary>
        /// retreives single category image from DB
        /// </summary>
        /// <param name="categoryId">string</param>
        /// <returns></returns>
        public DataTable RetreiveAllCategory()
        {
            ICategoryDatabaseService categoryDatabaseService = null;
            try
            {
                categoryDatabaseService = DBDelegateFactory.Current.CategoryDatabaseService;                
                return categoryDatabaseService.RetreiveAllCategory();
            }            
            finally
            {
                categoryDatabaseService = null;
            }
        }

        /// <summary>
        /// retreives all category information
        /// </summary>
        /// <returns>table</returns>
        public byte[] RetreiveCategoryImage(string categoryId)
        {
            ICategoryDatabaseService categoryDatabaseService = null;
            try
            {
                categoryDatabaseService = DBDelegateFactory.Current.CategoryDatabaseService;
                return categoryDatabaseService.RetreiveCategoryImage(categoryId);
            }
            finally
            {
                categoryDatabaseService = null;
            }
        }
        #endregion
    }
}
