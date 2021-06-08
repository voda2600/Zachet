using BankSelling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSelling.StrategyOfPoints
{
    public class MiddleAgeStr : IStrategy
    {
        public int Calculate()
        {
            return 14;
        }
    }
}
