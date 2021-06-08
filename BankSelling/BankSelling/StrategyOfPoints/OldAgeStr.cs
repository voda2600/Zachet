using BankSelling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSelling.StrategyOfPoints
{
   public class OldAgeStr:IStrategy
    {
        private bool Deposit { get; set; }
        public OldAgeStr(bool Deposit)
        {
            this.Deposit = Deposit;
        }
        public int Calculate()
        {
            if (Deposit) return 8;
            else return 0;
        }
    }
}
