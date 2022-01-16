
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace variant3
{
    class Program
    {

        static int[] d;

        public static int[] randommassive()
        {
            Random rnd = new Random();
            int b = rnd.Next(100);
            d = new int[b];
            for (int i = 0; i < d.Length; i++)
                d[i] = rnd.Next(-100, 500);
            for (int i = 0; i < d.Length; i++) Console.Write(" " + d[i]);//выводим массив
            return d;

        }

        public static void findminmaxfunction1(int[] d)
        {
            int max = 0;
            int min = 0;
            for (int i = 0; i < d.Length; i++)
            {
                if (d[i] > max) { max = d[i]; }
                if (d[i] < min) { min = d[i]; }
            }
            int answer = max - min;
            Console.WriteLine();
            Console.WriteLine("max:  " + max);
            Console.WriteLine("min  " + min);
            Console.WriteLine("Difference between max and min " + answer);
            Console.ReadLine();
        }


        public static void countFunction()
        {
            Random rnd = new Random();
            int[] M = randommassive();
            int count = 0;
            int g = 0;

            for (int i = 0; i < M.Length; i++)
            {
                g = M[i];
                if (g > 0 && g < 125)
                    count++;
            }
            Console.WriteLine();
            Console.WriteLine("число" + " " + count);
            Console.ReadLine();
        }

      


        public static int josephus(bool [] nodes, int d, int start, int left)
        {
            if (left == 1)
            {// Последний оставшийся человек, найти координаты этого человека и вернуть
                start = ignore(nodes, start);
                return ++start;
            }
            int i = 1; // Начинаем считать с начала, отфильтровываем людей из списка, пока не начнем считать до k-1
            while (i < d)
            {
                if (nodes[start] == false)
                {
                    i++;
                }
                start++;
                if (start == nodes.Length) start = 0;
            }
            start = ignore(nodes, start);
            nodes[start] = true; // Найти человека, который считает k, dequeue
            left--; // Общее количество людей уменьшается
            Console.WriteLine("person is killed under number:" + (start + 1));
            return josephus(nodes, d, (++start) % nodes.Length, left); // Перезапустить следующий раунд
        }

        private static int ignore(bool [] nodes, int start)
        {
            while (nodes[start])
            {
                start++;
                if (start == nodes.Length) start = 0;
            }
            return start;
        }

        static void Main(string[] args)
        {
            //Ü 3. Задача Иосифа.
            Console.WriteLine(" Задача Иосифа.");
            Console.WriteLine("choose size of your massive");
            int c = Convert.ToInt32(Console.ReadLine());
            bool [] nodes = new bool [c];
            for (int i = 0; i < nodes.Length; i++)
            {
                nodes[i] = false;
            }
            Console.WriteLine("choose count step");
            int d = Convert.ToInt32(Console.ReadLine());
            int start = 0;
            Console.WriteLine("the left is " + josephus(nodes, d,start, nodes.Length));
            Console.ReadLine();

            //Ü 1. В заданном массиве действительных чисел найдите разность между максимальным и минимальным числом.
            Console.WriteLine("В заданном массиве действительных чисел найдите разность между максимальным и минимальным числом.");
            findminmaxfunction1(randommassive());

            //Ü 2. В одномерном массиве из K чисел M[] подсчитайте количество элементов, удовлетворяющих условию 0 < M[i] <125. K, M создаются случайно.
            Console.WriteLine("В одномерном массиве из K чисел M[] подсчитайте количество элементов, удовлетворяющих условию 0 < M[i] <125");
            countFunction();


        }
    }
}
    




