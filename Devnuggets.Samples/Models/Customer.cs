using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Devnuggets.Samples.Models
{
    public class Customer
    {
        public string Id { get; set; }
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerTel { get; set; }
    }
}