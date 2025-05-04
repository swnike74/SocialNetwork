using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        IFriendRepository friendRepository;
        IUserRepository userRepository;

        public FriendService()
        {
            userRepository = new UserRepository();
            friendRepository = new FriendRepository();
        }

        public void Register(FriendRegistrationData friendRegistrationData, User user)
        {
            if (String.IsNullOrEmpty(friendRegistrationData.FriendEmail))
                throw new ArgumentNullException();

            if (!new EmailAddressAttribute().IsValid(friendRegistrationData.FriendEmail))
                throw new ArgumentNullException();

            var userentity = userRepository.FindByEmail(friendRegistrationData.FriendEmail);
            if (userentity == null) throw new UserNotFoundException();

            var friendEntity = new FriendEntity()
            {
                user_id = user.Id,
                friend_id = userentity.id
            };

            if (this.friendRepository.Create(friendEntity) == 0)
                throw new Exception();
        }

        public IEnumerable<Friend> FindById(int id)
        {
            var findFriendEntity = friendRepository.FindAllByUserId(id);
            if (findFriendEntity is null) throw new UserNotFoundException();

            return ConstructFriendModel(findFriendEntity);
        }



        private IEnumerable<Friend> ConstructFriendModel(IEnumerable<FriendEntity> friendEntity)
        {
            var myfriends = new List<Friend>();//!!!!

            foreach (FriendEntity fe in friendEntity)
            {
                int friendId = fe.friend_id;
                var userserv = new UserService();
                var fr = userserv.FindById(friendId);
                string frfirstName = fr.FirstName;
                string frlastName = fr.LastName;
                string fremail = fr.Email;
                var myfriend = new Friend(friendId, frfirstName, frlastName, fremail);
                myfriends.Add(myfriend);
            }
            return myfriends;
        }
    }
}
