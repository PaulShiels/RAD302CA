using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Trip_booking.Controllers;

namespace Trip_booking.Models
{
    public class Leg : IValidatableObject
    {
        public int LegId { get; set; }

        [Required]        
        public string startLocation { get; set; }

        [Required]
        public string endLocation { get; set; }

        ////[Range(0, 120, ErrorMessage = "Please enter between 0 to 120")]
        //[Range(typeof(DateTime), , "3/4/2004",
        //ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime startDate { get; set; }

        //[Range(typeof(DateTime),  , "3/4/2004",
        //ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime endDate { get; set; }

        public int tripID { get; set; }
        public virtual Trip trip { get; set; }
        public virtual ICollection<Guest> Guests { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            Trip t = this.trip;

            if (t.startDate < startDate || t.endDate > endDate)
            {
                yield return new ValidationResult("The party should not exceed after 10.00 PM");
                //return false;
            }
            else
            {
                yield return new ValidationResult("Drinks are only allowed if no. of joinees is 5 or more.");
                //return true;
            }

        }

        //public bool checkTrip(Trip t)
        //{
            
        //}

        

    }
}


//public class ValidationModel
//{
//    [Required]
//    [Display(Name = "User name")]
//    [StringLength(20, ErrorMessage = "Name not be exceed 20 char")]
//    public string Name { get; set; }

//    [Required(ErrorMessage = "Email_id must not be empty")]
//    [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please Enter valid mail id")]
//    public string Email { get; set; }

//    [Required(ErrorMessage = "Please enter  phone number")]
//    //[RegularExpression("@^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$”, ErrorMessage = “Enter valid number”)]
//    public string Phone { get; set; }

//    [Required(ErrorMessage = "Please enter your address")]
//    public string Address { get; set; }

//    [Range(0, 120, ErrorMessage = "Please enter between 0 to 120")]
//    public string Age { get; set; }
//}