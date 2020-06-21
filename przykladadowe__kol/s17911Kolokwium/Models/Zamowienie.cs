using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace s17911Kolokwium.Models
{
    public class Zamowienie
    {
        [Key]
        [Required]
        public int IdOrder { get; set; }
       
        [Required]
        public DateTime AcceptanceDate { get; set; }
        public DateTime RealizationDate { get; set; }
        [MaxLength(300)]
        public string Comments { get; set; }

        [ForeignKey("Klient")]
        public int IdClient { get; set; }
        public Klient Client { get; set; }

        [ForeignKey("Pracownik")]
        public int IdEmployee { get; set; }
        public Pracownik Employee { get; set; }

        public ICollection<ZamowienieProdukt> OrderItems { get; set; }
    }
}
