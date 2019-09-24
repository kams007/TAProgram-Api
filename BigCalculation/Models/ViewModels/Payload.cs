using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BigCalculation.Models.ViewModels
{
    public class Payload
    {
        public string FirstNumber { get; set; }
        public string SecondNumber { get; set; }
        public string SummationResult { get; set; }
        public string UserName { get; set; }
        public DateTime CalculationDate { get; set; }
    }
}