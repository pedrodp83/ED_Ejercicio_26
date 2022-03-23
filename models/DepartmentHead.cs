using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej26.models
{
    internal sealed class DepartmentHead : Trained
    {
        private int totalEmployeesInCharge;
        private int projects;
        private double plusDH;

        public DepartmentHead(
            string dni,
            string name,
            string surname,
            double baseSalary,
            string degreeTitle,
            double plus,
            string department,
            int totalEmployeesInCharge,
            int projects,
            double plusDH
        ) : base(dni, name, surname, baseSalary, degreeTitle, plus, department)
        {
            this.totalEmployeesInCharge = totalEmployeesInCharge;
            this.projects = projects;
            this.plusDH = plusDH;
        }

        public int TotalEmployeesInCharge { get => totalEmployeesInCharge; set => totalEmployeesInCharge = value; }
        public int Projects { get => projects; set => projects = value; }
        public double PlusDH { get => plusDH; set => plusDH = value; }
    }
}
