using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SpanningTree_PrimAlgorithm
{
    class Program
    {
        public static int n;
        public static int xp;
        public static int ts;
        public static LinkedList<Tuple<int, int>>[] ds;

        public static LinkedList<Tuple<int, int, int>>[] spanning_tree;
        public static bool[] IsChecked;

        public static void Input()
        {
            StreamReader sr = new StreamReader("graph.inp");
            string[] chuoi = sr.ReadLine().Trim().Split(' ');
            n = int.Parse(chuoi[0]);
            xp = int.Parse(chuoi[1]);
            ts = 0;

            ds = new LinkedList<Tuple<int, int>>[n];
            for(int i = 0;i < n; i++)
            {
                ds[i] = new LinkedList<Tuple<int, int>>();
                string[] s = sr.ReadLine().Trim().Split(' ');
                for(int j = 0; j < s.Count(); j++)
                {
                    ts += int.Parse(s[j + 1]);
                    ds[i].AddLast(new Tuple<int, int>(int.Parse(s[j]), int.Parse(s[j+1])));
                    j++;
                }
            }
            sr.Close();
        }
        public static void Output()
        {
            for (int i = 0; i < n; i++)
            {
                foreach (var item in ds[i])
                    Console.Write(item.Item1 + " " + item.Item2 + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public static void PrimAlgorithm()
        {
            spanning_tree = new LinkedList<Tuple<int, int, int>>[n - 1];
            IsChecked = new bool[n];
            IsChecked[xp - 1] = true;

            for(int k = 0; k < n - 1; k++)
            {
                spanning_tree[k] = new LinkedList<Tuple<int, int, int>>();

                int u = 0, v = 0, min = ts;

                for(int i = 0; i < n; i++)
                {
                    if (IsChecked[i])
                    {
                        foreach (var item in ds[i])
                        {
                            if(!IsChecked[item.Item1 - 1])
                            {
                                if(item.Item2 < min)
                                {
                                    u = i + 1;
                                    v = item.Item1;
                                    min = item.Item2;
                                }
                            }
                        }
                    }
                }
                IsChecked[v - 1] = true;
                spanning_tree[k].AddLast(new Tuple<int, int, int>(u, v, min));
            }
        }
        public static void PrimRoad()
        {
            Console.WriteLine("Cay khung nho nhat : ");

            for(int i = 0; i < spanning_tree.Count(); i++)
            {
                foreach(var item in spanning_tree[i])
                    Console.WriteLine(item.Item1 + " " + item.Item2 + " " + item.Item3);
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Input();
            Output();
            PrimAlgorithm();
            PrimRoad();
        }
    }
}
