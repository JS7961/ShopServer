using ShopServer.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopServer.Data
{
    public static class Produkt
    {

        public static List<Item> ItemListe ;

       public static string Exepfad = System.Reflection.Assembly.GetExecutingAssembly().Location;
     

        static string Pfad ="";

        static Produkt()
        {

            //   D:\VisualStudioProjekte\ShopServer

            ItemListe = new List<Item>();
            

            Item Item3 = new Item("","","","");

            Exepfad = Abschneiden(Exepfad);

            Pfad = Exepfad + "Produkte.dat";


            if ( File.Exists(Pfad) )
            {
                ListeEinlesen();
            }
            else
            {
                ItemListe.Add(new Item("1", "Huhn", "3,99", "300"));
                ListeSpeichern();
                ListeEinlesen();
            }

           
            
        }


        public static void Trigger()
        {
            
        }



        public static void ListeSpeichern()
        {
            StreamWriter StreamWriter1 = new StreamWriter(Pfad);

            for (int i = 0; i < ItemListe.Count; i++)
            {
                StreamWriter1.WriteLine(ItemListe[i].Id);
                StreamWriter1.WriteLine(ItemListe[i].Name);
                StreamWriter1.WriteLine(ItemListe[i].Preis);
                StreamWriter1.WriteLine(ItemListe[i].Menge);
            }
            StreamWriter1.Close();
        }

        public static void ListeEinlesen()
        {
            ItemListe.Clear();

            Item Item3 = new Item("", "", "", "");

            StreamReader Reader1 = new StreamReader(Pfad);

            while (Reader1.EndOfStream == false)
            {
                Item3 = new Item("", "", "", "");

                Item3.Id = Reader1.ReadLine();
                Item3.Name = Reader1.ReadLine();
                Item3.Preis = Reader1.ReadLine();
                Item3.Menge = Reader1.ReadLine();

                ItemListe.Add(Item3);
            }
            Reader1.Close();
        }







        static string Abschneiden(string wort)
        {
            string sl = @"\";
            for (int i = wort.Length-1; i > 0; i--)
            {
                if ( wort[i] == sl[0] )
                {
                   return wort.Substring(0, i+1);
                }
            }

            return wort;
        }




        public static string GetMessageString()
        {
            string message = "";

            message += "Produktliste\n"+Convert.ToString(ItemListe.Count)+"\n";

            for (int i = 0; i < ItemListe.Count; i++)
            {
                message+=ItemListe[i].Id+"\n"+ ItemListe[i].Name+"\n"+ ItemListe[i].Preis+"\n" ;
            }


            return message; 
        }


        

        public static Item GetProdukt(string Id)
        {
            Item Item1;

            Item1 = ItemListe.Find((x) => { return x.Id == Id; });


            if (Item1 == null)
            {
                Item1 = new Item("", "", "","");
                return Item1;
            }
            else
            {
                return Item1;
            }
        }

    }
}
