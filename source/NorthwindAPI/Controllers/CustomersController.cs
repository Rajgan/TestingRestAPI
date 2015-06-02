using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;

using NorthwindAPI.Data;
using NorthwindAPI.Data.Repositories;
using NorthwindAPI.Data.Entities;
using NorthwindAPI.Models;

namespace NorthwindAPI.Controllers
{
    /// <summary>
    /// API for managing customer data
    /// </summary>
    public class CustomersController : ApiController
    {
        private INorthwindRepository _repository;
        public CustomersController()
        {
            String cs = ConfigurationManager.ConnectionStrings["NorthwindSQL"].ConnectionString;

            _repository = new NorthwindRepository(new NorthwindDbContext(cs));
        }
        
        /// <summary>
        /// Return list of customers, page size, page number and an option to specify orders should be included
        /// </summary>
        /// <param name="pageSize">numer of items per page</param>
        /// <param name="pageNo">page number</param>
        /// <param name="includeOrders">flag to indicate customers orders should also be returned along with customer entity</param>
        /// <returns></returns>
        public IHttpActionResult GetCustomers([FromUri] int pageSize = 10, [FromUri] int pageNo = 1, [FromUri] bool includeOrders = false)
        {
            var entities =  _repository.GetCustomers();
            var totalCustomers = entities.Count();
            var totalPages = Math.Ceiling((decimal) (totalCustomers / pageSize));
            var skipCount = pageSize * (pageNo -1);
            var canPage = skipCount < totalCustomers ;
            String nextPageLink = null;
            String prevPageLink = null;
            IEnumerable<CustomerModel> customers = null;
            if(canPage){
                var subset = from c in entities
                          .OrderBy(c => c.CustomerID)
                          .Skip(skipCount)
                          .Take(pageSize)
                             select c;
                customers = ModelFactory.GetCustomers(subset);
                if (pageNo > 1)
                    prevPageLink = GetLink(pageSize, pageNo - 1, includeOrders);
                if ((totalCustomers - skipCount) > pageSize)
                {
                    //not at the end of page
                    var nextPageNo = pageNo + 1;
                    nextPageLink = GetLink(pageSize, nextPageNo, includeOrders);
                }
            }
            
            return Ok(
                new
                {
                    TotalCustomers = totalCustomers,
                    PageSize = pageSize,
                    PageNo = pageNo,
                    Results = customers,
                    NextPageLink = nextPageLink,
                    PreviousPageLink = prevPageLink
                });            
        }
        /// <summary>
        /// Retrieves a single customer entity
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        [Route("api/customers/{customerID}")]
        public IHttpActionResult GetCustomer([FromUri] String customerID)
        {
            var customer = _repository.GetCustomer(customerID);

            return Ok<CustomerModel>(ModelFactory.GetCustomer(customer));
        }
        /// <summary>
        /// Create a new customer
        /// </summary>
        /// <param name="newCustomer">create a new customer entity See <see cref="CustomerModel" />class</param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerModel newCustomer)
        {
            var entity = new Customer()
            {
                Address = newCustomer.Address,
                City = newCustomer.City,
                CompanyName = newCustomer.CompanyName,
                ContactName = newCustomer.ContactName,
                ContactTitle = newCustomer.ContactTitle,
                Country = newCustomer.Country,
                Fax = newCustomer.Fax,
                Phone = newCustomer.Phone,
                PostalCode = newCustomer.PostalCode,
                Region = newCustomer.Region
            };
            _repository.CreateCustomer(entity);
            var loc = Url.Link("api/customers/{customerID}", new { customerID = newCustomer.CustomerID});
            return Created<CustomerModel>(loc, newCustomer);
        }
        [Route("api/customers/{customerID}")]
        [HttpPut]
        public IHttpActionResult UpdateCustomer(CustomerModel customerToUpdate)
        {
            var entity = new Customer()
            {
                CustomerID = customerToUpdate.CustomerID,
                Address = customerToUpdate.Address,
                City = customerToUpdate.City,
                CompanyName = customerToUpdate.CompanyName,
                ContactName = customerToUpdate.ContactName,
                ContactTitle = customerToUpdate.ContactTitle,
                Country = customerToUpdate.Country,
                Fax = customerToUpdate.Fax,
                Phone = customerToUpdate.Phone,
                PostalCode = customerToUpdate.PostalCode,
                Region = customerToUpdate.Region
            };
            _repository.UpdateCustomer(entity);
            return Ok<CustomerModel>(customerToUpdate);
        }
        [Route("api/customers/{customerID}")]
        [HttpDelete]
        public IHttpActionResult DeleteCustomer([FromUri] String customerID)
        {
            throw new NotSupportedException("Deleting customer is not supported");
        }
        private string GetLink(int pageSize, int pageNo, bool includeOrders)
        {
            return Url.Link("DefaultApi", new
            {
                controller = "customers",
                pageNo = pageNo,
                pageSize = pageSize,
                includeOrders = includeOrders
            });
        }
    }
}
