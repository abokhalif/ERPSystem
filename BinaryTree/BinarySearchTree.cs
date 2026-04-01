using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BinaryTree
{
    internal class BinarySearchTree
    {
        public TreeNode? Root { get; set; }
        public int Size { get; set; }
        public BinarySearchTree()
        {
            Root = null;
            Size = 0;
        }
        public int Length() =>Size;
        public void Put(int key,string payload)
        {
            if (Root is not null)
                _put(key, payload,Root);            
            else
                Root =new TreeNode(key,payload);
            Size++;
            
        }

        private void _put(int key, string payload, TreeNode currentNode)
        {
            if (key < currentNode.Key)
            {
                if (currentNode.HasLeftChild())
                    _put(key, payload, currentNode.LeftChild);
                else
                    currentNode.LeftChild = new TreeNode(key, payload);
            }
            else
            {
                if (currentNode.HasRightChild())
                    _put(key, payload, currentNode.RightChild);
                else
                    currentNode.RightChild = new TreeNode(key, payload);
            }

        }

        public string Get(int key)
        {
           if(Root is not null)
            {
                TreeNode? res=_get(key,Root);
                if (res == null)
                    return "not found";
                return res.Payload.ToString();
            }
            return "not found";

        }
        public TreeNode? _get(int key,TreeNode? node)
        {
            if(node is null)
                return null;
            else if (key < node.Key)
                return _get(key, node.LeftChild);
            else if (key > node.Key)
                return _get(key, node.RightChild);
            else 
                return node;



        }

        public void InOrder()
        {
            _InOrder(Root);
        }
        public void PreOrder()
        {
            _preOrder(Root);
        }
        private void _preOrder(TreeNode node)
        {
            if (node != null)
            {
                Console.Write(node.Key + " ");
                _preOrder(node.LeftChild);
                _preOrder(node.RightChild);
            }
        }
        private void _InOrder(TreeNode node)
        {
            if (node != null)
            {
                _InOrder(node.LeftChild);
                Console.Write(node.Key + " ");
                _InOrder(node.RightChild);
            }
        }
        public void Delete(int key)
        {
            // find the treenode
            TreeNode node = _get(key, Root);
            if (node is null)
                return;
            // case 1 => if the node is the root 
            if(Root?.Key== key)
                Root=null;


            // case3 => node has both child , we will search about the next large key
            if(node.HasBothChildren())
            {
                TreeNode succ = node.RightChild;
                TreeNode p = node;
                while(succ.HasLeftChild())
                    succ = succ.LeftChild;
                //node.Key = succ.Key;
                //node.Payload = succ.Payload;
                node.ReplaceNodeData(succ.Key, succ.Payload, succ.LeftChild, succ.RightChild);
                node = succ;

            }    
            // case 2=> if the node is a leaf
            if (node.IsLeaf())
            {
                if(node.IsLeftChild())
                    node.Parent.LeftChild = null;
                else
                    node.Parent.RightChild=null;
            }
            // case 3 => if the node has single child
            else if(node.HasAnyChildren())
            {
                if(node.IsLeftChild())
                {
                    if(node.HasLeftChild())
                    {
                        node.LeftChild.Parent = node.Parent;
                        node.Parent.LeftChild = node.LeftChild;
                    }
                    else if(node.HasRightChild())
                    {
                        node.RightChild.Parent = node.Parent;
                        node.Parent.LeftChild = node.RightChild;
                    }
                    else // if the node has no parent ,it is the root ,we just replace the root with the left child
                    {
                        node.ReplaceNodeData(node.LeftChild.Key, node.LeftChild.Payload, node.LeftChild.LeftChild, node.LeftChild.RightChild);

                    }
                    
                }
                else if (node.IsRightChild())
                {
                    if (node.HasLeftChild())
                    {
                        node.LeftChild.Parent = node.Parent;
                        node.Parent.RightChild = node.LeftChild;
                    }
                    else if (node.HasRightChild())
                    {
                        node.RightChild.Parent = node.Parent;
                        node.Parent.RightChild = node.RightChild;
                    }
                    else // if the node has no parent ,it is the root ,we just replace the root with the right child
                    {
                        node.ReplaceNodeData(node.RightChild.Key, node.RightChild.Payload, node.RightChild.LeftChild, node.RightChild.RightChild);

                    }

                }
            }


        }

    }
}
