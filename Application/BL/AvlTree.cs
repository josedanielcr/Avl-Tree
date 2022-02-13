using ES2_T2.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BL
{
    internal class AvlTree
    {
        public Node? Root;
        FileWritter fw = new FileWritter();

        public AvlTree(){}

        //checks if the root is null, if it is null just creates the root with the new node, if it is no then call RecursiveInsert
        public void Add(int data)
        {
            Node newItem = new Node(data);
            if (Root == null)
            {
                Root = newItem;
            }
            else
            {
                Root = RecursiveInsert(Root, newItem);
            }
        }

        //inserts the new Node in the same way as the binary search tree, but it calls BalanceTree.
        private Node RecursiveInsert(Node current, Node newNode)
        {
            if (current == null)
            {
                current = newNode;
                return current;
            }
            else if (newNode.Data < current.Data)
            {
                current.Left = RecursiveInsert(current.Left, newNode);
                current = BalanceTree(current);
            }
            else if (newNode.Data > current.Data)
            {
                current.Right = RecursiveInsert(current.Right, newNode);
                current = BalanceTree(current);
            }
            return current;
        }

        private Node BalanceTree(Node current)
        {
            int b_factor = BalanceFactor(current);
            if (b_factor > 1)
            {
                if (BalanceFactor(current.Left) > 0)
                {
                    current = RotateLL(current);
                }
                else
                {
                    current = RotateLR(current);
                }
            }
            else if (b_factor < -1)
            {
                if (BalanceFactor(current.Right) > 0)
                {
                    current = RotateRL(current);
                }
                else
                {
                    current = RotateRR(current);
                }
            }
            return current;
        }

        private int BalanceFactor(Node current)
        {
            int l = GetHeight(current.Left);
            int r = GetHeight(current.Right);
            int b_factor = l - r;
            return b_factor;
        }

        private int GetHeight(Node current)
        {
            int height = 0;
            if (current != null)
            {
                int l = GetHeight(current.Left);
                int r = GetHeight(current.Right);
                int m = Max(l, r);
                height = m + 1;
            }
            return height;
        }

        private int Max(int l, int r)
        {
            return l > r ? l : r;
        }
        private Node RotateRR(Node parent)
        {
            Node pivot = parent.Right;
            parent.Right = pivot.Left;
            pivot.Left = parent;
            return pivot;
        }
        private Node RotateLL(Node parent)
        {
            Node pivot = parent.Left;
            parent.Left = pivot.Right;
            pivot.Right = parent;
            return pivot;
        }
        private Node RotateLR(Node parent)
        {
            Node pivot = parent.Left;
            parent.Left = RotateRR(pivot);
            return RotateLL(parent);
        }
        private Node RotateRL(Node parent)
        {
            Node pivot = parent.Right;
            parent.Right = RotateLL(pivot);
            return RotateRR(parent);
        }

        public void InOrder(Node current)
        {
            if (current != null)
            {
                InOrder(current.Left);
                fw.SaveData(current.Data.ToString());
                InOrder(current.Right);
            }
        }

        public void PreOrder(Node current)
        {
           
            if (current != null)
            {
                fw.SaveData(current.Data.ToString());
                PreOrder(current.Left);
                PreOrder(current.Right);
            }
        }

        public void PostOrder(Node current)
        {
            if (current != null)
            {
                PostOrder(current.Left);
                PostOrder(current.Right);
                fw.SaveData(current.Data.ToString());
            }
        }
    }

}
