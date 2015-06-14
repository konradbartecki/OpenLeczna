using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using OpenLeczna.Model;
using OpenLeczna.Models;
using System.Data.Entity;

namespace OpenLeczna.Controllers
{
    public class StationsController : ApiController
    {
        private TransportServiceContext db = new TransportServiceContext();

        // GET: api/Stations
        public IQueryable<Station> GetStations()
        {
            return db.Stations;
        }
        
        // GET: api/Stations/5
        [ResponseType(typeof(Station))]
        public async Task<IHttpActionResult> GetStation(int id)
        {
            Station station = await db.Stations.FindAsync(id);

            if (station == null)
            {
                return NotFound();
            }

            return Ok(station);
        }

        //// PUT: api/Stations/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutStation(int id, Station station)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != station.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(station).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!StationExists(id))
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

        //// POST: api/Stations
        //[ResponseType(typeof(Station))]
        //public async Task<IHttpActionResult> PostStation(Station station)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Stations.Add(station);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = station.Id }, station);
        //}

        //// DELETE: api/Stations/5
        //[ResponseType(typeof(Station))]
        //public async Task<IHttpActionResult> DeleteStation(int id)
        //{
        //    Station station = await db.Stations.FindAsync(id);
        //    if (station == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Stations.Remove(station);
        //    await db.SaveChangesAsync();

        //    return Ok(station);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StationExists(int id)
        {
            return db.Stations.Count(e => e.Id == id) > 0;
        }
    }
}