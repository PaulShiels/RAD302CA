using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trip_booking.DAL;
using Trip_booking.Models;

namespace Trip_booking.Controllers
{
    public class HomeController : Controller
    {
        private ITripRepository _repo;

        public HomeController(ITripRepository repo)
        {
            _repo = repo;
        }
        public ActionResult Index()
        {
            //int i = 0;
            //i = _repo.GetAllTrips().Count();
            return View(_repo.GetAllTrips());
        }

        public ActionResult Create()
        {
            ViewBag.Message = "Your application description page.";

            return View("CreateTrip");
        }

        public ActionResult listLegs(int id)
        {
            //return View(_repo.GetAllLegs());
            return PartialView("_Legs", _repo.GetLegById(id));//, _repo.GetTripById(id));
        }

        public ActionResult AddGuest(int id)
        {
            ViewBag.Guests = _repo.GetAllGuests();
            return View("AddGuest",_repo.GetLegToAddGuest(id));
        }

        [HttpPost]
        public ActionResult AddGuest(GuestToLegs gl)
        {
            //if (_repo.Guest2Leg.Contains(gl))
            //{

            //}

            _repo.addGuestToLeg(gl);
            return RedirectToAction("Index");
        }

        public ActionResult AddLegToTrip(int id)
        {
            ViewBag.Trip = _repo.GetTripById(id);
            return View("AddLeg");
        }

        [HttpPost]
        public ActionResult AddLegToTrip(Leg l)
        {
            _repo.AddLegToTrip(l);
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}