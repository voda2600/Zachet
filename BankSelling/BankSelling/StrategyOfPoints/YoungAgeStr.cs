using BankSelling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSelling.StrategyOfPoints
{
    public class YoungAgeStr : IStrategy
    {
        private int creditSum { get; set; }
        public YoungAgeStr(int creditSum)
        {
            this.creditSum = creditSum;
        }
        public int Calculate()
        {
            if (creditSum < 1000000) return 12;
            else if (creditSum >= 1000000 && creditSum <= 3000000) return 9;
            else return 0;
        }
    }
}
