using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLeczna.DTOs
{
    public class StationDto
    {
        public string Name { get; set; }
        public string City { get; set; }
        public virtual GeoPosDto GeoPosition { get; set; }
        public virtual ICollection<ScheduleDTO> Schedules { get; set; }
        public override string ToString()
        {
            //for example: Dworzec (Wamex), Łęczna
            return Name + ", " + City;
        }
    }

    public class StationDetailsDto : StationDto
    {
        public new virtual ICollection<ScheduleDetailsDTO> Schedules { get; set; }
    }
}
