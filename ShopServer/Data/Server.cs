using SuperSimpleTcp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopServer.Data
{
    public static class Server
    {



        public static bool Gestartet;

           static  string ausgabe = "";
           static string AktuelleIP = "";
            public static SimpleTcpServer server1;

        static Server()
        {
            Gestartet = false;
            Init();
        }


            public static void Init()
            {

            server1 = new SimpleTcpServer("127.0.0.1:9000");

            //server1 = new SimpleTcpServer("66.44.123.156:9000");

            //server1 = new SimpleTcpServer("0.0.0.0:1024");

            //server1 = new SimpleTcpServer("4444:333:222:1111:a107:4abc3:4b5:1111:9000");



            server1.Events.ClientConnected += ClientVerbunden;

                server1.Events.ClientDisconnected += ClientGetrennt;


                server1.Events.DataReceived += DatenEmpfangen;

                
             
            }

           public static void Start()
            {
            server1.Start();
            Gestartet=true;
            
        }


      public  static void Stop()
        {
            server1.Stop();
            Gestartet = false;
        }


        static void ClientVerbunden(object sender, ConnectionEventArgs e)
            {

            }

            static void ClientGetrennt(object sender, ConnectionEventArgs e)
            {

            }

            static  void DatenEmpfangen(object? sender, DataReceivedEventArgs e)
            {
                ausgabe = Encoding.UTF8.GetString(e.Data.Array, 0, e.Data.Count);
                
                AktuelleIP = e.IpPort;

                AnfrageErmitteln();

            }




            static void Senden(string IpundPort, string wort)
            {


                server1.Send(IpundPort, wort);
            }


            static void AnfrageErmitteln()
            {

                string zeile = "\n";
                int zeileanfang = 0;
                List<string> Nachricht = new List<string>();

                if (ausgabe[ausgabe.Length - 1] != zeile[0])
                {
                    ausgabe += zeile;
                }

                for (int i = 0; i < ausgabe.Length; i++)
                {

                    if (ausgabe[i] == zeile[0])
                    {
                        Nachricht.Add(ausgabe.Substring(zeileanfang, (i - zeileanfang)));
                        zeileanfang = i + 1;

                    }

                }                     

                if (Nachricht[0] == "Bestellung1378")
                {
                    Bestellungen.BestellungHinzufügen(Nachricht);
                }



            if (Nachricht[0] == "Produktliste1")
            {
                string antwort = "";
                antwort=Produkt.GetMessageString();

                Senden(AktuelleIP, antwort);
            }





        }



    }



    
}
