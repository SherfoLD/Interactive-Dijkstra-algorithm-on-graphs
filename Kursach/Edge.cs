using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach
{
    public class Edge
    {
        public Node edgeFrom;
        public Node edgeTo;
        public int edgeWeight;

        public Edge (Node edgeFrom, Node edgeTo, int edgeWeight)
        {
            this.edgeFrom = edgeFrom;
            this.edgeTo = edgeTo;
            this.edgeWeight = edgeWeight;
        }
    }
}
