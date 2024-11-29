using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace TpCsharpPoKEKW.MVVM.ViewModel
{
    public class LoginVM : BaseVM
    {
        public ICommand HandleRequestLog { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public LoginVM()
        {
            HandleRequestLog = new RelayCommand(Log);
        }

        
        public void Log()
        {
           
            MessageBox.Show($"E-mail : {Email}\nMot de passe : {Password}");
        }
    }
}
