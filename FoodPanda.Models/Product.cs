using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPanda.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Food Item Name")]
        public string ProductName { get; set; }
        [Required]
        [Display(Name ="About Food")]

        public string Description { get; set; }
        [Required]
		[ValidateNever]
        [Display(Name ="Image")]

        public string ImageUrl { get; set; }
        [Required]
        public double Price  { get; set; }
        [Required]
        [Display(Name ="Restaurant")]

        public int RestaurantId { get; set; }
        [ForeignKey("RestaurantId")]
		[ValidateNever]

		public Restaurant Restaurant { get; set; }
        [Required]
        [Display(Name ="Food Catagory")]

        public int FoodCatagoryId { get; set; }
        [ValidateNever]
        public FoodCatagory FoodCatagory { get; set; }
        
    }
}
