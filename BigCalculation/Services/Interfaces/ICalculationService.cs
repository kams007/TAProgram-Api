using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BigCalculation.Models;
using BigCalculation.Models.ViewModels;

namespace BigCalculation.Services.Interfaces
{
    public interface ICalculationService
    {
        bool DoCalculation(Payload model);
        IEnumerable<CalculationHistory> GetAll();
        IEnumerable GetAllCustom();
    }
}