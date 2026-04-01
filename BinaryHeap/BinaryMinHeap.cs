using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeap
{
    /*
     Index rules:
    Parent → (i - 1) / 2
    Left child → 2i + 1
    Right child → 2i + 2
    Built-in: PriorityQueue<TElement, TPriority>
    Uses
    ✅ Task scheduling
    ✅ Job queues
    ✅ Pathfinding algorithms (Dijkstra, A*)
    ✅ Load balancing
     */
    internal class BinaryMinHeap<T>//smallest priority comes first
    {
        private readonly List<(T Item, int Priority)> heap;
        public BinaryMinHeap()
        {
            heap = new List<(T, int)>();
        }
        public void Print()
        {
            int i = 0;
            while (i < heap.Count)
            {
                Console.WriteLine($"the Item= '{heap[i].Item}'' and the priority={heap[i].Priority}");
                i++;
            }

        }
        public int Count { get { return heap.Count; } }
        public void Enqueue(T item, int priority)
        {
            heap.Add((item, priority));
            HeapifyUp(heap.Count - 1);
        }
        public T Dequeue()
        {
            if (heap.Count == 0)
                throw new InvalidOperationException("Heap is empty");
            var returnValue = heap[0].Item;// the root item
            heap[0] = heap[^1];// move the last item to the root 
            heap.RemoveAt(heap.Count - 1);
            HeapifyDown(0);

            return returnValue;
        }



        private void HeapifyDown(int index)
        {
            int last = heap.Count - 1;
            while (true)
            {
                int leftChild = 2 * index + 1;
                int rightChild = 2 * index + 2;
                int smallest = index;//[0]
                if (leftChild <= last && heap[smallest].Priority > heap[leftChild].Priority)
                    smallest = leftChild;
                if (rightChild <= last && heap[smallest].Priority > heap[rightChild].Priority)
                    smallest = rightChild;
                if (smallest == index)//case the heap have one item
                    break;
                Swap(index, smallest);
                index = smallest;
            }
        }

        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parentIndex = (index - 1) / 2;
                if (heap[index].Priority <= heap[parentIndex].Priority)
                {
                    Swap(index, parentIndex);
                }
                index = parentIndex;
            }
        }
        private void Swap(int i, int j)
        {
            (heap[i], heap[j]) = (heap[j], heap[i]);
        }
        public T Peek()
        {
            return heap.Count() != 0 ? heap[0].Item : throw new InvalidOperationException("Heap is empty");
        }
        public void TestHeap()
        {
            BinaryMinHeap<string> binary = new BinaryMinHeap<string>();
            binary.Enqueue("Hello", 5);
            binary.Enqueue("He", 7);
            binary.Enqueue("tttto", 6);
            //binary.Enqueue("tttto", 22);
            //binary.Enqueue("Hdddo", 8);
            //binary.Enqueue("Hwwwo", 6);
            //binary.Enqueue("rrrro", 1);
            //binary.Enqueue("tttto", 12);
            //binary.Enqueue("qqqqo", 17);
            //binary.Enqueue("tttto", 7);
            //binary.Enqueue("tttto", 3);

            Console.WriteLine(binary.Count);
            Console.WriteLine(binary.Peek());
            binary.Print();
            binary.Dequeue();
            //binary.Dequeue();
            //binary.Dequeue();
            Console.WriteLine("******************************");
            binary.Print();
        }
    }
}
