using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_DAL
{
    [Table("Werknemers")]
    public class Werknemer
    {
        [Key]
        public int WerknemerID { get; set; }

        [Required]
        [MaxLength(20)]
        public string Achternaam { get; set; }

        [Required]
        [MaxLength(10)]
        public string Voornaam { get; set; }
        [MaxLength(30)]
        public string Functie { get; set; }
        [MaxLength(25)]
        public string Beleefdheidstitel { get; set; }
        public DateTime? Geboortedatum { get; set; }
        public DateTime? In_Dienst { get; set; }

       
    }
}
