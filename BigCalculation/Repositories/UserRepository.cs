using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BigCalculation.DBContext;
using BigCalculation.Models;
using BigCalculation.Repositories.Interfaces;

namespace BigCalculation.Repositories
{
    public class UserRepository: IUserRepository
    {
        protected readonly CalculationDbContext _context;
        public UserRepository() :
            this(new CalculationDbContext())
        {

        }
        private UserRepository(CalculationDbContext context)
        {
            _context = context;
        }

        public User GetByUserName(string userName)
        {
            return _context.Users.FirstOrDefault(_ => _.UserName == userName);
        }
    }
}