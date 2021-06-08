using BankSelling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSelling
{
    public interface IComponent
    {
        public string CreditInfo(Lender lender);
       
    }
}
