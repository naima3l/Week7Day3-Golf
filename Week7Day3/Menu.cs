using System;

namespace Week7Day3
{
    internal class Menu
    {
        // Torneo di golf
        // Scrivere un programma che gestisca l'iscrizione a un torneo di golf.



        // Al momento dell'iscrizione un utente deve fornire i seguenti dati:
        // - Nome
        // - Cognome
        // - Data di nascita
        // - Sesso(Maschio o femmina)
        // - Se è o no tesserato



        // Il programma permette di:
        // - visualizzare tutti gli iscritti
        // - modificare i dati di un iscritto
        // - eliminare un iscritto
        // - inserire un nuovo iscritto
        // - avere le informazioni di un iscritto dato nome e cognome
        // - fitrare gli iscritti tesserati



        // Note:

        // - rispettare la corretta struttura(Ogni classe e ogni metodo hanno uno e un solo scopo)
        // - creare un repository fittizio(quindi anche le interfacce)
        // - salvare i dati su sql server tramite ado
        internal static void Start()
        {
            bool check = true;
            int choice;
            do
            {
                Console.WriteLine("BENVENUTO! \nPremi 1 per vedere tutti gli iscritti \nPremi 2 per modificare i dati di un iscritto \nPremi 3 per eliminare un iscritto \nPremi 4 per inserire un nuovo iscritto \nPremi 5 per avere le informazioni di un iscritto dato nome e cognome \nPremi 6 per fitrare gli iscritti tesserati \nPremi 0 per uscire");

                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 6)
                {
                    Console.WriteLine("Scelta non valida! Riprova.");
                }

                switch (choice)
                {
                    case 1:
                        UserManager.ShowUsers();
                        break;
                    case 2:
                        UserManager.UpdateUser();
                        break;
                    case 3:
                        UserManager.DeleteUser();
                        break;
                    case 4:
                        UserManager.InsertUser();
                        break;
                    case 5:
                        GetUserInfoByNameAndSurname(); 
                        break;
                    case 6:
                        UserManager.ShowRegistredUsers(); ;
                        break;
                    case 0:
                        Console.WriteLine("Ciao ciao!");
                        check = false;
                        break;
                }
            } while (check);
        }

        private static void GetUserInfoByNameAndSurname()
        {
            Console.WriteLine("Inserisci il nome dell'utente di cui vuoi le info");
            string name = Console.ReadLine();

            Console.WriteLine("Inserisci il cognome dell'utente di cui vuoi le info");
            string surname = Console.ReadLine();

            UserManager.GetUserInfoByNameAndSurname(name, surname);
        }
    }
}