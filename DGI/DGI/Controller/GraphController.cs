using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DGI.Model;

namespace DGI.Controller
{
    public class GraphController
    {
        private static GraphModel graph;
        public static GraphModel Graph { get { return graph; } }

        private static MainWindow mainWindowRef;

        public GraphController(MainWindow window)
        {
            mainWindowRef = window;
            graph = new GraphModel();
            setWorker();

        }

        #region Asynchronous, background work
        BackgroundWorker backgroundWorker;

        public void setWorker( )
        {
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.RunWorkerCompleted += worker_Completed;
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.DoWork += worker_doWork;
            backgroundWorker.ProgressChanged += worker_ProgressChanged;
            backgroundWorker.RunWorkerAsync();

        }

        private void worker_doWork(object sender, DoWorkEventArgs e)
        {
            /* w przyszłości to do zastąpienia pobeiraniem wartości z pól do wprowadzania z MainWindow */
            List<List<int>> list = new List<List<int>>();
            Random random = new Random();
            int ileElem = 3000;
            double oneProgressStep = 70 / (double)ileElem;
            for (int i = 0; i < ileElem; i++)
                list.Add(new List<int>());

            for (int i = 0; i < ileElem; i++)
            {
                for (int j = 0; j < ileElem / 2; j++)
                {
                    var a = random.Next(1, list.Count + 1);
                    if (!list[i].Contains(a)) list[i].Add(a);
                }
                if(i%20==0) backgroundWorker.ReportProgress((int)(i * oneProgressStep));
            }
            graph.SetAdjList(list);
            /* koniec kodu tymczasowego  */


            int edges = 0;
            foreach (var row in graph.AdjacencyList)
                foreach (var item in row)
                    edges++;
            graph.EdgeCount = edges;
            backgroundWorker.ReportProgress(73);


            int n = graph.AdjacencyMatrix.GetLength(0);
            double oneStep = 28 / (double)n;
            for (int i = 0; i < n; i++)
            {
                var inOutEdg = countInAndOutEdges(i);
                graph.AddVertice(i, inOutEdg.Item1, inOutEdg.Item2);

                if(i%20==0) backgroundWorker.ReportProgress(72 + (int)(oneStep * i));
            }
            backgroundWorker.ReportProgress(100);
        }

        private void worker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("\n\n\n*** KONIEC!!! ***\n\n\n");
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MainWindow.ChangeProgress(e.ProgressPercentage);
        }
        #endregion

        private Tuple<int, int> countInAndOutEdges(int row)
        {
            int inEdg = 0;
            int outEdg = 0;
            for (int i = 0; i < graph.AdjacencyMatrix.GetLength(1); i++)
            {
                if (graph.AdjacencyMatrix[row, i] == 1) outEdg++;
                if (graph.AdjacencyMatrix[i, row] == 1) inEdg++;
            }
            return Tuple.Create(inEdg, outEdg);
        }
    }
}
