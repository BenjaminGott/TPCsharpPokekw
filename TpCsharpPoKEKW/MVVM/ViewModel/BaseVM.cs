using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TpCsharpPoKEKW.Model;
namespace TpCsharpPoKEKW.MVVM.ViewModel
{
    /*Commande qui marche avec tous les VM*/
    public class CombatMosnter : ObservableObject
    {
        private int _curentHealth;

        public int CurentHealth
        {
            get => _curentHealth;
            set { SetProperty(ref _curentHealth, value); OnPropertyChanged(nameof(CurentHealth)); } // Utilisation de SetProperty fourni par ObservableObject
        }

        public int Health { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public ObservableCollection<Spell> Spells { get; set; }

        /* public int CurentHealth { get; set; }*/


        public CombatMosnter(Monster m)
        {
            {
                CurentHealth = m.Health;
                Health = m.Health;
                Name = m.Name;
                Spells = new(m.Spells);
                ImageUrl = m.ImageUrl;
            }



        }

    }
    public class BaseVM : ObservableObject
    {
        public ICommand HandleRequestBackHome { get; set; }
        public static CombatMosnter MonsterCombat { get; set; }
        protected ExerciceMonsterContext context = new ExerciceMonsterContext();

        public BaseVM()
        {
            HandleRequestBackHome = new RelayCommand(BackHome);
        }
        public static void BackHome()
        {
            MainWindowVM.OnRequestVMChange?.Invoke(new MainViewVM());
        }


        public static class Session
        {
            public static List<SpellWithMonsters> SpellList;
            private static bool _isLoggedIn = false;

            public static int Id { get; set; } = 0;
            public static bool IsLoggedIn
            {
                get => _isLoggedIn;
                set
                {
                    _isLoggedIn = value;
                    OnStaticPropertyChanged(nameof(IsLoggedIn));
                }
            }

            private static string? _loggedInUsername = null;
            public static string? LoggedInUsername
            {
                get => _loggedInUsername;
                set
                {
                    _loggedInUsername = value;
                    OnStaticPropertyChanged(nameof(LoggedInUsername));
                }
            }

            public static event PropertyChangedEventHandler? StaticPropertyChanged;

            private static void OnStaticPropertyChanged(string propertyName)
            {
                StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
