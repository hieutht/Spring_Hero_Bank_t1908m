using System;
using Spring_Hero_Bank_t1908m.Controller;
using Spring_Hero_Bank_t1908m.Entity;
using Spring_Hero_Bank_t1908m.Helper;
using Spring_Hero_Bank_t1908m.Model;

namespace Spring_Hero_Bank_t1908m.View
{
    public class MenuControl
    {
        private readonly AccountController _accountController = new AccountController();

        // Lưu trữ thông tin người dùng đang login vào hệ thống.
        // Trường hợp chưa login thì biến này bằng null
        public static SHAccount CurrentUser;

        PasswordHelper _passwordHelper = new PasswordHelper();

        public void GenerateMainMenu()
        {
            try
            {
                while (CurrentUser == null)
                {
                    Console.WriteLine("------ SPRING HERO BANK ------");
                    Console.WriteLine("|      1.Register Account     ");
                    Console.WriteLine("|      2.Login                ");
                    Console.WriteLine("|      3.Exit                 ");
                    Console.WriteLine("|---------------------------- ");
                    Console.Write("ENTER CHOICE (1-3) = ");
                    var choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            _accountController.Register();
                            break;
                        case 2:
                            CurrentUser = _accountController.Login();
                            if (CurrentUser == null)
                            {
                                Console.WriteLine("Login fails! Please try again!");
                            }

                            break;
                        case 3:
                            Console.WriteLine("GoodBye!!");
                            Environment.Exit(3);
                            break;
                    }
                }

                switch (CurrentUser.Role)
                {
                    case 0:
                        GenerateUserMenu();
                        break;
                    case 1:
                        GenerateAdminMenu();
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Application error, please try again!");
                throw;
            }
        }

        public void GenerateUserMenu()
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("---------Account Manage----------");
                    Console.WriteLine("|        1.Edit account         |");
                    Console.WriteLine("|        2.Deposit              |");
                    Console.WriteLine("|        3.Withdraw             |");
                    Console.WriteLine("|        4.Transfer             |");
                    Console.WriteLine("|        5.Log out              |");
                    Console.WriteLine("|        6.Exist                |");
                    Console.WriteLine("---------------------------------");
                    Console.Write("Enter");
                    Console.Write("ENTER CHOICE (1-6) = ");
                    var choice = int.Parse(s: Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            _accountController.EditAccount();
                            break;
                        case 2:
                            _accountController.Deposit();
                            break;
                        case 3:
                            _accountController.Withdraw();
                            break;
                        case 4:
                            _accountController.Transfer();
                            break;
                        case 5:
                            CurrentUser = _accountController.Login();
                            if (CurrentUser == null)
                            {
                                Console.WriteLine("Login fails! Please try again!");
                            }

                            break;
                        case 6:
                            Console.WriteLine(value: "GoodBye!!");
                            Environment.Exit(exitCode: 3);
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(value: e);
                throw;
            }
        }


        public void GenerateAdminMenu()
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("--------------------------Account Manage---------------------");
                    Console.WriteLine("|        1.List of users.                                   |");
                    Console.WriteLine("|        2. List of transaction history.                    |");
                    Console.WriteLine("|        3. Search users by name.                           |");
                    Console.WriteLine("|        4. Search users by account number.                 |");
                    Console.WriteLine("|        5. Search users by phone number.                   |");
                    Console.WriteLine("|        6. Add new users.                                  |");
                    Console.WriteLine("|        7. Block user accounts.                            |");
                    Console.WriteLine("|        8. Search transaction history by account number.   |");
                    Console.WriteLine("|        9. Change account information.                     |");
                    Console.WriteLine("|        10.Exist                                           |");
                    Console.WriteLine("-------------------------------------------------------------");
                    Console.Write("Enter");
                    Console.Write("ENTER CHOICE (1-10) = ");
                    var choice = int.Parse(s: Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            _accountController.EditAccount();
                            break;
                        case 2:
                            _accountController.Deposit();
                            break;
                        case 3:
                            _accountController.Withdraw();
                            break;
                        case 4:
                            _accountController.Transfer();
                            break;
                        case 5:
                            CurrentUser = _accountController.Login();
                            if (CurrentUser == null)
                            {
                                Console.WriteLine("Login fails! Please try again!");
                            }

                            break;
                        case 6:
                            Console.WriteLine(value: "GoodBye!!");
                            Environment.Exit(exitCode: 3);
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(value: e);
                throw;
            }
        }
    }
}