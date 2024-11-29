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

namespace TpCsharpPoKEKW.MVVM.ViewModel
{
    public class SettingsVM : BaseVM
    {


        public ICommand HandleRequestDb { get; set; }

        public string dbLink { get; set; } = ExerciceMonsterContext.SqlDBLink ;


        public SettingsVM()
        {
            HandleRequestDb = new RelayCommand(Newdb);
        }


        public void Newdb()
        {
            ExerciceMonsterContext.SqlDBLink = dbLink;
            MessageBox.Show(ExerciceMonsterContext.SqlDBLink);
            MessageBox.Show(Adduser("ccezad", "1b2fe3"));

        }

        public string Adduser(string username, string password)
        {
            using (var context = new ExerciceMonsterContext())
            {
               /* if (context.Logins.Any(l => l.Username == username))
                {
                    return "Le nom d'utilisateur existe déjà !";
                }*/


                string hashedPassword = HashPassword(password);


                var login = new Login
                {
                    Username = username,
                    PasswordHash = hashedPassword
                };

                context.Logins.Add(login);
                context.SaveChanges();

                return "Utilisateur et joueur ajoutés avec succès !";


            }
        }

            static string HashPassword(string password)
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                    return Convert.ToBase64String(hashBytes);
                }
            }

        
    }
}
