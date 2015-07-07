using System;
using System.Collections;
//BusinessService Reference
using Spencer.BussinessService;

namespace Spencer.BLL
{
    /// <summary>
    /// Created by: Anandhan S
    /// Created on: 23/12/2010
    /// </summary>
    public class BLLFactory:BizDelegateFactory
    {
        #region Member Declaration
        private static string _nameSpace = "Spencer.BLL";
        public static Hashtable _factory = new Hashtable(); 
        #endregion

        #region GetDelegate
        /// <summary>
        /// Creates object for the corresponding classes passed
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns>object</returns>
        protected override object GetBLL(string typeName)
        {
            if (_factory.Contains(typeName) == false)
            {
                try
                {
                    Type type = Type.GetType(_nameSpace + "." + typeName);
                    _factory[typeName] = Activator.CreateInstance(type);
                }
                catch
                {
                    throw;
                }
            }
            return _factory[typeName];
        } 
        #endregion
    }
}


