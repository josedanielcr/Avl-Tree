using Application.BL;
using Application.TL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Application.UI
{
    internal class Startup
    {
        static void Main(string[] args)
        {
            BaseController Application = new BaseController();
            List<string> list = Application.executeExample();
            foreach(string item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}