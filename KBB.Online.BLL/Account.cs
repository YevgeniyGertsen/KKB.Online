using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBB.Online.BLL
{
    public class Account
    {
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
    }
}
