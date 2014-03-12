using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trip_booking.DAL;

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
            return View("Trips", _repo.GetAllTrips());
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