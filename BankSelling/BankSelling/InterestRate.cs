using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSelling
{
    public static class InterestRate
    {
      public static double Interest(int point)
        {
            if (point < 84) return 30;
            else if (point < 88) return 26;
            else if (point < 92) return 22;
            else if (point < 96) return 19;
            else if (point < 100) return 15;
            else return 12.5;
        }
    }
}
