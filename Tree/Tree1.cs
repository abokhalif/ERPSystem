using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    internal class Tree1// without size or depth
    {
        private TreeNode root;
        public Tree1()
        {
            root = new TreeNode();
        }
        public void TreeEmpty(TreeNode root) 
        {
            root = null;
        }
        public void InOrder(TreeNode root)
        {
            InOrder(root.left);
            Console.WriteLine(root.entry.ToString());
            InOrder(root.right); 
        }


    }

}
