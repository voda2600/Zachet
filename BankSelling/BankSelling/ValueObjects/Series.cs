using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankSelling.ValueObjects
{
    public class Series
    {
        public string _Series { get; private set; }
        public Series(string str)
        {
            string pattern = @"[0-9][0-9][0-9][0-9]";
            Regex regex = new Regex(pattern);
            if ((!(regex.IsMatch(str))) || str.Length != 4) throw new Exception("Номер пасспорта инвалиден");
            _Series = str;
        }
    }
}
