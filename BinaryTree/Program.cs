using System.Threading.Channels;

namespace BinaryTree
{
    interface ITest
    {
        void Show();
        void Print() => Console.WriteLine("i am in print in an interface");
        }
    class Test:ITest
    {
        public  void Show()
        {
            Console.WriteLine("Hello");
        }
    }
    class Test3
    {
        public void Show(int x, string y)
        {
            Console.WriteLine("int, string");
        }

        public void Show(string y, int x)
        {
            Console.WriteLine("string, int");
        }
    }

    internal class Program
    {

        static void Main(string[] args)
        {
            
            Test test = new Test();
            ITest test2 = new Test();
            //BinarySearchTree tree = new BinarySearchTree();
            //tree.Put(10, "jjjjjjjjjjj");
            //tree.Put(5, "ddddddjj");
            //tree.Put(15, "jjfffffffffffffjjjj");
            //tree.Put(3, "ggggggggggggj");
            //tree.Put(8, "jttttttttttttjj");
            //tree.Put(12, "jjrrrrrrrrrrrrrrrj");
            //tree.Put(20, "jjeeeeeeeeeeeeeeej");
            //tree.PreOrder();
            //Console.WriteLine( "***********************");
            //tree.Delete(5);
            //string s1 = "Hello!";
            //string s2 = "HELLO!";

            //Console.WriteLine(s1 == s2); // False
            //Console.WriteLine( s1.Equals(s2, StringComparison.OrdinalIgnoreCase) );//true


            


        }
    }
}
