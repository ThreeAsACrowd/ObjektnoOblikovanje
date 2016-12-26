using System;
using AccountingWPF.Models;
using AccountingWPF.nHibernateDb;
using AccountingWPF.Repositories;
using AccountingWPF.Repositories.InvoiceRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;

namespace AccountingUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            User user = new User();
            user.Id = 1;
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
    }
}
