using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? NamePr { get; set; }
        public float? PricePr { get; set; }
        public bool? CompletePr { get; set; }
    }
}
