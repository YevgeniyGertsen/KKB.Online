using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.Online.Lib
{
    public class Notification
    {
        public static void ResultCreateAccount(string message, bool result, string accountIBAN)
        {
            if (result)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Поздравляем Ваш счет {0} {1}", accountIBAN, message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("При создании счета возникла ошибка: {0}", message);
                Console.ForegroundColor = ConsoleColor.White;
            }

            //write exception log
        }

        public static void WriteException(Exception ex, int userId)
        {
            //запишем ошибку в файл
        }
    }
}
