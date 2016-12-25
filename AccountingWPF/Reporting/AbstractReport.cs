﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingWPF.Models;

namespace AccountingWPF.Factories
{
    public abstract class AbstractReport
    {
        public abstract byte[] Create(User user, int reportYear, IList<Expenditure> expenditures, IList<Receipt> receipts);
        public abstract byte[] CreateReportByYear(User user, List<MonetaryFlow> monetaryFlow);

    }
}