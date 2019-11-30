using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.city
{
    public class tb_city
    {
        public int id { get; set; }
        public string cityid { get; set; }
        public string cityname { get; set; }
        public string provid { get; set; }
        public string provname { get; set; }
        public int state { get; set; }
    }
}