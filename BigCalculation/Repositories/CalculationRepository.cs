using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BigCalculation.Models.ViewModels;
using BigCalculation.DBContext;
using BigCalculation.Repositories.Interfaces;

namespace BigCalculation.Repositories
{
    public class CalculationRepository:ICalculationRepository
    {

        protected readonly CalculationDbContext _context;
        public CalculationRepository() :
            this(new CalculationDbContext())
        {

        }
        private CalculationRepository(CalculationDbContext context)
        {
            _context = context;
        }

        public IEnumerable GetAllCustom()
        {
            return _context.CalculationHistories
                .Join(_context.Users, c => c.UserId, u => u.Id, (c, u) => new Payload
                {
                    FirstNumber = c.FirstNumber,
                    SecondNumber = c.SecondNumber,
                    SummationResult = c.SummationResult,
                    CalculationDate = c.CreateTime.Value,
                    UserName = u.UserName
                }).ToList();
        }
    }
}