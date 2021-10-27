using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_DAL
{
    [Table("Klanten")]
    public class Klant
    {
        [Key]
        public string Klantnummer { get; set; }

        [Required]
        [MaxLength(40)]
        [Index(IsUnique = true)]
        public string Bedrijf { get; set; }

        [MaxLength(60)]
        public string Adres { get; set; }
        [MaxLength(15)]
        public string Plaats { get; set; }
        [MaxLength(10)]
        public string Postcode { get; set; }
        [MaxLength(15)]
        public string Land { get; set; }
        [MaxLength(24)]
        public string Telefoonnummer { get; set; }

        //navigatieproperties
        public ICollection<Order> Orders { get; set; }
    }





}
