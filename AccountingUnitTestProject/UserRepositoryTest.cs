using System.Threading;
using DataRepository.Models;
using DataRepository.Repositories;
using DataRepository.Repositories.InvoiceRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AccountingUnitTestProject
{
    [TestClass]
    public class UserRepositoryTest
    {



        [TestMethod]
        public void CreateAndGetUserByCredentials()
        {
            User user = new User();
            user.Username = "mirko";
            user.Password = "pass";
            user.Address = "unska 3";
            user.Email = "mirko@gmail.com";
            user.OIB = "2313131441";

            IUserRepository userRepo = new UserRepository(SessionManagerTest.SessionFactory);
            userRepo.Create(user);

            User testUser = userRepo.GetUserByCredentials(new UserCredentials(user.Username, user.Password));

            Assert.AreEqual(user.Username, testUser.Username);
            Assert.AreEqual(user.Password, testUser.Password);
            Assert.AreEqual(user.Address, testUser.Address);
            Assert.AreEqual(user.OIB, testUser.OIB);
            Assert.AreEqual(user.Email, testUser.Email);

        }

        [TestMethod]
        public void DeleteUser()
        {
            User user = new User();
            user.Username = "mirko";
            user.Password = "pass";
            user.Address = "unska 3";
            user.Email = "mirko@gmail.com";
            user.OIB = "2313131441";

            IUserRepository userRepo = new UserRepository(SessionManagerTest.SessionFactory);
            userRepo.Create(user);

            User testUser = userRepo.GetUserByCredentials(new UserCredentials(user.Username, user.Password));

            userRepo.DeleteUser(testUser);
            Thread.Sleep(1000);
            User deletedUser = userRepo.GetUserByCredentials(new UserCredentials(user.Username, user.Password));

            Assert.IsNull(deletedUser);
        }

        [TestMethod]
        public void UpdateUser()
        {
            User user = new User();
            user.Username = "mirko";
            user.Password = "pass";
            user.Address = "unska 3";
            user.Email = "mirko@gmail.com";
            user.OIB = "2313131441";

            IUserRepository userRepo = new UserRepository(SessionManagerTest.SessionFactory);
            userRepo.Create(user);

            User testUser = userRepo.GetUserByCredentials(new UserCredentials(user.Username, user.Password));

            string newEmail = "novaadresa@gmail.com";
            testUser.Email = newEmail;
            userRepo.UpdateUser(testUser);

            User updatedUser = userRepo.GetUserByCredentials(new UserCredentials(user.Username, user.Password));

            Assert.AreEqual(updatedUser.Email, newEmail);
        }
    }
}
