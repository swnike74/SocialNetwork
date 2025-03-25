using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;

namespace SocialNetwork
{
    internal class Program
    {
        public static UserService userService = new UserService();
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в социальную сеть.");

            while (true)
            {
                Console.WriteLine("Для регистрации введите имя пользователя:");
                string firstName = Console.ReadLine();

                Console.Write("Фамилия:");
                string lastName = Console.ReadLine();

                Console.Write("Пароль:");
                string password = Console.ReadLine();

                Console.Write("Почтовый адрес:");
                string email = Console.ReadLine();

                UserRegistrationData userRegistrationData = new UserRegistrationData()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Password = password,
                    Email = email
                };

                try
                {
                    userService.Register(userRegistrationData);
                    Console.WriteLine("Регистрация прошла успешно!");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Введите правильное значение.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Произошла ошибка при регистрации - {0}",ex);
                }

            
                Console.ReadLine();
            }
        }
    }
}
