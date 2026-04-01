using LinkedList.CircularLinkedList;
using LinkedList.DoublyLinkedList;
using LinkedList.SingleLinkedList;

namespace LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Single linked list 
            // Single linked list 
            //LinkedList.SingleLinkedList.LinkedList list = new SingleLinkedList.LinkedList();
            //list.InsertAtEnd("1");
            //list.InsertAtEnd("2");
            //list.InsertAtEnd("3");
            //list.InsertAtEnd("4");
            //list.Insert("11", "1");
            //list.Insert("22", "2");
            //Console.WriteLine(list.Find("22").Element);
            //list.Remove("22");
            //list.PrintList();
            //Console.WriteLine(  );
            //Console.WriteLine(list.GetNodePosition("4"));
            //Console.WriteLine();

            //list.Reverse(); 
            #endregion
            #region StackLinkedList
            //StackLinkedList Stack = new StackLinkedList();
            //Stack.Push(1);
            //Stack.Push(2);
            //Stack.Push(3);
            //Stack.Push(4);
            //Stack.Push(55);
            //Stack.Push(555);
            //Stack.isEmpty();
            //Console.WriteLine(Stack.Size());
            //Console.WriteLine(Stack.Pop().Element);
            //Stack.Display();
            #endregion

            #region QueueLinkedList
            //QueueLinkedList queue = new QueueLinkedList();
            //queue.Enqueue(1);
            //queue.Enqueue(2);
            //queue.Enqueue(4);
            //queue.Display();
            //Console.WriteLine(queue.Dequeue().Element); 
            //Console.WriteLine(queue.Dequeue().Element); 
            //Console.WriteLine(queue.Dequeue().Element); 
            #endregion
            #region Doubly linkedList
            //DoublyList list = new DoublyList();
            //list.InsertAtBegining(1);
            //list.InsertAtBegining(2);
            //list.InsertAtBegining(3);
            //list.Display();
            //Console.WriteLine(list.Find(2).data);
            //Console.WriteLine(  );
            //list.PrintReverse();
            //list.Remove(2);
            //list.PrintReverse();

            #endregion
            #region Circularlist
            Circularlist list = new Circularlist();
            list.Insert(1);
            list.Insert(1);
            list.Insert(1);
            list.Insert(1);
            list.Insert(1);
            list.PrintList();
            #endregion
        }
    }
}
