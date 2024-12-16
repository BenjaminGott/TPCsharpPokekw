using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using TpCsharpPoKEKW.Model;

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
                MonsterCombat = new(monster);
                MainWindowVM.OnRequestVMChange?.Invoke(new CombatVM());

            }
        }



    }
}
