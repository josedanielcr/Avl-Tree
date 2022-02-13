using Application.BL;
using ES2_T2.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TL
{
    internal class AvlTreeController
    {
        private AvlTree tree;
        private FileWritter fw;
        public AvlTreeController() {
            tree = new AvlTree();
            fw = new FileWritter();
        }

        public void Insert(int pNumber)
        {
            tree.Add(pNumber);
        }

        public string genericOrder(int Type)
        {
            string result = "";
            switch (Type)
            {
                case 1:
                    fw.SaveData("InOrder");
                    tree.InOrder(tree.Root);
                    break;
                case 2:
                    fw.SaveData("PreOrder");
                    tree.PreOrder(tree.Root);
                    break;
                case 3:
                    fw.SaveData("PostOrder");
                    tree.PostOrder(tree.Root);
                    break;
            }
            result = fw.ReadData();
            fw.clearData();
            return result;
        }

    }
}
