using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BigCalculation.Models;

namespace BigCalculation.Services.Interfaces
{
    public interface IUserService
    {
        User GetByUserName(string userName);
    }
}