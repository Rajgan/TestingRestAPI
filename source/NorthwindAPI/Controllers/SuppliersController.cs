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
    public class SuppliersController : ApiController
    {
        private INorthwindRepository _repository;

        public SuppliersController()
        {
            String cs = ConfigurationManager.ConnectionStrings["NorthwindSQL"].ConnectionString;

            _repository = new NorthwindRepository(new NorthwindDbContext(cs));
        }

        public IHttpActionResult GetSuppliers()
        {
            var entities = _repository.GetSuppliers();
            return Ok<IEnumerable<SupplierModel>>(ModelFactory.GetSuppliers(entities));
        }
        [Route("api/suppliers/{supplierID}")]
        public IHttpActionResult GetSupplier([FromUri] int supplierID)
        {
            var entity = _repository.GetSupplier(supplierID);
            return Ok<SupplierModel>(ModelFactory.GetSupplier(entity));
        }
        [HttpPost]
        public IHttpActionResult CreateSupplier(SupplierModel newSupplier)
        {
            var entity = new Supplier{
                Address = newSupplier.Address,
                City = newSupplier.City,
                CompanyName = newSupplier.CompanyName,
                ContactName = newSupplier.ContactName,
                ContactTitle = newSupplier.ContactTitle,
                Country = newSupplier.Country,
                Fax = newSupplier.Fax,
                HomePage = newSupplier.HomePage,
                Phone = newSupplier.Phone,
                PostalCode = newSupplier.PostalCode,
            };
            entity = _repository.CreateSupplier(entity);
            newSupplier.SupplierID = entity.SupplierID;
            String loc = Url.Link("api/suppliers/{supplierID}", new { supplierID = entity.SupplierID});
            return Created<SupplierModel>(loc, newSupplier);
        }
        [Route("api/suppliers/{supplierID}")]
        [HttpPut]
        public IHttpActionResult UpdateSupplier(SupplierModel model)
        {
            var entity = new Supplier
            {
                Address = model.Address,
                City = model.City,
                CompanyName = model.CompanyName,
                ContactName = model.ContactName,
                ContactTitle = model.ContactTitle,
                Country = model.Country,
                Fax = model.Fax,
                HomePage = model.HomePage,
                Phone = model.Phone,
                PostalCode = model.PostalCode,
                Region = model.Region
            };
            _repository.UpdateSupplier(entity);
            return Ok<SupplierModel>(model);
        }
        [Route("api/suppliers/{supplierID}")]
        [HttpDelete]
        public IHttpActionResult DeleteSupplier([FromUri] int supplierID)
        {
            throw new NotSupportedException("Deleting supplier is not supported");
        }
    }
}
