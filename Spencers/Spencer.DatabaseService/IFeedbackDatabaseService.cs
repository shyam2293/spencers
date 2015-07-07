using System.Data;
//DAO Reference
using Spencer.DAO;

namespace Spencer.DatabaseService
{
    public interface IFeedbackDatabaseService
    {
        /// <summary>
        /// insertes user comments
        /// </summary>
        /// <param name="userFeedback">FeedbackDAO</param>
        /// <returns></returns>
        int InsertProductComment(FeedbackDAO userFeedback);

        /// <summary>
        /// retreives users comments of a product
        /// </summary>
        /// <param name="productId">string</param>
        /// <returns></returns>
        DataTable RetreiveProductComments(string productId);
    }
}
