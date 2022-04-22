using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach
{
    public class Node
    {
        public string name;
        public int workingValue;
        public int? orderOfLabelling;
        
        public Node (string name)
        {
            this.name = name;
            orderOfLabelling = null;
            workingValue = int.MaxValue;
        }
    }
}
