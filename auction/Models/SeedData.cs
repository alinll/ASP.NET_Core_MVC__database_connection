using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using auction.Data;
using System;
using System.Linq;

namespace auction.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context=new auctionContext(serviceProvider.GetRequiredService<DbContextOptions<auctionContext>>()))
            {
                if (context.Lot.Any())
                {
                    return;
                }
                context.Lot.AddRange(
                    new Lot
                    {
                        name_order = "villa",
                        starting_price = 590000000,
                        buyer_id_buyer = 1,
                        seller_id_seller = 5
                    },
                    new Lot
                    {
                        name_order = "book written before our era",
                        starting_price = 1700000000,
                        buyer_id_buyer = 3,
                        seller_id_seller = 6
                    },
                    new Lot
                    {
                        name_order = "picture \"River in the Carpathians\"",
                        starting_price = 336000,
                        buyer_id_buyer = 2,
                        seller_id_seller = 7
                    }
                    );
                context.SaveChanges();

                if (context.Seller.Any())
                {
                    return;
                }
                context.Seller.AddRange(
                    new Seller
                    {
                        first_name_seller = "Artem",
                        last_name_seller = "Tkachenko",
                        phone_number_seller = "0684778758"
                    },
                    new Seller
                    {
                        first_name_seller = "Bogdan",
                        last_name_seller = "Polischuk",
                        phone_number_seller = "0685637464"
                    },
                    new Seller
                    {
                        first_name_seller = "Eva",
                        last_name_seller = "Marchenko",
                        phone_number_seller = "0967653466"
                    }
                    );
                context.SaveChanges();

                if (context.Buyer.Any())
                {
                    return;
                }
                context.Buyer.AddRange(
                    new Buyer
                    {
                        first_name_buyer = "Roksolana",
                        last_name_buyer = "Kovalenko",
                        phone_number_buyer = "0687685746"
                    },
                    new Buyer
                    {
                        first_name_buyer = "Adam",
                        last_name_buyer = "Schvec",
                        phone_number_buyer = "0967676347"
                    },
                    new Buyer
                    {
                        first_name_buyer = "Maryna",
                        last_name_buyer = "Kravchenko",
                        phone_number_buyer = "0683746736"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
