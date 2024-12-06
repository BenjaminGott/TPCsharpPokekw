using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using System.Windows;
using TpCsharpPoKEKW.Model;
using System.Security.Cryptography;
using TpCsharpPoKEKW.Model;
using System.Windows.Media.Animation;

namespace TpCsharpPoKEKW.MVVM.ViewModel
{
    public class SettingsVM : BaseVM
    {


        public ICommand HandleRequestDb { get; set; }

        public string dbLink { get; set; } = ExerciceMonsterContext.SqlDBLink;


        public SettingsVM()
        {
            HandleRequestDb = new RelayCommand(Newdb);
        }


        public void Newdb()
        {
            ExerciceMonsterContext.SqlDBLink = dbLink;
            MessageBox.Show(DbLogic.FirstAdduser());
            MessageBox.Show(DbLogic.InitializeMonsters());
            BackHome();

        }

    }
}
