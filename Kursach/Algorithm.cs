using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach
{
    public class Algorithm
    {

        public Algorithm(Node[] nodes, Edge[] edges, Node startNode, Node endNode)
        {
            ApplyDijkstra(nodes, edges, startNode, endNode);
        }

        public void ApplyDijkstra(Node[] nodes, Edge[] edges, Node startNode, Node endNode)
        {
            Node end = endNode;
            Node start = startNode;
            Node currentNode = start;
            currentNode.workingValue = 0;
            currentNode.orderOfLabelling = 1;
            int labelCount = 2;
            int nodeCount = nodes.Count();
            bool loop = true;
            while (loop)
            {
                foreach (Edge edge in edges)
                {
                    if (edge.edgeFrom == currentNode)
                    {
                        if (edge.edgeTo.workingValue > (currentNode.workingValue + edge.edgeWeight))
                        {
                            edge.edgeTo.workingValue = currentNode.workingValue + edge.edgeWeight;
                        }
                    }
                }
                int minWorkingValue = int.MaxValue;
                Node nextNode = currentNode;
                foreach (Node node in nodes)
                {
                    if (node.workingValue < minWorkingValue && node.orderOfLabelling == null)
                    {
                        minWorkingValue = node.workingValue;
                        nextNode = node;
                    }
                }
                currentNode = nextNode;
                nextNode.orderOfLabelling = labelCount;
                if (labelCount == nodeCount)
                {
                    loop = false;
                }
                labelCount++;
            }
            GetPath(nodes, edges, start, end);
        }

        public string result;

        public void GetPath(Node[] nodes, Edge[] edges, Node start, Node end)
        {
            Node currentNode = end;
            bool loop = true;
            List<Node> finalPath = new List<Node>();
            finalPath.Add(currentNode);
            int totalWeight = 0;

            while (loop)
            {
                List<Edge> relatedPaths = new List<Edge>();
                bool found = false;
                int pathCount = 0;
                while (!found)
                {
                    Edge currentPath = edges[pathCount];
                    if (currentPath.edgeTo == currentNode)
                    {
                        if (currentNode.workingValue - currentPath.edgeWeight == currentPath.edgeFrom.workingValue)
                        {
                            finalPath.Add(currentPath.edgeFrom);
                            totalWeight += currentPath.edgeWeight;
                            currentNode = currentPath.edgeFrom;
                            found = true;
                        }
                        else
                        {
                            pathCount++;
                        }
                    }
                    else
                    {
                        pathCount++;
                    }
                }
                if (currentNode == start)
                {
                    loop = false;
                }
            }
            finalPath.Reverse();
            string[] finalPathStrings = new string[finalPath.Count];
            for (int n = 0; n < finalPath.Count; n++)
            {
                finalPathStrings[n] = finalPath[n].name;
            }

            result = "Dijkstra Completed.\r\nFastest Route: " + string.Join(" -> ", finalPathStrings) + "\r\nPath Weight: " + totalWeight.ToString();
        }
    }
}
