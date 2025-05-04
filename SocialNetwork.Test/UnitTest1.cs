using NUnit.Framework.Legacy;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;

namespace SocialNetwork.Test
{
    public class SocialNetworkTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void UserRegistrationDataMustRegisterNewUser()
        {
            IEnumerable<Message> IncomingMessageges = new List<Message>();
            IEnumerable<Message> OutcomingMessageges = new List<Message>();
            IEnumerable<Friend> friends = new List<Friend>();

            var user1RegistrationData = new UserRegistrationData();
            user1RegistrationData.FirstName = "Jack";
            user1RegistrationData.LastName = "Daniels";
            user1RegistrationData.Email = "Jack66@gmail.com";
            user1RegistrationData.Password = "12345678";

            UserService userService = new UserService();
            userService.Register(user1RegistrationData);

            var authenticationData = new UserAuthenticationData();
            authenticationData.Email = user1RegistrationData.Email;
            authenticationData.Password = user1RegistrationData.Password;

            var usertest = userService.Authenticate(authenticationData);
            User user1 = new User(
                1,
                user1RegistrationData.FirstName,
                user1RegistrationData.LastName,
                user1RegistrationData.Password,
                user1RegistrationData.Email,
                "",
                "",
                "",
                IncomingMessageges,
                OutcomingMessageges,
                friends);

            CollectionAssert.AreEqual(usertest.FirstName, user1.FirstName);
            CollectionAssert.AreEqual(usertest.LastName, user1.LastName);
            CollectionAssert.AreEqual(usertest.Email, user1.Email);
            CollectionAssert.AreEqual(usertest.Password, user1.Password);

        }
    }
}