using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace TpCsharpPoKEKW.MVVM.ViewModel
{
    /*Commande just pour la main View  -- le body (en html)*/

    public class MainViewVM : BaseVM
    {
        public ICommand HandleRequestSettings { get; set; }
        public ICommand HandleRequestLogIn { get; set; }
        public MainViewVM() 
        {
            HandleRequestLogIn = new RelayCommand(Login);
            HandleRequestSettings = new RelayCommand(Settings);
        }

        public void Login()
        {
            MainWindowVM.OnRequestVMChange?.Invoke(new LoginVM());
        }

        public void Settings()
        {
            MainWindowVM.OnRequestVMChange?.Invoke(new SettingsVM());
        }
    }
}
