using System;
using System.Collections.Generic;
using Spring_Hero_Bank_t1908m.Entity;
using Spring_Hero_Bank_t1908m.Model;

namespace Spring_Hero_Bank_t1908m.Helper
{
    public class SeedingHelper
    {
        AccountModel _model = new AccountModel();

        public void SeedAcount()
        {
            List<SHAccount> accounts = new List<SHAccount>();
            var salt = SaltHelper.GenerateSalt();
            var account = new SHAccount()
            {
                AccountNumber = Guid.NewGuid().ToString(),
                UserName = "hacongmanh1",
                Salt = salt,
                Email = "manh5@gmail.com",
                FirstName = "Ninh",
                LastName = "Tuan",
                Balance = 150000,
                Role = 1,
                PasswordHash = SaltHelper.EncrypString("quenmatakhau", salt),
                Status = SHAccountStatus.ACTIVE
            };
            accounts.Add(account);
            salt = SaltHelper.GenerateSalt();
            account = new SHAccount()
            {
                AccountNumber = Guid.NewGuid().ToString(),
                UserName = "nguyen231",
                Salt = salt,
                Email = "manh6@gmail.com",
                FirstName = "Hai",
                LastName = "Tuan",
                Balance = 1350000,
                Role = 2,
                PasswordHash = SaltHelper.EncrypString("123@123@qwe", salt),
                Status = SHAccountStatus.ACTIVE
            };
            accounts.Add(account);
            salt = SaltHelper.GenerateSalt();
            account = new SHAccount()
            {
                AccountNumber = Guid.NewGuid().ToString(),
                UserName = "langioxanh",
                Salt = salt,
                Email = "manh2@gmail.com",
                FirstName = "Nguyen",
                LastName = "Hoang",
                Balance = 1250000,
                Role = 1,
                PasswordHash = SaltHelper.EncrypString("nguyesfqw", salt),
                Status = SHAccountStatus.ACTIVE
            };
            accounts.Add(account);
            salt = SaltHelper.GenerateSalt();
            account = new SHAccount()
            {
                AccountNumber = Guid.NewGuid().ToString(),
                UserName = "hacongmanh2",
                Salt = salt,
                Email = "manh3@gmail.com",
                FirstName = "Ta",
                LastName = "Trang",
                Balance = 1950000,
                Role = 1,
                PasswordHash = SaltHelper.EncrypString("quentenem", salt),
                Status = SHAccountStatus.ACTIVE
            };
            accounts.Add(account);
            salt = SaltHelper.GenerateSalt();
            account = new SHAccount()
            {
                AccountNumber = Guid.NewGuid().ToString(),
                UserName = "hacongmanh3",
                Salt = salt,
                Email = "manh4@gmail.com",
                FirstName = "Thuy",
                LastName = "Linh",
                Balance = 1850000,
                Role = 1,
                PasswordHash = SaltHelper.EncrypString("nfasdaf", salt),
                Status = SHAccountStatus.ACTIVE
            };
            accounts.Add(account);
            salt = SaltHelper.GenerateSalt();
            account = new SHAccount()
            {
                AccountNumber = Guid.NewGuid().ToString(),
                UserName = "hacongmanh4",
                Salt = salt,
                Email = "manh7@gmail.com",
                FirstName = "Quynh",
                LastName = "Chi",
                Balance = 1750000,
                Role = 1,
                PasswordHash = SaltHelper.EncrypString("nguyesfqw", salt),
                Status = SHAccountStatus.ACTIVE
            };
            accounts.Add(account);
            salt = SaltHelper.GenerateSalt();
            account = new SHAccount()
            {
                AccountNumber = Guid.NewGuid().ToString(),
                UserName = "hacongmanh5",
                Salt = salt,
                Email = "manh8@gmail.com",
                FirstName = "Thuy",
                LastName = "Duong",
                Balance = 1650000,
                Role = 1,
                PasswordHash = SaltHelper.EncrypString("asqwreqrq123", salt),
                Status = SHAccountStatus.ACTIVE
            };
            accounts.Add(account);
            salt = SaltHelper.GenerateSalt();
            account = new SHAccount()
            {
                AccountNumber = Guid.NewGuid().ToString(),
                UserName = "hacongmanh6",
                Salt = salt,
                Email = "manh9@gmail.com",
                FirstName = "Tien",
                LastName = "Dat",
                Balance = 1550000,
                Role = 1,
                PasswordHash = SaltHelper.EncrypString("sfsadasg", salt),
                Status = SHAccountStatus.ACTIVE
            };
            accounts.Add(account);
            salt = SaltHelper.GenerateSalt();
            account = new SHAccount()
            {
                AccountNumber = Guid.NewGuid().ToString(),
                UserName = "hacongmanh7",
                Salt = salt,
                Email = "manh10@gmail.com",
                FirstName = "Dinh",
                LastName = "Nhan",
                Balance = 1450000,
                Role = 1,
                PasswordHash = SaltHelper.EncrypString("nguyesfqw", salt),
                Status = SHAccountStatus.ACTIVE
            };
            accounts.Add(account);
            salt = SaltHelper.GenerateSalt();
            account = new SHAccount()
            {
                AccountNumber = Guid.NewGuid().ToString(),
                UserName = "hacongmanh8",
                Salt = salt,
                Email = "manh11@gmail.com",
                FirstName = "Dong",
                LastName = "Hieu",
                Balance = 1350000,
                Role = 1,
                PasswordHash = SaltHelper.EncrypString("asdastw", salt),
                Status = SHAccountStatus.ACTIVE
            };
            accounts.Add(account);
            salt = SaltHelper.GenerateSalt();
            account = new SHAccount()
            {
                AccountNumber = Guid.NewGuid().ToString(),
                UserName = "hacongmanh9",
                Salt = salt,
                Email = "manh12@gmail.com",
                FirstName = "Nguyen",
                LastName = "Trang",
                Balance = 1250000,
                Role = 1,
                PasswordHash = SaltHelper.EncrypString("minhminh1232", salt),
                Status = SHAccountStatus.ACTIVE
            };
            accounts.Add(account);
            salt = SaltHelper.GenerateSalt();
            account = new SHAccount()
            {
                AccountNumber = Guid.NewGuid().ToString(),
                UserName = "langioxanh23",
                Salt = salt,
                Email = "manh13@gmail.com",
                FirstName = "Ta",
                LastName = "Hanh",
                Balance = 1150000,
                Role = 1,
                PasswordHash = SaltHelper.EncrypString("EncrypString", salt),
                Status = SHAccountStatus.ACTIVE
            };
            accounts.Add(account);
            salt = SaltHelper.GenerateSalt();
            account = new SHAccount()
            {
                AccountNumber = Guid.NewGuid().ToString(),
                UserName = "langioxanh66",
                Salt = salt,
                Email = "manh15@gmail.com",
                FirstName = "Thu",
                LastName = "Linh",
                Balance = 950000,
                Role = 1,
                PasswordHash = SaltHelper.EncrypString("SaltHelper", salt),
                Status = SHAccountStatus.ACTIVE
            };
            accounts.Add(account);
            salt = SaltHelper.GenerateSalt();
            account = new SHAccount()
            {
                AccountNumber = Guid.NewGuid().ToString(),
                UserName = "langioxanh55",
                Salt = salt,
                Email = "manh17@gmail.com",
                FirstName = "Cong",
                LastName = "Manh",
                Balance = 850000,
                Role = 1,
                PasswordHash = SaltHelper.EncrypString("account", salt),
                Status = SHAccountStatus.ACTIVE
            };
            accounts.Add(account);
            salt = SaltHelper.GenerateSalt();
            account = new SHAccount()
            {
                AccountNumber = Guid.NewGuid().ToString(),
                UserName = "langioxanh33",
                Salt = salt,
                Email = "manh241@gmail.com",
                FirstName = "Hoa",
                LastName = "Hong",
                Balance = 750000,
                Role = 1,
                PasswordHash = SaltHelper.EncrypString("AccountNumber", salt),
                Status = SHAccountStatus.ACTIVE
            };
            accounts.Add(account);
            salt = SaltHelper.GenerateSalt();
            account = new SHAccount()
            {
                AccountNumber = Guid.NewGuid().ToString(),
                UserName = "langioxanh22",
                Salt = salt,
                Email = "manh231@gmail.com",
                FirstName = "Hoa",
                LastName = "Minh",
                Balance = 650000,
                Role = 1,
                PasswordHash = SaltHelper.EncrypString("Status", salt),
                Status = SHAccountStatus.ACTIVE
            };
            accounts.Add(account);
            salt = SaltHelper.GenerateSalt();
            account = new SHAccount()
            {
                AccountNumber = Guid.NewGuid().ToString(),
                UserName = "langioxanh11",
                Salt = salt,
                Email = "manh221@gmail.com",
                FirstName = "Thi",
                LastName = "Tam",
                Balance = 550000,
                Role = 1,
                PasswordHash = SaltHelper.EncrypString("PasswordHash", salt),
                Status = SHAccountStatus.ACTIVE
            };
            accounts.Add(account);
            salt = SaltHelper.GenerateSalt();
            account = new SHAccount()
            {
                AccountNumber = Guid.NewGuid().ToString(),
                UserName = "langioxanh8",
                Salt = salt,
                Email = "manh221@gmail.com",
                FirstName = "Hai",
                LastName = "Minh",
                Balance = 450000,
                Role = 1,
                PasswordHash = SaltHelper.EncrypString("UserName", salt),
                Status = SHAccountStatus.ACTIVE
            };
            accounts.Add(account);
            salt = SaltHelper.GenerateSalt();
            account = new SHAccount()
            {
                AccountNumber = Guid.NewGuid().ToString(),
                UserName = "langioxanh7",
                Salt = salt,
                Email = "manh21@gmail.com",
                FirstName = "Tha",
                LastName = "Thu",
                Balance = 350000,
                Role = 1,
                PasswordHash = SaltHelper.EncrypString("NewGuid", salt),
                Status = SHAccountStatus.ACTIVE
            };
            accounts.Add(account);
            salt = SaltHelper.GenerateSalt();
            account = new SHAccount()
            {
                AccountNumber = Guid.NewGuid().ToString(),
                UserName = "langioxanh6",
                Salt = salt,
                Email = "manh20@gmail.com",
                FirstName = "Xuan",
                LastName = "Hung",
                Balance = 250000,
                Role = 1,
                PasswordHash = SaltHelper.EncrypString("adanfadaf", salt),
                Status = SHAccountStatus.ACTIVE
            };
            accounts.Add(account);
            salt = SaltHelper.GenerateSalt();
            account = new SHAccount()
            {
                AccountNumber = Guid.NewGuid().ToString(),
                UserName = "langioxanh3",
                Salt = salt,
                Email = "manh1@gmail.com",
                FirstName = "Minh",
                LastName = "Trang",
                Balance = 150000,
                Role = 1,
                PasswordHash = SaltHelper.EncrypString("nguyesfqw", salt),
                Status = SHAccountStatus.ACTIVE
            };

            accounts.Add(account);
            _model.Save(accounts);
        }
    }
}