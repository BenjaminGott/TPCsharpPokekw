using System.Globalization;
using System.Windows.Data;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using TpCsharpPoKEKW.Model;

namespace TpCsharpPoKEKW.MVVM.ViewModel
{
    public class MainViewVM : BaseVM
    {

        public static string? LoggedInUsername => Session.LoggedInUsername;
        public static bool IsLoggedIn => Session.IsLoggedIn;

        public ICommand HandleRequestSettings { get; set; }
        public ICommand HandleRequestLogIn { get; set; }
        public ICommand HandleRequestSignIn { get; set; }
        public ICommand HandleRequestLogOut { get; set; }
        public ICommand HandleRequestPlay { get; set; }
        public ICommand HandleRequestListMo { get; set; }

        public MainViewVM()
        {
            HandleRequestLogIn = new RelayCommand(Login);
            HandleRequestSettings = new RelayCommand(Settings);
            HandleRequestSignIn = new RelayCommand(Sign);
            HandleRequestLogOut = new RelayCommand(LogOut);
            HandleRequestPlay = new RelayCommand(Play);
            HandleRequestListMo = new RelayCommand(ListM);
        }

        public void Sign()
            
        {
            if (ExerciceMonsterContext.SqlDBLink == null)
            {
                MessageBox.Show("No database connection go to settings");
            }
            else
            {
                MainWindowVM.OnRequestVMChange?.Invoke(new SigninVM());
            }
        }

        public void Login()
        {
            if (ExerciceMonsterContext.SqlDBLink == null)
            {
                MessageBox.Show("No database connection go to settings");
            }
            else
            {
                MainWindowVM.OnRequestVMChange?.Invoke(new LoginVM());
            }

        }

        public static void ListM()
        {
            MainWindowVM.OnRequestVMChange?.Invoke(new ListMonsterVM());
        }

        public void Settings()
        {
            MainWindowVM.OnRequestVMChange?.Invoke(new SettingsVM());
        }


        public void Play()
        {
            // Logique pour commencer à jouer
        }
    }
}
