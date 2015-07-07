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
    public class FeedbackBLL : IFeedbackBussinessService
    {
        #region IFeedbackBussinessService Members

        /// <summary>
        /// insertes user comments
        /// </summary>
        /// <param name="userFeedback">FeedbackDAO</param>
        /// <returns></returns>
        public int InsertProductComment(FeedbackDAO userFeedback)
        {
            IFeedbackDatabaseService feedbackDatabaseService = null;
            try
            {
                feedbackDatabaseService = DBDelegateFactory.Current.FeedbackDatabaseService;
                return feedbackDatabaseService.InsertProductComment(userFeedback);
            }
            finally
            {
                feedbackDatabaseService = null;
            }
        }

        /// <summary>
        /// retreives users comments of a product
        /// </summary>
        /// <param name="productId">string</param>
        /// <returns></returns>
        public DataTable RetreiveProductComments(string productId)
        {
            IFeedbackDatabaseService feedbackDatabaseService = null;
            try
            {
                feedbackDatabaseService = DBDelegateFactory.Current.FeedbackDatabaseService;
                return feedbackDatabaseService.RetreiveProductComments(productId);
            }
            finally
            {
                feedbackDatabaseService = null;
            }
        }

        #endregion
    }
}
