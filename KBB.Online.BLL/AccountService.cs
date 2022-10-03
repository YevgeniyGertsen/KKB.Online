using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBB.Online.BLL
{
    public class AccountService
    {
        public delegate void NotificationHandler
           (string message, bool result, string accountIBAN);

        NotificationHandler del;

        public delegate void NotificationExHandler(Exception ex, int userId);

        NotificationExHandler delEx;

        public void RegisterNotificationHandler(NotificationHandler del)
        {
            this.del = del;
        }

        public void RegisterNotificationHandler(NotificationExHandler delEx)
        {
            this.delEx = delEx;
        }


        public string Path { get; set; }

        public AccountService(string Path)
        {
            this.Path = Path;
        }

       

        public ResultMessage CreateAccount(int userId)
        {
            ResultMessage result = new ResultMessage();
            
            try
            {
                Account account = new Account();
                account.UserId = userId;
                account.Balance = 0;
                account.CreationDate = DateTime.Now;
                account.Currency = 1;
                account.IBAN = GenerateIBAN();

                using (var db = new LiteDatabase(Path))
                {
                    var accounts = db.GetCollection<Account>("Account");

                    accounts.Insert(account);
                    result.IBAN = account.IBAN;
                }
            }
            catch (Exception ex)
            {
                if (delEx != null)
                    delEx.Invoke(ex, userId);

                result.Result = false;
                result.Message = "При создании счета возникла ошибка: " + ex.Message;
            }

            if (del != null)
                del.Invoke(result.Message, result.Result, result.IBAN);

            return result;
        }

        private string GenerateIBAN()
        {
            string account = "KZ";
            Random rnd = new Random();

            for (int i = 0; i < 20; i++)
            {
                account = account + rnd.Next(0, 9);
            }
            return account;
        }

        public List<Account> GetAllAccounts()
        {
            List<Account> accounts = new List<Account>();
            try
            {
                using (var db = new LiteDatabase(Path))
                {
                    var collectionAc = db.GetCollection<Account>("Account");

                    accounts = collectionAc.FindAll().ToList();

                }
            }
            catch (Exception ex)
            {
                if (delEx != null)
                    delEx.Invoke(ex, 0);
            }           

            return accounts;
        }

        public List<Account> GetUserAccounts(int userId)
        {
            List<Account> accounts = new List<Account>();

            accounts = GetAllAccounts().Where(w => w.UserId == userId).ToList();

            return accounts;
        }

        public bool AddBalance(int accountId, double balance)
        {
            try
            {
                using (LiteDatabase db = new LiteDatabase(Path))
                {

                    var accounts = db.GetCollection<Account>("Account");

                    Account account = accounts.FindById(accountId);
                    account.Balance = account.Balance + balance;

                    accounts.Update(account);

                    return true;
                }
            }
            catch (Exception ex)
            {
                if (delEx != null)
                    delEx.Invoke(ex, 0);

                return false;
            }
        }
    }

    public class ResultMessage
    {
        public bool Result { get; set; } = true;
        public string Message { get; set; } = "";
        public string IBAN { get; set; } = "";
    }

}
