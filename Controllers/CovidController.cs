using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api_covid.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CovidController : ControllerBase
    {
        private readonly ILogger<CovidController> _logger;

        public CovidController(ILogger<CovidController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("DadosIniciais")]
        public IActionResult DadosIniciais()
        {
            var response = Service.HttpService<Model.Sumary>.Request("summary");
            var result = response.Countries.OrderByDescending(o=> o.TotalConfirmed).Take(10);
            return !result.Any() ? BadRequest() : Ok(result);
        }

    }
}
