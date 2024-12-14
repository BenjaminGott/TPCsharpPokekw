using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System.Windows.Input;
using System.Windows;
using TpCsharpPoKEKW.Model;

namespace TpCsharpPoKEKW.MVVM.ViewModel
{
    internal class ListSpellVM : BaseVM
    {
        public ObservableCollection<Spell> Spells { get; set; }


        public ICommand HandleRequestPlays { get; set; }

        public ListSpellVM()
        {
            Spells = new(context.Spells.Include(m => m.Monsters));

            HandleRequestPlays = new RelayCommand<Spell>(Goplays);

        }


        public static void Goplays(Spell spell)
        //sz
        {
            if (spell != null)
            {
                MessageBox.Show($"Les't GO FIGHT With {spell.Name}");

            }
        }
    }
}