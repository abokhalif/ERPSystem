using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Tree
{
    public class Node<T> where T:IComparable<T>
    {
        public Node<T>? Left;
        public Node<T>? Right;
        public T Value;
        public Node(T val)
        {
            Value = val;
            Left = null;
            Right = null;
        }
        public void DisplayNode()
        {
            Console.WriteLine(Value);
        }

    }
    public class BinarySearchTree<T> where T:IComparable<T>
    {
        public Node<T>? Root ;
        public void Insert(T data)
        {
            Node<T> node = new Node<T>(data);
            if (Root == null) Root = node;
            else
            {
                Node<T> current = Root;
                Node<T> Parent;
                while (true)
                {
                    Parent = current;
                    if (data.CompareTo(current.Value) < 0)
                    {
                        current = current.Left;//is the most left leaf
                        if (current is null)
                        {
                            Parent.Left = node;
                            break;
                        }
                    }
                    else
                    {
                        current = current.Right;
                        if(current is null)
                        {
                            Parent.Right = node;
                            break;
                        }
                    }
                }
            }
        }
        public void InOrderTraversal(Node<T> node)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left);
                node.DisplayNode();
                InOrderTraversal(node.Right);
            }
        }

        public void DisplayTree()
        {
            Console.WriteLine("In-Order Traversal of the Tree:");
            InOrderTraversal(Root);
        }
        public Node<T> Search(T val)
        {
            Node<T> current = Root;
            while (current != null )
            {
                if (current.Value.CompareTo(val) > 0)
                {
                    current = current.Left;
                }
                else current = current.Right;
                if (current.Value.CompareTo(val) == 0)
                    break;
            }
            return current;
        }
        /// <summary>
        /// if input node == root(retunr of this method) make root =null
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public Node<T> GetParent(T val)
        {
            if (Root == null )
                return null; // Root has no parent or tree is empty.
            if ( Root.Value.CompareTo(val) == 0)
                return Root; //if deleting node == root make root =null
            Node<T> current = Root;
            Node<T> parent = null;

            while (current != null)
            {
                int comparison = current.Value.CompareTo(val);

                if (comparison > 0)
                {
                    parent = current;
                    current = current.Left; // Move left for smaller values
                }
                else if (comparison < 0)
                {
                    parent = current;
                    current = current.Right; // Move right for larger values
                }
                else
                {
                    return parent; // Value found, return its parent
                }
            }

            return null; // Value not found in the tree
        }
        public void RemoveNode(T val)
        {
            if (Root == null) return;

            Node<T> current = Root;
            Node<T> parent = null;
            bool isLeft = true;//the current isLeft to the parent

            // Find the node and its parent
            while (current != null && current.Value.CompareTo(val) != 0)
            {
                parent = current;
                if (val.CompareTo(current.Value) < 0)
                {
                    current = current.Left;
                    isLeft = true;
                }
                else
                {
                    current = current.Right;
                    isLeft = false;
                }
            }

            // If the node was not found, exit
            if (current == null) return;

            // Case 1: Node is a leaf
            if (current.Left == null && current.Right == null)
            {
                if (current == Root)
                    Root = null; // If it's the root, set the root to null
                else if (isLeft)
                    parent.Left = null;
                else
                    parent.Right = null;
            }
            // Case 2: Node has only a left child
            else if (current.Right == null)
            {
                if (current == Root)
                    Root = current.Left; // If it's the root, promote the left child
                else if (isLeft)
                    parent.Left = current.Left; // Link parent's left to current's left
                else
                    parent.Right = current.Left; // Link parent's right to current's left
            }
            // Case 3: Node has only a right child
            else if (current.Left == null)
            {
                if (current == Root)
                    Root = current.Right; // If it's the root, promote the right child
                else if (isLeft)
                    parent.Left = current.Right; // Link parent's left to current's right
                else
                    parent.Right = current.Right; // Link parent's right to current's right
            }
            // Case 4: Node has two children (not handled here)
            // Add logic for replacing the node with its in-order successor or predecessor if needed
            else
            {
                // Find the in-order successor
                Node<T> successorParent = current;
                Node<T> successor = current.Right;

                // Find the leftmost node in the right subtree (successor)

                while (successor.Left!=null)
                {
                    successorParent = successor;
                    successor = successor.Left;
                }
                current.Value = successor.Value;
                // Remove the successor node (successor can only have a right child)
                if (successorParent == current)
                    successorParent.Right = successor.Right; // Successor is directly under current
                else
                    successorParent.Left = successor.Right; // Successor is deeper in the tree
            }
        }

    }
}
