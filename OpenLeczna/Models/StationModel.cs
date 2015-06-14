using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenLeczna.Model
{
    [Table("Stations")]
    public class Station
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public GeoPos GeoPosId { get; set; }
        public List<Schedule> Schedules { get; set; }
    }

    public class GeoPos
    {
        [Key]
        public int Id { get; set; }
        public string StreetName { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
    }
    [Table("Schedules")]
    public class Schedule
    {
        [Key]
        public int Id { get; set; }
        public string CarrierName { get; set; }
        public string DestinationCity { get; set; }
        public string StationName { get; set; }
        //Weekdays, Saturdays, Sundays, Holidays or Special
        public string ApplicableDays { get; set; }
        public virtual List<Departure> Departures { get; set; }
        //public List<Departure> WeekdaysDepartures { get; set; }
        //public List<Departure> SaturdayDepartures { get; set; }
        //public List<Departure> SundayDepartures { get; set; }
        //public List<Departure> HolidaysDepartures { get; set; }
        //public List<SpecialDeparture> SpecialDepartures { get; set; }
    }
    [Table("Departures")]
    public class Departure
    {
        [Key]
        public int Id { get; set; }
        public string Time { get; set; }
        public bool IsBetterBusAvailable { get; set; }
    }
    public class SpecialDeparture : Departure
    {
        public List<DateTime> ApplicableDateTimes { get; set; }
    }
    [Table("Carriers")]
    public class Carrier
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
    [Table("Cities")]
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public static class ScheduleTranslator
    {
        public static List<Departure> GetDeparturesListFromString(string data)
        {
            var freshList = new List<Departure>();
            char[] delimeterChars = new char[]
            {
                ',',
                ';'
            };

            string[] splitDepartureStrings = data.Split(delimeterChars);
            foreach (string departureString in splitDepartureStrings)
            {
                string cleanDepartureString = departureString.Replace(" ", ""); //remove whitespace
                bool betterBusAvailable = false;

                //Check if better bus is available
                if (cleanDepartureString.Contains("ir"))
                {
                    betterBusAvailable = true;
                    cleanDepartureString = cleanDepartureString.Replace("ir", "");
                }
                //Build new departure object
                var departure = new Departure()
                {
                    IsBetterBusAvailable = betterBusAvailable,
                    Time = cleanDepartureString
                };

                freshList.Add(departure);
            }
          
            return freshList;
        }
    }
}
