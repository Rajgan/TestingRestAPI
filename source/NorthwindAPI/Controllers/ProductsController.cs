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
    public class ProductsController : ApiController
    {
        private NorthwindRepository _repository;
        public ProductsController()
        {
            String cs = ConfigurationManager.ConnectionStrings["NorthwindSQL"].ConnectionString;
            _repository = new NorthwindRepository(new NorthwindDbContext(cs));
        }

        public IHttpActionResult GetProducts()
        {
            var entities = _repository.GetProducts();
            return Ok<IEnumerable<ProductModel>>(ModelFactory.GetProducts(entities));
        }
        [Route("api/products/{productID}")]
        public IHttpActionResult GetProduct([FromUri] int productID)
        {
            var entity = _repository.GetProduct(productID);
            return Ok<ProductModel>(ModelFactory.GetProduct(entity));
        }
        [Route("api/products/{productID}")]
        [HttpPut]
        public IHttpActionResult UpdateProduct(ProductModel productToUpdate)
        {
            throw new NotImplementedException("Deleting product not allowed");
        }
        [HttpPost]
        public IHttpActionResult AddProduct(ProductModel newProduct)
        {
            throw new NotImplementedException("Deleting product not allowed");
        }
        [HttpDelete]
        [Route("api/products/{productID}")]
        public string DeleteProduct([FromUri] int productID)
        {
            throw new NotImplementedException("Deleting product not allowed");
        }
    }
}
