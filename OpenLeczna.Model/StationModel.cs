//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.ComponentModel;

//namespace OpenLeczna.Model
//{
//    public class Station
//    {
//        [Key]
//        public int Id { get; set; }
//        public string Name { get; set; }
//        public string City { get; set; }
//        public GeoPos GeoPos { get; set; }
//        public List<Schedule> Schedules { get; set; }
//    }

//    public class GeoPos
//    {
//        public string StreetName { get; set; }
//        public float X { get; set; }
//        public float Y { get; set; }
//    }

//    public class Schedule
//    {
//        public string CarrierName { get; set; }
//        public string DestinationCity { get; set; }
//        public List<Departure> WeekdaysDepartures { get; set; }
//        public List<Departure> SaturdayDepartures { get; set; }
//        public List<Departure> SundayDepartures { get; set; }
//        public List<Departure> HolidaysDepartures { get; set; }
//        public List<Departure> SpecialDepartures { get; set; }
//    }
//    public class Departure
//    {
//        public string Time { get; set; }
//        public bool IsBetterBusAvailable { get; set; }
//    }

//    public class SpecialDeparture : Departure
//    {
//        public List<DateTime> ApplicableDateTimes { get; set; }
//    }

//    public static class ScheduleTranslator
//    {
//        public static List<Departure> GetDeparturesListFromString(string data)
//        {
//            var freshList = new List<Departure>();
//            char[] delimeterChars = new char[]
//            {
//                ',',
//                ';'
//            };

//            string[] splitDepartureStrings = data.Split(delimeterChars);
//            foreach (string departureString in splitDepartureStrings)
//            {
//                string cleanDepartureString = departureString.Replace(" ", ""); //remove whitespace
//                bool betterBusAvailable = false;

//                //Check if better bus is available
//                if (cleanDepartureString.Contains("ir"))
//                {
//                    betterBusAvailable = true;
//                    cleanDepartureString = cleanDepartureString.Replace("ir", "");
//                }
//                //Build new departure object
//                var departure = new Departure()
//                {
//                    IsBetterBusAvailable = betterBusAvailable,
//                    Time = cleanDepartureString
//                };

//                freshList.Add(departure);
//            }
          
//            return freshList;
//        }
//    }
//}
