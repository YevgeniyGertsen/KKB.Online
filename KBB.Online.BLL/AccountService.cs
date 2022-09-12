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
        public string Path { get; set; }
        public AccountService(string Path)
        {
            this.Path = Path;
        }

        public bool CreateAccount(int userId, out string message, out string accountIBAN)
        {
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

                    message = "Successfully";
                    accountIBAN = account.IBAN;
                    return true;
                }
            }
            catch (Exception Ex)
            {
                message = "При создании счета возникла ошибка: " + Ex.Message;
                accountIBAN = "";
                return false;
            }
            
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
    }
}
