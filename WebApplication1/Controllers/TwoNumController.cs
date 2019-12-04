using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class TwoNumController : Controller
    {
        // GET: TwoNum
        public ActionResult Index()
        {
            return View();
        }
        public int[] twoSum(int[] nums, int target = 9)
        {
            nums = new int[6] { 11, 9, 1, 2, 7, 15 };
            int indexArrayMax = 2047;
            int[] indexArrays = new int[indexArrayMax + 1];
            for (int i = 0; i < nums.Length; i++)
            {
                int diff = target - nums[i];
                int index = diff & indexArrayMax; //控制下标索引始终为正
                if (indexArrays[index] != 0)
                {
                    return new int[] { indexArrays[index] - 1, i };
                }
                indexArrays[nums[i] & indexArrayMax] = i + 1;
            }
            throw new AggregateException("No two sum value");
        }
    }
}