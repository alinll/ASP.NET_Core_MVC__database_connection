using System.ComponentModel.DataAnnotations;

namespace auction.Models
{
    public class Seller
    {
        public int Id { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        [Display(Name = "First name")]
        public string first_name_seller { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        [Display(Name = "Last name")]
        public string last_name_seller { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        [Display(Name = "Phone number")]
        public string phone_number_seller { get; set; }
    }
}
