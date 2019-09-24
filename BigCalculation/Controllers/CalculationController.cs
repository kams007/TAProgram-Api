using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BigCalculation.Models.ViewModels;
using BigCalculation.Services.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BigCalculation.Controllers
{
    public class CalculationController : ApiController
    {
        private readonly ICalculationService _calculationService;

        public CalculationController(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }

        public IEnumerable Get()
        {
            return _calculationService.GetAllCustom();
        }

        public HttpResponseMessage Post(Payload model)
        {
            var data = _calculationService.DoCalculation(model);
            return data ? Request.CreateResponse(HttpStatusCode.OK, model) : Request.CreateResponse(HttpStatusCode.NotAcceptable, model);
        }
    }
}
