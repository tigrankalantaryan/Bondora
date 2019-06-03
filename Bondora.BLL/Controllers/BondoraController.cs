using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bondora.BLL.Models;
using Bondora.BLL.Services;
using Bondora.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace Bondora.BLL.Controllers
{
    [Produces("application/json")]
    [Route("api/Bondora/[action]")]
    [ApiController]
    public class BondoraController : ControllerBase
    {
        private IManagerRepository _manager;
        private static ILogger<BondoraController> logger;
        public BondoraController(IManagerRepository manager, ILogger<BondoraController> _logger)
        {
            _logger = logger;
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetProduct()
        {
            try
            {
                var products = _manager.GetProducts();

                return Ok(products);
            }
            catch (Exception ex)
            {
                logger.LogError("Get Product Action" + ex.Message);
            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult GetInvoice([FromBody]long customerId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var invoce = _manager.GetInvoice(customerId);
                return Ok(invoce);
            }
            catch (Exception ex)
            {
                logger.LogError("GetInvoice Action" + ex.Message);
            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult AddRent([FromBody] RentedInfo data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
               var IsAdded= _manager.AddRent(data.CustomerId, data.RentedData);
                return Ok(IsAdded);
            }
            catch (Exception ex)
            {
                logger.LogError("AddRent Action" + ex.Message);
            }

            return BadRequest();
        }
    }
}