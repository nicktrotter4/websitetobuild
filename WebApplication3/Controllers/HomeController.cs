using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using System.IO;
using CsvHelper;
using System.Diagnostics;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        //Client Website Demo View
        public ActionResult TestWebsite()
        {

            return View();
        }



        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file, Clients clients)
        {
            string path = null;
            List<Clients> Clientstodisplay = new List<Clients>();

            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                path = AppDomain.CurrentDomain.BaseDirectory + "upload\\" + fileName;
                file.SaveAs(path);

                var csv = new CsvReader(new StreamReader(path));
                var ClientList = csv.GetRecords<Class1>();

                foreach (var c in ClientList)
                {
                    Clients ClientToDisplay = new Clients();

                    ClientToDisplay.Name = c.Name;
                    ClientToDisplay.Phone = c.Phone;
                    ClientToDisplay.City = c.City;
                    ClientToDisplay.Zip = c.Zip;
                    ClientToDisplay.Category = c.Category;
                    ClientToDisplay.Email = c.Email;
                    ClientToDisplay.Address = c.Address;

                    Clientstodisplay.Add(ClientToDisplay);  
                }

      

                
            }

            return View(clients);
        }
    }
}