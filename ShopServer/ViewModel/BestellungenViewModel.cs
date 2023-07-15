using ShopServer.Data;
using ShopServer.Model;
using ShopServer.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShopServer.ViewModel
{
    internal class BestellungenViewModel : ViewModelBase
    {

        public ObservableCollection<BestellungenModel> BestellungsListe { get; set; }

        public BestellungenViewModel()
        {
           BestellungsListe = new ObservableCollection<BestellungenModel>();

            Bestellungen.EinlesenAuslösen();


            for (int i = 0; i < Bestellungen.BestellungsListe.Count(); i++)
            {
                BestellungsListe.Add(Bestellungen.BestellungsListe[i]);
            }


            


        }

       

}
}
