using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW_DM_4_1_Console
{
    public class Graph
    {
        public int[][] AdjencyMatrix { get { return _matr; } }

        private int[][] _matr;

        public Graph()
        {
            this.SetGraph();
        }

        public Graph(int[][] adjacencyMatrix)
        {
            _matr = adjacencyMatrix;
        }

        public void SetGraph()
        {
            _matr = new int[][] { new int[] { 0, 1, 2, 0, 0, 0, 0, 0},
                                  new int[] { 0, 0, 1, 5, 2, 0, 0, 0},
                                  new int[] { 0, 0, 0, 2, 1, 4, 0, 0},
                                  new int[] { 0, 0, 0, 0, 3, 6, 8, 0},
                                  new int[] { 0, 0, 0, 0, 0, 3, 7, 0},
                                  new int[] { 0, 0, 0, 0, 0, 0, 5, 2},
                                  new int[] { 0, 0, 0, 0, 0, 0, 0, 6},
                                  new int[] { 0, 0, 0, 0, 0, 0, 0, 0} };
        }

        public void SetGraph(int[][] adjacencyMatrix)
        {
            _matr = adjacencyMatrix;
        }

        public int SearchMinLength(int startIndex, int finishIndex)
        {
            // установка начальных значений
            int[] minLength = SetInfinity(_matr.Length);
            minLength[startIndex] = 0;
            bool[] visited = SetFalse(_matr.Length);

            int minVertexInd = VertexIndexWithMinimumLength(minLength, visited);
            while (minVertexInd != -1)
            {
                // из выбранной вершины (minVertex) проходимся по значениям минимального пути других вершин
                for (int i = 0; i < minLength.Length; i++)
                {
                    if (!visited[i] && Length(minVertexInd, i) > 0)
                    {
                        if (minLength[i] > minLength[minVertexInd] + Length(minVertexInd, i))
                        {
                            minLength[i] = minLength[minVertexInd] + Length(minVertexInd, i);
                        }
                    }
                }
                // отмечаем вершину как посещенную
                visited[minVertexInd] = true;
                // ищем следующую вершину, в которую пойдем
                minVertexInd = VertexIndexWithMinimumLength(minLength, visited);
            }
            return minLength[finishIndex];
        }

        private int VertexIndexWithMinimumLength(int[] minLength, bool[] visited)
        {
            int min = int.MaxValue;
            int minInd = -1;
            for (int i = 0; i < minLength.Length; i++)
            {
                if (!visited[i] && min > minLength[i])
                {
                    min = minLength[i];
                    minInd = i;
                }
            }
            return minInd;
        }

        private int Length(int startIndex, int finishIndex)
        {
            if (startIndex >= 0 && startIndex < _matr.Length && finishIndex >= 0 && finishIndex < _matr.Length)
                return _matr[startIndex][finishIndex];
            else
                throw new ArgumentOutOfRangeException("One of indexes out of range");
        }

        private int[] SetInfinity(int vertexNumber)
        {
            int[] res = new int[vertexNumber];
            for (int i = 0; i < vertexNumber; i++)
            {
                res[i] = int.MaxValue;
            }
            return res;
        }

        private bool[] SetFalse(int vertexNumber)
        {
            bool[] res = new bool[vertexNumber];
            for (int i = 0; i < vertexNumber; i++)
            {
                res[i] = false;
            }
            return res;
        }
    }
}
