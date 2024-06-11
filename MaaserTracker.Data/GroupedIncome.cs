using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaaserTracker.Data
{
    public class GroupedIncome
    {
        public string Source { get; set; }
        public List<Income> Incomes { get; set; }
    }
}
