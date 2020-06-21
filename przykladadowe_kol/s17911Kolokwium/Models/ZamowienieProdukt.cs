using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace s17911Kolokwium.Models
{
    public class ZamowienieProdukt
    {
        
        [Required]
        public int Quantity { get; set; }
        [MaxLength(300)]
        public string Comments { get; set; }

        [Key]
        [ForeignKey("WyrobProdukt")]
        public int IdConfectioneryProduct { get; set; }
        public WyrobProdukt ConfectioneryProduct { get; set; }

        [Key]
        [ForeignKey("Zamowienie")]
        public int IdOrder { get; set; }
        public Zamowienie Order { get; set; }
    }
}
