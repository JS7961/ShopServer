using ShopServer.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopServer.Data
{
    public static class Bestellungen
    {

        public static List<BestellungenModel> BestellungsListe;        
     
        static string Pfad ="";

        public static bool NeuEinlesen = true;

        static string TrennString = @"ioerg§$Z=0qw389hg=)G§Q$oiaeurg234987a54tuhr";

        public static int AktuellerBestellunsIndex = 0;


        static Bestellungen()
        {
            BestellungsListe = new List<BestellungenModel>();           
        }

        public static void BestellungHinzufügen(List<string> message)
        {
            BestellungsListe.Add(new BestellungenModel(message));
            BestellungsListe[BestellungsListe.Count - 1].Index = BestellungsListe.Count-1;
            ListeSpeichern();
        }


        public static void EinlesenAuslösen()
        {
            if (NeuEinlesen == true)
            {
                Pfad = Produkt.Exepfad + @"\Bestellungen.dat";

                if (File.Exists(Pfad))
                {
                    ListeEinlesen();
                    ListeSpeichern();
                }
                else
                {
                    List<string> message = new List<string>();
                    for (int i = 0; i < 10; i++)
                    {
                        message.Add("daten");
                    }
                    BestellungsListe.Add(new BestellungenModel(message) );
                    ListeSpeichern();
                    ListeEinlesen();
                }
                NeuEinlesen=false;  
            }

        }



        public static void ListeSpeichern()
        {
            Pfad = Produkt.Exepfad + @"\Bestellungen.dat";
            StreamWriter StreamWriter1 = new StreamWriter(Pfad);

            for (int i = 0; i < BestellungsListe.Count; i++)
            {                
                StreamWriter1.WriteLine(BestellungsListe[i].GesamtText);
                StreamWriter1.WriteLine(TrennString);
            }
            StreamWriter1.Close();
        }

        public static void ListeEinlesen()
        {
            BestellungsListe.Clear();

            string wort = "",Bestellungstext="";

            List<string> Zeilen = new List<string>();

            StreamReader Reader1 = new StreamReader(Pfad);

            while (Reader1.EndOfStream == false)
            {
                wort =Reader1.ReadLine();

                if (wort == TrennString)
                {
                    BestellungsListe.Add(new BestellungenModel(Zeilen) );
                    BestellungsListe[BestellungsListe.Count - 1].Index = BestellungsListe.Count - 1;
                    Zeilen = new List<string>();
                }
                else
                {
                    Bestellungstext += wort+"\n";
                    Zeilen.Add(wort);
                }



            }
            Reader1.Close();
        }





    }
}
