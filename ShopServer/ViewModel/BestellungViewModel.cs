using ShopServer.Data;
using ShopServer.Model;
using ShopServer.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopServer.ViewModel
{
    internal class BestellungViewModel : ViewModelBase
    {


        public BestellungenModel Bestellung1 { get; set; }

        public ObservableCollection<Bestellungsposten> BestellungsPostenListe { get; set; }



        public BestellungViewModel()
        {
            Bestellungen.EinlesenAuslösen();

            if (Bestellungen.AktuellerBestellunsIndex < Bestellungen.BestellungsListe.Count)
            {

                Bestellung1 = Bestellungen.BestellungsListe[Bestellungen.AktuellerBestellunsIndex];

                Bestellung1.BestellungspostenListeErstellen();

                BestellungsPostenListe = new ObservableCollection<Bestellungsposten>();

                for (int i = 0; i < Bestellung1.BestellungspostenListe.Count; i++)
                {
                    BestellungsPostenListe.Add(Bestellung1.BestellungspostenListe[i]);
                }

                Bestellung1.GesamtpreisBerechen();
            }

        }









    }
}
