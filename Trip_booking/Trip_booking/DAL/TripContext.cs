using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Trip_booking.DAL;
using Trip_booking.Migrations;
//using Trip_booking.Migrations;
using Trip_booking.Models;

namespace Trip_booking.DAL
{
    public class TripContext : DbContext
    {
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Leg> Legs { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<GuestToLegs> Guest2Leg { get; set; }

        public TripContext()
            : base("TripContext")
        {
            //Database.SetInitializer(new TripInitializer());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TripContext, Configuration>());

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

    public class TripInitializer : DropCreateDatabaseIfModelChanges<TripContext>
    {
        protected override void Seed(TripContext context)
        {
            var guests = new List<Guest>
            {
                new Guest{name="Paddy"},
                new Guest{name="Joe"},
                new Guest{name="Siobhan"},
                new Guest{name="Micky"},
                new Guest{name="Ann"},
                new Guest{name="John"},
                new Guest{name="Brian"},
                new Guest{name="Ciara"},
                new Guest{name="Mae"},
                new Guest{name="Sean"},
                new Guest{name="Jim"},
                new Guest{name="Brendan"},
                new Guest{name="Pat"},
                new Guest{name="Darragh"},
                new Guest{name="Mary"},
                new Guest{name="Liam"},
                new Guest{name="Dan"}
            };

            //var legs = new List<Leg>
            //{
            //    new Leg{startLocation="Shannon", endLocation = "Dublin", startDate=DateTime.Parse("01/03/2013"), endDate=DateTime.Parse("01/03/2013")},
            //    new Leg{startLocation="Dublin Centre", endLocation = "Dublin North", startDate=DateTime.Parse("02/03/2013"), endDate=DateTime.Parse("02/03/2013")},
            //    new Leg{startLocation="Dublin North", endLocation = "Kildare", startDate=DateTime.Parse("03/03/2013"), endDate=DateTime.Parse("03/03/2013")},
            //    new Leg{startLocation="Kildare", endLocation = "Dingle", startDate=DateTime.Parse("04/03/2013"), endDate=DateTime.Parse("04/03/2013")},
            //    new Leg{startLocation="Dingle", endLocation = "Killarny", startDate=DateTime.Parse("05/03/2013"), endDate=DateTime.Parse("05/03/2013")},
            //    new Leg{startLocation="Kilarny", endLocation = "Dublin", startDate=DateTime.Parse("06/03/2013"), endDate=DateTime.Parse("06/03/2013")},
                
            //    new Leg{startLocation="Dublin Centre", endLocation="Dublin South", startDate=DateTime.Parse("04/02/2013"), endDate=DateTime.Parse("06/02/2013")},
            //    new Leg{startLocation="Dublin South", endLocation="Belfast", startDate=DateTime.Parse("07/02/2013"), endDate=DateTime.Parse("10/02/2013")},
            //    new Leg{startLocation="Belfast", endLocation="Derry", startDate=DateTime.Parse("11/02/2013"), endDate=DateTime.Parse("15/02/2013")},
            //    new Leg{startLocation="Derry", endLocation="Donegal", startDate=DateTime.Parse("16/02/2013"), endDate=DateTime.Parse("18/02/2013")},
            //    new Leg{startLocation="Donegal", endLocation="Sligo", startDate=DateTime.Parse("19/02/2013"), endDate=DateTime.Parse("21/02/2013")},

            //    new Leg{startLocation="Shannon", endLocation="Limerick", startDate=DateTime.Parse("12/01/2013"), endDate=DateTime.Parse("14/01/2013")},
            //    new Leg{startLocation="Limerick", endLocation="Killarney", startDate=DateTime.Parse("15/01/2013"), endDate=DateTime.Parse("16/01/2013")},
            //    new Leg{startLocation="Killarney", endLocation="Skibbereen ", startDate=DateTime.Parse("17/01/2013"), endDate=DateTime.Parse("20/01/2013")},
            //    new Leg{startLocation="Skibbereen", endLocation="Baltimore", startDate=DateTime.Parse("21/01/2013"), endDate=DateTime.Parse("22/01/2013")},
            //    new Leg{startLocation="Baltimore", endLocation="Wexford ", startDate=DateTime.Parse("23/01/2013"), endDate=DateTime.Parse("26/01/2013")},

            //    new Leg{startLocation="Belfast", endLocation="Newry", startDate=DateTime.Parse("28/03/2013"), endDate=DateTime.Parse("31/03/2013")},
            //    new Leg{startLocation="Newry", endLocation="Eniskillen", startDate=DateTime.Parse("01/04/2013"), endDate=DateTime.Parse("03/04/2013")},
            //    new Leg{startLocation="Eniskillen", endLocation="Omagh", startDate=DateTime.Parse("04/01/2013"), endDate=DateTime.Parse("05/04/2013")},
            //    new Leg{startLocation="Omagh", endLocation="Derry", startDate=DateTime.Parse("06/01/2013"), endDate=DateTime.Parse("10/04/2013")},
            //    new Leg{startLocation="Derry", endLocation="Portrush", startDate=DateTime.Parse("11/04/2013"), endDate=DateTime.Parse("12/04/2013")},

            //    new Leg{startLocation="Knock", endLocation="Westport", startDate=DateTime.Parse("18/04/2013"), endDate=DateTime.Parse("21/04/2013")},
            //    new Leg{startLocation="Westport", endLocation="Galway", startDate=DateTime.Parse("22/04/2013"), endDate=DateTime.Parse("25/04/2013")},
            //    new Leg{startLocation="Galway", endLocation="Ennis", startDate=DateTime.Parse("26/04/2013"), endDate=DateTime.Parse("29/04/2013")},
            //    new Leg{startLocation="Ennis", endLocation="Waterford", startDate=DateTime.Parse("30/04/2013"), endDate=DateTime.Parse("30/04/2013")},
            //    new Leg{startLocation="Waterford", endLocation= "Dublin", startDate=DateTime.Parse("01/05/2013"), endDate=DateTime.Parse("03/05/2013")},
            //};
            

            var trips = new List<Trip>
            {
                new Trip {name="Irish Ledgends", startDate=DateTime.Parse("01/03/2013"), endDate=DateTime.Parse("06/03/2013"), minimumGuests=6, legs= new List<Leg>
                {
                new Leg{startLocation="Shannon", endLocation = "Dublin", startDate=DateTime.Parse("01/03/2013"), endDate=DateTime.Parse("01/03/2013")},
                new Leg{startLocation="Dublin Centre", endLocation = "Dublin North", startDate=DateTime.Parse("02/03/2013"), endDate=DateTime.Parse("02/03/2013")},
                new Leg{startLocation="Dublin North", endLocation = "Kildare", startDate=DateTime.Parse("03/03/2013"), endDate=DateTime.Parse("03/03/2013")},
                new Leg{startLocation="Kildare", endLocation = "Dingle", startDate=DateTime.Parse("04/03/2013"), endDate=DateTime.Parse("04/03/2013")},
                new Leg{startLocation="Dingle", endLocation = "Killarny", startDate=DateTime.Parse("05/03/2013"), endDate=DateTime.Parse("05/03/2013")},
                new Leg{startLocation="Kilarny", endLocation = "Dublin", startDate=DateTime.Parse("06/03/2013"), endDate=DateTime.Parse("06/03/2013")} //legs_T = new List<Leg>{legs[0],legs[1],legs[2],legs[3],legs[4], legs[5]}},
                }
                },

                new Trip {name="Mystical Ireland", startDate=DateTime.Parse("04/02/2013"), endDate=DateTime.Parse("21/03/2013"), minimumGuests=12, legs = new List<Leg>
                {
                    new Leg{startLocation="Dublin Centre", endLocation="Dublin South", startDate=DateTime.Parse("04/02/2013"), endDate=DateTime.Parse("06/02/2013")},
                    new Leg{startLocation="Dublin South", endLocation="Belfast", startDate=DateTime.Parse("07/02/2013"), endDate=DateTime.Parse("10/02/2013")},
                    new Leg{startLocation="Belfast", endLocation="Derry", startDate=DateTime.Parse("11/02/2013"), endDate=DateTime.Parse("15/02/2013")},
                    new Leg{startLocation="Derry", endLocation="Donegal", startDate=DateTime.Parse("16/02/2013"), endDate=DateTime.Parse("18/02/2013")},
                    new Leg{startLocation="Donegal", endLocation="Sligo", startDate=DateTime.Parse("19/02/2013"), endDate=DateTime.Parse("21/02/2013")},
                }
                },//legs_T = new List<Leg>{legs[6],legs[7],legs[8],legs[9],legs[10]}},

                new Trip {name="Southern Supreme", startDate=DateTime.Parse("12/01/2013"), endDate=DateTime.Parse("26/02/2013"), legs = new List<Leg>
                {
                    new Leg{startLocation="Shannon", endLocation="Limerick", startDate=DateTime.Parse("12/01/2013"), endDate=DateTime.Parse("14/01/2013")},
                new Leg{startLocation="Limerick", endLocation="Killarney", startDate=DateTime.Parse("15/01/2013"), endDate=DateTime.Parse("16/01/2013")},
                new Leg{startLocation="Killarney", endLocation="Skibbereen ", startDate=DateTime.Parse("17/01/2013"), endDate=DateTime.Parse("20/01/2013")},
                new Leg{startLocation="Skibbereen", endLocation="Baltimore", startDate=DateTime.Parse("21/01/2013"), endDate=DateTime.Parse("22/01/2013")},
                new Leg{startLocation="Baltimore", endLocation="Wexford ", startDate=DateTime.Parse("23/01/2013"), endDate=DateTime.Parse("26/01/2013")},
                }
                },// minimumGuests=8, legs_T = new List<Leg>{legs[11],legs[12],legs[13],legs[14],legs[15]}},// legs = new List<Leg>{ new Leg{startLocation="Desert West", endLocation = "Desert East", startDate=DateTime.Parse("12/01/2013"), endDate=DateTime.Parse("16/01/2013"),tripID=1}}},                

                new Trip {name="Northern Tradition", startDate=DateTime.Parse("28/03/2013"), endDate=DateTime.Parse("12/04/2013"), minimumGuests=10, legs = new List<Leg>
                {                    
                new Leg{startLocation="Belfast", endLocation="Newry", startDate=DateTime.Parse("28/03/2013"), endDate=DateTime.Parse("31/03/2013")},
                new Leg{startLocation="Newry", endLocation="Eniskillen", startDate=DateTime.Parse("01/04/2013"), endDate=DateTime.Parse("03/04/2013")},
                new Leg{startLocation="Eniskillen", endLocation="Omagh", startDate=DateTime.Parse("04/01/2013"), endDate=DateTime.Parse("05/04/2013")},
                new Leg{startLocation="Omagh", endLocation="Derry", startDate=DateTime.Parse("06/01/2013"), endDate=DateTime.Parse("10/04/2013")},
                new Leg{startLocation="Derry", endLocation="Portrush", startDate=DateTime.Parse("11/04/2013"), endDate=DateTime.Parse("12/04/2013")},
                }
                }, //legs_T = new List<Leg>{legs[16],legs[17],legs[18],legs[19],legs[20]}},   

                new Trip {name="Emerald Supreme", startDate=DateTime.Parse("18/04/2013"), endDate=DateTime.Parse("03/05/2013"), minimumGuests=13, legs = new List<Leg>
                {                
                new Leg{startLocation="Knock", endLocation="Westport", startDate=DateTime.Parse("18/04/2013"), endDate=DateTime.Parse("21/04/2013")},
                new Leg{startLocation="Westport", endLocation="Galway", startDate=DateTime.Parse("22/04/2013"), endDate=DateTime.Parse("25/04/2013")},
                new Leg{startLocation="Galway", endLocation="Ennis", startDate=DateTime.Parse("26/04/2013"), endDate=DateTime.Parse("29/04/2013")},
                new Leg{startLocation="Ennis", endLocation="Waterford", startDate=DateTime.Parse("30/04/2013"), endDate=DateTime.Parse("30/04/2013")},
                new Leg{startLocation="Waterford", endLocation= "Dublin", startDate=DateTime.Parse("01/05/2013"), endDate=DateTime.Parse("03/05/2013")},
                }
                }, //legs_T = new List<Leg>{legs[21],legs[22],legs[23],legs[24],legs[25]}},
            };

            var GuestsToLeg = new List<GuestToLegs>
            {
                new GuestToLegs{GuestId=1, LegId=2},
                new GuestToLegs{GuestId=1, LegId=2},
                new GuestToLegs{GuestId=1, LegId=3},
                new GuestToLegs{GuestId=1, LegId=4},
                new GuestToLegs{GuestId=1, LegId=5},
                new GuestToLegs{GuestId=1, LegId=6},
                new GuestToLegs{GuestId=2, LegId=1},
                new GuestToLegs{GuestId=2, LegId=2},
                new GuestToLegs{GuestId=2, LegId=3},
                new GuestToLegs{GuestId=2, LegId=4},
                new GuestToLegs{GuestId=2, LegId=5},
                new GuestToLegs{GuestId=2, LegId=6},
                new GuestToLegs{GuestId=3, LegId=1},
                new GuestToLegs{GuestId=3, LegId=2},
                new GuestToLegs{GuestId=3, LegId=3},
                new GuestToLegs{GuestId=4, LegId=5}
            };
            trips.ForEach(s => context.Trips.Add(s));
            //legs.ForEach(l => context.Legs.Add(l));
            guests.ForEach(g => context.Guests.Add(g));
            context.SaveChanges();

            GuestsToLeg.ForEach(gl => context.Guest2Leg.Add(gl));
            context.SaveChanges();
        }
    }
}