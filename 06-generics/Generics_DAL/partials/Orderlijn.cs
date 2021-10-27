using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_DAL
{
    public partial class Orderlijn : Basisklasse
    {
        public override string this[string columnName]
        {
            get
            {
                if (columnName == "OrderID" && OrderID <= 0)
                {
                    return "OrderID moet een positief getal zijn!";
                }
                if (columnName == "Hoeveelheid" && Hoeveelheid <= 0)
                {
                    return "Hoeveelheid moet een positief getal zijn!";
                }
                if (columnName == "Productnummer" && Productnummer <= 0)
                {
                    return "Selecteer een product";
                }
                return "";
            }
        }
    }
}
