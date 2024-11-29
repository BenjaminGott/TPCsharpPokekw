using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace TpCsharpPoKEKW.MVVM.ViewModel
{
    /*Commande quyi marche avec tout les Vm*/
    public class BaseVM : ObservableObject
    {
        public void BackHome( )
        {
            MainWindowVM.OnRequestVMChange?.Invoke(new MainViewVM()); 
        } 
       
    }
}
