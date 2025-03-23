using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SocialNetwork.DAL.Repositories;


namespace SocialNetwork.BLL.Services
{
    public class UserService
    {
        IUserRepository userRepository;
        public UserService()
        {
            userRepository = new UserRepository();
        }
        public void Register(UserRegistrationData userRegistrationData)
        {
            if (String.IsNullOrEmpty(userRegistrationData.FirstName))
                throw new ArgumentNullException();
            if (String.IsNullOrEmpty(userRegistrationData.LastName))
                throw new ArgumentNullException();
            if (String.IsNullOrEmpty(userRegistrationData.Password))
                throw new ArgumentNullException();
            if (String.IsNullOrEmpty(userRegistrationData.Email))
                throw new ArgumentNullException();

            if (userRegistrationData.Password.Length < 8)
                throw new ArgumentNullException();
            if (!new EmailAddressAttribute().IsValid(userRegistrationData.Email))
                throw new ArgumentNullException();
        }
    }
}
