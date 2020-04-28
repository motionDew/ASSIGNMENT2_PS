using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace assignment2.Models
{
    public class User
    {
        [Key]
        public int id {get; set;}
        private String name { get; set; }
        private String username { get; set; }
        private String password { get; set; }
    }
}
