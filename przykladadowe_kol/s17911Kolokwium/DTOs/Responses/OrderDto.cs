using s17911Kolokwium.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace s17911Kolokwium.DTOs
{
    public class OrderDto
    {
        [Required]
        public int IdOrder { get; set; }
        [Required]
        public DateTime AcceptanceDate { get; set; }
        public DateTime RealizationDate { get; set; }
        [MaxLength(300)]
        public string Comments { get; set; }

        public ICollection<OrderItemDto> OrderItems { get; set; }
    }
}
