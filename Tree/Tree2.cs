using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    internal class Tree2// with size or depth
    {
        TreeNode root;
        int size;
        int depth;
        public Tree2()
        {
            root = new TreeNode();
            size = 0;
            depth = 0;
                
        }
        public void TreeEmpty(TreeNode root)
        {
            root = null;
            size = 0;
            depth = 0;
        }
        public void InOrder(TreeNode root)
        {
            InOrder(root.left);
            Console.WriteLine(root.entry.ToString());
            InOrder(root.right);
        }
    }
}
