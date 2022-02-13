using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES2_T2.Helpers
{
    internal class FileWritter
    {
        const string path = "C:/JD-local/proyectos-universidad/Estructuras_de_datos_2/AVL-Tree/Application/UTL/Data.txt";

        public FileWritter(){}

        public void SaveData(string number)
        {
            StreamWriter sw = new StreamWriter(path,true);
            try
            {
                sw.WriteLine(number);
                sw.Close();
            } 
            catch(Exception ex)
            {
                sw.WriteLine("error!");
                sw.Close();
            }
        }

        public string ReadData()
        {
            StreamReader sr = new StreamReader(path);
            string result;
            result = sr.ReadToEnd();
            sr.Close();
            return result;
        }

        public void clearData()
        {
            StreamWriter sw = new StreamWriter(path);
            sw.Write(String.Empty);
            sw.Close();
        }
    }

}
