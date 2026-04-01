using DataStructure.Tree;

namespace DataStructure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Insert(50);
            tree.Insert(30);
            tree.Insert(70);
            tree.Insert(20);
            tree.Insert(40);
            tree.Insert(60);
            tree.Insert(80);
            tree.RemoveNode(60);
            tree.DisplayTree();

            
        }
    }
}
