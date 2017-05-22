using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evgeniy.Database;

namespace Evgeniy.Utils
{
    public static class Calculation
    {
        public static double CalculateTrend(List<SalesTransaction> listOfTransactions)
        {
            var startDate = DateTime.Now.AddDays(-90);
            var endDate = DateTime.Now;
            var count = 1;
            var listOfResult = new List<ItemByDay>();
            for (DateTime date = startDate; date.Date <= endDate.Date; date = date.AddDays(1))
            {
                var date1 = date;
                var items = listOfTransactions.Where(x => x.CreatedAt.Month == date1.Month && x.CreatedAt.Day == date1.Day);
                listOfResult.Add(new ItemByDay { Value = items.Count(), Day = count });
                count++;
            }

            var sum = listOfResult.Select(x => x.Value).Sum();
            double p1 = sum / Convert.ToDouble(listOfResult.Count);
            var p2 = listOfResult.Select((t, i) => t.Value * (i + 1)).Sum();

            var p3 = (p2 - p1 * 10) / 5;

            var p4 = p1 - p3 * 2.5;
            var p5 = p3 * 5 + p4;
            return p5;
        }
    }
}
