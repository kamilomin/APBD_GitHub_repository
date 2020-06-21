using s17911Kolokwium.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace s17911Kolokwium.DTOs
{
    public class OrderItemDto
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        [MaxLength(40)]
        public string Type { get; set; }
        [Required]
        public int Quantity { get; set; }
        [MaxLength(300)]
        public string Comments { get; set; }
        
    }
}
