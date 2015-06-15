using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OpenLeczna.Models
{
    public class TransportServiceContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TransportServiceContext() : base("name=TransportServiceContext")
        {
        }

        public System.Data.Entity.DbSet<OpenLeczna.Models.Station> Stations { get; set; }

        public System.Data.Entity.DbSet<OpenLeczna.Models.Carrier> Carriers { get; set; }

        public System.Data.Entity.DbSet<OpenLeczna.Models.City> Cities { get; set; }

        public System.Data.Entity.DbSet<OpenLeczna.Models.Schedule> Schedules { get; set; }
    }
}
