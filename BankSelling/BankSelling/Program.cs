using BankSelling.BankApi;
using BankSelling.Models;
using BankSelling.StrategyOfPoints;
using BankSelling.ValueObjects;
using System;
using System.IO;
using System.Linq;

namespace BankSelling
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ФИО сотрудника банка");
            string FIO = Console.ReadLine();
            try
            {
                StreamWriter sw = new StreamWriter("Config.txt");
                sw.WriteLine(FIO);
                sw.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            IComponent businessLogic = new BusinessLogic(new ApplicationContext());
            DecorateLog decorateLog = new DecorateLog(new ApplicationContext(), businessLogic);
            Lender lender = decorateLog.ReadAndSetinDB();
            Console.WriteLine(decorateLog.CreditInfo(lender));
        }


    }
}
