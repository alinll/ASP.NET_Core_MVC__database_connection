using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace auction.Models
{
    public class BuyerNameViewModel
    {
        public List<Buyer>? Buyers { get; set; }
        public SelectList? First_names { get; set; }
        public string? BuyerFirst_name { get; set; }
        public string? SearchString { get; set; }
    }
}
