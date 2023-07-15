using ShopServer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopServer.Model
{
    public class BestellungenModel
    {

        public List<string> Bestellungszeilen;


        public List<Bestellungsposten> BestellungspostenListe;

        public string Gesamtpreis { get; set; }

        public int Index { get; set; }


        public BestellungenModel(List<string> Zeilen)
        {
                Bestellungszeilen = Zeilen;
            for (int i = 0; i < Zeilen.Count; i++)
            {
                GesamtText += Zeilen[i] + "\n";
            }

            GesamtText = GesamtText.Substring(0,GesamtText.Length-1); 

            for (int i = 1; i < 10; i++)
            {
                AnzeigeText+= Zeilen[i] + "\n";
            }
                
        }

        public void BestellungspostenListeErstellen()
        {
            BestellungspostenListe = new List<Bestellungsposten>();
            for (int i = 10; i < Bestellungszeilen.Count; i+=2)
            {
                BestellungspostenListe.Add( new (Bestellungszeilen[i + 1], Produkt.GetProdukt(Bestellungszeilen[i]) )) ;
            }
        }


        void Kopieren(List<string> Zeilen)
        {
            Bestellungszeilen = new List<string>();
            for (int i = 0;i < Zeilen.Count;i++)
            {
                Bestellungszeilen.Add(Zeilen[i]);
            }
        }


        public string GesamtText { get; set; }

        public string AnzeigeText { get; set; }


        public void GesamtpreisBerechen()
        {
            decimal preis = 0;
            for (int i = 0; i < BestellungspostenListe.Count; i++)
            {
                preis+=BestellungspostenListe[i].GetPostenPreis();
            }

            Gesamtpreis = preis.ToString(); 
        }






    }
}
