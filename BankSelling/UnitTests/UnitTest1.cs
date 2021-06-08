using BankSelling;
using BankSelling.Models;
using BankSelling.StrategyOfPoints;
using System;
using Xunit;

namespace UnitTests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("Мухаметов","Ильнур","Фаваризович",21,"false",1200000, "Потребительский кредит", "ТК РФ","нет", "Готово! Ставка:30")]
        [InlineData("Мухаметов", "Ильнур", "Фаваризович", 30, "false", 2800000, "Потребительский кредит", "ТК РФ", "нет", "Готово! Ставка:26")]
        public void TestBusinessLogic(string Surname, string Name, string FatherName, int Age, string IsJail, int CreditSum, string Goal, string WorkType, string isMoreCredits, string answer)
        {
            BusinessLogic businessLogic = new BusinessLogic(null);
            LenderViewModel lenderView = new LenderViewModel(Surname, Name, FatherName, Age, IsJail, WorkType);
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
            BusinessLogic.CheckJailApi(Surname, Name, FatherName, lenderView);
            Lender lender = new Lender(lenderView, ageStrategy, convictionStrategy, employmentStrategy, goalStrategy, creditHaveStrategy, creditSumStrategy);
            Assert.Equal(answer, businessLogic.CreditInfo(lender));
        }
    }
}
