using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MaaserTracker.Data
{
    public class Repository
    {
        private readonly string _connection;

        public Repository(string connection)
        {
            _connection = connection;
        }

        public List<Income> GetAllIncomes()
        {
            using var context = new MaaserTrackerDataContext(_connection);
            return context.Incomes.ToList();
        }

        public List<Maaser> GetAllMaasers()
        {
            using var context = new MaaserTrackerDataContext(_connection);
            return context.Maasers.ToList();
        }

        public List<IncomeSource> GetAllSources()
        {
            var sources = new HashSet<string>();

            foreach (Income i in GetAllIncomes())
            {
                sources.Add(i.Source);
            }
            return sources.Select(s => new IncomeSource() { Label = s }).ToList();
        }

        public void AddIncome(Income income)
        {
            using var context = new MaaserTrackerDataContext(_connection);
            context.Incomes.Add(income);
            context.SaveChanges();
        }

        public void AddMaaser(Maaser maaser)
        {
            using var context = new MaaserTrackerDataContext(_connection);
            context.Maasers.Add(maaser);
            context.SaveChanges();
        }

    }
}
