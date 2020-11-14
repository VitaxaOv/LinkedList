using System;
using System.Collections.Generic;
using System.Text;

namespace DataDataStructures.LL
{
    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }

        public Node()
        {
            Next = null;
        }

        public Node(int value)
        {
            Value = value;
            Next = null;
        }
    }
}