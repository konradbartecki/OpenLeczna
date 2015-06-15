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
using OpenLeczna.DTOs;
using OpenLeczna.Models;
using WebGrease.Css.Extensions;

namespace OpenLeczna.Controllers
{
    public class CitiesController : ApiController
    {
        private TransportServiceContext db = new TransportServiceContext();

        private static readonly Expression<Func<City, CityDTO>> AsCityDto =
            x => new CityDTO
                {
                    Name = x.Name
                };

        public static List<CityDTO> ConvertCityListToDtos(List<City> cityCollection)
        {
            return cityCollection.ConvertAll(x => new CityDTO() {Name = x.Name});
        } 

        // GET: api/Cities
        public IQueryable<CityDTO> GetCities()
        {
            return db.Cities.Select(AsCityDto);
        }

        // GET: api/Cities/Lublin
        [ResponseType(typeof(CityDTO))]
        public async Task<IHttpActionResult> GetCity(string name)
        {
            CityDTO city = await db.Cities
                .Where(x => x.Name == name)
                .Select(AsCityDto)
                .FirstOrDefaultAsync();

            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }

        //// PUT: api/Cities/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutCity(int id, City city)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != city.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(city).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CityExists(id))
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

        //// POST: api/Cities
        //[ResponseType(typeof(City))]
        //public async Task<IHttpActionResult> PostCity(City city)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Cities.Add(city);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = city.Id }, city);
        //}

        //// DELETE: api/Cities/5
        //[ResponseType(typeof(City))]
        //public async Task<IHttpActionResult> DeleteCity(int id)
        //{
        //    City city = await db.Cities.FindAsync(id);
        //    if (city == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Cities.Remove(city);
        //    await db.SaveChangesAsync();

        //    return Ok(city);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CityExists(int id)
        {
            return db.Cities.Count(e => e.Id == id) > 0;
        }
    }
}