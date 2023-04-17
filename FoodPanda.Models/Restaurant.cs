using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPanda.Models
{
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; }
        [Required]
        [DisplayName("Restaurant Name")]
        public string RestaurantName { get; set; }
        [Required]
        [DisplayName("Restaurant Image")]
        public string RestaurantImage { get; set; }
        [Required]
        [DisplayName("Restaurant Rating")]

        public double RestaurantRating { get; set; }

        [Required]
        [DisplayName("Address")]
        public string Address { get; set; } 
        public DateTime CreationDate { get; set; }     =DateTime.Now;
        public DateTime ModificationDate { get; set; }   = DateTime.Now;
    }
}
