using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace TpCsharpPoKEKW.MVVM.ViewModel
{
    /*Commande just pour la main View  -- le body (en html)*/

    public class MainViewVM : BaseVM
    {
        public ICommand HandleRequestSignIn { get; set; }
        public ICommand HandleRequestLogIn { get; set; }
        public MainViewVM() 
        {
            HandleRequestLogIn = new RelayCommand(Login);
            HandleRequestSignIn = new RelayCommand(SignIn);
        }

        public void Login()
        {
            MainWindowVM.OnRequestVMChange?.Invoke(new LoginVM());
        }

        public void SignIn()
        {
            MainWindowVM.OnRequestVMChange?.Invoke(new SigninVM());
        }
    }
}
