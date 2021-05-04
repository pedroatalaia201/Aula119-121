using System;
using System.Globalization;
using Aula_119_121.Entities;
using Aula_119_121.Entities.Enums;

namespace Aula_119_121 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Exercício Resolvido\n");

            Console.Write("Enter department's name: ");
            string dptName = Console.ReadLine();

            Console.WriteLine("Enter Worker data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());//converter de string para WorkerLevel;

            Console.Write("Base salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(dptName);
            Worker worker = new Worker(name, level, baseSalary, dept);// dept já vai instanciado;

            Console.Write("\nHow many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 1; i <= n; i++) {
                Console.WriteLine($"Enter #{i} contract data: ");

                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());

                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, valuePerHour, hours);//ponteiro com a classe instanciada;
                worker.AddContract(contract);//levado como parametro;          
            }

            Console.Write("\nEnter month and year to calculate income(MM/YYYY): ");
            string monthAndYear = Console.ReadLine();

            int month = int.Parse(monthAndYear.Substring(0, 2));//substring(posição onde começa, onde termina);
            int year = int.Parse(monthAndYear.Substring(3));//onde vai começar apenas(vai até a ultima posição);

            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: " + worker.Department.Name);
            /*
             * a partir do objeto worker, se pode acessar a propriedade Department, e a partir
             * do Department se pode acessar o Nome.
            */
            Console.WriteLine("Income for " + monthAndYear + ": " + worker.Income(year, month).ToString("F2",
                CultureInfo.InvariantCulture));

            Console.ReadKey();
        }
    }
}
