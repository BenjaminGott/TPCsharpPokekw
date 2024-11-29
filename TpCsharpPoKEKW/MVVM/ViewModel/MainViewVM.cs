using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace TpCsharpPoKEKW.MVVM.ViewModel
{
    /*Commande just pour la main View  -- le body (en html)*/

    public class MainViewVM : BaseVM
    {
        public ICommand HandleRequestSettings { get; set; }
        public ICommand HandleRequestLogIn { get; set; }
        public ICommand HandleRequestSignIn { get; set; }
        public MainViewVM() 
        {
            HandleRequestLogIn = new RelayCommand(Login);
            HandleRequestSettings = new RelayCommand(Settings);
            HandleRequestSignIn = new RelayCommand(Sign);
        }

        public void Sign()
        {
            MainWindowVM.OnRequestVMChange?.Invoke(new SigninVM());
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
