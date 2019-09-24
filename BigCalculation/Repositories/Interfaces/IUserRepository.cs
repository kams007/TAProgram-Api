using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BigCalculation.Models;

namespace BigCalculation.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetByUserName(string userName);
    }
}