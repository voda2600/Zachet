using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSelling.Models
{
     public class Log
    {
        public int Id { get; set; }
        public int LenderId { get; set; }
        public string Percent { get; set; }
        public DateTime Time { get; set; }
    }
}
