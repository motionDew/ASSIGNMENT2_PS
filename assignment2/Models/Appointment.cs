using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace assignment2.Models
{
    public class Appointment
    {

        [Key]
        public int id { get; set; }

        [Display(Name = "Registration Date")]
        [DataType(DataType.DateTime)]
        public DateTime date { get; set; }
        [Display(Name = "Client Name")]
        public String clientName { get; set; }
        [Display(Name = "Telephone Number")]
        public String telephoneNo { get; set; }
        [Display(Name = "Car")]
        public String carBrand { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }
        [Display(Name = "Status")]
        public int status { get; set; }

    }
}
