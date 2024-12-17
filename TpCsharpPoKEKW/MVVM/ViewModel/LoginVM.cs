using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using TpCsharpPoKEKW.Model;

namespace TpCsharpPoKEKW.MVVM.ViewModel
{
    public class LoginVM : BaseVM
    {
        public ICommand HandleRequestLog { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public ICommand HandleRequestLogGuess { get; set; }

        public LoginVM()
        {
            HandleRequestLog = new RelayCommand(Log);
            HandleRequestLogGuess = new RelayCommand(LogGuess);
        }


        public void Log()
        {
            MessageBox.Show(DbLogic.LoginUser(Email, Password));
            BackHome();

        }
        public void LogGuess()
        {
            MessageBox.Show(DbLogic.LoginUser("guess", "Password"));
            BackHome();
        }
    }
}
