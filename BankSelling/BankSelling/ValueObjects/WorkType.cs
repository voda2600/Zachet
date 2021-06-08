using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSelling.ValueObjects
{
    public class WorkType
    { 
        public string _WorkType { get; private set; }
        public WorkType(string str)
        {
            switch (str)
            {
                case "ТК РФ": _WorkType = str; break;
                case "Безработный": _WorkType = str; break;
                case "ИП": _WorkType = str; break;
                case "Без договора": _WorkType = str; break;
                default: throw new Exception("Не верный тип работы");
            }
        }
    }
}
