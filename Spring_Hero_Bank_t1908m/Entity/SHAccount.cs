using System;

namespace Spring_Hero_Bank_t1908m.Entity
{
    public class SHAccount
    {
        public string AccountNumber { get; set; }
        public int Role { get; set; } // 1. User | 2. Admin
        public int IdentityNumber { get; set; }
        public double Balance { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        
        
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public SHAccountStatus Status { get; set; }
        
    }

    public enum SHAccountStatus
    {
        ACTIVE = 1,
        DEACTIVE = 0,
        LOCK = 2
    }
}