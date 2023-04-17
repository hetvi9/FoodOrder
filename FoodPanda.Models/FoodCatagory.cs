using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FoodPanda.Models
{
    public class FoodCatagory
    {
        [Key]
        public int FoodCatagoryId { get; set; }
        [Required]
        [Display(Name="Food Catagory Name")]
        public string FoodCatagoryType { get; set; }
       
      
    }
}
