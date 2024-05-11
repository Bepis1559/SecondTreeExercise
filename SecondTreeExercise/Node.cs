using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondTreeExercise
{
    internal class Node(int data)
    {
        public Node? Left { get; set; } = null;
        public Node? Right { get; set; } = null;
        public int Data { get; set; } = data;
    }
}
