using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DGI.Controller;
using DGI.Model;

namespace DGI.CoreClasses
{
    public static class GraphCompare
    {
        private static Stopwatch stopWatch;
        private static BackgroundWorker backgroundWorker;

        private static GraphModel graph1;
        private static GraphModel graph2;

        private static bool checkingResult;

        private static double progressVal;
        private static int progressTimes;

        public static void AreBijective(GraphController gc1, GraphController gc2)
        {
            stopWatch = new Stopwatch();
            stopWatch.Start();
            graph1 = gc1.Graph;
            graph2 = gc2.Graph;
            checkingResult = false;

            progressTimes = 1;
            progressVal = 95 / (double) graph1.EdgeCount;


            backgroundWorker = new BackgroundWorker();
            backgroundWorker.RunWorkerCompleted += worker_Completed;
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.DoWork += worker_startCheckingIfBijective;
            backgroundWorker.ProgressChanged += worker_ProgressChanged;
            backgroundWorker.RunWorkerAsync();
        }

        private static void worker_startCheckingIfBijective(object sender, DoWorkEventArgs e)
        {
            if (graph1.EdgeCount != graph2.EdgeCount || graph1.AdjacencyList.Count != graph2.AdjacencyList.Count)
            {
                checkingResult = false;
                backgroundWorker.ReportProgress(100);
                return;
            }
            backgroundWorker.ReportProgress(5);
            checkingResult = areBijective(graph1, graph2, 0, new bool[graph2.AdjacencyList.Count], new List<int>());
            backgroundWorker.ReportProgress(100);
            
        }

        private static void worker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            stopWatch.Stop();
            Console.WriteLine("Wszystko zajęło: " + stopWatch.ElapsedMilliseconds + " ms\nWynik: " + checkingResult);
            // stopWatch = null;
            backgroundWorker = null;
        }

        private static void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //MainWindow.ChangeProgresDupy(e.ProgressPercentage);
            // if(progressTimes%10 ==0) Console.WriteLine("Reportuje progres {0}", progressTimes);
        } 


        private static bool areBijective(GraphModel G1, GraphModel G2, int current, bool[] used, List<int> newOrder)
        {
            backgroundWorker.ReportProgress(5 + (int)(progressVal * progressTimes));
            progressTimes++;
            for (int i = 0; i < G2.Vertices.Count; i++)
            {
                if (current >= G1.Vertices.Count)
                {
                    List<List<int>> outcome = Converters.NewAdjacencyListOrder(newOrder, G2.AdjacencyList);
                    if (compareTwoAdjLists(outcome, G1.AdjacencyList)) return true;
                    else return false;
                }

                if (G1.Vertices[current] == G2.Vertices[i])
                {
                    if (used[i] == false)
                    {
                        used[i] = true;
                        newOrder.Add(i);
                        bool isTrue = areBijective(G1, G2, current + 1, used, newOrder);
                        newOrder.RemoveAt(newOrder.Count - 1);
                        if (isTrue) return true;
                        else used[i] = false;
                    }
                }
            }
            return false;
        }

        private static bool compareTwoAdjLists(List<List<int>> list1, List<List<int>> list2)
        {
            backgroundWorker.ReportProgress(5 + (int)(progressVal * progressTimes));
            progressTimes++;
            foreach (var item in list2) item.Sort();
            foreach (var item in list1) item.Sort();

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
    }
}
