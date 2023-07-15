using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopServer.Model
{
    public class Item
    {


        public string Id { get; set; }
        public string Name { get; set; }
        public string Preis { get; set; }       
        public string Menge { get; set; }


        public Item(string id, string name, string preis, string menge)
        {
            Id= id;
            Name= name;
            Preis= preis;
            Menge= menge;
        }






    }
}
