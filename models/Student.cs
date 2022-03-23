using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej26.models
{
    internal interface Student
    {
        List<float> ExamScores { get; set; }
        string University { get; set; }
        void AddExamScore(int examScore);
        List<float> Exams();
        float AverageGrade();
    }
}
