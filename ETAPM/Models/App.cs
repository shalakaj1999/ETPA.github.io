using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace ETAPM.Models
{
    public class App
    {
        public static string GetShortFileName(string Prefix, char Separator = '_')
        {
            string name = string.Format("{0}{1}{2:yyyyMMdd}{1}{2:hhmmssffff}", Prefix, Separator, DateTime.Now);
            Thread.Sleep(1);
            return name;
        }
    }
}