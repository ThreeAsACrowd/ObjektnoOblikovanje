using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingWPF.BindingModels;
using System.Windows;
using AccountingWPF.Models;
using AccountingWPF.Repositories;
using AccountingWPF.Views;
using AccountingWPF.BaseLib;
using AccountingWPF.Factories;

namespace AccountingWPF.ViewModels
{
    public class LoginViewModel
    {
        public LoginBindingModel LoginBM { get; set; }

        public Window ChildWindow { get; set; }

        public LoginViewModel()
        {
            LoginBM = new LoginBindingModel();
        }

        public bool Login()
        {
            if (true)
            {
                TestLogin();
                return false;
            }
            else
            {
                string username = LoginBM.Username;
                string password = LoginBM.Password;

                if (String.IsNullOrEmpty(username))
                {
                    MessageBox.Show("Username must not be empty");
                }
                else if (String.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Password must not be empty");
                }
                else
                {

                    UserRepository userRepository = new UserRepository();
                    // UserRepository.CreateNewUser(Mock.getUser());

                    UserCredentials userCredentials = new UserCredentials(username, password);
                    //mock login
                    User user = userRepository.GetUserByCredentials(userCredentials);
                    if (user != null)
                    {
                        UserManager.LogIn(user);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Di ceees");
                    }

                }
                return false;
            }

        }

        public void OpenHome()
        {
            ChildWindow = new Home();
            ChildWindow.ShowDialog();

            LoginBM.Username = "";
            LoginBM.Password = "";
        }

        public void TestLogin()
        {
            UserCredentials cred = new UserCredentials(Mock.getUser().Username, Mock.getUser().Password);
            User mock = Mock.getUser();
            //UserRepository.abstractCreateUser(Mock.getUser());
            //UserRepository.absractGetUserByCredentials(cred);
            ExpenditureRepository exRepo = new ExpenditureRepository();

            UserRepository userRepository = new UserRepository();

            //  UserRepository.CreateNewUser(mock);
            User user = userRepository.GetUserByCredentials(cred);
            //User user2 = UserRepository.GetUserById(mock.Id);
            //MessageBox.Show(user.Username);
        }

        public void populateDatabase()
        {
            ExpenditureRepository expenditureRepo = new ExpenditureRepository();
            ReceiptRepository receiptsRepo = new ReceiptRepository();

            User mock = Mock.getUser();
            IList<Expenditure> expenditures = Mock.getExpendituresByUserId(mock.Id);
            foreach (Expenditure e in expenditures)
            {
                expenditureRepo.Create(e);
            }

            IList<Expenditure> expenditurelist = expenditureRepo.getByUserId(mock.Id);


            IList<Receipt> receipts = Mock.getReceiptsByUserId(mock.Id);
            foreach (Receipt r in receipts)
            {
                receiptsRepo.Create(r);
            }

            IList<Receipt> receiptsList = receiptsRepo.getByUserId(mock.Id);
        }

    }
}
