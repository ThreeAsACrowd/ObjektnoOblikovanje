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

            populateDatabase();
            //       UserCredentials cred = new UserCredentials(Mock.getUser().Username, Mock.getUser().Password);
            //         User mock = Mock.getUser();

        }

        public void populateDatabase()
        {

            User mock = Mock.getUser();

            ExpenditureRepository expenditureRepo = new ExpenditureRepository();
            //IList<Expenditure>  e = createExcedituresInDatabase(expenditureRepo, mock.Id);

            ReceiptRepository receiptsRepo = new ReceiptRepository();
            //IList<Receipt> r=createReceiptsInDatabase(receiptsRepo, mock.Id);


            VATRepository vatRepo = new VATRepository();
            IList<VAT> v = createVatsInDatabase(vatRepo);

        }

        public IList<Expenditure> createExcedituresInDatabase(ExpenditureRepository expenditureRepo, int id)
        {
            IList<Expenditure> expenditures = Mock.getExpendituresByUserId(id);
            foreach (Expenditure e in expenditures)
            {
                expenditureRepo.Create(e);
            }

            return expenditureRepo.getByUserId(id);
        }

        public IList<Receipt> createReceiptsInDatabase(ReceiptRepository receiptsRepo, int id)
        {
            IList<Receipt> receipts = Mock.getReceiptsByUserId(id);
            foreach (Receipt r in receipts)
            {
                receiptsRepo.Create(r);
            }

            return receiptsRepo.getByUserId(id);
        }

        public IList<VAT> createVatsInDatabase(VATRepository vatRepo)
        {
            IList<VAT> vats = Mock.getAllVATs();
            foreach (VAT v in vats)
            {
                vatRepo.Create(v);
            }

            return vatRepo.getAll();
        }

    }
}
