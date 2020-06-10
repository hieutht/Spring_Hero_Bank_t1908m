using System;
using System.Text;
using MySql.Data.MySqlClient;
using Spring_Hero_Bank_t1908m.Entity;
using Spring_Hero_Bank_t1908m.Helper;
namespace Spring_Hero_Bank_t1908m.Model
{
    public class TransactionModel
    {
       private static string WithDrawMessage = "Withdra at Sping Helo ATM - 8 Ton That Thuyet";
        private static string DepositMessage = "Deposit at Spring Hero Transaction Station";
        public bool WithDraw(string accountNumber, int amount)
        {
            bool result = false;
            var cnn = ConnectionHelper.GetConnection();
            cnn.Open();
            var mySqlTransaction = cnn.BeginTransaction();
            MySqlDataReader readerGetBalance;
            try
            {
                var cmdGetBalance =
                    new MySqlCommand(
                        $"select balance from shaccount where accountNumber = '{accountNumber}' and status ='{(int)SHAccountStatus.ACTIVE}'",
                        cnn);
               readerGetBalance = cmdGetBalance.ExecuteReader();
                if (!readerGetBalance.Read())
                {
                    readerGetBalance.Close();
                    throw new Exception("Account is not found or has been locked!");
                    
                }

                var balance = readerGetBalance.GetDouble("balance");
                readerGetBalance.Close();

                var updateBalance = balance - amount;
                if (updateBalance <= 50000)
                {
                    throw new Exception("Account is not enough money!");
                    
                }
                var cmdUpdateBalance =
                    new MySqlCommand(
                        $"update shaccount set balance = {updateBalance} where accountNumber = '{accountNumber}'",
                        cnn);
                // 2.2 Thực thi câu lệnh update.
                cmdUpdateBalance.ExecuteNonQuery();
                // 3. lưu transaction.
                // 3.1 Tạo đối tượng transaction.
                var transactionHistory = new SHTransactionHistory()
                {
                    TransactionCode = Guid.NewGuid().ToString(), // code được sinh ra unique
                    CreateAt = DateTime.Now, // Thời gian hiện tại.
                    UpdateAt = DateTime.Now,
                    Type = SHTransactionType.WITHDRAW,
                    Amount = amount,
                    Fee = 0,
                    Message = WithDrawMessage,
                    Status = SHTransactionStatus.DONE
                };
                 StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append($"insert into shtransactionhistory ");
                stringBuilder.Append(
                    $"(TransactionCode , createdByAccountNumber, CreateAt, UpdateAt, SenderAccountNumber, ReceiverAccountNumber, Type, Amount, Fee, Message, Status) ");
                stringBuilder.Append("values");
                stringBuilder.Append(" (");
                stringBuilder.Append($"'{transactionHistory.TransactionCode}',");
                stringBuilder.Append($"'{accountNumber}',");
                // Thời gian khi insert phải format theo yyyy-MM-dd hh:mm:ss
                stringBuilder.Append($"'{transactionHistory.CreateAt:yyyy-MM-dd hh:mm:ss}',");
                stringBuilder.Append($"'{transactionHistory.UpdateAt:yyyy-MM-dd hh:mm:ss}',");
                stringBuilder.Append($"'{null}',");
                stringBuilder.Append($"'{null}',");
                stringBuilder.Append($"{(int)transactionHistory.Type},");
                stringBuilder.Append($"{(double)transactionHistory.Amount},");
                stringBuilder.Append($"{(double)transactionHistory.Fee},");
                stringBuilder.Append($"'{transactionHistory.Message}',");
                stringBuilder.Append($"{(int)transactionHistory.Status}");
                stringBuilder.Append(" )");
                var cmdInsertTransaction = new MySqlCommand(stringBuilder.ToString(), cnn);
                // Thực thi câu lệnh, lưu transaction.
                cmdInsertTransaction.ExecuteNonQuery();
                // kết thúc transaction ở trạng thái thành công, đảm bảo tất cả các câu lệnh được thực thi.
                // update thông tin vào database.
                mySqlTransaction.Commit();
                result = true; // set kết quả = true.
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                mySqlTransaction.Rollback(); // đưa tất cả về xuất phát điểm bản đầu.
                result = false;
            }
            cnn.Close();
            return result;
        }
        
         public bool Deposit(string accNumber, int amount)
        {
            bool result = false;
            var cnn = ConnectionHelper.GetConnection();
            cnn.Open();
            var transaction = cnn.BeginTransaction();
            try
            {
                var cmdGetBalance =
                    new MySqlCommand(
                        $"select balance from shaccount where accountNumber = '{accNumber}' and status = {(int) SHAccountStatus.ACTIVE}",
                        cnn);
                var reader = cmdGetBalance.ExecuteReader();
                if (!reader.Read())
                {
                    reader.Close();
                    throw new Exception("Account is not found or has been looked!");
                }
                var balance = reader.GetDouble("balance");
                reader.Close();

                var updateBalance = balance + amount;
                var cmdUpdate =
                    new MySqlCommand($"UPDATE shaccount SET balance = {updateBalance} where accountNumber = '{accNumber}'",
                        cnn);
                cmdUpdate.ExecuteNonQuery();

                SHTransactionHistory transactionHistory = new SHTransactionHistory()
                {
                    TransactionCode = Guid.NewGuid().ToString(), //code được sinh ra unique
                    CreateAt = DateTime.Now, //thời gian hiện tại.
                    UpdateAt = DateTime.Now,
                    SenderAccountNumber = "",
                    ReceiverAccountNumber = accNumber,
                    Type = SHTransactionType.DEPOSIT,
                    Amount = amount,
                    Fee = 0,
                    Message = DepositMessage,
                    Status = SHTransactionStatus.DONE
                };

                //thực thi câu lệnh transaction
                var cmdInsertTransaction = new MySqlCommand($"insert into shtransactionhistory (TransactionCode, CreateAt, UpdateAt, SenderAccountNumber, ReceiverAccountNumber, Type, Amount, Fee, Message, Status) " +
                                                            $"values ('{transactionHistory.TransactionCode}', '{transactionHistory.CreateAt:yyyy-MM-dd hh:hh:mm:ss}', '{transactionHistory.UpdateAt:yyyy-MM-dd hh:hh:mm:ss}', '{transactionHistory.SenderAccountNumber}','{transactionHistory.ReceiverAccountNumber}', {(int)transactionHistory.Type}, {transactionHistory.Amount}, {transactionHistory.Fee}, '{transactionHistory.Message}', {(int) transactionHistory.Status})",
                    cnn);
                cmdInsertTransaction.ExecuteNonQuery();
                //kết thúc transaction ở trạng thái thành công , đảm bảo thất cả các câu lệnh được thực thi.
                // update thông tin vào database thành công.
                transaction.Commit();
                result = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                transaction.Rollback();
                result = false;
            }
            cnn.Close();
            return result;
        }

         public bool Transfer(string username, int amount)
         {
             bool result = false;
             var cnn = ConnectionHelper.GetConnection();
             cnn.Open();
             var transaction = cnn.BeginTransaction();
             try
             {

             }
             catch (Exception e)
             {
                 Console.WriteLine(e);
                 transaction.Rollback();
                 result = false;
             }
             cnn.Close();
             return true;
         }
         

    }
    
}