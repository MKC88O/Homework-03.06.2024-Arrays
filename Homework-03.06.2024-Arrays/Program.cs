using System.ComponentModel.Design;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Homework_03._06._2024_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /////////////////////////      ROME DIGITS      /////////////////////////

            string[] romeDigitsArray = new string[4000];
            int[] arabDigitsArray = new int[4000];
            for (int i = 1; i < 4000; i++)
            {
                arabDigitsArray[i] = i;
            }
            int[] arabDigits = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] romeDigits = ["M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"];

            for (int i = 1; i < 4000; i++)
            {
                int number = arabDigitsArray[i];
                string result = "";
                for (int j = 0; j < arabDigits.Length; j++)
                {
                    int count = number / arabDigits[j];
                    for (int k = 0; k < count; k++)
                    {
                        result += romeDigits[j];
                    }
                    number %= arabDigits[j];
                }
                romeDigitsArray[i] = result;
            }

            for (int i = 1; i < 4000; i++)
            {
                Console.WriteLine(romeDigitsArray[i] + "\t\t\n");
            }

            /////////////////////////      TEXT NUMBERS      /////////////////////////

            string[] units = {"один", "два", "три", "четыре", "пять", "шесть", "семь",
                              "восемь", "девять", "десять", "одинадцать", "двенадцать", "тринадцать", "четырнадцать",
                              "пятьнадцать", "шестьнадцать", "семнадцать", "восемнадцать","девятнадцать" };
            string[] tens = { "двадцать", "тридцать", "сорок", "пятьдесят", "шестьдесят", "семдесят", "восемдесят", "девяносто" };
            string[] hungreds = { "сто", "двести", "триста", "четыреста", "пятьсот", "шестьсот", "семьсот", "восемьсот", "девятьсот" };
            string[] thousands = { "тысяча" };
            string[] millions = { "миллион" };
            Console.Write("Enter convert number: ");
            int convertNumber = Convert.ToInt32(Console.ReadLine());

            string res = "";

            if (convertNumber >= 1000000)
            {
                int mlln = convertNumber / 1000000;
                if (mlln > 0)
                {
                    if (mlln >= 100)
                    {
                        int hngrd = mlln / 100;
                        res += hungreds[hngrd - 1] + " ";
                        mlln %= 100;
                    }

                    if (mlln >= 20)
                    {
                        int ten = mlln / 10;
                        res += tens[ten - 2] + " ";
                        mlln %= 10;
                    }

                    if (mlln > 0)
                    {
                        res += units[mlln - 1] + " " + millions[0];
                    }
                    
                    convertNumber %= 1000000;
                }
            }

            if (convertNumber >= 1000)
            {
                int thsnd = convertNumber / 1000;
                if (thsnd > 0)
                {
                    if (thsnd >= 100)
                    {
                        int hngrd = thsnd / 100;
                        res += hungreds[hngrd - 1] + " ";
                        thsnd %= 100;
                    }

                    if (thsnd >= 20)
                    {
                        int ten = thsnd / 10;
                        res += tens[ten - 2] + " ";
                        thsnd %= 10;
                    }

                    if (thsnd > 0)
                    {
                        res += units[thsnd - 1] + " " + thousands[0] + " ";
                    }

                    convertNumber %= 1000;
                }
            }

            if (convertNumber > 0)
            {
                if (convertNumber >= 100)
                {
                    int hngrd = convertNumber / 100;
                    res += hungreds[hngrd - 1] + " ";
                    convertNumber %= 100;
                }

                if (convertNumber >= 20)
                {
                    int ten = convertNumber / 10;
                    res += tens[ten - 2] + " ";
                    convertNumber %= 10;
                }

                if (convertNumber > 0)
                {
                    res += units[convertNumber - 1] + " ";
                }
            }
            Console.WriteLine(res);

            /////////////////////////      МАССИВ С ЛЕВА НА ПРАВО      /////////////////////////

            Console.Write("Enter number 'N': ");
            int N = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter number 'M': ");
            int M = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            int[,] array = new int[N, M];
            int startArray = 1;

            Console.WriteLine("\t\tRegular Array: \n");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    array[i, j] = startArray++;
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }

            ///////////////////////////      МАССИВ ЗМЕЙКОЙ      /////////////////////////

            for (int i = 0; i < N; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < M; j++)
                    {
                        array[i, j] = startArray++;
                    }
                }
                else
                {
                    for (int j = M - 1; j >= 0; j--)
                    {
                        array[i, j] = startArray++;
                    }
                }
            }

            Console.WriteLine("\n\t\tSnake Array: \n");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
