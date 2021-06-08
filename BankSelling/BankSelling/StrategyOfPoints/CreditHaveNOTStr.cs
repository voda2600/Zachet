using BankSelling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSelling.StrategyOfPoints
{
    public class CreditHaveNOTStr:IStrategy
    {
        private string goal;
        public CreditHaveNOTStr(string goal)
        {
            this.goal = goal;
        }

        public int Calculate()
        {
            if (goal == "Перекредитование") return 0;
            else return 14;
        }
    }
}
