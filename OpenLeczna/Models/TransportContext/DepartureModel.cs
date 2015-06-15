using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLeczna.Models
{
    [Table("Departures")]
    public class Departure
    {
        [Key]
        public int Id { get; set; }
        public string Time { get; set; }
        public bool IsBetterBusAvailable { get; set; }
    }
    //public class SpecialDeparture : Departure
    //{
    //    public List<DateTime> ApplicableDateTimes { get; set; }
    //}
}
