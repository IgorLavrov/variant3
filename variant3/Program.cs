
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
            Console.ReadLine();
            Console.WriteLine("число" + " " + count);
            Console.ReadLine();
        }

        public static Dictionary<int, string> MyDic(int n)
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            Console.WriteLine("Введите имя : \n");
            string s;
            for (int j = 1; j <= n; j++)
            {
                Console.Write("Имя{0} --> ", j);
                s = Console.ReadLine();
                dic.Add(j, s);
            }
            return dic;
        }


        public static int josephus(bool [] nodes, int k, int start, int left)
        {
            if (left == 1)
            {// Последний оставшийся человек, найти координаты этого человека и вернуть
                start = ignore(nodes, start);
                return ++start;
            }
            int i = 1; // Начинаем считать с начала, отфильтровываем людей из списка, пока не начнем считать до k-1
            while (i < k)
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
            return josephus(nodes, k, (++start) % nodes.Length, left); // Перезапустить следующий раунд
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
            Random rnd = new Random();
            int b = rnd.Next(10, 100);
            bool [] nodes = new bool [b];
            for (int i = 0; i < nodes.Length; i++)
            {
                nodes[i] = false;
            }
            Console.WriteLine("the left is " + josephus(nodes, 7, 0, nodes.Length));


            //findminmaxfunction1(randommassive());

            //countFunction();






            /* optional 
             * 
             * Console.Write("Сколько игроков добавить?");
        int n = int.Parse(Console.ReadLine());
        Dictionary<int, string> dic = Program.MyDic(n);
        Console.Write("До какого считать?");
        int k = int.Parse(Console.ReadLine());

            Random rnd = new Random();
            int[] M = new int[100];
            int count = 0;
            for (int i = 0; i < 100; i++)
            {
                M[i] = rnd.Next(-100, 200);
                if (M[i] > 0 && M[i] < 125)
                    count++;
            }
            Console.WriteLine(count);

            Random rnd = new Random();
            int[] d = new int[30];
            int max = 0, min = 100;
            for (int i = 0; i < d.Length; i++)
                d[i] = rnd.Next(100);

            for (int i = 0; i < d.Length; i++)
            {
                if (d[i] > max) max = d[i];
                if (d[i] < min) min = d[i];
            }

            for (int i = 0; i < d.Length; i++) Console.Write(" " + d[i]);//выводим массив
            Console.WriteLine();
            Console.WriteLine("max:  " + max);
            Console.WriteLine("min  " + min);
            Console.WriteLine("Difference betwen min and max" + (max - min));
            Console.ReadKey();*/



        }
    }
}
    




