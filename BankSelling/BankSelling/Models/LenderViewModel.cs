using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BankSelling.ValueObjects;

namespace BankSelling.Models
{
    public class LenderViewModel
    {
        public LenderViewModel(string Surname, string Name, string FatherName, int Age, string IsJail, string WorkType)
        {
            try
            {
                this.Surname = Surname;
                this.Name = Name;
                this.FatherName = FatherName;  
                this.Age = Age;
                this.IsJail = IsJail;
                this.WorkType = WorkType;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public bool IsValid()
        {

            string pattern = @"[а-яА-я]+";
            Regex regex = new Regex(pattern);
            if (!(regex.IsMatch(Surname))) return false;
            if (!(regex.IsMatch(Name))) return false;
            if (!(regex.IsMatch(FatherName))) return false;
            if (!(IsJail == "true" || IsJail == "false")) return false;
            return true;
        }
       


        public string Surname { get; set; }


        public string Name { get; set; }


        public string FatherName { get; set; }


        public int Age { get; set; }

        public string IsJail { get; set; }


        public string WorkType { get; set; }


    }
}
