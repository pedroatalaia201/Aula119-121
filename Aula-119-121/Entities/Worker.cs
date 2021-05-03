using System;
using System.Collections.Generic;
using Aula_119_121.Entities.Enums;

namespace Aula_119_121.Entities {
    class Worker {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }//Associação entre duas classes diferentes; 
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();//queria saber disso antes '-'

        public Worker() {
        }

        public Worker(string name, WorkerLevel level, double baseSalary, Department department) {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
            /*
                Não incluir as associações para muitos(Contracts/List/Array), porque não
                é usual que se passe uma lista instânciada num construtor de um objeto.                
            */
        }

        public void AddContract(HourContract contract) {
            Contracts.Add(contract);
        }

        public void RemoveContract(HourContract contract) {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month) {
            double soma = BaseSalary;

            foreach(HourContract contract in Contracts) {
                if(contract.Date.Year == year && contract.Date.Month == month) {
                    soma += contract.TotalValue();
                }
            }

            return soma;
        }
    }
}
