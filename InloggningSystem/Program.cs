using InloggSystem;

namespace InloggningSystem
{
    internal class Program
    {
        // Definiera användarnamn och lösenord som statiska egenskaper
        public static string Username { get; private set; }
        public static string Password { get; private set; }

        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till inloggningssidan!");

            while (true)
            {
                Console.WriteLine("Välj en åtgärd:");
                Console.WriteLine("1. Sign in");
                Console.WriteLine("2. Log in");
                Console.WriteLine("3. Avsluta");
                Console.WriteLine("4. Uppdatera användare");
                Console.WriteLine("5. Ta bort användare");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Sign in");
                        Console.Write("Ange användarnamn: ");
                        string newUsername = Console.ReadLine();
                        Console.Write("Ange lösenord: ");
                        string newPassword = Console.ReadLine();
                        AddUser(newUsername, newPassword); // Skapa användare
                        break;

                    case "2":
                        Console.WriteLine("Log in");
                        Console.Write("Ange användarnamn: ");
                        string username = Console.ReadLine();
                        Console.Write("Ange lösenord: ");
                        string password = Console.ReadLine();
                        var user = GetUser(username);
                        if (user != null && user.Password == password)
                        {
                            Console.WriteLine("Du är inloggad!");
                        }
                        else
                        {
                            Console.WriteLine("Fel användarnamn eller lösenord.");
                        }
                        break;

                    case "4":
                        Console.WriteLine("Ange användarnamn att uppdatera:");
                        string currentUsername = Console.ReadLine();
                        Console.WriteLine("Ange nytt användarnamn:");
                        string updatedUsername = Console.ReadLine();
                        Console.WriteLine("Ange nytt lösenord:");
                        string updatedPassword = Console.ReadLine();
                        UpdateUser(currentUsername, updatedUsername, updatedPassword);
                        break;

                    case "5":
                        Console.WriteLine("Ange användarnamn att ta bort:");
                        string deleteUsername = Console.ReadLine();
                        RemoveUser(deleteUsername);
                        break;

                    case "3":
                        Console.WriteLine("Avslutar programmet...");
                        return;

                    default:
                        Console.WriteLine("Felaktigt val, försök igen.");
                        break;
                }
            }
        }

        // Skapa en ny användare
        static void AddUser(string username, string password)
        {
            using (var context = new UserContext())
            {
                var user = new User { Username = username, Password = password };
                context.Users.Add(user);
                context.SaveChanges();
                Console.WriteLine("Användaren har skapats.");
            }
        }

        // Uppdatera en användare
        static void UpdateUser(string currentUsername, string newUsername, string newPassword)
        {
            using (var context = new UserContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == currentUsername);
                if (user != null)
                {
                    user.Username = newUsername;
                    user.Password = newPassword;
                    context.SaveChanges();
                    Console.WriteLine("Användaren har uppdaterats.");
                }
                else
                {
                    Console.WriteLine("Användaren kunde inte hittas.");
                }
            }
        }

        // Ta bort en användare
        static void RemoveUser(string username)
        {
            using (var context = new UserContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == username);
                if (user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                    Console.WriteLine("Användaren har tagits bort.");
                }
                else
                {
                    Console.WriteLine("Användaren kunde inte hittas.");
                }
            }
        }

        // Hämta användare från databasen
        static User GetUser(string username)
        {
            using (var context = new UserContext())
            {
                return context.Users.FirstOrDefault(u => u.Username == username);
            }
        }
    }
}


