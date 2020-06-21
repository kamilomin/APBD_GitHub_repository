using s17911Kolokwium.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace s17911Kolokwium.DTOs
{
    public class NoweZamowienieDto
    {
        [Required]
        public DateTime DataPrzyjecia { get; set; }
      
        [MaxLength(300)]
        public string Uwagi { get; set; }

        public ICollection<NoweZamowienieProduktDto> Wyroby { get; set; }
    }
}
