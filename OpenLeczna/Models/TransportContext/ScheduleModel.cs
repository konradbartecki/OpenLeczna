using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLeczna.Models
{
    [Table("Schedules")]
    public class Schedule
    {
        public enum ApplicableDaysEnum
        {
            Weekdays = 0,
            Saturdays = 1,
            Sundays = 2,
            Holidays = 3,
            Special = 4
        }

        [Key]
        public int Id { get; set; }

        public ApplicableDaysEnum ApplicableDays { get; set; }

        public virtual ICollection<Departure> Departures { get; set; }
        public virtual Carrier Carrier { get; set; }
        public virtual City DestinationCity { get; set; }
        //public virtual Station Station { get; set; }
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
