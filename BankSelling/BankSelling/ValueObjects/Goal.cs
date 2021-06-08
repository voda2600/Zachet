using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSelling.ValueObjects
{
    public class Goal
    { 
        public string _Goal { get; private set; }
        public Goal(string str)
        {
            switch (str)
            {
                case "Потребительский кредит": _Goal = str; break;
                case "Недвижимость": _Goal = str; break;
                case "Перекредитование": _Goal = str; break;
                default: throw new Exception("Цель с некорректными данными");
            }
        }
    }
}
