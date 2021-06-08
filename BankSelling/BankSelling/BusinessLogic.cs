using BankSelling.BankApi;
using BankSelling.Models;
using BankSelling.StrategyOfPoints;
using BankSelling.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSelling
{
    public class BusinessLogic:IComponent
    {
  

        private ApplicationContext db;
        public BusinessLogic(ApplicationContext _db)
        {
            db = _db;
        }
        public string CreditInfo(Lender lender)
        {

            int points = lender.CalculatePoints();
            if (points >= 80)
            {
                double interestRate = InterestRate.Interest(points);

                return "Готово! Ставка:" + interestRate;

            }
            else return "Вам отказано в кредите";

        }
        public void MoreCreditsInAnotherBank(string isMoreCredits, int lenderId)
        {
            if (isMoreCredits == "да")
            {
                Console.WriteLine("Сколько кредитов в других банках ?");
                int kol = int.Parse(Console.ReadLine());
                for (int i = 0; i < kol; i++)
                {
                    Console.WriteLine("Введите Сумму кредита, Цель");
                    db.Credits.Add(new Credit(int.Parse(Console.ReadLine()), Console.ReadLine(), lenderId));
                    
                }
                db.SaveChanges();
            }
        }
        public Lender ReadAndSetinDB()
        {
          
                Console.WriteLine("Введите Фамилию");
                string Surname = Console.ReadLine();
                Console.WriteLine("Введите Имя");
                string Name = Console.ReadLine();
                Console.WriteLine("Введите Отчество");
                string FatherName = Console.ReadLine();
                Console.WriteLine("Введите серию паспорта");
                string Serial = Console.ReadLine();
                Console.WriteLine("Введите номер паспорта");
                string Number = Console.ReadLine();
                Console.WriteLine("Введите кем выдан");
                string Vidan = Console.ReadLine();
                Console.WriteLine("Введите дату выдачи");
                DateTime VidanTime = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Введите прописку");
                string Propiska = Console.ReadLine();
                Passport passport = new Passport(Serial, Number, Vidan, VidanTime, Propiska);


                Console.WriteLine("Введите Возраст");
                int Age = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите Судимость true/false");
                string IsJail = Console.ReadLine();
                Console.WriteLine("Введите Сумму кредита");
                int CreditSum = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите Цель кредита Потребительский кредит/Недвижимость/Перекредитование");
                string Goal = Console.ReadLine();
                Console.WriteLine("Введите Трудоустройство  Безработный / ИП / ТК РФ / Без договора");
                string WorkType = Console.ReadLine();
                Console.WriteLine("Есть ли другие кредиты ? да/нет");
                string isMoreCredits = Console.ReadLine();




                LenderViewModel lenderView = new LenderViewModel(Surname, Name, FatherName, Age, IsJail, WorkType);
                if (lenderView.IsValid())
            {
                IStrategy ageStrategy;
                if (lenderView.Age <= 28)
                    ageStrategy = new YoungAgeStr(CreditSum);
                else if (lenderView.Age < 60)
                    ageStrategy = new MiddleAgeStr();
                else if (lenderView.Age <= 72)
                    ageStrategy = new OldAgeStr(true);
                else throw new Exception("Проблема с возрастом");

                IStrategy convictionStrategy;
                if (Convert.ToBoolean(lenderView.IsJail))
                    convictionStrategy = new WithCriminal();
                else if (Convert.ToBoolean(lenderView.IsJail) == false)
                    convictionStrategy = new WithoutCriminal();
                else throw new Exception("Проблема со справкой о судимости");


                IStrategy employmentStrategy;
                if (lenderView.WorkType == "ТК РФ")
                    employmentStrategy = new EmploymentWithTK();
                else if (lenderView.WorkType == "ИП")
                    employmentStrategy = new EmploymentWithIP();
                else if (lenderView.WorkType == "Без договора")
                    employmentStrategy = new EmploymentFreelance();
                else
                    employmentStrategy = new EmploymentWithAge(lenderView.Age);


                IStrategy goalStrategy;
                if (Goal == "Потребительский кредит")
                    goalStrategy = new ConsumerCreditStr();
                else if (Goal == "Недвижимость")
                    goalStrategy = new ConsumerRealEstateCreditStr();
                else if (Goal == "Перекредитование")
                    goalStrategy = new ConsumerRecrediting();
                else
                    throw new Exception("Цель кредита не опознана");



                IStrategy creditHaveStrategy;
                if (isMoreCredits == "нет")
                    creditHaveStrategy = new CreditHaveNOTStr(Goal);
                else if (isMoreCredits == "да")
                    creditHaveStrategy = new CreditHaveStr();
                else
                    throw new Exception("Не удалось выяснить историю кредитов");

                IStrategy creditSumStrategy;
                if (CreditSum <= 1000000)
                    creditSumStrategy = new LowCreditSumStr();
                else if (CreditSum <= 5000000)
                    creditSumStrategy = new BigCreditSumStr();
                else if (CreditSum <= 10000000)
                    creditSumStrategy = new BiggestCreditSumStr();
                else
                    throw new Exception("Проблема с суммой кредита");

                CheckJailApi(Surname, Name, FatherName, lenderView);

                db.Passports.Add(passport);
                db.SaveChanges();

                Lender lender = new Lender(lenderView, ageStrategy, convictionStrategy, employmentStrategy, goalStrategy, creditHaveStrategy, creditSumStrategy);



                lender.AddPassport(passport.Id);
                db.Lenders.Add(lender);
                db.SaveChanges();

                MoreCreditsInAnotherBank(isMoreCredits, lender.Id);
                Credit credit = new Credit(CreditSum, Goal, lender.Id);
                db.Credits.Add(credit);
                return lender;
            }
            throw new ArgumentException("Не валидные данные");
            
        }

        public static void CheckJailApi(string Surname, string Name, string FatherName, LenderViewModel lenderView)
        {
            IMOK Check = new MOKbyFIO(Surname + " " + Name + " " + FatherName);
            if (Check.IsJail())
            {
                lenderView.IsJail = "true";
            }
            else
            {
                lenderView.IsJail = "false";
            }
        }
    }
}
