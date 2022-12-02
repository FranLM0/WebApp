﻿using System.ComponentModel.DataAnnotations;

namespace CarniceriaWebApp.ViewModels
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public int ProductId { get; set; }

        public string ProductCategory { get; set; }
       
    }
}