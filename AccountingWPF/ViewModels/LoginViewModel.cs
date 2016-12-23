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
using AccountingWPF.Repositories.InvoiceRepository;

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
            if (false)
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

                    IUserRepository userRepository = new UserRepository();
                    UserCredentials userCredentials = new UserCredentials(username, password);

                    User user = userRepository.GetUserByCredentials(userCredentials);
                    if (user != null)
                    {
                        UserManager.LogIn(user);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("User does not exists");
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

            //populateDatabase();
            //       UserCredentials cred = new UserCredentials(Mock.getUser().Username, Mock.getUser().Password);
            //         User mock = Mock.getUser();

        }

        public void populateDatabase()
        {

            User mock = new User();
            mock.Username = "marko";
            mock.Password = "pass";
            mock.OIB = "123141";
            mock.Address = "Unska 3";
            mock.Email = "mojemail@email.com";
            mock.AssociationName = "udruga";


            IUserRepository userRepository = new UserRepository();
            userRepository.Create(mock);

            mock.Id = 1;

            MonateryFlowCRUD<Expenditure> expenditureRepo = new ExpenditureRepository<Expenditure>();
            IList<Expenditure> e = createExcedituresInDatabase(expenditureRepo, mock.Id);

            MonateryFlowCRUD<Receipt> receiptsRepo = new ReceiptRepository<Receipt>();
            IList<Receipt> r = createReceiptsInDatabase(receiptsRepo, mock.Id);


            IVatRepository vatRepo = new VATRepository();
            IList<VAT> v = createVatsInDatabase(vatRepo);

            IngoingInvoiceRepository ingoingInvoiceRepo = new IngoingInvoiceRepository();
            IList<IngoingInvoice> ingoingInvoices = createIngointInvoiceInDatabase(ingoingInvoiceRepo, mock.Id);

            OutgoingInvoiceRepository outgoingInvoiceRepo = new OutgoingInvoiceRepository();
            IList<OutgoingInvoice> outgoingInvoices = createOutgointInvoiceInDatabase(outgoingInvoiceRepo, mock.Id);
        }

        public IList<Expenditure> createExcedituresInDatabase(MonateryFlowCRUD<Expenditure> expenditureRepo, int id)
        {
            IList<Expenditure> expenditures = Mock.getExpendituresByUserId(id);
            foreach (Expenditure e in expenditures)
            {
                expenditureRepo.Create(e);
            }

            return expenditureRepo.getByUserId(id);
        }

        public IList<Receipt> createReceiptsInDatabase(MonateryFlowCRUD<Receipt> receiptsRepo, int id)
        {
            IList<Receipt> receipts = Mock.getReceiptsByUserId(id);
            foreach (Receipt r in receipts)
            {
                receiptsRepo.Create(r);
            }

            return receiptsRepo.getByUserId(id);
        }

        public IList<VAT> createVatsInDatabase(IVatRepository vatRepo)
        {
            IList<VAT> vats = Mock.getAllVATs();
            foreach (VAT v in vats)
            {
                vatRepo.Create(v);
            }

            return vatRepo.getAll();
        }

        public IList<IngoingInvoice> createIngointInvoiceInDatabase(IngoingInvoiceRepository ingoingInvoiceRepo, int id)
        {
            IList<IngoingInvoice> ingoingInvoices = Mock.getIngoingInvoicesByUserId(id);
            foreach (IngoingInvoice i in ingoingInvoices)
            {
                ingoingInvoiceRepo.Create(i);
            }

            return ingoingInvoiceRepo.getByUserId(id);
        }

        public IList<OutgoingInvoice> createOutgointInvoiceInDatabase(OutgoingInvoiceRepository outgoingInvoiceRepo, int id)
        {
            IList<OutgoingInvoice> outgoingInvoices = Mock.getOutgoingInvoicesByUserId(id);
            foreach (OutgoingInvoice i in outgoingInvoices)
            {
                outgoingInvoiceRepo.Create(i);
            }

            return outgoingInvoiceRepo.getByUserId(id);
        }

    }
}
