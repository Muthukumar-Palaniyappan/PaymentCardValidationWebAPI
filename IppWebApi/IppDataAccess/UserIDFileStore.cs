using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPPContracts;
using System.IO;
using System.Configuration;
using System.Web.Hosting;

namespace IppDataAccess
{
    public class UserIDFileStore : IUserStore
    {
    
        string IUserStore.GetUserID()
        {
            string userId = string.Empty;
            string resourcePath = GetResourcePath();
            if (File.Exists(resourcePath))
            {
                using (var sr = new StreamReader(resourcePath))
                {
                    userId = sr.ReadToEnd().Trim();
                }
            }
            return userId;
        }
        private string GetResourcePath()
        {
            string hostPath = HostingEnvironment.MapPath("~");
            string resourcePath = Path.Combine(hostPath, @"..\IppDataAccess\App_Data\WhatsYourId.txt");
            return resourcePath;
        }
        
    }
}
