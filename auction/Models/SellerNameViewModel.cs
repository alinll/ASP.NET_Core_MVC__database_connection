using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace auction.Models
{
    public class SellerNameViewModel
    {
        public List<Seller>? Sellers { get; set; }
        public SelectList? First_names { get; set; }
        public string? SellerFirst_name { get; set; }
        public string? SearchString { get; set; }
    }
}
