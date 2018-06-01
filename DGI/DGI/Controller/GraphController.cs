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
        GraphModel graph;
        public GraphModel Graph { get { return graph; } private set { graph = value; } }

        private static MainWindow mainWindowRef;

        public GraphController(MainWindow window, List<List<int>> adjList)
        {
            mainWindowRef = window;
            graph = new GraphModel(adjList);
            SetWorker();

        }

        #region Asynchronous, background work
        BackgroundWorker backgroundWorker;

        public void SetWorker( )
        {
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.RunWorkerCompleted += Worker_Completed;
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.DoWork += Worker_doWork;
            backgroundWorker.ProgressChanged += Worker_ProgressChanged;
            backgroundWorker.RunWorkerAsync();

        }

        private void Worker_doWork(object sender, DoWorkEventArgs e)
        {
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
                var inOutEdg = CountInAndOutEdges(i);
                graph.AddVertice(i, inOutEdg.Item1, inOutEdg.Item2);

                if(i%20==0) backgroundWorker.ReportProgress(72 + (int)(oneStep * i));
            }
            backgroundWorker.ReportProgress(100);
        }

        private void Worker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("\n\n\n*** KONIEC!!! ***\n\n\n");
            backgroundWorker = null;
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MainWindow.ChangeProgress(e.ProgressPercentage);
        }
        #endregion

        private Tuple<int, int> CountInAndOutEdges(int row)
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
