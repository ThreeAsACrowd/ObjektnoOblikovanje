using System;
using System.Collections.Generic;
using AccountingWPF.BindingModels;
using System.Windows;
using AccountingWPF.Views;
using AccountingWPF.BaseLib;
using DataRepository.Models;
using DataRepository.Repositories;
using DataRepository.Repositories.InvoiceRepository;
using DataRepository.Factories;

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
                //testiranje repozitorijal
                TestLogin();
                return false;
            }
            else if (false)
            {
                //napuni bazu podataka
                populateDatabase();
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

            IUserRepository userRepository = new UserRepository();
            IVatRepository vatRepo = new VatRepository();
            IMonetaryFlowRepository<Expenditure> expenditureRepo = new ExpenditureRepository<Expenditure>();
            IMonetaryFlowRepository<Receipt> receiptsRepo = new ReceiptRepository<Receipt>();
            IInvoiceRepository<IngoingInvoice> ingoingInvoiceRepo = new IngoingInvoiceRepository<IngoingInvoice>();
            IInvoiceRepository<OutgoingInvoice> outgoingInvoiceRepo = new OutgoingInvoiceRepository<OutgoingInvoice>();

            //       UserCredentials cred = new UserCredentials(Mock.getUser().Username, Mock.getUser().Password);
            //         User mock = Mock.getUser();

            // IList<Expenditure> e = expenditureRepo.getByUserId(1);

            IList<Expenditure> eByYear = expenditureRepo.getUserMonetaryFlowByYear(1, 2016);
            IList<Expenditure> rByYear = expenditureRepo.getUserMonetaryFlowByYear(1, 2016);
            // IList<Expenditure> rByNoYear = expenditureRepo.getUserMonetaryFlowByYear(1, 2015);

            IList<int> eYears = expenditureRepo.getAvailableYearsByUserId(1);
            IList<int> rYears = receiptsRepo.getAvailableYearsByUserId(1);

            IList<IngoingInvoice> ingoing = ingoingInvoiceRepo.getByUserId(1);
            IList<OutgoingInvoice> outgoing = outgoingInvoiceRepo.getByUserId(1);

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

            //repoi
            IUserRepository userRepository = new UserRepository();
            IVatRepository vatRepo = new VatRepository();
            IMonetaryFlowRepository<Expenditure> expenditureRepo = new ExpenditureRepository<Expenditure>();
            IMonetaryFlowRepository<Receipt> receiptsRepo = new ReceiptRepository<Receipt>();
            IInvoiceRepository<IngoingInvoice> ingoingInvoiceRepo = new IngoingInvoiceRepository<IngoingInvoice>();
            IInvoiceRepository<OutgoingInvoice> outgoingInvoiceRepo = new OutgoingInvoiceRepository<OutgoingInvoice>();

            userRepository.Create(mock);
            mock.Id = 1;



            //kreiranje objekata
            IList<Vat> v = createVatsInDatabase(vatRepo);
            IList<Expenditure> e = createExcedituresInDatabase(expenditureRepo, mock.Id);
            IList<Receipt> r = createReceiptsInDatabase(receiptsRepo, mock.Id);
            IList<IngoingInvoice> ingoingInvoices = createIngointInvoiceInDatabase(ingoingInvoiceRepo, mock.Id);
            IList<OutgoingInvoice> outgoingInvoices = createOutgointInvoiceInDatabase(outgoingInvoiceRepo, mock.Id);
        }

        public IList<Expenditure> createExcedituresInDatabase(IMonetaryFlowRepository<Expenditure> expenditureRepo, int id)
        {
            IList<Expenditure> expenditures = MockFactory.getExpendituresByUserId(id);
            foreach (Expenditure e in expenditures)
            {
                expenditureRepo.Create(e);
            }

            return expenditureRepo.getByUserId(id);
        }

        public IList<Receipt> createReceiptsInDatabase(IMonetaryFlowRepository<Receipt> receiptsRepo, int id)
        {
            IList<Receipt> receipts = MockFactory.getReceiptsByUserId(id);
            foreach (Receipt r in receipts)
            {
                receiptsRepo.Create(r);
            }

            return receiptsRepo.getByUserId(id);
        }

        public IList<Vat> createVatsInDatabase(IVatRepository vatRepo)
        {
            IList<Vat> vats = MockFactory.getAllVATs();
            foreach (Vat v in vats)
            {
                vatRepo.Create(v);
            }

            return vatRepo.getAll();
        }

        public IList<IngoingInvoice> createIngointInvoiceInDatabase(IInvoiceRepository<IngoingInvoice> ingoingInvoiceRepo, int id)
        {
            IList<IngoingInvoice> ingoingInvoices = MockFactory.getIngoingInvoicesByUserId(id);
            foreach (IngoingInvoice i in ingoingInvoices)
            {
                ingoingInvoiceRepo.Create(i);
            }

            return ingoingInvoiceRepo.getByUserId(id);
        }

        public IList<OutgoingInvoice> createOutgointInvoiceInDatabase(IInvoiceRepository<OutgoingInvoice> outgoingInvoiceRepo, int id)
        {
            IList<OutgoingInvoice> outgoingInvoices = MockFactory.getOutgoingInvoicesByUserId(id);
            foreach (OutgoingInvoice i in outgoingInvoices)
            {
                outgoingInvoiceRepo.Create(i);
            }

            return outgoingInvoiceRepo.getByUserId(id);
        }

    }
}
