using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TL
{
    internal class BaseController
    {
        private AvlTreeController treeController = new AvlTreeController();

        public BaseController() { }

        public List<String> executeExample() 
        {
            List<String> result = new List<String>();
            AddHomeworkVaues();
            try
            {
                for(int i = 1; i <= 3; i++)
                {
                    result.Add(treeController.genericOrder(i));
                }
            }catch (Exception ex)
            {
                result = null;
            }
            return result;
        }

        public void AddHomeworkVaues()
        {
            treeController.Insert(7);
            treeController.Insert(14);
            treeController.Insert(28);
            treeController.Insert(5);
            treeController.Insert(9);
            treeController.Insert(8);
            treeController.Insert(21);
            treeController.Insert(3);
            treeController.Insert(15);
            treeController.Insert(24);
            treeController.Insert(100);
            treeController.Insert(1);
        }
    }
}
