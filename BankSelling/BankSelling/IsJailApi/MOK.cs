using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSelling.BankApi
{
    class MOKbyFIO : IMOK
    {
        private string FIO;
        public MOKbyFIO(string FIO)
        {
            this.FIO = FIO;
        }
        public bool IsJail()
        {
            if (FIO == "Леонид Ильич Брежнев") return true;
            else return false;
        }
    }
}
