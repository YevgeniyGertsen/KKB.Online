using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBB.Online.BLL
{
    internal class AccountService
    {
        public string Path { get; set; }
        public AccountService(string Path)
        {
            this.Path = Path;
        }

        public void CreateAccount(int userId)
        {
            Account account = new Account();
            account.UserId = userId;
            account.Balance = 0;
            account.CreationDate = DateTime.Now;
            account.Currency = 1;
            account.IBAN = GenerateIBAN();

            using (var db = new LiteDatabase(Path))
            {
                var users = db.GetCollection<personal_data>("Users");

                users.Insert(user);

                message = "Successfully";
                return true;
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
