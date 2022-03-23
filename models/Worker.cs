using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej26.models
{
    internal sealed class Worker : Employee
    {
        private string destination;
        private int overtime;
        private double overtimePrice;

        public Worker(
            string dni,
            string name,
            string surname,
            double baseSalary,
            string destination,
            int overtime,
            double overtimePrice
        ) : base(dni, name, surname, baseSalary)
        {
            this.destination = destination;
            this.overtime = overtime;
            this.overtimePrice = overtimePrice;
        }

        public string Destination { get => destination; set => destination = value; }
        public int Overtime { get => overtime; set => overtime = value; }
        public double OvertimePrice { get => overtimePrice; set => overtimePrice = value; }
        public override string Information() => 
            $"Destino: {destination}, Precio Horas Extra: {overtimePrice}€";
    }
}
