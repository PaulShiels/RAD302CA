using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_booking.Models;


namespace Trip_booking.DAL
{
    public interface ITripRepository : IDisposable
    {
        IQueryable<Trip> GetAllTrips();
        Trip GetTripById(int? id);
        
        IQueryable<Leg> GetLegById(int id);
        IQueryable<Leg> GetAllLegs();
        Leg GetLegToAddGuest(int id);
        IQueryable<Guest> GetAllGuests();
        void addGuestToLeg(GuestToLegs gl);
        void AddLegToTrip(Leg l);

        
        
        void AddTrip(Trip t);

    }
}
