using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class FriendsView
    {
        public void Show(IEnumerable<Friend> myFriends)
        {
            Console.WriteLine("Мои друзья:");

            if (myFriends.Count() == 0)
            {
                Console.WriteLine("Друзей нет");
                return;
            }

            myFriends.ToList().ForEach(friend =>
            {
                Console.WriteLine("Имя: {0}{1}. E-mail: ", friend.FirstName, friend.LastName, friend.Email);
            });
        }
    }
}
