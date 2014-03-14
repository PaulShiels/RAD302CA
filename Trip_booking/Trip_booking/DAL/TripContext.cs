using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Trip_booking.DAL;
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
            : base("TripDB")
        {
            Database.SetInitializer(new TripInitializer());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<TripContext, Configuration>());

        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}
    }

    public class TripInitializer : DropCreateDatabaseIfModelChanges<TripContext>
    {
        protected override void Seed(TripContext context)
        {
            var legs = new List<Leg>
            {
                new Leg{startLocation="Desert West", endLocation = "Desert East", startDate=DateTime.Parse("12/01/2013"), endDate=DateTime.Parse("16/01/2013")},
                new Leg{startLocation="Desert West", endLocation = "Desert East", startDate=DateTime.Parse("12/01/2013"), endDate=DateTime.Parse("16/01/2013")},
                new Leg{startLocation="Desert West", endLocation = "Desert East", startDate=DateTime.Parse("12/01/2013"), endDate=DateTime.Parse("16/01/2013")},
                new Leg{startLocation="Desert West", endLocation = "Desert East", startDate=DateTime.Parse("12/01/2013"), endDate=DateTime.Parse("16/01/2013")},
                new Leg{startLocation="Desert West", endLocation = "Desert East", startDate=DateTime.Parse("12/01/2013"), endDate=DateTime.Parse("16/01/2013")}
            };
            

            var trips = new List<Trip>
            {
                new Trip {name="Sahara Adventure", startDate=DateTime.Parse("12/01/2013"), endDate=DateTime.Parse("12/02/2013"), minimumGuests=10, legs = new List<Leg>{ new Leg{startLocation="Desert West", endLocation = "Desert East", startDate=DateTime.Parse("12/01/2013"), endDate=DateTime.Parse("16/01/2013"),tripID=1}}},
                new Trip {name="Sahara Adventure", startDate=DateTime.Parse("12/01/2013"), endDate=DateTime.Parse("12/02/2013"), minimumGuests=10,legs = new List<Leg>{ new Leg{startLocation="Desert West", endLocation = "Desert East", startDate=DateTime.Parse("12/01/2013"), endDate=DateTime.Parse("16/01/2013"),tripID=1}}},
                new Trip {name="Sahara Adventure", startDate=DateTime.Parse("12/01/2013"), endDate=DateTime.Parse("12/02/2013"), minimumGuests=10, legs=legs},
                new Trip {name="Sahara Adventure", startDate=DateTime.Parse("12/01/2013"), endDate=DateTime.Parse("12/02/2013"), minimumGuests=10}
            };
            trips.ForEach(s => context.Trips.Add(s));
            legs.ForEach(l => context.Legs.Add(l));
            context.SaveChanges();

            

            var guests = new List<Guest>
            {
                new Guest{name="Paddy"},
                new Guest{name="Joe"},
                new Guest{name="Mick"},
                new Guest{name="Sean"},
                new Guest{name="Jim"}
            };
            guests.ForEach(g => context.Guests.Add(g));
            context.SaveChanges();

            //    //    var enrollments = new List<Enrollment>
            //    //{
            //    //new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
            //    //new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
            //    //new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
            //    //new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
            //    //new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
            //    //new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
            //    //new Enrollment{StudentID=3,CourseID=1050},
            //    //new Enrollment{StudentID=4,CourseID=1050,},
            //    //new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
            //    //new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
            //    //new Enrollment{StudentID=6,CourseID=1045},
            //    //new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
            //    //};
            //    //    enrollments.ForEach(s => context.Enrollments.Add(s));
            //    //    context.SaveChanges();
            //    //}
            //}
        }
    }
}