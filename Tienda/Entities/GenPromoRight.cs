using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class GenPromoRight
    {
        [Key]
        public int PromoRightID { get; set; }
        public string ImageURL { get; set; }
        public string AltText { get; set; }
        public string OfferTag { get; set; }
        public string Title { get; set; }
        public bool? isDeleted { get; set; }
    }
}
