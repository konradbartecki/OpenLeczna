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
        //public string GeoPosition { get; set; }
        public virtual List<ScheduleDTO> Schedules { get; set; }
    }

    public class StationDetailsDto : StationDto
    {
        public new virtual List<ScheduleDetailsDTO> Schedules { get; set; }
    }
}
