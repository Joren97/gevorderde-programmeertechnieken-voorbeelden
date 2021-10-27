using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_DAL
{
    public partial class Product
    {
        public override bool Equals(object obj)
        {
            return obj is Product product &&
                    Productnummer == product.Productnummer;
        }

        public override int GetHashCode()
        {
            return -1472680747 + Productnummer.GetHashCode();
        }

        public override string ToString()
        {
            return this.Naam;
        }


    }
}
