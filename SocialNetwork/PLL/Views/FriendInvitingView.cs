using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class FriendInvitingView
    {
        UserService userService;
        FriendService friendService;
        public FriendInvitingView(UserService userService, FriendService friendService)
        {
            this.userService = userService;
            this.friendService = friendService;
        }

        public void Show(User user)
        {
            var friendRegistrationData = new FriendRegistrationData();

            Console.Write("Введите почтовый адрес друга: ");
            friendRegistrationData.FriendEmail = Console.ReadLine();

            friendRegistrationData.userId = user.Id;
            try
            {
                this.friendService.Register(friendRegistrationData, user);
                SuccessMessage.Show("Вы успешно пригласили своего друга.");
                user = userService.FindById(user.Id);
            }
            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение.");
            }

            catch (UserNotFoundException)
            {
                AlertMessage.Show("Друг не найден!");
            }

            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при регистрации друга.");
            }

        }
    }
}
