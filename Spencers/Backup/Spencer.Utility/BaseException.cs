using System;
using System.Xml;
using System.Web;

namespace Spencer.Utility
{
    /// <summary>
    /// Created by: Anandhan S
    /// Created on: 23/12/2010
    /// </summary>
    public class BaseException:ApplicationException
    {
        #region Constructors
        public BaseException()
            : base()
        {
        }

        public BaseException(string message)
            : base(message)
        {
            string customMessage = GetCustomMessage(message);
            if (!customMessage.Equals(string.Empty))
                throw new BaseException(customMessage);
        } 
        #endregion

        #region Private Methods
        /// <summary>
        /// Converting Exception messge to userDefined
        /// </summary>
        /// <param name="message"></param>
        /// <returns>custom message</returns>
        private string GetCustomMessage(string message)
        {
            XmlDocument xDoc = null;
            XmlNode node = null;
            try
            {
                HttpContext context = HttpContext.Current;
                string path = context.Server.MapPath("~/Common/ErrorMessage.xml");

                xDoc = new XmlDocument();
                xDoc.Load(path);
                node = xDoc.SelectSingleNode("//Message[@key='" + message + "']");
                if (node != null)
                    return node.InnerText;
                else
                    return string.Empty;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                node = null;
            }
        } 
        #endregion

    }
}
