using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DGI.Controller;
using DGI.CoreClasses;

namespace DGI.Model
{
    public class GraphModel
    {
        int[,] adjMtrx;
        public int[,] AdjacencyMatrix { get { return adjMtrx; } private set { adjMtrx = value; } }

        List<List<int>> adjList;
        public List<List<int>> AdjacencyList { get { return adjList; } private set { adjList = value; } }

        int edgeCount;
        public int EdgeCount { get { return edgeCount; } set { edgeCount = value; } }

        List<VerticeModel> vertices;
        public List<VerticeModel> Vertices { get { return vertices; } }

        #region Constructors
        public GraphModel()
        {
            vertices = new List<VerticeModel>();
        }

        public GraphModel(int[,] matrix)
        {
            vertices = new List<VerticeModel>();
            adjMtrx = matrix;
            adjList = Converters.AdjacencyMatrixToList(adjMtrx);
        }

        public GraphModel(List<List<int>> list)
        {
            vertices = new List<VerticeModel>();
            adjList = list;
            adjMtrx = Converters.ListToAdjacencyMatrix(adjList);
        }

        public  static GraphModel RandomGraph(int verticesCount, int maxOutEdgeCount)
        {
            if (maxOutEdgeCount > verticesCount)
                return null;

            List<List<int>> adjacencyList = new List<List<int>>();
            int edgeCount = 0;
            int newVertice = 0;
            Random random = new Random();

            for (int i = 0; i < verticesCount; i++)
            {
                List<int> listToAdd = new List<int>();
                edgeCount = random.Next(0, maxOutEdgeCount);
                for (int j = 0; j < edgeCount; j++)
                {
                    newVertice = random.Next(0, verticesCount);
                    while (listToAdd.Contains(newVertice))
                    {
                        newVertice = random.Next(0, verticesCount);
                    }
                    listToAdd.Add(newVertice);
                }
                adjacencyList.Add(listToAdd);
            }
            return new GraphModel(adjacencyList);
        }
        #endregion

        #region Set params
        public void SetAdjList(List<List<int>> list)
        {
            this.adjList = list;
            adjMtrx = Converters.ListToAdjacencyMatrix(list);
        }

        public void SetAdjMtrx(int[,] matrix)
        {
            this.AdjacencyMatrix = matrix;
            adjList = Converters.AdjacencyMatrixToList(matrix);
        }

        public void AddVertice(int name, int inEdges, int outEdges)
        {
            vertices.Add(new VerticeModel(name, inEdges, outEdges));
        }
        #endregion
    }
}
