using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IppWebApi.Contracts
{
    public interface IUserStore
    {
        string GetUserID();
    }
}