using s17911Kolokwium.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace s17911Kolokwium.DTOs
{
    public class NoweZamowienieProduktDto
    {
        [Required]
        [MaxLength(200)]
        public string Wyrob { get; set; }
        
        [Required]
        public string Ilosc { get; set; }
        
        [MaxLength(300)]
        public string Uwagi { get; set; }
        
    }
}
