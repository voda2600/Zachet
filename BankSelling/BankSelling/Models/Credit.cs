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
    public class Credit : IValidator
    {
        [ForeignKey("Lender")]
        public int LenderId { get; set; }
        public Lender Lender { get; set; }

        public int Id { get; set; }

        public int CreditSum { get; set; }

        public Goal Goal { get; set; }

        public Credit(int CreditSum, string Goal, int lenderId)
        {
            LenderId = lenderId;
            if (CreditSum <= 0) throw new Exception("Отрицательная сумма кредита");
            this.CreditSum = CreditSum;
            this.Goal = new Goal(Goal);
            if (!(this.IsValid()))
                throw new Exception("Сумма кредита не верна");
        }
        private Credit()
        {

        }
        public bool IsValid()
        {
            if (CreditSum <= 0) return false;
            return true;
        }
    }
}
