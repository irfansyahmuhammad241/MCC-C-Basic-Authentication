namespace MCC_C__Code_Create_User_Page
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<User> UserList { get; set; } = new List<User>();


        public void CreateUser()
        {
            Console.Clear();
            Console.WriteLine("Create User");
            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine();

            string username = GenerateUsername(firstName, lastName);

            // Check if the username already exists
            if (UserList.Exists(u => u.Username == username))
            {
                Console.WriteLine("Account Already Exist, Please Register With Another Name!");
                return;
            }

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            // Create a new user and add it to the list
            User newUser = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Username = username,
                Password = password
            };

            UserList.Add(newUser);

            Console.WriteLine("User created successfully!");
            Console.WriteLine("Press Any Button To Go Back to Menu");
            Console.ReadKey();

        }


        public string GenerateUsername(string firstName, string lastName)
        {
            string username = "";

            if (firstName.Length >= 2)
                username += firstName.Substring(0, 2);

            if (lastName.Length >= 2)
                username += lastName.Substring(0, 2);

            return username;
        }

        public void ListUser()
        {
            Console.Clear();
            Console.WriteLine("List of Users");

            if (UserList.Count == 0)
            {
                Console.WriteLine("No users found.");
            }
            else
            {
                foreach (var user in UserList)
                {
                    Console.WriteLine("========================");
                    Console.WriteLine($"ID: {UserList.IndexOf(user) + 1}\nName: {user.FirstName} {user.LastName}\nUsername: {user.Username}\nPassword: {user.Password}");
                    Console.WriteLine("========================");
                }
            }
            Console.WriteLine("Press Any Button To Go Back to Menu");
            Console.ReadKey();
        }

        public void SearchUser()
        {
            Console.Clear();
            Console.WriteLine("Search User");
            Console.Write("Enter username to search: ");
            string username = Console.ReadLine();

            // Find the user with the specified username
            User user = UserList.Find(u => u.Username == username);

            if (user == null)
            {
                Console.WriteLine("User not found.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"Name: {user.FirstName} {user.LastName}\nUsername: {user.Username} \nPassword: {user.Password}");
                Console.WriteLine();

                while (true)
                {
                    Console.WriteLine("1. Update User");
                    Console.WriteLine("2. Delete User");
                    Console.WriteLine("3. Back to Menu");

                    Console.Write("Please enter your choice: ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    switch (choice)
                    {
                        case 1:
                            UpdateUser(user);
                            return;
                        case 2:
                            DeleteUser(user);
                            return;
                        case 3:
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }

                    Console.WriteLine();
                }
            }
        }

        public void UpdateUser(User user)
        {
            Console.WriteLine("Update User");
            Console.Write("Enter new password: ");
            string newPassword = Console.ReadLine();

            user.Password = newPassword;
            Console.WriteLine("User updated successfully!");
            Console.WriteLine("Press Any Button To Go Back to Menu");
            Console.ReadKey();
        }

        public void DeleteUser(User user)
        {
            UserList.Remove(user);
            Console.WriteLine("User deleted successfully!");
            Console.WriteLine("Press Any Button To Go Back to Menu");
            Console.ReadKey();
        }

        public void LoginUser()
        {
            Console.Clear();
            Console.WriteLine("Login Page");
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            // Find the user with the specified username and password
            User user = UserList.Find(u => u.Username == username && u.Password == password);

            if (user == null)
            {
                Console.WriteLine("Invalid username or password.");
                Console.WriteLine("Press Any Button To Go Back to Menu");
                Console.ReadKey();
            }
            else
            {

                Console.WriteLine("Login successful!");
                Console.WriteLine($"Selamat Datang {user.FirstName} {user.LastName}");
                Console.WriteLine("Press Any Button To Go Back to Menu");
                Console.ReadKey();

            }

        }
    }
}


