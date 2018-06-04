using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using DGI.CoreClasses;
using DGI.Model;

namespace DGI.Controller
{
    /// <summary>
    /// Klasa służąca do przechowywania operacji na grafach.
    /// Dla wszystkich operacji mierzony jest czas wykonywania 
    /// </summary>
    public class GraphOperation
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="G1"></param>
        /// <param name="G2"></param>
        /// <param name="current"></param>
        /// <param name="used">Vertices from G2 assigned to G1</param>
        /// <returns></returns>
        public static bool IsBijective(GraphModel G1, GraphModel G2, int current, bool[] used, List<int> newOrder, ref int a)
        {
            for (int i = 0; i < G2.Vertices.Count; i++)
            {
                if (current >= G1.Vertices.Count)
                {
                    a++; //do wywalenia
                    List<List<int>> outcome = Converters.NewAdjacencyListOrder(newOrder, G2.AdjacencyList);
                    if (CompareTwoLists(outcome, G1.AdjacencyList)) return true;
                    else return false;
                }

                if (G1.Vertices[current] == G2.Vertices[i])
                {
                    if (used[i] == false)
                    {
                        used[i] = true;
                        newOrder.Add(i);
                        bool isTrue = IsBijective(G1, G2, current + 1, used, newOrder, ref a);
                        newOrder.RemoveAt(newOrder.Count - 1);
                        if (isTrue) return true;
                        else used[i] = false;
                    }
                }
            }
            return false;
        }

        private static bool CompareTwoLists(List<List<int>> list1, List<List<int>> list2)
        {
            foreach (var item in list2)
                item.Sort();
            foreach (var item in list1)
                item.Sort();

            for (int i = 0; i < list1.Count; i++)
            {
                List<int> sublist1 = list1[i];
                List<int> sublist2 = list2[i];
                if (sublist1.Count != sublist2.Count) return false;
                for (int j = 0; j < sublist1.Count; j++)
                    if (sublist1[j] != sublist2[j]) return false;
            }
            return true;
        }
        /// <summary>
        /// Delegat dla operacji na grafach.
        /// Wszystkie operacje na grafach będą się wykonywać asynchronicznie.
        /// </summary>
        /// <param name="graph_1"></param>
        /// <param name="graph_2"></param>
        /// <returns></returns>
        public delegate Task Operation(GraphModel graph_1, GraphModel graph_2);

        private const string GRAPH_OPERATION_RESULT = "Obliczenia trwały: ";
        private Operation graphOperation;
        private Stopwatch stopwatch;

        public GraphOperation(Operation graphOperation)
        {
            this.graphOperation = graphOperation;
        }

        public async Task<string> Run(GraphModel graph_1, GraphModel graph_2)
        {
            string result = GRAPH_OPERATION_RESULT;
            stopwatch.Start();

            await graphOperation(graph_1, graph_2);

            stopwatch.Stop();

            result += stopwatch.ElapsedMilliseconds;
            return result;
        }


    }
}
