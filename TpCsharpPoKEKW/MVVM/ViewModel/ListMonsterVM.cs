using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using System.Windows;
using TpCsharpPoKEKW.Model;
using Microsoft.EntityFrameworkCore;

namespace TpCsharpPoKEKW.MVVM.ViewModel
{
    public class ListMonsterVM : BaseVM
    {
        public ObservableCollection<Monster> Monsters { get; set; }
   

        public ICommand HandleRequestPlay { get; set; }

        public ListMonsterVM()
        {
            Monsters = new(context.Monsters.Include(m => m.Spells));
       
            HandleRequestPlay = new RelayCommand<Monster>(Goplay);

        }


        public static void Goplay(Monster monster)
        {
            if (monster != null)
            {
                MessageBox.Show($"Les't GO FIGHT With {monster.Name}");
              
            }
        }

     

    }
}
