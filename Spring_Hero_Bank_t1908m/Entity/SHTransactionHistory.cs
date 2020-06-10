using System;

namespace Spring_Hero_Bank_t1908m.Entity
{
    public class SHTransactionHistory
    {
        public string TransactionCode { get; set; }
        public DateTime CreateAt { get; set; }
      
        public DateTime UpdateAt { get; set; }
        public string SenderAccountNumber { get; set; }
        public string ReceiverAccountNumber { get; set; }
        public SHTransactionType Type { get; set; }
        public double Amount { get; set; }
        public double Fee { get; set; }
        public string Message { get; set; }
        public SHTransactionStatus Status { get; set; }

    }

    public enum SHTransactionType
    {
        DEPOSIT = 1,
        WITHDRAW = 2,
        TRANSFER = 3
    }

    public enum SHTransactionStatus
    {
        DONE = 1,
        FAILS = 2,
        PROCESSING = 3
    }
}