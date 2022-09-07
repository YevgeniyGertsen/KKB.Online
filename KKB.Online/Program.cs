using KBB.Online.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.Online
{
    internal class Program
    {
        static string Path = @"C:\Temp\MyData.db";
        static void Main(string[] args)
        {
            int ch = 0;
            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                UserService userService = new UserService(Path);
                string message = "";


                Console.WriteLine("Добро пожаловать в Интернет Банкинг");
                Console.WriteLine("");
                Console.WriteLine("Выберете пункты меню: ");
                Console.WriteLine("1. Авторизация");
                Console.WriteLine("2. Регистрация");
                Console.WriteLine("3. Выход");

               ch =  Convert.ToInt32(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        {
                            string IIN;
                            string Password;
                            Console.Clear();
                            Console.Write("Введите ИИН: ");
                            IIN = Console.ReadLine();
                            Console.Write("Введите пароль: ");
                            Password = Console.ReadLine();
                            personal_data user = userService.GetUser(IIN, Password);
                            if (user == null)
                            {
                                Console.WriteLine("ИИН и пароль введены не правильно!");
                            }
                            else
                            {
                                Console.WriteLine("Добро пожаловать {0}", user.FullName);
                            }
                        }
                        break;
                    case 2:
                        {
                            #region Registartion
                            //User user = new User();
                            //user.Accounts = null;
                            //user.Address = null;
                            //user.Birth = new DateTime(1988, 01, 11);
                            //user.IIN = "880111300392";
                            //user.Name = "Yevgeniy";
                            //user.SecondName = "Gertsen";
                            //user.Password = "123";
                            //user.PhoneNumber = "+7 777 209 43 43";
                            //user.Sex = "M";

                            Console.Write("Введите Ваш ИИН ");
                            string iin = Console.ReadLine();
                            
                            if (userService.GetUserData(iin, out message))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(message);
                                Console.ForegroundColor = ConsoleColor.White;
                              
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(message);
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            #endregion
                        }
                        break;
                    default:
                        throw new Exception("Необходимо выбрать пункт меню");
                }
            }
            catch (Exception) when (ch==0)
            {
                Console.WriteLine("у не должен быть рвен 0");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {

            }
            catch (Exception)
            {

                throw;
            }








        }
    }
}
