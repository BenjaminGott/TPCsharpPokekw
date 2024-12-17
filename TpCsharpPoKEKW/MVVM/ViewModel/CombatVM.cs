using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using TpCsharpPoKEKW.Model;

namespace TpCsharpPoKEKW.MVVM.ViewModel
{


    internal class CombatVM : BaseVM
    {

        private string messageBat;

        public bool talking { get; set; } = false;
        public string MessageBat { get => messageBat; set { SetProperty(ref messageBat, value); OnPropertyChanged(nameof(MessageBat)); } }

        public Spell spellB { get; set; }

        private CombatMosnter _monsterA;
        public CombatMosnter MonsterA
        {
            get => _monsterA;
            set
            {
                if (_monsterA != value)
                {
                    SetProperty(ref _monsterA, value);
                    OnPropertyChanged(nameof(MonsterA));
                }
            }
        }
        private CombatMosnter _monsterB;
        public CombatMosnter MonsterB
        {
            get => _monsterB;
            set
            {
                if (_monsterB != value)
                {
                    SetProperty(ref _monsterB, value);
                    OnPropertyChanged(nameof(MonsterB));
                }
            }
        }
        Random random = new Random();
        public ICommand HandleRequestUse { get; set; }


        public CombatVM()
        {
            MessageBat = "It's Your turn";
            MonsterA = MonsterCombat;
            MonsterB = GetRandomMonster();

            HandleRequestUse = new RelayCommand<Spell>(Use);

        }

        public CombatMosnter GetRandomMonster()
        {
            ObservableCollection<Monster> Monsters = new(context.Monsters.Include(m => m.Spells));
            int index = random.Next(Monsters.Count);
            return new(Monsters[index]);
        }


        public async void Use(Spell spell) => await Task.Run(() =>
        {
            if (talking)
            {
                MessageBox.Show($"Wait");
                return;
            }
            if (spell != null)
            {
                talking = true;
                MessageBat = ($"You use  {spell.Name}");
                Task.Delay(2000).Wait();
                //Random entre 0 est 2 pour savoir si cette capa est efficasse
                int n = random.Next(200);
                if (n < 10)
                {
                    MessageBat = ($"The monster dodged the attack!\n Damage avoided");
                    n = 0;
                }
                else if (n < 35)
                {
                    MessageBat = ($"The attack barely scratched the monster.\n Damage dealt: {spell.Damage * n / 100}");
                }
                else if (n < 75)
                {
                    MessageBat = ($"The attack landed, but it wasn't very effective.\n Damage dealt: {spell.Damage * n / 100}");
                }
                else if (n < 125)
                {
                    MessageBat = ($"A solid hit! The attack was moderately effective. \n Damage dealt: {spell.Damage * n / 100}");
                }
                else if (n < 175)
                {
                    MessageBat = ($"A critical strike! The monster is heavily wounded.\n Damage dealt: {spell.Damage * n / 100}");
                }
                else
                {
                    MessageBat = ($"An overwhelming blow! The monster barely stands!\n Damage dealt: {spell.Damage * n / 100}");
                }

                if (MonsterB.CurentHealth - spell.Damage * n / 100 < 0)
                {
                    MonsterB.CurentHealth = 0;

                    MessageBox.Show($"You WIN. \n and You gonna be redirected to the main page. \n please play again -_-");
                    talking = false;
                    BackHome();
                    return;
                }
                else
                {
                    MonsterB.CurentHealth -= spell.Damage * n / 100;
                }
                OnPropertyChanged(nameof(MonsterB));
                Task.Delay(2000).Wait();
                MessageBat = "It's Enemie turn";
                Task.Delay(2000).Wait();
                n = random.Next(4);
                spellB = MonsterB.Spells[n];

                MessageBat = ($"{MonsterB.Name} Use {spellB.Name}");

                Task.Delay(2000).Wait();
                n = random.Next(200);
                if (n < 10)
                {
                    MessageBat = ($"The monster dodged the attack!\n Damage avoided");
                    n = 0;
                }
                else if (n < 35)
                {
                    MessageBat = ($"The attack barely scratched the monster.\n Damage dealt: {spellB.Damage * n / 100}");
                }
                else if (n < 75)
                {
                    MessageBat = ($"The attack landed, but it wasn't very effective.\n Damage dealt: {spellB.Damage * n / 100}");
                }
                else if (n < 125)
                {
                    MessageBat = ($"A solid hit! The attack was moderately effective. \n Damage dealt: {spellB.Damage * n / 100}");
                }
                else if (n < 175)
                {
                    MessageBat = ($"A critical strike! The monster is heavily wounded.\n Damage dealt: {spellB.Damage * n / 100}");
                }
                else
                {
                    MessageBat = ($"An overwhelming blow! The monster barely stands!\n Damage dealt: {spellB.Damage * n / 100}");
                }


                if (MonsterA.CurentHealth - spellB.Damage * n / 100 < 0)
                {
                    MonsterA.CurentHealth = 0;
                    MessageBox.Show($"You Lose. \n and You gonna be redirected to the main page. \n please try again -_-");
                    talking = false;
                    BackHome();
                    return;
                }
                else
                {
                    MonsterA.CurentHealth -= spellB.Damage * n / 100;
                }

                Task.Delay(2000).Wait();
                MessageBat = "It's Your turn";


                talking = false;


            }
        });

    }
}
