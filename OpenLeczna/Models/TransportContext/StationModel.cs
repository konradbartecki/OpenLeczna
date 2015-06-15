using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenLeczna.Models
{
    [Table("Stations")]
    public class Station
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual City City { get; set; }
        //public virtual GeoPos GeoPos { get; set; }
        public virtual List<Schedule> Schedules { get; set; }
    }
}
