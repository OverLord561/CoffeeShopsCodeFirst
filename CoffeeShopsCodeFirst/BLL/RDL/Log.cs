using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace CoffeeShopsCodeFirst.BLL.RDL
{
    public static class Log
    {
        public static void Write(Exception exception)
        {
            string logfile = String.Empty;
            string strPhysicalFolder = HttpContext.Current.Server.MapPath("..\\");
        
                logfile = strPhysicalFolder + "Errors\\ErrorLog.txt";
            try
            {

                if (File.Exists(logfile))
                {
                    using (var writer = new StreamWriter(logfile, true))
                    {
                        writer.WriteLine(
                            "=>{0} An Error occurred: {1} '\n'Message: {2}{3}",
                            DateTime.Now,
                            exception.StackTrace,
                            exception.Message,
                            Environment.NewLine
                            );
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}