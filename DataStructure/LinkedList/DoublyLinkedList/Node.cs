using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LinkedList.DoublyLinkedList
{
    public class Node
    {
        public object data;
        public Node prev;
        public Node next;
        public Node()
        {
            data = null;
            prev = next = null;
        }
        public Node(object o)
        {
            data = o;
            prev = next = null;
        }
    }
    public class DoublyList
    {
        public Node head;
        public DoublyList()
        {
            head = null;
        }
        public void Display()
        {
          
            Node current = head;
            while (current != null)
            {
                Console.WriteLine(current.data);
                current = current.next;
            }
        }
        public Node Find(object o)
        {
            Node current = head;
            while(current!=null)
            {
                if (current.data.Equals(o)) 
                    return current;
                current = current.next;
            }
            return null;
        }
        public void InsertAtBegining(object o)
        {
            Node temp = new Node(o);
            if (head == null)
            {
                head = temp;
            }
            else
            {
                temp.next = head;
                head.prev = temp;
                head = temp;

            }
           
        }
        public void Remove(object o)
        {
            Node ptr = Find(o);
            if(ptr!=null)
            {
                ptr.prev.next = ptr.next;
                ptr.next.prev = ptr.prev;
                ptr.next = null;
                ptr.prev = null;
            }
        }
        public Node FindLast()
        {
            Node current = head;
            while (current.next != null)
                current = current.next;
            return current;
        }
       
        public void PrintReverse()
        {
            Node ptr = FindLast();
            while (ptr.prev != null)
            {
                Console.WriteLine(ptr.data);
                ptr = ptr.prev;
            }
        }


    }
}
