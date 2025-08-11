using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S2P09_u22738241.Models
{
    public class Member
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string fullName { get; set; }

        [Required]
        public string clubName { get; set; } // 'Blue Sky','Rotary','Red Hat','Spicy'

        [Required]
        public int Age { get; set; }

        public decimal memberFee { get; set; }
    }
}