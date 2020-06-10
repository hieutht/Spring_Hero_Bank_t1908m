using System;
using Spring_Hero_Bank_t1908m.Entity;
using Spring_Hero_Bank_t1908m.Model;
namespace Spring_Hero_Bank_t1908m.Helper
{
    public class PasswordHelper
    {
        AccountModel _accountModel = new AccountModel();
        

        public bool CheckLogin(string userName, string password)
        {
            var existingAccount = _accountModel.GetByUsername(userName);
            return existingAccount != null && existingAccount.Status == SHAccountStatus.ACTIVE
                                           && SaltHelper.ComparePassword(password, existingAccount.PasswordHash,
                                               existingAccount.Salt);
        }
    }
}