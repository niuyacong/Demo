using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.services
{
    public class quartzdemo:IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("execute job");
        }
    }
}