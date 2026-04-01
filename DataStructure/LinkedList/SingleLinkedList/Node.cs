using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.SingleLinkedList
{
    public class Node
    {
        public object Element;
        public Node? Link;
        public Node()
        {

        }
        public Node(object element)
        {
            Element = element;
            Link = null;
        }
    }
    public class LinkedList
    {
         Node? header;
        public LinkedList()
        {
            header = new Node("header");
        }
        public Node Find (object item)
        {
            Node? current = header;
            while (current != null&&current.Element != item )
            {
                current = current.Link;
            }
            return current;
        }
        public void InsertAtEnd(object item)
        {
            Node node = new Node(item);
            Node current = new Node();
            current = header;
            while (current.Link != null)
                current = current.Link;
            current.Link = node;
        }
        public void Insert(object newItem,object after)//after => the newnode will be after that node
        {
            Node current = new Node();
            Node newNode = new Node(newItem);
            current = Find(after);
            newNode.Link = current.Link;
            current.Link = newNode;

        }
        public void PrintList()
        {
            Node current = new Node();
            current = header;
            while(current.Link!=null)
            {
                Console.WriteLine(current.Link.Element);
                current = current.Link;
            }
        }
        public void Remove(object item)
        {
            Node current = header;
            while (current.Link.Element != item && current.Link != null)
                current = current.Link;
            current.Link = current.Link.Link;
        }
        public int GetNodePosition(object item)
        {
            Node? current = header;
            int p = 0;
            while(current!=null)
            {
                if (current.Element == item)
                    return p;
                current = current.Link;
                p++;
            }
            return -1;
        }
        public void Reverse()
        {
            Node? ptr, prev=null, next=null;
            ptr = header;
            while(ptr!=null)
            {
                next = ptr.Link;
                ptr.Link = prev;
                prev = ptr;
                ptr = next;
            }
            header = prev;//ptr will be null
            PrintList();
        }
    }
    
    public class StackLinkedList
    {
        Node? top=null;
        public int Size()
        {
            int s = 0;
            Node current = top;
            while(current != null)
            {
                current = current.Link;
                s++;
            }
            return s;
        }
        public bool isEmpty()
        {
            if (top == null)
                return true;
            else
                return false;
        }
        public void Push(object item)
        {
            Node newItem = new Node(item);
            newItem.Link = top;
            top = newItem;
        }
        public Node Pop()
        {
            if(isEmpty())
            {
                return new Node(int.MinValue);
            }
            Node node = top;
            top = top.Link;
            return node;
        }
        public void Display()
        {
            Node p = top;
            if(isEmpty())
                Console.WriteLine("the stack is empty");
            Console.WriteLine("Stack is:");
            while (p!=null)
            {
                Console.WriteLine($"{p.Element}");
                p = p.Link;
            }
        }
    }
    public class QueueLinkedList
    {
        Node front,rear;
        public QueueLinkedList()
        {
            front = rear = null;
        }
        public bool IsEmpty()
        {
            if (front == null)
                return true;
            return false;
        }
        public void Enqueue(object item)
        {
            Node newNode = new Node(item);
            if (IsEmpty())
                front = newNode;
            else
                rear.Link = newNode;
            rear = newNode;

        }
        public Node Dequeue()
        {
            if (IsEmpty())
                return new Node(int.MinValue);
            Node node = front;
            front = front.Link;
            return node;
        }
       public void Display()
        {
            Node node = front;
            if(IsEmpty())
                Console.WriteLine("Queue is empty");
            while (node!=null)
            {
                Console.WriteLine(node.Element);
                node = node.Link;
            }
        }
    }

  
}
