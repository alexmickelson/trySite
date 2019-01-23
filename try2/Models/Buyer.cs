using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace try2.Models
{
    public class Buyer
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string  buyerName { get; set; }

        public string buyerAddress { get; set; }

        public string phone { get; set; }

        public string  email { get; set; }
    }
}
