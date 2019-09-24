using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BigCalculation.Models;
using BigCalculation.Repositories.Interfaces;
using BigCalculation.Services.Interfaces;

namespace BigCalculation.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository1)
        {
            _userRepository = userRepository1;
        }

        public User GetByUserName(string userName)
        {
            return _userRepository.GetByUserName(userName);
        }
    }
}