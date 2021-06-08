using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankSelling.ValueObjects
{
    public class Number
    {
        public string _Number { get; private set; }
        public Number(string str)
        {
            string pattern = @"[0-9]+";
            Regex regex = new Regex(pattern);
            if ((!(regex.IsMatch(str))) || str.Length != 6) throw new Exception("Номер пасспорта инвалиден");
            _Number = str;
        }
    }
}
