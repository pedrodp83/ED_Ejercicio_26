using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej26.models
{
    internal class Trained : Employee
    {
        private string degree;
        private double plus;
        private string department;

        public Trained(
            string dni,
            string name,
            string surname,
            double baseSalary,
            string degree,
            double plus,
            string department
        ) : base(dni, name, surname, baseSalary)
        {
            this.degree = degree;
            this.plus = plus;
            this.department = department;
        }

        public string Degree { get => degree; set => degree = value; }
        public double Plus { get => plus; set => plus = value; }
        public string Department { get => department; set => department = value; }
        public override string Information() => $"Titulación: {degree}, Departamento: {department}";
    }
}
