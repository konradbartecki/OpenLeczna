using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenLeczna.Models;

namespace OpenLeczna.Models
{
    [Table("GeoPos")]
    public class GeoPos
    {
        [Key]
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        //public string StreetName { get; set; }
        //public virtual Station Station { get; set; }
    }
}
