using BankSelling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSelling.StrategyOfPoints
{
    public class EmploymentWithAge : IStrategy
    {
        private int age;

        public EmploymentWithAge(int age)
        {
            this.age = age;
        }
        public int Calculate()
        {
            if (age<=70)
            return 5;
            else
            {
                return 0;
            }
        }
    }
}
