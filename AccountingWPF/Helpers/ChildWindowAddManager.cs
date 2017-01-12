using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.ViewModel;
using System.Windows;

namespace AccountingWPF.Helpers
{
    public class ChildWindowAddManager : NotificationObject
    {
        public ChildWindowAddManager()
        {
            
            WindowVisibility = Visibility.Collapsed;
            XmlContent = null;
        }

        //Singleton pattern implementation
        private static ChildWindowAddManager instance;
        public static ChildWindowAddManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ChildWindowAddManager();
                }
                return instance;
            }
        }

        #region Public Properties

        private Visibility windowVisibility;
        public Visibility WindowVisibility
        {
            get { return windowVisibility; }
            set
            {
                windowVisibility = value;
                RaisePropertyChanged("WindowVisibility");
            }
        }

        private FrameworkElement xmlContent;
        public FrameworkElement XmlContent
        {
            get { return xmlContent; }
            set
            {
                xmlContent = value;
                RaisePropertyChanged("XmlContent");
            }
        }

        #endregion

        #region Public Methods

        public void ShowChildWindow(FrameworkElement content)
        {
            XmlContent = content;
            RaisePropertyChanged("XmlContent");
            WindowVisibility = Visibility.Visible;
            RaisePropertyChanged("WindowVisibility");
        }

        public void CloseChildWindow()
        {
            WindowVisibility = Visibility.Collapsed;
            RaisePropertyChanged("WindowVisibility");
            XmlContent = null;
            RaisePropertyChanged("XmlContent");
        }

        #endregion

    }
}
