using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.CircularLinkedList
{
    public class Node
    {
         public Node Link;
        public object Data;
        public Node()
        {
            Link = null;
            Data = null;
        }
        public Node(object o)
        {
            Data = o;
            Link = null;
        }
    }
    public class Circularlist
    {
        Node Last = new Node();
        public void Insert(object data)
        {
            Node node = new Node(data);
            if(Last.Link==null)
            {
                Last = node;
                Last.Link = node;
            }
            else
            {
                node.Link = Last.Link;
                Last.Link = node;
                Last = node;
            }
        }
        public void PrintList()
        {
            Node ptr = Last.Link;
           
                while (ptr.Link != Last.Link)
                {
                    Console.WriteLine(ptr.Data);
                    ptr = ptr.Link;
                }
            Console.WriteLine(Last.Data);

        }

    }
}
