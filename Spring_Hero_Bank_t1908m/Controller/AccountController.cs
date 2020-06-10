using System;
using Spring_Hero_Bank_t1908m.Entity;
using Spring_Hero_Bank_t1908m.Helper;
using Spring_Hero_Bank_t1908m.Model;
using Spring_Hero_Bank_t1908m.View;

namespace Spring_Hero_Bank_t1908m.Controller
{
    public class AccountController
    {
        private readonly AccountModel _model = new AccountModel();
        private readonly TransactionModel _transactionModel = new TransactionModel();

        public void Register()
        {
            var shAccount = new SHAccount();
            shAccount.AccountNumber = Guid.NewGuid().ToString();
            Console.WriteLine("Please enter your username: ");
            shAccount.UserName = Console.ReadLine();
            Console.WriteLine("Please enter your password: ");
            var password = Console.ReadLine();
            Console.WriteLine("Please enter your first name: ");
            shAccount.FirstName = Console.ReadLine();
            Console.WriteLine("Please enter your last name:");
            shAccount.LastName = Console.ReadLine();
            Console.WriteLine("Please enter your email: ");
            shAccount.Email = Console.ReadLine();
            // validate user data.
            var salt = SaltHelper.GenerateSalt();
            var encryptPassword = SaltHelper.EncrypString(password, salt);
            shAccount.Status = SHAccountStatus.ACTIVE;
            shAccount.PasswordHash = encryptPassword;
            shAccount.Salt = salt;
            if (_model.Save(shAccount))
            {
                Console.WriteLine("Create account success!");
            }
            else
            {
                Console.WriteLine("Can't create account! Please try again!");
            }
        }

        public SHAccount Login()
        {
            Console.WriteLine("Please enter your username: ");
            var username = Console.ReadLine();
            Console.WriteLine("Please enter your password: ");
            var password = Console.ReadLine();
            var existingAccount = _model.GetByUsername(username);
            if (existingAccount != null && existingAccount.Status == SHAccountStatus.ACTIVE
                                        && SaltHelper.ComparePassword(password, existingAccount.PasswordHash,
                                            existingAccount.Salt))
            {
                Console.WriteLine($"Login Success! Welcome back {existingAccount.FirstName} {existingAccount.LastName}");
                return existingAccount;
            }
            return null;
        }

        // Yêu cầu ng dùng (đã đăng nhập) nhập số tiền cần rút và gọi đến model lưu db.
        public void Withdraw()
        {
            Console.WriteLine("----------Spring Hero Bank--------");
            Console.WriteLine("-----------Withdraw money----------");
            Console.WriteLine("Please enter amount to withdraw: ");
            var amount = int.Parse(Console.ReadLine());
            if (_transactionModel.WithDraw(MenuControl.CurrentUser.AccountNumber, amount))
            {
                Console.WriteLine("Withdraw success!");
            }
            else
            {
                Console.WriteLine("Withdraw fails, please try again!");
            }
        }

        public void Deposit()
        {
            Console.WriteLine("----------Spring Hero Bank--------");
            Console.WriteLine("-----------Deposit money----------");
            Console.WriteLine("Please enter amount to deposit: ");
            var amount = int.Parse(Console.ReadLine());
            if (_transactionModel.Deposit(MenuControl.CurrentUser.AccountNumber, amount))
            {
                Console.WriteLine("Deposit success!");
            }
            else
            {
                Console.WriteLine("Deposit fails, please try again!");
            }
        }
        
        public void Transfer(){
            
            Console.WriteLine("----------Spring Hero Bank--------");
            Console.WriteLine("-----------Transfer money----------");
            Console.WriteLine("Please enter amount to transfer : ");
            Console.WriteLine("Please enter Enter the account to transfer money : ");
            var username = Console.ReadLine();
            var amount = int.Parse(Console.ReadLine());
            if (_transactionModel.Transfer(MenuControl.CurrentUser.AccountNumber ,amount))
            {
                Console.WriteLine("Transfer success!");
            }
            else
            {
                Console.WriteLine("Transfer fails, please try again!");
            }
          
        }

        public void EditAccount()
        {
            throw new NotImplementedException();
        }
    }
}