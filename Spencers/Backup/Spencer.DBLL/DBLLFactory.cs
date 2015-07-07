using System;
using System.Collections;
//DatabaseService Reference
using Spencer.DatabaseService;

namespace Spencer.DBLL
{
    /// <summary>
    /// Created by: Anandhan S
    /// Created on:23/12/2010
    /// </summary>
    public class DBLLFactory:DBDelegateFactory
    {
        #region Member Declaration
        private static string _nameSpace = "Spencer.DBLL";
        public static Hashtable _factory = new Hashtable(); 
        #endregion

        #region GetDelegate
        /// <summary>
        /// Creates object for the corresponding classes passed
        /// </summary>
        /// <param name="typeName">string</param>
        /// <returns></returns>
        protected override object GetDBLL(string typeName)
        {
            if (_factory.Contains(typeName) == false)
            {
                lock (_factory.SyncRoot)
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
            }
            return _factory[typeName];
        } 
        #endregion
    }
}
