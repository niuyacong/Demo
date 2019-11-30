using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.city
{
    public class tb_county
    {
        public int id { get; set; }
        public string countyid { get; set; }
        public string countyname { get; set; }
        public string cityid { get; set; }
        public string cityname { get; set; }
        public int state { get; set; }
    }
}