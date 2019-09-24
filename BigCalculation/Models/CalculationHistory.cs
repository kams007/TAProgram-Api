using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BigCalculation.Models
{
    public class CalculationHistory:Entity
    {
        public string FirstNumber { get; set; }
        public string SecondNumber { get; set; }
        public string SummationResult { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

    }
}