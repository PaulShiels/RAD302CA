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
            return _ctx.Trips.Find(id);//.Include(s => s.trips).SingleOrDefault();//s => s.trips == id);
        }

        public IQueryable<Leg> GetLegById(int id)
        {
            return _ctx.Legs.Where(l=>l.trip.tripID == id);
        }

        public Leg GetLegToAddGuest(int id)
        {
            return _ctx.Legs.Find(id);
        }

        public void addGuestToLeg(GuestToLegs gl)
        {            
            _ctx.Guest2Leg.Add(gl);
            _ctx.Entry(gl).State = EntityState.Added;
            _ctx.SaveChanges();
        }

        public IQueryable<Guest> GetAllGuests()
        {
            return _ctx.Guests;
        }

        public IQueryable<Leg> GetAllLegs()
        {
            return _ctx.Legs;
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

        public void AddLegToTrip(Leg l)
        {
            _ctx.Entry(l).State = EntityState.Added;
            _ctx.SaveChanges();
        }
    }
}