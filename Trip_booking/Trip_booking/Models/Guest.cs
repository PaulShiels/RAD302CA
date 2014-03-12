using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trip_booking.Models
{
    public class Guest
    {
        public int ID { get; set; }
        public string name { get; set; }
        public int legs { get; set; }

        //public Guest()
        //{

        //}

        //public Guest(string name)
        //{
        //    this.name = name;
        //}

        public ICollection<Guest> Guests { get; set; }
    }
}