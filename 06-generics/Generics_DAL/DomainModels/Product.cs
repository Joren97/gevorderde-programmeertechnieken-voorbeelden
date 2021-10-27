using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_DAL
{
    [Table("Producten")]
    public partial class Product
    {
        [Key]
        public int Productnummer { get; set; }
        
        [Required]
        [MaxLength(40)]
        public string Naam { get; set; }

        [MaxLength(20)]
        public string Verpakking { get; set; }

        [Column(TypeName = "money")]
        public decimal? Prijs { get; set; }

        public short? Voorraad { get; set; }

        //navigatieproperties
        public ICollection<Orderlijn> Orderlijnen { get; set; }
    }

   

}
