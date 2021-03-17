using System;
using System.Collections.Generic;
using System.Linq;

namespace TasksAgain
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> gradesByStudents = new Dictionary<string, List<double>>();
            int countRows = int.Parse(Console.ReadLine());

            for (int i = 0; i < countRows; i++)
            {
                string studentName = Console.ReadLine();
                double gradeOfStudent = double.Parse(Console.ReadLine());

                if (!gradesByStudents.ContainsKey(studentName))
                {
                    gradesByStudents.Add(studentName, new List<double>{});                    
                }

                gradesByStudents[studentName].Add(gradeOfStudent);
            }

            Dictionary<string, double> avgGradesByStudents = gradesByStudents
                .Select(x => new KeyValuePair<string, double>(x.Key, x.Value.Average()))
                .Where(x => x.Value >= 4.50)
                .OrderByDescending(x => x.Value)
                .ToDictionary(x =>  x.Key, x => x.Value);

            foreach (var student in avgGradesByStudents)
            {
                Console.WriteLine($"{student.Key} -> {student.Value:F2}");
            }
        }
    }
}
