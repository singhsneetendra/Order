using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Orders.Models;
using Orders.Clients;

namespace DemoWebAPIWithSwagger.Controllers
{
    public class OrderController : ControllerBase
    {
        [HttpPost]
        [Route("GetOrder")]
        public string Post([FromBody]  List<ObjectType> orderList)
        {
            bool response = true;
            string responseText;

            // validate orderlist provided.
            (response, responseText) = Order.ValidateOrderList(orderList);
            if (!response)
            {
                return responseText;
            }

	    // Send a post request to Invoices api to insert ordelist to database.
            responseText = InvoicesApi.CreateOrder(orderList);
            return responseText;
        }
    }
}
