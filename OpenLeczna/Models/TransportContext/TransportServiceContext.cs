using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using SQLite.CodeFirst;

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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new TransportContextDbInitializer(Database.Connection.ConnectionString, modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
        }

        public class TransportContextDbInitializer : SqliteDropCreateDatabaseAlways<TransportServiceContext>
        {
            public TransportContextDbInitializer(string connectionString, DbModelBuilder modelBuilder)
        : base(connectionString, modelBuilder) { }

            protected override void Seed(TransportServiceContext context)
            {
                var CarriersList = new List<Carrier>()
            {
                new Carrier()
                {
                    Id = 0,
                    Name = "Łęcz-Trans"
                },
                new Carrier()
                {
                    Id = 1,
                    Name = "PiątekBus"
                }
            };

                var CitiesList = new List<City>()
            {
                new City()
                {
                    Id = 0,
                    Name = "Łęczna"
                },
                new City()
                {
                    Id = 1,
                    Name = "Lublin"
                }
            };

                var GeoPosList = new List<GeoPos>()
            {
                new GeoPos()
                {
                    //Dworzec Łęczna
                    Id = 0,
                    Latitude = 51.299388,
                    Longitude = 22.888110
                },
                new GeoPos()
                {
                    //Wierzbowa
                    Id = 1,
                    Latitude = 51.291481,
                    Longitude = 22.888590
                }
            };

                context.Stations.AddOrUpdate(x => x.Name,
                                new Station()
                                {
                                    Id = 0,
                                    City = CitiesList[0],
                                    GeoPosition = GeoPosList[0],
                                    Name = "Dworzec (Wamex)",
                                    Schedules = new List<Schedule>()
                                        {
                                        //Łęcz-Trans -> Lublin
                                        new Schedule()
                                        {
                                            Carrier = CarriersList[0],
                                            DestinationCity = CitiesList[1],
                                            ApplicableDays = Schedule.ApplicableDaysEnum.Weekdays,
                                            Departures = ScheduleTranslator.GetDeparturesListFromString("4:40ir, 4:50, 5:15, 5:30, 5:45, 5:58ir, 6:04, 6:15, 6:26ir, 6:30, 6:36, 6:45, 6:55, 7:04, 7:15, 7:30ir, 7:42, 7:53, 8:05ir, 8:14, 8:30, 8:34, 8:49, 8:58, 9:15ir, 9:35, 9:50ir, 10:00, 10:10, 10:19, 10:30, 10:40, 10:53, 11:08ir, 11:20, 11:40, 11:50ir, 11:56, 12:18, 12:29, 12:40, 13:00, 13:15ir, 13:25, 13:37, 13:53ir, 14:00, 14:09, 14:20, 14:30, 14:38, 14:51, 15:04ir, 15:10, 15:20, 15:40ir, 15:49, 16:00, 16:15, 16:25, 16:45ir, 16:59, 17:10, 17:24ir, 17:38, 17:52, 18:02, 18:14, 18:30ir, 18:45, 19:06, 19:20, 19:40, 20:10, 20:38, 21:30")
                                        },
                                        new Schedule()
                                        {
                                            Carrier = CarriersList[0],
                                            DestinationCity = CitiesList[1],
                                            ApplicableDays = Schedule.ApplicableDaysEnum.Saturdays,
                                            Departures = ScheduleTranslator.GetDeparturesListFromString("4:50, 5:15, 5:30, 5:45, 6:04, 6:20, 6:36, 6:50, 7:04, 7:15, 7:30, 7:42, 7:53, 8:05, 8:14, 8:34, 8:49, 9:03, 9:15, 9:40, 9:55, 10:10, 10:19, 10:40, 11:00, 11:20, 11:40, 11:50, 11:56, 12:18, 12:40, 13:00, 13:15, 13:25, 13:45, 14:00, 14:09, 14:20, 14:38, 14:51, 15:04, 15:28, 15:40, 16:00, 16:15, 16:25, 16:45, 16:59, 17:24, 17:38, 18:02, 18:30, 18:45, 19:06, 19:30, 19:50, 20:10, 21:00, 21:30")
                                        },
                                        new Schedule()
                                        {
                                            Carrier = CarriersList[0],
                                            DestinationCity = CitiesList[1],
                                            ApplicableDays = Schedule.ApplicableDaysEnum.Sundays,
                                            Departures = ScheduleTranslator.GetDeparturesListFromString("5:30, 6:04, 6:36, 6:55, 7:15, 7:42, 8:05, 8:49, 9:15, 9:40, 9:55, 10:10, 10:40, 11:00, 11:20, 11:56, 12:29, 13:00, 13:25, 13:45, 14:00, 14:20, 14:38, 15:04, 15:28, 16:00, 16:15, 16:45, 16:59, 17:24, 17:38, 18:02, 18:30, 18:45, 19:06, 19:30, 20:10, 20:38, 21:30")
                                        },
                                        //PiątekBus -> Lublin
                                        new Schedule()
                                        {
                                            Carrier = CarriersList[1],
                                            DestinationCity = CitiesList[1],
                                            ApplicableDays = Schedule.ApplicableDaysEnum.Weekdays,
                                            Departures = ScheduleTranslator.GetDeparturesListFromString("5:05; 5:32; 5:50; 6:18; 6:50; 7:08; 7:29; 7:57; 8:20; 8:33; 8:52; 9:19; 9:35; 9:50; 10:25; 10:35;10: 58; 11: 10; 11: 40; 12: 12; 12: 23; 12: 56; 13: 18; 13: 40; 14: 15; 14: 25; 14: 35; 14: 53; 15: 23; 15: 55; 16: 19; 16: 30; 17: 00;17: 35; 17: 56; 18: 19; 18: 45; 19: 05; 19: 40; 20: 10; 20: 35; 21: 00; 21: 50; 22: 20; 22:40")
                                        },
                                        new Schedule()
                                        {
                                            Carrier = CarriersList[1],
                                            DestinationCity = CitiesList[1],
                                            ApplicableDays = Schedule.ApplicableDaysEnum.Saturdays,
                                            Departures = ScheduleTranslator.GetDeparturesListFromString("5:50; 6:36; 7:08; 7:57; 8:33; 9:35; 10:25; 10:35; 11:40; 12:23; 12:40; 13:18; 13:45; 14:25;14: 53; 15: 23; 16: 45; 17: 35; 18: 45; 19: 30; 20: 35; 21: 25; 22: 40")
                                        },
                                        new Schedule()
                                        {
                                            Carrier = CarriersList[1],
                                            DestinationCity = CitiesList[1],
                                            ApplicableDays = Schedule.ApplicableDaysEnum.Sundays,
                                            Departures = ScheduleTranslator.GetDeparturesListFromString("5:50; 6:36; 7:14; 7:29; 8:33; 9:13; 9:35; 10:35; 11:50; 12:23; 12:50; 13:18; 13:45; 14:25;14: 53; 15: 23; 16: 30; 17: 35; 18: 25; 19: 10; 20: 35; 21:10")
                                        }
                                        }
                                },
                                new Station()
                                {
                                    Id = 1,
                                    City = CitiesList[0],
                                    Name = "Wierzbowa",
                                    GeoPosition = GeoPosList[1]
                                }                                
                    );
                context.SaveChanges();
            }
        }

        public System.Data.Entity.DbSet<OpenLeczna.Models.Station> Stations { get; set; }

        public System.Data.Entity.DbSet<OpenLeczna.Models.Carrier> Carriers { get; set; }

        public System.Data.Entity.DbSet<OpenLeczna.Models.City> Cities { get; set; }

        public System.Data.Entity.DbSet<OpenLeczna.Models.Schedule> Schedules { get; set; }
    }
}
