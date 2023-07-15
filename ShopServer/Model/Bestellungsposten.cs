using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopServer.Model
{
    public class Bestellungsposten
    {



        public Item Produkt { get; set; }

        public string Anzahl { get; set; }


        public Bestellungsposten(string anzahl, Item produkt)
        {
            Produkt = produkt;
            Anzahl = anzahl;
        }

        public decimal GetPostenPreis()
        {
            decimal preis = 0;
            decimal anzahl = 0;

            preis=Convert.ToDecimal(Produkt.Preis);
            anzahl=Convert.ToDecimal(Anzahl);

            return preis*anzahl;
        }







    }
}
