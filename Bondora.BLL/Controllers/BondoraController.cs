using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bondora.BLL.Models;
using Bondora.BLL.Services;
using Bondora.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Bondora.BLL.Controllers
{
    [Produces("application/json")]
    [Route("api/Bondora/[action]")]
    [ApiController]
    public class BondoraController : ControllerBase
    {
        private IManagerRepository _manager;

        public BondoraController(IManagerRepository manager)
        {
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

            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult AddRent([FromBody] JObject data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var info = data.ToObject<dynamic>();
                _manager.AddRent((long)info.CustomerId, (CustomerInfo)info.RentedData);
                return Ok();
            }
            catch (Exception ex)
            {
                
            }

            return BadRequest();
        }
    }
}