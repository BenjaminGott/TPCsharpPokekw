using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TpCsharpPoKEKW.MVVM.ViewModel;

namespace TpCsharpPoKEKW.MVVM.View
{
    /// <summary>
    /// Logique d'interaction pour SigninView.xaml
    /// </summary>
    public partial class SigninView : UserControl
    {
        public SigninView()
        {
            InitializeComponent();
        }
        private void PasswordBox_PasswordChangedSign(object sender, RoutedEventArgs e)
        {
            if (DataContext is SigninVM vm)
            {
                {
                    var passwordBox = sender as PasswordBox;
                    vm.Password = passwordBox?.Password;
                }
            }
        }
    }
}