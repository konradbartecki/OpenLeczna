using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using OpenLeczna.DTOs;
using OpenLeczna.Models;

namespace OpenLeczna.Controllers
{
    public class CarriersController : ApiController
    {
        private TransportServiceContext db = new TransportServiceContext();

        private static readonly Expression<Func<Carrier, CarrierDTO>> AsCarrierDto =
            x => new CarrierDTO
            {
                Name = x.Name
            };

        // GET: api/Carriers
        public IQueryable<CarrierDTO> GetCarriers()
        {
            return db.Carriers.Select(AsCarrierDto);
        }

        // GET: api/Carriers/Łęcz-Trans
        [ResponseType(typeof(CarrierDTO))]
        public async Task<IHttpActionResult> GetCarrier(string name)
        {
            CarrierDTO carrier = await db.Carriers
                .Where(x => x.Name == name)
                .Select(AsCarrierDto)
                .FirstOrDefaultAsync();

            if (carrier == null)
            {
                return NotFound();
            }

            return Ok(carrier);
        }

        // PUT: api/Carriers/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutCarrier(int id, Carrier carrier)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != carrier.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(carrier).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CarrierExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Carriers
        //[ResponseType(typeof(Carrier))]
        //public async Task<IHttpActionResult> PostCarrier(Carrier carrier)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Carriers.Add(carrier);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = carrier.Id }, carrier);
        //}

        //// DELETE: api/Carriers/5
        //[ResponseType(typeof(Carrier))]
        //public async Task<IHttpActionResult> DeleteCarrier(int id)
        //{
        //    Carrier carrier = await db.Carriers.FindAsync(id);
        //    if (carrier == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Carriers.Remove(carrier);
        //    await db.SaveChangesAsync();

        //    return Ok(carrier);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarrierExists(int id)
        {
            return db.Carriers.Count(e => e.Id == id) > 0;
        }
    }
}