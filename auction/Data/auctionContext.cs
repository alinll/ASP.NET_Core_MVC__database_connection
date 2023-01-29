using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using auction.Models;

namespace auction.Data
{
    public class auctionContext : DbContext
    {
        public auctionContext (DbContextOptions<auctionContext> options)
            : base(options)
        {
        }

        public DbSet<auction.Models.Lot> Lot { get; set; } = default!;

        public DbSet<auction.Models.Seller> Seller { get; set; } = default!;

        public DbSet<auction.Models.Buyer> Buyer { get; set; } = default!;
    }
}
