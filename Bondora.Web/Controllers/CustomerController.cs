using Bondora.Models;
using Bondora.Models.Models;
using Bondora.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bondora.Web.Controllers
{
    public class CustomerController : Controller
    {
        private static ILogger<CustomerController> logger;

        public CustomerController(ILogger<CustomerController> _logger)
        {
            logger = _logger;
        }

        public IActionResult StartAndGetProductcs()
        {
            try
            {
                var url = "http://localhost:12689/api/bondora/getproduct";
                var productsJson = WebRequest.SendWebRequest(url, "GET", null);
                if (productsJson != null)
                {
                    var products = JsonConvert.DeserializeObject<List<RentItems>>(productsJson);
                    return Ok(products);
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Start and get Product action " + ex.Message);
            }

            return View();
        }

        public IActionResult GetInvoice()
        {
            try
            {
                long customerId = 1;
                var url = "http://localhost:12689/api/bondora/getinvoice";
                var invoiceJson = WebRequest.SendWebRequest(url, "POST", customerId.ToString());
                if (invoiceJson != null)
                {
                    var invoice = JsonConvert.DeserializeObject<Invoice>(invoiceJson);
                    return Ok(invoice);
                }

            }
            catch (Exception ex)
            {
                logger.LogError("Get Invocie action " + ex.Message);
            }

            return BadRequest();
        }


        public IActionResult AddRent([FromBody]CustomerInfo data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                long customerId = 1;
                if (!Helpers.CheckBalance())
                {
                    return BadRequest("not enought balance");
                }

                Helpers.CalculateRent(data);
                var url = "http://localhost:12689/api/bondora/addrent";
                WebRequest.SendWebRequest(url, "POST", JsonConvert.SerializeObject(new { customerId, RentedData = data }));
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError("Add rent action " + ex.Message);
            }

            return BadRequest();
        }
    }
}
