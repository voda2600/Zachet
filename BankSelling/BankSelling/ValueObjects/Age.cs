using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSelling.ValueObjects
{
    [Keyless]
    public class Age
    {
        public int age { get; private set; }
        public Age(int age)
        {
            if (age >= 21 && age < 150)
            {
                this.age = age;
            }
            else
            {
                throw new ArgumentException("Ваш возраст не подходит");
            }

        }
    }
}
