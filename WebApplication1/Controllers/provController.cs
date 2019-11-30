using HuaTang.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.city;
using WebApplication1.services;

namespace WebApplication1.Controllers
{
    public class provController : Controller
    {
        // GET: prov
        public ActionResult Index()
        {
            return View();
        }
        public void InsertProv()
        {
            var txt = LoadFile.ReadFile(@"F:\1.json");
            if (!string.IsNullOrEmpty(txt))
            {
                var txtnew = txt.Replace("\r", "").Replace("\n", "").Replace("\t", "");
                List<info> prov = JsonConvert.DeserializeObject<List<info>>(txtnew);
                for (int i = 0; i < prov.Count; i++)
                {
                    info provmode = prov[i];//省

                    //插入省份
                    var model = new tb_province();
                    model.provid = provmode.code;
                    model.provname = provmode.name;
                    model.state = 1;
                    DbContext.Instance.Insert<tb_province>(model);

                    for(int j=0;j<provmode.sub.Count;j++){
                         
                      

                            var citym =new tb_city();
                            citym.cityid = provmode.sub[j].code;
                            citym.cityname = provmode.sub[j].name;
                            citym.provid = provmode.code;
                            citym.provname = provmode.name;
                            citym.state = 1;
                            DbContext.Instance.Insert<tb_city>(citym);

                            //List<model> countrymodel = JsonConvert.DeserializeObject<List<model>>(provmode.sub[j].sub);
                            if (provmode.sub[j].sub != null)
                            {
                                for (int c = 0; c < provmode.sub[j].sub.Count; c++)
                                {
                                    var country = provmode.sub[j].sub[c];//县

                                    var cmodel = new tb_county();
                                    cmodel.countyid = country.code;
                                    cmodel.countyname = country.name;
                                    cmodel.cityid = provmode.sub[j].code;
                                    cmodel.cityname = provmode.sub[j].name;
                                    cmodel.state = 1;
                                    DbContext.Instance.Insert<tb_county>(cmodel);

                                }
                            }
                    }

                }
            }
        }

        public ActionResult GetProv()
        {
            var rst = new RestfulData<tb_province>();
            var prov = DbContext.Instance.List<tb_province>("where state=1");
            rst.code = 100;
            rst.result = prov;
            return Json(rst, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCity(string provid)
        {
            var rst = new RestfulData<tb_city>();
            var city = DbContext.Instance.List<tb_city>("where provid='" + provid + "' and state=1");
            rst.code = 100;
            rst.result = city;
            return Json(rst, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetTown(string cityid)
        {
            var rst = new RestfulData<tb_county>();
            var town = DbContext.Instance.List<tb_county>("where cityid='" + cityid + "' and state=1");
            rst.code = 100;
            rst.result = town;
            return Json(rst, JsonRequestBehavior.AllowGet);
        }

     
    }
}