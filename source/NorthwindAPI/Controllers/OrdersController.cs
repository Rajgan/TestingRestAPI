using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;

using NorthwindAPI.Data;
using NorthwindAPI.Data.Entities;
using NorthwindAPI.Data.Repositories;
using NorthwindAPI.Models;

namespace NorthwindAPI.Controllers
{
    public class OrdersController : ApiController
    {
        private NorthwindRepository _repository;
        public OrdersController()
        {
            String cs = ConfigurationManager.ConnectionStrings["NorthwindSQL"].ConnectionString;

            _repository = new NorthwindRepository(new NorthwindDbContext(cs));
        }
        [Route("api/customers/{customerID}/orders")]
        public IHttpActionResult GetOrdersForCustomer([FromUri] String customerID)
        {
            var entities = _repository.GetOrders(customerID);
            var orders = ModelFactory.GetOrders(entities); 
            return Ok<IEnumerable<OrderModel>>(orders);
        }
        [Route("api/customers/{customerID}/orders/{orderID}")]
        public IHttpActionResult GetOrderForCustomer(String customerID, int orderID)
        {
            var order = _repository.GetOrder(customerID, orderID);
            return Ok<OrderModel>(ModelFactory.GetOrder(order));
        }
    }
}
