using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace s17911Kolokwium.Models
{
    public class Pracownik
    {
        [Key]
        [Required]
        public int IdEmployee { get; set; }
       
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
       
        [Required]
        [MaxLength(60)]
        public string Surname { get; set; }

        public ICollection<Zamowienie> Orders { get; set; }
    }
}
