using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopServer.Data;
using ShopServer.Model;
using ShopServer.MVVM;

namespace ShopServer.ViewModel
{
    internal class ProduktViewModel : ViewModelBase
    {

        public ObservableCollection<Item> ItemListe { get; set; }




        public ProduktViewModel()
        {         
            ItemListe = new ObservableCollection<Item>();

            Produkt.Trigger();


            for (int i = 0; i < Produkt.ItemListe.Count(); i++)
            {
                ItemListe.Add(Produkt.ItemListe[i]);
            }

            item1 = new Item("", "", "", "");
        }


        public RelayCommand AddCommand
        {
            get
            {
                return new RelayCommand(ProduktHinzufügen, KannProduktHinzufügen );
            }
        }

        public void ProduktHinzufügen(object parameter)
        {
            Item Item2 = new Item(Item1.Id, Item1.Name, Item1.Preis, Item1.Menge);

            Produkt.ItemListe.Add(Item2);
            ItemListe.Add(Item2);          

            Item1 = new Item("", "", "", "");

            Produkt.ListeSpeichern();

        }

        public bool KannProduktHinzufügen(object parameter)
        {
            if (Item1.Id != "" && Item1.Name != "" && Item1.Preis != "" && Item1.Menge != "" )
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        private Item item1;

        public Item Item1
        {
            get { return item1; }
            set 
            { 
                item1 = value; 
                OnPropertyChanged("Item1");
            }
        }




        public void Erneuern()
        {
            //ItemListe.Add(new Item(0, "", "", 0, "", 0));
            // ItemListe.RemoveAt(ItemListe.Count - 1);
            //ItemListe.Add(new Item(0, "", "", 0, "", 0));


            ItemListe.Clear();


            for (int i = 0; i < Produkt.ItemListe.Count(); i++)
            {
                ItemListe.Add(Produkt.ItemListe[i]);
            }
            
        }








    }
}
