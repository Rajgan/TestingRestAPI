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
    public class ShippersController : ApiController
    {
        private INorthwindRepository _repository;
        public ShippersController()
        {
            String cs = ConfigurationManager.ConnectionStrings["NorthwindSQL"].ConnectionString;

            _repository = new NorthwindRepository(new NorthwindDbContext(cs));
        }
        public IHttpActionResult GetShippers()
        {
            var entities = _repository.GetShippers();
            return Ok<IEnumerable<ShipperModel>>(ModelFactory.GetShippers(entities));
        }
        [Route("api/shippers/{shipperID}")]
        public IHttpActionResult GetShipper([FromUri] int shipperID)
        {
            var entity = _repository.GetShipper(shipperID);
            return Ok<ShipperModel>(ModelFactory.GetShipper(entity));
        }
        [HttpPost]
        public IHttpActionResult CreateShipper(ShipperModel newShipper)
        {
            var entity = new Shipper
            {
                CompanyName = newShipper.CompanyName,
                Phone = newShipper.Phone
            };
            entity = _repository.CreateShipper(entity);
            newShipper.ShipperID = entity.ShipperID;
            String loc = Url.Link("api/shippers/{shipperID}", new { shipperID = entity.ShipperID });
            return Created<ShipperModel>(loc, newShipper);
        }
        [Route("api/shippers/{shipperID}")]
        [HttpPut]
        public IHttpActionResult UpdateShipper(ShipperModel existing)
        {
            var entity = new Shipper
            {
                CompanyName = existing.CompanyName,
                Phone = existing.Phone
            };
            _repository.UpdateShipper(entity);
            return Ok<ShipperModel>(existing);
        }
    }
}
