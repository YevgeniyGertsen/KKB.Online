using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBB.Online.BLL
{
    public class Account
    {
        public int UserId { get; set; }
        public int AccountId { get; set; }
        public string IBAN { get; set; }

        private double Balance_;
        public double Balance
        {
            get
            {
                return Balance_;
            }
            set
            {
                if (value < 0)
                {
                    Balance_ = 0;
                }
                else
                {
                    Balance_ = value;
                }
            }
        }

        public DateTime CreationDate { get; set; } = DateTime.Now;
        public int Currency { get; set; } = 1;//1-kzt, 2-usd


        public string GetCurrencyName
        {
            get
            {
                if(Currency == 1)
                {
                    return "тенге";
                }
                else //if(Currency == 2)
                {
                    return "доллары США";
                }
            }
        }
        public string GetBalance
        {
            get
            {
                return string.Format("{0} {1}", Balance, GetCurrencyName);
            }
        }
        public static double operator +(Account a, Account b)
        {
            return a.Balance + b.Balance;
        }
        public static bool operator >(Account a, Account b)
        {
            if(a.Currency == b.Currency)
            {
                return a.Balance > b.Balance;
            }
            else if(a.Currency != b.Currency && a.Currency == 2)
            {

                return (a.Balance * 480) > b.Balance;
            }
            else
            {
                return (a.Balance / 480) > b.Balance;
            }
        }
        public static bool operator <(Account a, Account b)
        {
            if (a.Currency == b.Currency)
            {
                return a.Balance < b.Balance;
            }
            else if (a.Currency != b.Currency && a.Currency == 2)
            {

                return (a.Balance * 480) < b.Balance;
            }
            else
            {
                return (a.Balance / 480) < b.Balance;
            }
        }
        public override string ToString()
        {
            return String.Format("{0}. {1} - {2} {3}", AccountId, IBAN, Balance, GetCurrencyName);
        }

    }
}
