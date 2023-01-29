using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace auction.Models
{
    public class Lot
    {
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        [Display(Name = "Name")]
        public string name_order { get; set; }
        [Display(Name = "Starting price")]
        public float starting_price { get; set; }
        [Display(Name = "Id buyer")]
        public int buyer_id_buyer { get; set; }
        [Display(Name = "Id seller")]
        public int seller_id_seller { get; set; }
    }
}
