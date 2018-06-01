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

            result += stopwatch.ElapsedMilliseconds / 1000;
            return result;
        }


    }
}
