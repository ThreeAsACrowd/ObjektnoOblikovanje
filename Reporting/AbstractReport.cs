using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models;

namespace Reporting
{
    public abstract class AbstractReport
    {
        public abstract byte[] CreateAnnualReport(User user, int reportYear, IList<Expenditure> expenditures, IList<Receipt> receipts);
        public abstract byte[] CreateMonetaryFlowReport(User user, List<MonetaryFlow> monetaryFlow);

    }
}
