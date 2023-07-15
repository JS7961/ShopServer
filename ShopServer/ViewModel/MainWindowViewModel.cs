using ShopServer.Data;
using ShopServer.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopServer.ViewModel
{

    internal class MainWindowViewModel : ViewModelBase
    {


        public MainWindowViewModel()
        {
            SelectedViewModel = new HomeViewModel();
        }



        public RelayCommand HomeCommand
        {
            get
            {
                return new RelayCommand(ShowHome, canExecute => SelectedViewModel.GetType() != typeof(HomeViewModel));
            }
        }


        public void ShowHome(object parameter)
        {
            SelectedViewModel = new HomeViewModel();
        }

        public RelayCommand ProduktCommand
        {
            get
            {
                return new RelayCommand(ShowProdukt, canExecute => SelectedViewModel.GetType() != typeof(ProduktViewModel));
            }
        }


        public void ShowProdukt(object parameter)
        {
            SelectedViewModel = new ProduktViewModel();
        }


        public RelayCommand BestellungenCommand
        {
            get
            {
                return new RelayCommand(ShowBestellungen, canExecute => SelectedViewModel.GetType() != typeof(BestellungenViewModel));
            }
        }


        public void ShowBestellungen(object parameter)
        {
            SelectedViewModel = new BestellungenViewModel();
        }

        public RelayCommand BestellungCommand
        {
            get
            {
                return new RelayCommand(ShowBestellung, canExecute => SelectedViewModel.GetType() != typeof(BestellungViewModel));
            }
        }


        public void ShowBestellung(object parameter)
        {
            SelectedViewModel = new BestellungViewModel();
        }


        public RelayCommand BestellungSelectCommand
        {
            get
            {
                return new RelayCommand(ShowBestellungSelect, canExecute => SelectedViewModel.GetType() != typeof(BestellungViewModel));
            }
        }


        public void ShowBestellungSelect(object parameter)
        {
            int wert = Convert.ToInt32(parameter);
            Bestellungen.AktuellerBestellunsIndex = wert;

            SelectedViewModel = new BestellungViewModel();
        }



        private ViewModelBase selectedViewModel;

        public ViewModelBase SelectedViewModel
        {
            get { return selectedViewModel; }
            set
            {
                selectedViewModel = value;
                OnPropertyChanged("SelectedViewModel");
            }
        }




    }
}
