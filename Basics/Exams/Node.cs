using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exams
{
    
    public class Node
    {
        protected int Data { get; set; }
        protected int? Next { get; set; }

        protected Node(int d)
        {
            Data = d;
            Next = null;
        }
    }



    public class DNode
    {
        public int Data { get; set; }
        public int? Next { get; set; }
        public int? Prev { get; set; }

        public DNode(int d)
        {
            Data = d;
            Next = null;
            Prev = null;
        }
    }
}
