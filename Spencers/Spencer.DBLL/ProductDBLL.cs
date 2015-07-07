using System;
using System.Collections.Generic;
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
    public class ProductDBLL : IProductDatabaseService
    {
        #region IProductDatabaseService Members
        /// <summary>
        /// retreives product based on word matches
        /// </summary>
        /// <param name="productName">string</param>
        /// <param name="count">int</param>
        /// <returns></returns>
        public string[] RetreiveAllProduct(string productName, int count)
        {
            Database database = null;
            DbCommand selectCommand = null;
            DataSet dataset = null;
            List<string> list = null;
            try
            {
                database = DatabaseFactory.CreateDatabase();
                selectCommand = database.GetStoredProcCommand("uspRetreiveAllProduct");
                database.AddInParameter(selectCommand, "productName", DbType.String, productName);
                database.AddInParameter(selectCommand, "count", DbType.Int16, count);
                dataset = database.ExecuteDataSet(selectCommand);

                list = new List<string>();
                foreach (DataRow row in dataset.Tables[0].Rows)
                    list.Add(row["productName"].ToString());

                return list.ToArray();
            }
            catch (Exception ex)
            {
                SpencerLogger.Error("ProductDBLL->RetreiveProducts()", ex);
                throw new BaseException("DBSelect");
            }
            finally
            {
                if (selectCommand.Connection.State == ConnectionState.Open)
                    selectCommand.Connection.Close();
                selectCommand = null;
                database = null;
                list = null;
                dataset = null;
            }
        }

        /// <summary>
        /// retreives all product informations
        /// </summary>
        /// <returns></returns>
        public DataTable RetreiveAllProducts()
        {
            Database database = null;
            DbCommand selectCommand = null;
            try
            {
                database = DatabaseFactory.CreateDatabase();
                selectCommand = database.GetStoredProcCommand("uspRetreiveAllProducts");
                return database.ExecuteDataSet(selectCommand).Tables[0];
            }
            catch (Exception ex)
            {
                SpencerLogger.Error("ProductDBLL->RetreiveAllProducts()", ex);
                throw new BaseException("DBSelect");
            }
            finally
            {
                if (selectCommand.Connection.State == ConnectionState.Open)
                    selectCommand.Connection.Close();
                selectCommand = null;
                database = null;
            }
        }                

        #endregion
    }
}
