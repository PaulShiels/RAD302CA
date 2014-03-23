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
        public int G_to_L_ID { get; set; }
        [Key, Column(Order = 0)]
        public int GuestId { get; set; }
        [Key, Column(Order=1)]
        public int LegId { get; set; }

        public virtual Leg Leg { get; set; }
        public virtual Guest Guest { get; set; }
    }
}