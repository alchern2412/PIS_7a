using System;
using System.IO;
using System.Web.Hosting;
using System.Web.Mvc;

namespace lab7a_new.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ContentResult Home()
        {
            using (FileStream fstream = System.IO.File.OpenRead(HostingEnvironment.MapPath(@"~/App_Data/Dictionary.html")))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                Console.WriteLine($"Текст из файла: {textFromFile}");

                //return File(array, "application/file", "template.html");
                return new ContentResult
                {
                    ContentType = "text/html",
                    Content = textFromFile
                };
            }
            //byte[] toBytes = Encoding.Unicode.GetBytes(htmlTextView);



            
        }
    }
}
