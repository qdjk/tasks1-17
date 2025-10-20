using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace mnimie_chicla
{

    internal class Program
    {
        static int Main(string[] args)
        {
            int n;
            double[,] matrix;
            double[] vector;
            using (StreamReader read = new StreamReader("C:\\Users\\M\\source\\repos\\mnimie_chicla\\mnimie_chicla\\data.txt"))
            {
                string line = read.ReadLine();
                n = int.Parse(line);
                
                matrix = new double[n,n];

                for (int i = 0; i < n; i++)
                {
                    string row=read.ReadLine();
                    string[] parts= row.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length > n) { Console.WriteLine("Ошибка симметричности матрицы"); return 1; }
                    for (int j = 0; j < n; j++)
                    {
                        matrix[i,j]= double.Parse(parts[j]);
                    }
                }
                string row1 = read.ReadLine();
                string[] parts1 = row1.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                vector=new double[parts1.Length];
                for (int i = 0; i < parts1.Length; i++)
                {
                    vector[i] = double.Parse(parts1[i]);
                }

            }

            // Проверка симметричности
            bool symmetric = true;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (matrix[i, j] != matrix[j, i])
                        symmetric = false;
            if (symmetric == false)
            {
                Console.WriteLine("Ошибка симметричности матрицы"); return 1;
            }

            double[] Gx = new double[n];
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    Gx[i] += matrix[i, j] * vector[j];
                }
            }
            double result = 0;
            for(int i = 0; i < n; i++)
            {
                result += vector[i]*Gx[i];
            }
            result = Math.Sqrt(result);
            Console.WriteLine($"Длина вектора: {result}");


            return 0;
        }
    }
}
