using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WebApplication1.services
{
    public class LoadFile
    {
        public static string ReadFile(string path)
        {
            string text = System.IO.File.ReadAllText(@"" + path + "", Encoding.Default);
            return text;
        }
    }
}