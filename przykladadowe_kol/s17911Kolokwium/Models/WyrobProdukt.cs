using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace s17911Kolokwium.Models
{
    public class WyrobProdukt
    {
        [Key]
        [Required]
        public int IdConfectioneryProduct { get; set; }
      
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
      
        [Required]
        public float PricePerUnit { get; set; }
       
        [Required]
        [MaxLength(40)]
        public string Type { get; set; }

        public ICollection<ZamowienieProdukt> OrderItems { get; set; }
    }
}
