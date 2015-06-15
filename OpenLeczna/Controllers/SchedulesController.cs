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
    public class SchedulesController : ApiController
    {
        private TransportServiceContext db = new TransportServiceContext();

        //private static readonly Expression<Func<Schedule, ScheduleDTO>> AsScheduleDto =
        //    x => new ScheduleDTO
        //    {
        //        Carrier = x.Carrier.Name,
        //        DestinationCity = x.DestinationCity.Name,
        //        Station = x.Carrier.Name,
        //        ApplicableDays = x.ApplicableDays.ToString(),
        //    };

        //public static List<ScheduleDTO> ConvertScheduleListToDtos(List<Schedule> scheduleList)
        //{
        //    var items = scheduleList.Select(x => AsScheduleDto).ToS
        //    var list = items.ToList();

        //    return list;
        //} 

        // GET: api/Schedules
        //public IQueryable<ScheduleDTO> GetSchedules()
        //{
        //    return db.Schedules.Select(x => Mapper.Map<ScheduleDTO>(x));
        //}

        // GET: api/Schedules/5
        //[ResponseType(typeof(Schedule))]
        //public async Task<IHttpActionResult> GetSchedule(string stationName)
        //{
        //    Schedule schedule = await db.Schedules.FindAsync(id);
        //    if (schedule == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(schedule);
        //}

        //// PUT: api/Schedules/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutSchedule(int id, Schedule schedule)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != schedule.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(schedule).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ScheduleExists(id))
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

        //// POST: api/Schedules
        //[ResponseType(typeof(Schedule))]
        //public async Task<IHttpActionResult> PostSchedule(Schedule schedule)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Schedules.Add(schedule);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = schedule.Id }, schedule);
        //}

        //// DELETE: api/Schedules/5
        //[ResponseType(typeof(Schedule))]
        //public async Task<IHttpActionResult> DeleteSchedule(int id)
        //{
        //    Schedule schedule = await db.Schedules.FindAsync(id);
        //    if (schedule == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Schedules.Remove(schedule);
        //    await db.SaveChangesAsync();

        //    return Ok(schedule);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ScheduleExists(int id)
        {
            return db.Schedules.Count(e => e.Id == id) > 0;
        }
    }
}