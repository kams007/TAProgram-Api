using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BigCalculation.Repositories.Interfaces
{
    public interface ICalculationRepository
    {
        IEnumerable GetAllCustom();
    }
}