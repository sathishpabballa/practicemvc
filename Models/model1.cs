using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace practicemvc.Models
{
    public class model1
    {
       
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required]
        public string address { get; set; }
        
    }
}