using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductsSelection.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        #nullable enable
        public string? ProductDiscription { get; set; }
        public string? ProductCategory { get; set; }
        public string? ProductImg { get; set; }
    }
}