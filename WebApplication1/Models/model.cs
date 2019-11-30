using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class model
    {
        public string name { get; set; }
        public string code { get; set; }
    }
    public class subs
    {
        public string name { get; set; }
        public string code { get; set; }
        public List<model> sub { get; set; }
    }
    public class info
    {
        public string name { get; set; }
        public string code { get; set; }
        public List<subs> sub { get; set; }
    }

    public class infomodel
    {
        public string name { get; set; }
        public string code { get; set; }
        public List<model> sub { get; set; }
    }
}