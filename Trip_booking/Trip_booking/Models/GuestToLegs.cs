using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Trip_booking.Models
{
    public class GuestToLegs
    {
        [Key, Column(Order = 0)]
        public int GuestId { get; set; }
        [Key, Column(Order=1)]
        public int LegId { get; set; }
        public virtual Leg leg { get; set; }
        public virtual Guest guest { get; set; }
    }
}