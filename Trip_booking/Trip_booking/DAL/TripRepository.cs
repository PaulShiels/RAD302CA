using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Trip_booking.DAL;
using Trip_booking.Models;

namespace Trip_booking.DAL
{
    public class TripRepository : ITripRepository
    {
        private TripContext _ctx;

        public TripRepository()
        {
            _ctx = new TripContext();
        }
        public IQueryable<Trip> GetAllTrips()
        {
            return _ctx.Trips;
        }

        public Trip GetTripById(int? id) //College2.Models.Student GetStudentById(int? id)
        {
            return _ctx.Trips.Include(s => s.trips).SingleOrDefault();//s => s.trips == id);
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }

        public Trip AddTrip(Trip t)
        {
            /*_ctx.Students.Add(s);*/
            _ctx.Entry(t).State = EntityState.Added;
            _ctx.SaveChanges();
            return t;
        }
    }
}