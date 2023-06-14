namespace MCC_C__Code_Create_User_Page
{

    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        public static void Menu()
        {
            User user = new User();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Program!");
                Console.WriteLine("Please Make Your Account First!");
                Console.WriteLine("1. Create User");
                Console.WriteLine("2. List Users");
                Console.WriteLine("3. Search User");
                Console.WriteLine("4. Login User");
                Console.WriteLine("5. Exit");

                Console.Write("Please enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();


                switch (choice)
                {
                    case 1:
                        user.CreateUser();
                        break;
                    case 2:
                        user.ListUser();
                        break;
                    case 3:
                        user.SearchUser();
                        break;
                    case 4:
                        user.LoginUser();
                        break;
                    case 5:
                        Console.WriteLine("Exiting the program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }


    }
}
