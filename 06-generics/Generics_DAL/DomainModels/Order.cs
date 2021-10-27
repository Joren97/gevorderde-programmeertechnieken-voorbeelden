using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_DAL
{
    [Table("Orders")]
    public class Order
    {
        public int OrderID { get; set; }

        public string Klantnummer { get; set; }

        public int WerknemerID { get; set; }

        public DateTime Orderdatum { get; set; }

        [MaxLength(40)]
        public string VerzendBedrijf { get; set; }

        [MaxLength(60)]
        public string Verzendadres { get; set; }

        [MaxLength(15)]
        public string Verzendplaats { get; set; }

        [MaxLength(10)]
        public string Verzendpostcode { get; set; }

        [MaxLength(15)]
        public string Verzendland { get; set; }

        //navigatieproperties
       
        public Klant Klant { get; set; }
        public Werknemer Werknemer { get; set; }

        public ICollection<Orderlijn> Orderlijnen { get; set; }

    }
}
