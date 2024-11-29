using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using System.Windows;
using TpCsharpPoKEKW.Model;

namespace TpCsharpPoKEKW.MVVM.ViewModel
{
    public class SigninVM : BaseVM
    {
        public ICommand HandleRequestSign { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public SigninVM()
        {
            HandleRequestSign = new RelayCommand(Sign);
        }


        public void Sign()
        {
            DbLogic.Adduser(Email, Password);
            MessageBox.Show(DbLogic.Adduser(Email, Password));
            BackHome();
        }
    }
}
