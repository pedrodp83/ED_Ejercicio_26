using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej26.models
{
    internal sealed class Scholar : Employee, Student
    {
        private string degree;
        private string course;
        private string department;
        private int numDesck;
       
        public Scholar(
            string dni,
            string name,
            string surname,
            double baseSalary,
            string degree,
            string course,
            string department,
            string university
        ) : base(dni, name, surname, baseSalary)
        {
            this.degree = degree;
            this.course = course;
            this.department = department;
            ExamScores = new List<float>();
            this.University = university;
        }

        public override string Information() => $"Carrera: {degree}, Departamento: {department}";
        public List<float> ExamScores { get; set; }
        public string Degree { get => degree; set => degree = value; }
        public string Course { get => course; set => course = value; }
        public string Department { get => department; set => department = value; }
        public string University { get; set; }
        public float AverageGrade() => Exams().Count > 0 ? Exams().Average() : 0.0f;
        public List<float> Exams() => ExamScores.Count <= 3 
            ? ExamScores 
            : ExamScores.GetRange(ExamScores.Count - 3, 3);
        public void AddExamScore(int examScore)
        {
            ExamScores.Add(examScore);
        }
    }
}
