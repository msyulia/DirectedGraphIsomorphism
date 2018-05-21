using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DGI.CoreClasses;

namespace DGI.Model
{
    public class GraphModel
    {
        int[,] adjMtrx;
        List<List<int>> adjList;
        int edgeCount;
        List<VerticeModel> vertices;
        public GraphModel(int[,] matrix)
        {
            adjMtrx = matrix;
            adjList = Converters.AdjacencyMatrixToList(adjMtrx);
            setWorker();
        }
        public GraphModel(List<List<int>> list)
        {
            adjList = list;
            adjMtrx = Converters.ListToAdjacencyMatrix(adjList);
            setWorker();
        }


        #region Asynchronous, background work
        BackgroundWorker backgroundWorker;

        public void setWorker()
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

        }

        private void worker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }
        #endregion
    }
}
