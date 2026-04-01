using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    internal class TreeNode
    {
        public int Key { get; set; }
        public string Payload { get; set; }
        public TreeNode? LeftChild { get; set; } = null;
        public TreeNode? RightChild { get; set; } = null;
        public TreeNode? Parent { get; set; } = null;
        public TreeNode(int key,string payload , TreeNode? leftChild=null, TreeNode? rightChild=null,TreeNode? parent=null )
        {
            Key = key;
            Payload = payload;
            LeftChild = leftChild;
            RightChild = rightChild;
            Parent = parent;
        }
        public TreeNode? ReturnedLeftChild()=> this.LeftChild;
        public TreeNode? ReturnedRightChild()=> this.RightChild;
        public bool HasLeftChild() => this.LeftChild!=null;
        public bool HasRightChild() => this.RightChild!=null;
        public bool IsLeftChild()=> (this.Parent!=null) && (this.Parent.LeftChild == this);
        public bool IsRightChild()=> (this.Parent!=null) && (this.Parent.RightChild == this);
        public bool IsRoot()=> this.Parent == null;
        public bool IsLeaf()=> (this.LeftChild==null)||(this.RightChild==null);
        public bool HasAnyChildren()=>(this.LeftChild!=null)||(this.RightChild!=null);
        public bool HasBothChildren()=>(this.LeftChild!=null)&&(this.RightChild!=null);
        public void ReplaceNodeData(int key, string payload , TreeNode leftChild, TreeNode rightChild)
        {
            Key= key; 
            Payload= payload;
            LeftChild = leftChild;
            RightChild = rightChild;
            if (this.HasLeftChild!=null)
                
                this.LeftChild.Parent = this;
            if (this.HasRightChild!=null)
                this.RightChild.Parent = this;
        }

    }
}
