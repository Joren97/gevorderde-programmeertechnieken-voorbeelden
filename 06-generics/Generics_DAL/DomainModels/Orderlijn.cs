using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_DAL
{
    [Table("Orderlijnen")]
    public partial class Orderlijn
    {
        public int OrderlijnID { get; set; }

        [Index("IX_OrderIDProductNummer", 1, IsUnique =true)]
        public int OrderID { get; set; }

        [Index("IX_OrderIDProductNummer",2, IsUnique = true)]
        public int Productnummer { get; set; }

        public double? Eenheidsprijs { get; set; }

        public short? Hoeveelheid { get; set; }

        //navigatieproperties
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
