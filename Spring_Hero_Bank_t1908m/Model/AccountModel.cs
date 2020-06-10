using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using MySql.Data.MySqlClient;
using Spring_Hero_Bank_t1908m.Entity;
using Spring_Hero_Bank_t1908m.Helper;
namespace Spring_Hero_Bank_t1908m.Model
{
    public class AccountModel
    {
         public bool Save(SHAccount shAccount)
        {
            try
            {
                var cnn = ConnectionHelper.GetConnection();
                cnn.Open();
                var stringBuilder = new StringBuilder();
                stringBuilder.Append("INSERT INTO shaccount ");
                stringBuilder.Append("(accountNumber, Role, identityNumber, balance, username, PasswordHash, phone, address, createdAt, updateAt, FirstName, LastName, email, salt, status) ");
                stringBuilder.Append("VALUES ");
                stringBuilder.Append($"('{shAccount.AccountNumber}', {shAccount.Role},'{shAccount.IdentityNumber}',{shAccount.Balance},'{shAccount.UserName}', '{shAccount.PasswordHash}','{shAccount.Phone}','{shAccount.Address}','{shAccount.CreatedAt.ToString("yyyy-MM-dd")}','{shAccount.UpdateAt.ToString("yyyy-MM-dd")}', '{shAccount.FirstName}', '{shAccount.LastName}', '{shAccount.Email}', '{shAccount.Salt}', {(int) shAccount.Status}),");
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
                var cmd = new MySqlCommand(stringBuilder.ToString(), cnn);
                cmd.ExecuteNonQuery();
                cnn.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }
            

        public SHAccount GetByUsername(string username)
        {
            SHAccount result = null;
            var cnn = ConnectionHelper.GetConnection();
            cnn.Open();
            var cmd = new MySqlCommand(
                $"SELECT * FROM shaccount where username = '{username}'",
                cnn);
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                result = new SHAccount()
                {
                    AccountNumber = reader.GetString("AccountNumber"),
                    IdentityNumber = reader.GetInt32("IdentityNumber"),
                    Balance = reader.GetInt32("Balance"),
                    UserName = reader.GetString("Username"),
                    PasswordHash = reader.GetString("PasswordHash"),
                    FirstName = reader.GetString("FirstName"),
                    LastName = reader.GetString("LastName"),
                    Phone = reader.GetInt32("Phone"),
                    Address = reader.GetString("Address"),
                    Email = reader.GetString("Email"),
                    Salt = reader.GetString("Salt"),
                    CreatedAt = reader.GetDateTime("CreatedAt"),
                    UpdateAt = reader.GetDateTime("UpdateAt"),
                    Status = (SHAccountStatus) reader.GetInt32("Status")
                };
            }

            cnn.Close();
            return result;
        }


        public AccountCount GetCount()
        {
            AccountCount count = null;
            try
            {
                var cnn = ConnectionHelper.GetConnection();
                cnn.Open();
                var cmd = new MySqlCommand($"select count from acc_count where id = 1 ", cnn);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    count = new AccountCount()
                    {
                        Count = reader.GetInt32("count")
                    };
                }

                cnn.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return count;
        }

        public void Save(List<SHAccount> shAccounts)
        {
            var cnn = ConnectionHelper.GetConnection();
            cnn.Open();
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("INSERT INTO shaccount ");
            stringBuilder.Append("(accountNumber, Role, identityNumber, balance, username, PasswordHash, phone, address, createdAt, updateAt, FirstName, LastName, email, salt, status) ");
            stringBuilder.Append("VALUES ");
            foreach (var shAccount in shAccounts)
            {
                stringBuilder.Append($"('{shAccount.AccountNumber}', {shAccount.Role},'{shAccount.IdentityNumber}',{shAccount.Balance},'{shAccount.UserName}', '{shAccount.PasswordHash}','{shAccount.Phone}','{shAccount.Address}','{shAccount.CreatedAt.ToString("yyyy-MM-dd")}','{shAccount.UpdateAt.ToString("yyyy-MM-dd")}', '{shAccount.FirstName}', '{shAccount.LastName}', '{shAccount.Email}', '{shAccount.Salt}', {(int) shAccount.Status}),");
            }
            stringBuilder.Remove(stringBuilder.Length - 1, 1);
            var cmd = new MySqlCommand(stringBuilder.ToString(), cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}