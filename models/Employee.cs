using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej26.models
{
    internal abstract class Employee
    {
        protected string name;
        protected string surname;
        protected double baseSalary;
        protected string dni;

        protected Employee(string dni, string name, string surname, double baseSalary)
        {
            this.dni = dni;
            this.name = name;
            this.surname = surname;
            this.baseSalary = baseSalary;
        }

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public double BaseSalary { get => baseSalary; set => baseSalary = value; }
        public string Dni { get => dni; set => dni = value; }
        public abstract string Information();
    }
}
