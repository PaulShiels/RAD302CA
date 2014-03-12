using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trip_booking.Models
{
    public class Leg
    {
        public int ID { get; set; }
        public string startLocation { get; set; }
        public string endLocation { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public int tripID { get; set; }
        public Trip trip { get; set; }

        //public Leg()
        //{

        //}

        //public Leg(string startLocation, string endLocation, DateTime startDate, DateTime endDate)
        //{
        //    this.startLocation = startLocation;
        //    this.endLocation = endLocation;
        //    this.startDate = startDate;
        //    this.endDate = endDate;
        //}
    }
}