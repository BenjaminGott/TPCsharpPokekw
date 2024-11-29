using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TpCsharpPoKEKW.Model
{
    public class DbLogic 

    {
        public static string Adduser(string username, string password)
        {
            using (var context = new ExerciceMonsterContext())
            {
               


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

        public static string HashPassword(string password)
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
}
