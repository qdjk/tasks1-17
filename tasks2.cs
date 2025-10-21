using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnimie_chicla
{

    public struct Complex
    {
        public double Im;
        public double Re;

        public Complex(double re, double im)
        {
            this.Re = re;
            this.Im = im;
        }
        public void Plus(Complex other)
        {
            this.Im += other.Im;
            this.Re += other.Re;
        }
        public void Minus(Complex other)
        {
            this.Im -= other.Im;
            this.Re -= other.Re;
        }
        public void Multiply(Complex other)
        {
            double newRe = Re * other.Re - Im * other.Im;
            double newIm = Re * other.Im + Im * other.Re;
            this.Re *= newRe;
            this.Im *= newIm;
        }
        public void Divide(Complex other)
        {
            double znam = other.Re * other.Re + other.Im * other.Im;
            if (znam == 0)
            {
                Console.WriteLine("Ошибка: деление на 0!");
                return;
            }
            double newRe = (Re * other.Re + Im * other.Im) / znam;
            double newIm = (Im * other.Re - Re * other.Im) / znam;

            Re = newRe;
            Im = newIm;
        }
        public double Modulus()
        {
            return Math.Sqrt(Re * Re + Im * Im);
        }
        public double ArgumentRadians()
        {
            return Math.Atan2(Im, Re);
        }
        public void Print()
        {

            if (Im >= 0.0) Console.WriteLine(Re + " + " + Im + "i");
            else Console.WriteLine(Re + "" + Im + "i");
        }
        public void PrintChastyam()
        {
            Console.WriteLine("Вещественная часть: " + Re);
            Console.WriteLine("Мнимая часть: " + Im + "i");
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            double newRe = 0; double newIm = 0;
            Complex complex = new Complex(0, 0);
            Complex complex1 = new Complex(0, 0);
            while (true)
            {
                Console.WriteLine("1. Ввод нового числа 1.");
                Console.WriteLine("2. Сложить");
                Console.WriteLine("3. Вычесть");
                Console.WriteLine("4. Умножить");
                Console.WriteLine("5. Разделить");
                Console.WriteLine("6. Модуль");
                Console.WriteLine("7. Аргумент");
                Console.WriteLine("8. Вывести число на экран");
                Console.WriteLine("Q или q. Выход");
                string ok = Console.ReadLine();
                switch (ok)
                {
                    case "1":
                        Console.WriteLine();
                        Console.WriteLine("Вводим новое число с которым будут выполняться операции");
                        Console.WriteLine();
                        Console.WriteLine("Введите вещественную часть: ");
                        double Re = double.Parse(Console.ReadLine());
                        Console.WriteLine("Введите мнимую часть: ");
                        double Im = double.Parse(Console.ReadLine());
                        complex = new Complex(Re, Im);
                        break;
                    case "2":
                        Console.WriteLine("Число 1:  "); complex.Print();
                        Console.WriteLine("Введите число 2: вещественная /enter  мнимая часть /enter");
                        newRe = double.Parse(Console.ReadLine());
                        Console.WriteLine("Введите мнимую часть: ");
                        newIm = double.Parse(Console.ReadLine());
                        complex1 = new Complex(newRe, newIm);
                        complex.Plus(complex1);
                        Console.WriteLine();
                        complex.Print();

                        break;
                    case "3":
                        Console.WriteLine("Число 1:  "); complex.Print();
                        Console.WriteLine("Введите число 2: вещественная /enter  мнимая часть /enter");
                        newRe = double.Parse(Console.ReadLine());
                        Console.WriteLine("Введите мнимую часть: ");
                        newIm = double.Parse(Console.ReadLine());
                        complex1 = new Complex(newRe, newIm);
                        complex.Minus(complex1);
                        Console.WriteLine();
                        complex.Print();
                        break;
                    case "4":
                        Console.WriteLine("Число 1:  "); complex.Print();
                        Console.WriteLine("Введите число 2: вещественная /enter  мнимая часть /enter");
                        newRe = double.Parse(Console.ReadLine());
                        Console.WriteLine("Введите мнимую часть: ");
                        newIm = double.Parse(Console.ReadLine());
                        complex1 = new Complex(newRe, newIm);
                        complex.Multiply(complex1);
                        Console.WriteLine();
                        complex.Print();
                        break;
                    case "5":
                        Console.WriteLine("Число 1:  "); complex.Print();
                        Console.WriteLine("Введите число 2: вещественная /enter  мнимая часть /enter");
                        newRe = double.Parse(Console.ReadLine());
                        Console.WriteLine("Введите мнимую часть: ");
                        newIm = double.Parse(Console.ReadLine());
                        complex1 = new Complex(newRe, newIm);
                        complex.Divide(complex1);
                        Console.WriteLine();
                        complex.Print();
                        break;
                    case "6":
                        Console.WriteLine("Число 1:  "); complex.Print();
                        Console.WriteLine("Модуль числа: ");
                        Console.WriteLine(complex.Modulus());
                        Console.WriteLine();
                        complex.Print();
                        break;
                    case "7":
                        Console.WriteLine("Число 1:  "); complex.Print();
                        Console.WriteLine("Аргумент числа: ");
                        Console.WriteLine(complex.ArgumentRadians());
                        Console.WriteLine();
                        complex.Print();
                        break;
                    case "8":
                        Console.WriteLine();
                        Console.WriteLine("Информация о числе 1: ");
                        complex.PrintChastyam();
                        Console.WriteLine();
                        complex.Print();
                        break;
                    case "Q":
                        Console.WriteLine("Выход из программы!!!");
                        Console.WriteLine();
                        return;
                    case "q":
                        Console.WriteLine("Выход из программы!!!");
                        Console.WriteLine();
                        return;
                    default:
                        Console.WriteLine("Введен не тот символ!!!");
                        Console.WriteLine();
                        break;
                }

            }
        }
    }
}
