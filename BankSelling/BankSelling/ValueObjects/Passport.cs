using BankSelling.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSelling.ValueObjects
{
    public class Passport
    {
        public void AddLender(int id)
        {
            throw new Exception();
        }
        public int Id { get; set; }
        public Series Series { get; private set; }
        public Number Number { get; private  set; }

        public string Vidan { get; private set; }

        public DateTime VidanTime { get; private set; }

        public string Propiska { get; private set; }
       
        private Passport()
        {

        }
        public Passport(string Series, string Number, string Vidan, DateTime VidanTime, string Propiska)
        {
            if (VidanTime >= DateTime.Now)
                throw new Exception("Ошибка даты получения паспорта");
            this.Series = new Series(Series);
            this.Number = new Number(Number);
            this.Vidan = Vidan;
            this.VidanTime = VidanTime;
            this.Propiska = Propiska;
        }

    }
}
