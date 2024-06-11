using MaaserTracker.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaaserTracker.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaaserController : ControllerBase
    {
        private readonly string _connection;

        public MaaserController(IConfiguration config)
        {
            _connection = config.GetConnectionString("ConStr");
        }

        [HttpGet("getallIncomes")]
        public List<Income> GetAllIncomes()
        {
            var repo = new Repository(_connection);
            return repo.GetAllIncomes();
        }

        [HttpGet("getgroupedincomes")]
        public List<GroupedIncome> GetGroupedIncomes()
        {
            var repo = new Repository(_connection);
            var incomes = repo.GetAllIncomes();

            var groupedIncomes = new List<GroupedIncome>();

            foreach (Income i in incomes)
            {
                var match = groupedIncomes.FirstOrDefault(g => g.Source == i.Source);

                if (match == null)
                {
                    groupedIncomes.Add(new ()
                    {
                        Source = i.Source,
                        Incomes = new() { i }
                    });
                }
                else
                {
                    match.Incomes.Add(i);
                }
            }

            return groupedIncomes;
        }

        [HttpGet("getallmaasers")]
        public List<Maaser> GetAllMaasers()
        {
            var repo = new Repository(_connection);
            return repo.GetAllMaasers();
        }

        [HttpGet("gettotalincome")]
        public decimal GetTotalIncome()
        {
            var repo = new Repository(_connection);
            return repo.GetAllIncomes().Select(i => i.Amount).Sum();
        }

        [HttpGet("gettotalmaaser")]
        public decimal GetTotalMaaser()
        {
            var repo = new Repository(_connection);
            return repo.GetAllMaasers().Select(i => i.Amount).Sum();
        }

        [HttpGet("getsources")]
        public List<IncomeSource> GetSources()
        {
            var repo = new Repository(_connection);
            return repo.GetAllSources();
        }

        [HttpPost("AddIncome")]
        public void AddIncome(Income income)
        {
            var repo = new Repository(_connection);
            repo.AddIncome(income);
        }


        [HttpPost("AddMaaser")]
        public void AddMaaser(Maaser maaser)
        {
            var repo = new Repository(_connection);
            repo.AddMaaser(maaser);
        }

        [HttpGet("GetUniqueIncomeSources")]
        public List<string> GetUniqueIncomeSources()
        {
            var repo = new Repository(_connection);
            return repo.GetAllIncomes().Select(i => i.Source).ToHashSet().ToList();
        }
    }
}
