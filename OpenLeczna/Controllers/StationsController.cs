using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using OpenLeczna.DTOs;
using OpenLeczna.Models;

namespace OpenLeczna.Controllers
{
    public class StationsController : ApiController
    {
        private TransportServiceContext db = new TransportServiceContext();


        //Todo: api/Stations/Łęczna/Lublin

        // Typed lambda expression for Select() method. 
        //private static readonly Expression<Func<Station, StationDto>> AsStationDto =
        //    x => new StationDto
        //    {
        //         Name = x.Name,
        //         City = x.City.Name,
        //         //GeoPosition = x.GeoPos
        //    };

  

        // GET: api/Stations
        public IQueryable<StationDto> GetStations()
        {
            return db.Stations.AsEnumerable().Select(x => Mapper.Map<StationDto>(x)).AsQueryable();
        }
        
        // GET: api/Stations/Dworzec (Wamex)
        [ResponseType(typeof(StationDetailsDto))]
        public async Task<IHttpActionResult> GetStation(string name)
        {
            var station = await db.Stations.Include(x => x.Schedules)
                .Where(x => x.Name == name)
                .FirstOrDefaultAsync();

            var newstation = Mapper.Map<StationDetailsDto>(station);

            if (newstation == null)
            {
                return NotFound();
            }

            return Ok(newstation);
        }

        //[Route("{name:string/details")]
        //[ResponseType(typeof(StationDetailsDto))]
        //public async Task<IHttpActionResult> GetStationDetails(string name)
        //{
        //    StationDetailsDto station = await (from s in db.Stations
        //        where s.Name == name
        //        select new StationDetailsDto
        //        {
        //            Name = s.Name,
        //            City = s.City.Name,
        //            //Schedules = SchedulesController.ConvertScheduleListToDtos(s.Schedules)
        //        }).FirstOrDefaultAsync();

        //    if (station == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(station);
        //}

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