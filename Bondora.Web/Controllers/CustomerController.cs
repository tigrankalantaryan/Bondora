using Bondora.Models;
using Bondora.Models.Models;
using Bondora.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bondora.Web.Controllers
{

    public class CustomerController : Controller
    {
        private static ILogger<CustomerController> logger;
        private static Urls urls;

        public CustomerController(ILogger<CustomerController> _logger, IOptions<Urls> _urls)
        {
            urls = _urls.Value;
            logger = _logger;
        }

        public IActionResult StartAndGetProductcs()
        {
            try
            {
                var productsJson = WebRequest.SendWebRequest(urls.GetProducts, "GET", null);
                if (productsJson != null)
                {
                    var products = JsonConvert.DeserializeObject<List<RentItems>>(productsJson);
                    return View(products);
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Start and get Product action " + ex.Message);
            }

            return View();
        }

        [HttpGet]
        public IActionResult GetInvoice()
        {
            try
            {
                long customerId = 1;
                var invoiceJson = WebRequest.SendWebRequest(urls.GetInvoice, "POST", customerId.ToString());
                if (invoiceJson != null)
                {
                    var invoice = JsonConvert.DeserializeObject<List<Invoice>>(invoiceJson);
                    return View(invoice);
                }

            }
            catch (Exception ex)
            {
                logger.LogError("Get Invocie action " + ex.Message);
            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult AddRent([FromBody]CustomerRentInfo data)
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
                WebRequest.SendWebRequest(urls.AddRent, "POST", JsonConvert.SerializeObject(new { customerId, RentedData = data }));
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
