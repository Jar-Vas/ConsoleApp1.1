using System.Collections.Specialized;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            /*
            */
            #region task1
            Console.WriteLine("Task 1");
            int[] A = new int[5];
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Input number " + (i + 1) + ": ");
                int.TryParse(Console.ReadLine(), out int n);
                A[i] = n;
            }

            double[,] B = new double[3, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    B[j, i] = rand.NextDouble() * 5; // {x | x є B} => x є [0, 5)
                }
            }

            Console.WriteLine("Arrays: ");
            Console.Write("A:");
            foreach (int i in A)
            {
                Console.Write(" " + i);
            }
            Console.Write("\nB: ");
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    Console.Write(B[i, j] + " ");
                }
                Console.WriteLine();
            }
            double min = A[0];
            double max = A[0];
            double sum = 0;
            double prod = 1;
            int evenSum = 0;
            double oddSum = 0;
            foreach (int i in A)
            {
                min = Math.Min(min, i);
                max = Math.Max(max, i);
                sum += i;
                prod *= i;
                if (i % 2 == 0) { evenSum += i; }
            }
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    min = Math.Min(min, B[i, j]);
                    max = Math.Max(max, B[i, j]);
                    sum += B[i, j];
                    prod *= B[i, j];
                    if (j % 2 == 1) { oddSum += B[i, j]; }
                }
            }

            Console.WriteLine("Answers: " + min + " " + max + " " + sum + " " + prod + " " + evenSum + " " + oddSum);

            #endregion task1


            #region task2
            Console.WriteLine("Task 2");

            int[,] arr2 = new int[5, 5];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    arr2[i, j] = Random.Shared.Next(-100, 101);
                }
            }

            int sum2 = 0;

            int min2 = arr2[0, 0];
            int max2 = arr2[0, 0];
            int min2_ind = 0;
            int max2_ind = 0;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (arr2[i, j] < min2) { min2 = arr2[i, j]; min2_ind = i * 5 + j; }
                    if (arr2[i, j] > max2) { max2 = arr2[i, j]; max2_ind = i * 5 + j; }
                }
            }
            if (min2_ind > max2_ind) { (min2_ind, max2_ind) = (max2_ind, min2_ind); }

            for (int i = min2_ind + 1; i < max2_ind; i++)
            {
                sum2 += arr2[i / 5, i % 5];
            }

            Console.WriteLine("Answer " + sum2);
            #endregion task2
            

            #region task3

            Console.WriteLine("Task 3");

            Console.Write("Input string: ");
            string s3 = Console.ReadLine();
            string out3 = "";
            int key = 3;
            for (int i = 0; i < s3.Length; i++)
            {
                out3 += (char)(s3[i] + key);
            }

            Console.WriteLine("Coded: " + out3);
            Console.WriteLine("EnCoded: " + encoding(out3, key));

            #endregion task3

            #region task4
            //           |||
            // Functions |||
            //           vvv
            #endregion task4


            #region task5

            Console.WriteLine("Task 5");

            char[] separators = { '-', '+' };
            Console.Write("Input string: ");
            string s5 = Console.ReadLine();
            if (s5[0] == '-')
            {
                s5 = "0" + s5;
            }
            string[] parts = s5.Split(separators);
            char[] operation = { };
            for (int i = 0; i < s5.Length; i++)
            {
                if (s5[i] == '+' || s5[i] == '-')
                {
                    Array.Resize(ref operation, operation.Length + 1);
                    operation[operation.Length - 1] = s5[i]; 
                }
            }
            int.TryParse(parts[0], out int sum5);
            for (int i = 1; i < parts.Length; i++)
            {
                int k = (operation[i-1] == '-') ? -1 : 1;
                int.TryParse(parts[i], out int _num);
                sum5 += _num * k;
            }

            Console.WriteLine("Answer " + sum5);
            #endregion task5
        }

        static string encoding(string s, int key)
        {
            string temp = "";
            for (int i = 0; i < s.Length; i++)
            {
                temp += (char)(s[i] - key);
            }
            return temp;
        }

        static int[,] add(int[,] m1,  int[,] m2)
        {
            if (m1.GetLength(0) != m2.GetLength(0) || m1.GetLength(1) != m2.GetLength(1)) { throw new ArgumentException("Idk wt u want"); }

            int[,] m3 = new int[m1.GetLength(0), m1.GetLength(1)];

            for (int i = 0; i <  m1.GetLength(0); i++)
            {
                for (int j = 0; j <  m2.GetLength(1); j++)
                {
                    m3[i, j] = m1[i, j] + m2[i, j];
                }
            }
            return m3;
        }

        static int [,] multiplication(int[,] m1, int number)
        {
            int[,] m2 = new int[m1.GetLength(0), m1.GetLength(1)];

            for (int i = 0; i < m1.GetLength(0); i++)
            {
                for (int j = 0; j < m1.GetLength(1); j++)
                {
                    m2[i, j] = m1[i, j] * number;
                }
            }
            return m2;
        }

        static int[,] multiplication(int[,] m1, int[,] m2)
        {
            if (m1.GetLength(1) != m2.GetLength(0)) { throw new ArgumentException("Idk wt u want"); } // defined only fol m*n and n*k matrix

            int[,] m3 = new int[m1.GetLength(0), m2.GetLength(1)];

            for (int i = 0; i < m1.GetLength(0); ++i)        
            {
                for (int j = 0; j < m2.GetLength(1); ++j)    
                {
                    for (int k = 0; k < m2.GetLength(0); ++k)
                    {
                        m3[i, j] += m1[i, k] * m2[k, j];
                    }
                }
            }
            return m3;
        }
    }
}
