using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using static TpCsharpPoKEKW.MVVM.ViewModel.BaseVM;

namespace TpCsharpPoKEKW.Model
{
    public class SpellWithMonsters
    {
        public int SpellId { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        public string Description { get; set; }
        public List<Model.Monster> Monsters { get; set; }
    }
    public class DbLogic

    {
        public static string HashPassword(string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                return Convert.ToBase64String(hashBytes);
            }
        }
        #region initdb


        public static string FirstAdduser()
        {
            using (var context = new ExerciceMonsterContext())
            {

                string hashedPassword = HashPassword("1234");


                var login = new Login
                {
                    Username = "test",
                    PasswordHash = hashedPassword
                };

                context.Logins.Add(login);
                context.SaveChanges();

                return "ok";


            }
        }

        // init spell

        //init monster

        public static string InitializeMonsters()
        {
            using (var context = new ExerciceMonsterContext())
            {

                var spell1 = new Spell { Name = "Fireball", Damage = 50, Description = "A blazing fireball that burns enemies." };
                var spell2 = new Spell { Name = "Ice Shard", Damage = 40, Description = "A sharp shard of ice that pierces enemies." };
                var spell3 = new Spell { Name = "Thunder Strike", Damage = 60, Description = "A powerful lightning strike." };
                var spell4 = new Spell { Name = "Aniheal", Damage = 30, Description = "Don't Restores health instead, causing damage." };
                var spell5 = new Spell { Name = "Poison Dart", Damage = 35, Description = "A toxic dart that poisons enemies over time." };
                var spell6 = new Spell { Name = "Earthquake", Damage = 70, Description = "A tremor that shakes the ground and damages all enemies." };
                var spell7 = new Spell { Name = "Wind Blade", Damage = 45, Description = "A sharp blade of wind that cuts through enemies." };
                var spell8 = new Spell { Name = "Shadow Strike", Damage = 55, Description = "A stealthy attack from the shadows." };
                var spell9 = new Spell { Name = "Light Beam", Damage = 50, Description = "A concentrated beam of light that burns evil beings." };
                var spell10 = new Spell { Name = "Water Surge", Damage = 40, Description = "A powerful surge of water that pushes enemies back." };
                var spell11 = new Spell { Name = "Meteor Shower", Damage = 80, Description = "A storm of meteors that rains destruction on all enemies." };
                var spell12 = new Spell { Name = "Arcane Blast", Damage = 60, Description = "A burst of arcane energy that overwhelms enemies." };
                var spell13 = new Spell { Name = "Flame Wall", Damage = 50, Description = "A wall of fire that blocks and burns advancing enemies." };
                var spell14 = new Spell { Name = "Frost Nova", Damage = 45, Description = "A freezing blast that slows and damages enemies." };
                var spell15 = new Spell { Name = "Divine Shield", Damage = 0, Description = "Creates a shield that absorbs damage and protects the caster." };
                var spell16 = new Spell { Name = "Venom Cloud", Damage = 50, Description = "A toxic cloud that poisons all enemies." };
                var spell17 = new Spell { Name = "Lightning Cage", Damage = 55, Description = "A cage of electricity that traps and zaps enemies." };
                var spell18 = new Spell { Name = "Blazing Meteor", Damage = 90, Description = "A single massive meteor that crashes into enemies." };
                var spell19 = new Spell { Name = "Frozen Barrier", Damage = 0, Description = "A wall of ice that blocks enemies and absorbs damage." };
                var spell20 = new Spell { Name = "Dark Pulse", Damage = 60, Description = "A wave of dark energy that saps life from enemies." };
                var spell21 = new Spell { Name = "Holy Nova", Damage = 70, Description = "A burst of divine energy that damages enemies and heals allies." };
                var spell22 = new Spell { Name = "Sandstorm", Damage = 45, Description = "A storm of sand that blinds and damages enemies over time." };
                var spell23 = new Spell { Name = "Lava Flow", Damage = 75, Description = "A surge of lava that burns everything in its path." };
                var spell24 = new Spell { Name = "Energy Drain", Damage = 50, Description = "Drains energy from enemies to restore the caster's health." };
                var spell25 = new Spell { Name = "Spirit Call", Damage = 0, Description = "Summons spirits to aid in battle or heal allies." };



                context.Spells.AddRange(spell1, spell2, spell3, spell4, spell5);
                context.SaveChanges();


                var imageUrls = new List<string>
        {
            "Assets/IMG/1.png",
            "Assets/IMG/2.png",
            "Assets/IMG/3.png",
            "Assets/IMG/4.png",
            "Assets/IMG/5.png",
            "Assets/IMG/6.png",
            "Assets/IMG/7.png",
            "Assets/IMG/8.png",
            "Assets/IMG/9.png",
            "Assets/IMG/10.png",
            "Assets/IMG/11.png",
            "Assets/IMG/12.png",
            "Assets/IMG/13.png",
            "Assets/IMG/14.png",
            "Assets/IMG/15.png",
            "Assets/IMG/16.png",
            "Assets/IMG/17.png",
            "Assets/IMG/18.png",
            "Assets/IMG/19.png",
            "Assets/IMG/20.png"
        };


                var monsters = new List<Monster>
                {
                new Monster { Name = "Dragon", Health = 300, ImageUrl = imageUrls[0], Spells = new List<Spell> { spell18, spell1, spell24, spell14 } },
                new Monster { Name = "Phoenix", Health = 250, ImageUrl = imageUrls[1], Spells = new List<Spell> { spell21, spell2, spell23, spell10 } },
                new Monster { Name = "Cyclops", Health = 200, ImageUrl = imageUrls[2], Spells = new List<Spell> { spell17, spell5, spell22, spell8 } },
                new Monster { Name = "Troll", Health = 180, ImageUrl = imageUrls[3], Spells = new List<Spell> { spell16, spell19, spell4, spell3 } },
                new Monster { Name = "Golem", Health = 350, ImageUrl = imageUrls[4], Spells = new List<Spell> { spell19, spell3, spell20, spell13 } },
                new Monster { Name = "Kraken", Health = 400, ImageUrl = imageUrls[5], Spells = new List<Spell> { spell23, spell5, spell22, spell11 } },
                new Monster { Name = "Basilisk", Health = 220, ImageUrl = imageUrls[6], Spells = new List<Spell> { spell16, spell2, spell3, spell14 } },
                new Monster { Name = "Griffin", Health = 270, ImageUrl = imageUrls[7], Spells = new List<Spell> { spell17, spell20, spell21, spell7 } },
                new Monster { Name = "Minotaur", Health = 240, ImageUrl = imageUrls[8], Spells = new List<Spell> { spell22, spell4, spell24, spell6 } },
                new Monster { Name = "Hydra", Health = 380, ImageUrl = imageUrls[9], Spells = new List<Spell> { spell25, spell2, spell18, spell12 } },
                new Monster { Name = "Wraith", Health = 150, ImageUrl = imageUrls[10], Spells = new List<Spell> { spell20, spell16, spell25, spell9 } },
                new Monster { Name = "Lich", Health = 230, ImageUrl = imageUrls[11], Spells = new List<Spell> { spell24, spell19, spell3, spell8 } },
                new Monster { Name = "Chimera", Health = 310, ImageUrl = imageUrls[12], Spells = new List<Spell> { spell18, spell21, spell2, spell13 } },
                new Monster { Name = "Dark Elf", Health = 200, ImageUrl = imageUrls[13], Spells = new List<Spell> { spell16, spell20, spell5, spell10 } },
                new Monster { Name = "Werewolf", Health = 250, ImageUrl = imageUrls[14], Spells = new List<Spell> { spell17, spell4, spell22, spell15 } },
                new Monster { Name = "Zombie King", Health = 280, ImageUrl = imageUrls[15], Spells = new List<Spell> { spell23, spell24, spell3, spell6 } },
                new Monster { Name = "Specter", Health = 180, ImageUrl = imageUrls[16], Spells = new List<Spell> { spell20, spell25, spell2, spell11 } },
                new Monster { Name = "Djinn", Health = 270, ImageUrl = imageUrls[17], Spells = new List<Spell> { spell18, spell23, spell21, spell7 } },
                new Monster { Name = "Harpy", Health = 220, ImageUrl = imageUrls[18], Spells = new List<Spell> { spell17, spell16, spell1, spell12 } },
                new Monster { Name = "Necromancer", Health = 300, ImageUrl = imageUrls[19], Spells = new List<Spell> { spell24, spell25, spell20, spell9 } },
                };

                context.Monsters.AddRange(monsters);
                context.SaveChanges();

                return "10 monsters with images and spells have been initialized successfully!";
            }
        }



        #endregion initdb

        public static string Adduser(string username, string password)
        {
            using var context = new ExerciceMonsterContext();

            // Vérifie si le nom d'utilisateur existe déjà
            if (context.Logins.Any(l => l.Username == username))
            {
                return "Le nom d'utilisateur existe déjà !";
            }

            // Hash le mot de passe
            string hashedPassword = HashPassword(password);

            // Crée un nouvel utilisateur
            var login = new Login
            {
                Username = username,
                PasswordHash = hashedPassword
            };

            context.Logins.Add(login);
            context.SaveChanges();

            // Crée un joueur lié au nouvel utilisateur
            var player = new Player
            {
                Name = username, // Utilise le nom d'utilisateur comme nom de joueur, ou change cette logique si nécessaire
                LoginId = login.Id
            };

            context.Players.Add(player);
            context.SaveChanges();

            return "Utilisateur et joueur ajoutés avec succès !";
        }
        /*public static string Adduser(string username, string password)
        {
            using var context = new ExerciceMonsterContext();

            if (context.Logins.Any(l => l.Username == username))
            {
                return "Le nom d'utilisateur existe déjà !";
            }

            string hashedPassword = HashPassword(password);

            var login = new Login
            {
                Username = username,
                PasswordHash = hashedPassword
            };

            context.Logins.Add(login);
            context.SaveChanges();

            return "Utilisateur et joueur ajoutés avec succès !";
        }*/


        public static string LoginUser(string username, string password)
        {
            using (var context = new ExerciceMonsterContext())
            {

                var login = context.Logins.FirstOrDefault(l => l.Username == username);

                if (login == null)
                {
                    return "Nom d'utilisateur incorrect.";
                }

                string hashedPassword = HashPassword(password);

                if (login.PasswordHash != hashedPassword)
                {
                    return "Mot de passe incorrect.";
                }
                Session.SpellList = DbLogic.GetSpellsWithMonsters();
                Session.IsLoggedIn = true;
                Session.LoggedInUsername = login.Username;

                return $"Connexion réussie, bienvenue {login.Username} !";
            }
        }

        //get all spell ( sppel + monster)
        public static List<SpellWithMonsters> GetSpellsWithMonsters()
        {
            using (var context = new ExerciceMonsterContext())
            {
                // Récupérer tous les sorts avec les monstres qui les utilisent
                var spellsWithMonsters = context.Spells
                    .Select(spell => new SpellWithMonsters
                    {
                        SpellId = spell.Id,
                        Name = spell.Name,
                        Damage = spell.Damage,
                        Description = spell.Description,
                        Monsters = spell.Monsters.Select(monster => new Model.Monster
                        {
                            Id = monster.Id,
                            Name = monster.Name,
                            Health = monster.Health,
                            ImageUrl = monster.ImageUrl
                        }).ToList()
                    }).ToList();

                return spellsWithMonsters;
            }
        }


        // get all moonster 
        public static List<Model.Monster> GetMonsters()
        {
            using (var context = new ExerciceMonsterContext())
            {
                // Récupérer tous les monstres
                var monsters = context.Monsters
                    .Select(monster => new Model.Monster
                    {
                        Id = monster.Id,
                        Name = monster.Name,
                        Health = monster.Health,
                        ImageUrl = monster.ImageUrl
                    }).ToList();

                return monsters;
            }

        }
        // modifier player add monster 
        public static string AddMonsterToPlayer(int playerId, int monsterId)
        {
            using (var context = new ExerciceMonsterContext())
            {
                // Récupérer le joueur et le monstre
                var player = context.Players.FirstOrDefault(p => p.Id == playerId);
                var monster = context.Monsters.FirstOrDefault(m => m.Id == monsterId);

                if (player == null)
                {
                    return "Joueur non trouvé.";
                }

                if (monster == null)
                {
                    return "Monstre non trouvé.";
                }
                player.Monsters.Add(monster);
                context.SaveChanges();

                return $"Le monstre {monster.Name} a été ajouté au joueur {player.Name}.";
            }
        }
        public static string RemoveMonsterFromPlayer(int playerId, int monsterId)
        {
            using (var context = new ExerciceMonsterContext())
            {
                var player = context.Players.FirstOrDefault(p => p.Id == playerId);
                var monster = context.Monsters.FirstOrDefault(m => m.Id == monsterId);

                if (player == null)
                {
                    return "Joueur non trouvé.";
                }

                if (monster == null)
                {
                    return "Monstre non trouvé.";
                }

                if (!player.Monsters.Contains(monster))
                {
                    return $"Le joueur {player.Name} ne possède pas le monstre {monster.Name}.";
                }

                player.Monsters.Remove(monster);
                context.SaveChanges();

                return $"Le monstre {monster.Name} a été retiré du joueur {player.Name}.";
            }
        }

            // get monster for a player (monster tab + spell ) 

            public static List<Monster> GetPlayerMonsters(int playerId)
        {
            using (var context = new ExerciceMonsterContext())
            {
                // Récupérer le joueur
                var player = context.Players
                    .Where(p => p.Id == playerId)
                    .Select(p => new {
                        Monsters = p.Monsters.Select(m => new Monster
                        {
                            Id = m.Id,
                            Name = m.Name,
                            Health = m.Health,
                            ImageUrl = m.ImageUrl
                        }).ToList()
                    })
                    .FirstOrDefault();

                if (player == null || player.Monsters == null || !player.Monsters.Any())
                {
                    return new List<Monster>();
                }

                return player.Monsters;
            }
        }

   


    }
}




