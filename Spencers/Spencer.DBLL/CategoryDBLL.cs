using System;
using System.Data;
using System.Data.Common;
//Microsoft Enterprise Library 4.0
using Microsoft.Practices.EnterpriseLibrary.Data;
//Database Reference
using Spencer.DatabaseService;
//Utility Reference
using Spencer.Utility;

namespace Spencer.DBLL
{
    /// <summary>
    /// Created by: Anandhan S
    /// Created on: 23/12/2010
    /// </summary>
    public class CategoryDBLL:ICategoryDatabaseService
    {
        #region ICategoryDatabaseService Members
        /// <summary>
        /// retreives single category image from DB
        /// </summary>
        /// <param name="categoryId">string</param>
        /// <returns></returns>
        public DataTable RetreiveAllCategory()
        {
            Database database = null;
            DbCommand selectCommand = null;
            try
            {
                database = DatabaseFactory.CreateDatabase("SpencerConnectionString");
                selectCommand = database.GetStoredProcCommand("uspRetreiveAllCategory");
                return database.ExecuteDataSet(selectCommand).Tables[0];
            }
            catch (Exception ex)
            {
                SpencerLogger.Error("CategoryDBLL->SearchCategory()", ex);
                throw new BaseException("DBSelect");
            }
            finally
            {
                if (selectCommand.Connection.State == ConnectionState.Open)
                    selectCommand.Connection.Close();
                database = null;
                selectCommand = null;
            }
        }

        /// <summary>
        /// retreives all category information
        /// </summary>
        /// <returns>table</returns>
        public byte[] RetreiveCategoryImage(string categoryId)
        {
            Database database = null;
            DbCommand selectCommand = null;
            try
            {
                database = DatabaseFactory.CreateDatabase();
                selectCommand = database.GetStoredProcCommand("uspRetreiveCategoryImage");
                database.AddInParameter(selectCommand, "@categoryId", DbType.String, categoryId);
                return database.ExecuteScalar(selectCommand) as byte[];
            }
            catch (Exception ex)
            {
                SpencerLogger.Error("CategoryDBLL->RetreiveCategoryImage()", ex);
                throw new BaseException("DBSelect");
            }
            finally
            {
                if (selectCommand.Connection.State == ConnectionState.Open)
                    selectCommand.Connection.Close();
                database = null;
                selectCommand = null;
            }
        }

        #endregion
    }
}
