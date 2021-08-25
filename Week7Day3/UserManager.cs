using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7Day3.AdoRepositories;
using Week7Day3.Entities;
using Week7Day3.Repositories;

namespace Week7Day3
{
    class UserManager
    {
        //STATIC LIST

        //public static UserListRepository ur = new UserListRepository();

        //ADO
        public static UserADORepository ur = new UserADORepository();

        internal static void ShowUsers()
        {
            List<User> users = ur.Fetch();

            foreach(var x in users)
            {
                Console.WriteLine(x.Print());
            }

        }

        internal static void UpdateUser()
        {
            User userChosen = ChooseUser();
            User user = UserData();
            user.Id = userChosen.Id;
            ur.Update(user);
        }

        internal static void DeleteUser()
        {
            User user = ChooseUser();
            ur.Delete(user);
        }

        private static User ChooseUser()
        {
            List<User> users = ur.Fetch();

            int i = 1;
            foreach (var x in users)
            {
                Console.WriteLine($"Premi {i} per {x.Print()}");
                i++;
            }

            bool isInt;
            int userChosen;
            do
            {
                Console.WriteLine("Quale utente vuoi eliminare/modificare?");

                isInt = int.TryParse(Console.ReadLine(), out userChosen);

            } while (!isInt || userChosen <= 0 || userChosen > users.Count);

            return users.ElementAt(userChosen - 1);
        }

        internal static void InsertUser()
        {
            User user = UserData();
            ur.Insert(user);
        }

        private static User UserData()
        {
            User user = new User();

            Console.WriteLine("Inserisci il nome :");
            user.Name = Console.ReadLine();

            Console.WriteLine("Inserisci il cognome :");
            user.Surname = Console.ReadLine();

            Console.WriteLine("Inserisci la data di nascita :");
            DateTime date = new DateTime();
            while (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.WriteLine("Riprova.");
            }
            user.BirthDate = date;

            Console.WriteLine("Inserisci il sesso, 0 maschio o 1 femmina :");
            int s = 0;
            while (!int.TryParse(Console.ReadLine(), out s) || s < 0 || s > 1)
            {
                Console.WriteLine("Scelta non valida! Riprova.");
            }
            user.Sex = (EnumSex)s;

            Console.WriteLine("Inserisci 'false' se non è registrato, 'true' se lo è :");
            bool r = true;
            while (!bool.TryParse(Console.ReadLine(), out r))
            {
                Console.WriteLine("Scelta non valida! Riprova.");
            }
            user.Registred = r;

            return user;
        }

        internal static void GetUserInfoByNameAndSurname(string name, string surname)
        {
            List<User> users = ur.Fetch();
            User user = users.Find(u => u.Name == name && u.Surname == surname);
            if (user == null)
            {
                Console.WriteLine($"Non esiste nessun utente che ha nome {name} e cognome {surname}");
            }
            else
            {
                Console.WriteLine("Ecco qui le info dell'utente che hai cercato : ");
                Console.WriteLine(user.Print());
            }
        }

        internal static void ShowRegistredUsers()
        {
            List<User> users = ur.Fetch();

            foreach (var x in users)
            {
                if(x.Registred == true)
                {
                    Console.WriteLine(x.Print());
                }
                
            }
        }
    }
}
