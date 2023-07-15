using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopServer.Data;
using ShopServer.MVVM;

namespace ShopServer.ViewModel
{
    internal class HomeViewModel : ViewModelBase
    {





        public RelayCommand StartCommand
        {
            get
            {
                return new RelayCommand(ServerStarten, KannStarten);
            }
        }

        public void ServerStarten(object parameter)
        {
            Server.Start();
        }

        public bool KannStarten(object parameter)
        {
            return !Server.Gestartet;
        }




        public RelayCommand StopCommand
        {
            get
            {
                return new RelayCommand(ServerStoppen, KannStoppen);
            }
        }

        public void ServerStoppen(object parameter)
        {
            Server.Stop();  
        }

        public bool KannStoppen(object parameter)
        {
            return Server.Gestartet;
        }






    }
}
