using BankSelling.StrategyOfPoints;
using BankSelling.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSelling.Models
{
    public class Lender
    {
        [NotMapped]
        private IStrategy ageStrategy { get; set; }
        [NotMapped]
        private IStrategy convictionStrategy { get;  set; }
        [NotMapped]
        private IStrategy employmentStrategy { get;  set; }
        [NotMapped]
        private IStrategy goalStrategy { get; set; }
        [NotMapped]
        private IStrategy creditHaveStrategy { get;  set; }

        [NotMapped]
        private IStrategy creditSumStrategy { get;  set; }

        public int CalculatePoints()
        {
            return ageStrategy.Calculate() +
                convictionStrategy.Calculate() +
                employmentStrategy.Calculate() +
                goalStrategy.Calculate() +
                creditHaveStrategy.Calculate() +
                creditSumStrategy.Calculate();
        }

        public Lender(LenderViewModel view, IStrategy _ageStrategy, IStrategy _convictionStrategy, IStrategy _employmentStrategy, IStrategy _goalStrategy, IStrategy _creditHaveStrategy, IStrategy _creditSumStrategy)
        {

                this.Surname = view.Surname;
                this.Name = view.Name;
                this.FatherName = view.FatherName;
                this.Age = new Age(view.Age);
                this.ageStrategy = _ageStrategy;
                this.convictionStrategy = _convictionStrategy;
                this.employmentStrategy = _employmentStrategy;
                this.goalStrategy = _goalStrategy;
                this.creditHaveStrategy = _creditHaveStrategy;
                this.creditSumStrategy = _creditSumStrategy;
                this.IsJail = Convert.ToBoolean(view.IsJail);
                this.WorkType = new WorkType(view.WorkType);
                if (!(Surname.Length <= 40)) throw new Exception("Фамилия более 40 символов");
                if (!(Name.Length <= 40)) throw new Exception("Имя больше 40");
                if (!(FatherName.Length <= 40)) throw new Exception("Отчество более 40");
    
           
        }
        private Lender()
        {

        }

        public void AddPassport(int id)
        {
            PassportId = id;
        }

        [Key]
        public int Id { get;private set; }


        public string Surname { get; private set; }


        public string Name { get; private set; }

    
        public string FatherName { get; private set; }
        


        [ForeignKey("Passport")]
        public int PassportId { get; private set; }

        public Passport Passport { get; private set; }

        public Age Age { get; private set; }



        public bool IsJail { get; private set; }


        public WorkType WorkType {get; private set; }

        public List<Credit> Credits { get; private set; }

     
    }
}
