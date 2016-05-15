using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPPContracts;
using System.IO;
using System.Configuration;

namespace IppDataAccess
{
    public class UserIDFileStore : IUserStore
    {
        string IUserStore.GetUserID()
        {
            string userId = string.Empty;

            string userIDStoreFilePath = getDataStorePath();
          
            if(File.Exists(userIDStoreFilePath))
            {
                using (var sr = new StreamReader(userIDStoreFilePath))
                {
                    userId = sr.ReadToEnd().Trim();
                }
            }
            return userId;
        }
        private string getDataStorePath()
        {
            string userIDStoreFilePath = string.Empty;
            var dataStorePath = ConfigurationManager.AppSettings["UserIDStoreFilePath"];
            if(!string.IsNullOrEmpty(dataStorePath))
            {
                 userIDStoreFilePath = dataStorePath.ToString();
            }
            return userIDStoreFilePath;
        }
    }
}
