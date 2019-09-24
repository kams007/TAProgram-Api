using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using BigCalculation.Helper;
using BigCalculation.Models;
using BigCalculation.Models.ViewModels;
using BigCalculation.Repositories.Interfaces;
using BigCalculation.Services.Interfaces;

namespace BigCalculation.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly IRepository<CalculationHistory> _repository;
        private readonly IRepository<User> _userRepository;
        private readonly IUserService _userService;
        private readonly ICalculationRepository _calculationRepository;

        public CalculationService(IRepository<CalculationHistory> calculationRepository, IUserService userService, IRepository<User> userRepository, ICalculationRepository calculationRepository1)
        {
            _repository = calculationRepository;
            _userService = userService;
            _userRepository = userRepository;
            _calculationRepository = calculationRepository1;
        }

        public bool DoCalculation(Payload model)
        {
            try
            {
                var user = _userService.GetByUserName(model.UserName) ?? CreateUser(model.UserName);
                model = DoSum(model);
                var history = HistoryModelInitialization(model, user);
                _repository.Insert(history);
                _repository.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<CalculationHistory> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable GetAllCustom()
        {
            return _calculationRepository.GetAllCustom();
        }

        private CalculationHistory HistoryModelInitialization(Payload model, Entity user)
        {
            return new CalculationHistory
            {
                FirstNumber = model.FirstNumber,
                SecondNumber = model.SecondNumber,
                SummationResult = model.SummationResult,
                UserId = user.Id
            };
        }

        private Payload DoSum(Payload model)
        {
            AlterMaxLength(model);

            var first = model.FirstNumber.ReverseStr();
            var second = model.SecondNumber.ReverseStr();

            var carry = MathOperation(first, second, out var outputSum);

            if (carry > 0)
                outputSum += (char)(carry + '0');

            model.SummationResult = outputSum.ReverseStr();
            return model;
        }

        private int MathOperation(string first, string second, out string outputSum)
        {
            var carry = 0;
            outputSum = string.Empty;


            for (var i = 0; i < first.Length; i++)
            {
                var sum = ((int)(first[i] - '0') + (int)(second[i] - '0') + carry);
                outputSum += (char)(sum % 10 + '0');
                carry = sum / 10;
            }
            
            carry = AddRemainingDigits(first, second, carry, outputSum, out var totalSum);
            return carry;
        }

        private int AddRemainingDigits(string first, string second, int carry, string outputSum, out string totalSum)
        {
            totalSum = outputSum;

            for (var i = first.Length; i < second.Length; i++)
            {
                var sum = ((int)(second[i] - '0') + carry);
                totalSum += (char)(sum % 10 + '0');
                carry = sum / 10;
            }

            return carry;
        }

        private void AlterMaxLength(Payload model)
        {
            if (model.FirstNumber.Length <= model.SecondNumber.Length) return;
            var temp = model.FirstNumber;
            model.FirstNumber = model.SecondNumber;
            model.SecondNumber = temp;
        }

        private User CreateUser(string userName)
        {
            var user = new User
            {
                UserName = userName
            };
            _userRepository.Insert(user);
            _userRepository.SaveChanges();
            return user;
        }

    }
}