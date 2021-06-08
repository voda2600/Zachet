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
        [InlineData("���������","������","�����������",21,"false",1200000, "��������������� ������", "�� ��","���", "������! ������:30")]
        [InlineData("���������", "������", "�����������", 30, "false", 2800000, "��������������� ������", "�� ��", "���", "������! ������:26")]
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
            else throw new Exception("�������� � ���������");

            IStrategy convictionStrategy;
            if (Convert.ToBoolean(lenderView.IsJail))
                convictionStrategy = new WithCriminal();
            else if (Convert.ToBoolean(lenderView.IsJail) == false)
                convictionStrategy = new WithoutCriminal();
            else throw new Exception("�������� �� �������� � ���������");


            IStrategy employmentStrategy;
            if (lenderView.WorkType == "�� ��")
                employmentStrategy = new EmploymentWithTK();
            else if (lenderView.WorkType == "��")
                employmentStrategy = new EmploymentWithIP();
            else if (lenderView.WorkType == "��� ��������")
                employmentStrategy = new EmploymentFreelance();
            else
                employmentStrategy = new EmploymentWithAge(lenderView.Age);


            IStrategy goalStrategy;
            if (Goal == "��������������� ������")
                goalStrategy = new ConsumerCreditStr();
            else if (Goal == "������������")
                goalStrategy = new ConsumerRealEstateCreditStr();
            else if (Goal == "����������������")
                goalStrategy = new ConsumerRecrediting();
            else
                throw new Exception("���� ������� �� ��������");



            IStrategy creditHaveStrategy;
            if (isMoreCredits == "���")
                creditHaveStrategy = new CreditHaveNOTStr(Goal);
            else if (isMoreCredits == "��")
                creditHaveStrategy = new CreditHaveStr();
            else
                throw new Exception("�� ������� �������� ������� ��������");

            IStrategy creditSumStrategy;
            if (CreditSum <= 1000000)
                creditSumStrategy = new LowCreditSumStr();
            else if (CreditSum <= 5000000)
                creditSumStrategy = new BigCreditSumStr();
            else if (CreditSum <= 10000000)
                creditSumStrategy = new BiggestCreditSumStr();
            else
                throw new Exception("�������� � ������ �������");
            BusinessLogic.CheckJailApi(Surname, Name, FatherName, lenderView);
            Lender lender = new Lender(lenderView, ageStrategy, convictionStrategy, employmentStrategy, goalStrategy, creditHaveStrategy, creditSumStrategy);
            Assert.Equal(answer, businessLogic.CreditInfo(lender));
        }
    }
}
