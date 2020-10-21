using System;
using System.IO;
using System.Web.Hosting;

namespace QUANGHANH_MANUFACTURING.Models
{
    public class MyError
    {
        public void AddError(Exception ex, params string[] input)
        {
            string fileName = HostingEnvironment.MapPath("/dist/log/ErrorLog.txt");
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName, true))
                {
                    writer.WriteLine("-----------------------------------------------------------------------------");
                    writer.WriteLine("Date : " + DateTime.Now.ToString());
                    writer.WriteLine();

                    while (ex != null)
                    {
                        writer.WriteLine(ex.GetType().FullName);
                        writer.WriteLine("Message : " + ex.Message);
                        writer.WriteLine("StackTrace : " + ex.StackTrace);
                        writer.WriteLine("Input : " + input);

                        ex = ex.InnerException;
                    }
                }
            }
            catch (Exception e)
            {
                string path = HostingEnvironment.MapPath("/dist/log");
                if (e.InnerException is DirectoryNotFoundException)
                {
                    Directory.CreateDirectory(path);
                }
                if (e.InnerException is FileNotFoundException)
                {
                    try
                    {
                        using (System.IO.File.Create(fileName)) { }
                    }
                    catch (Exception) { }
                }
            }
        }
    }
}