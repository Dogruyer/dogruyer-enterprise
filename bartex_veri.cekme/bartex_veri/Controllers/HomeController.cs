using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Threading.Tasks;
using bartex_veri.Models;
namespace bartex_veri.Controllers
{
    public class HomeController : Controller
    {
        public Array MyProperty { get; set; }

        public ActionResult Index()
        {
            var connect = @"Provider=Microsoft.Jet.OleDb.4.0;Data Source= C:\Users\Dogruyer_2\Desktop\oztektekstil\bartex\bartex_baglanti.mdb";

            DataTable dt = new DataTable();
            var unitsSQL = "SELECT * FROM Planlar";
            using (var conn = new OleDbConnection(connect))
            {
                var cmd = new OleDbCommand(unitsSQL, conn);
                var da = new OleDbDataAdapter(cmd);
                da.Fill(dt);
            }
            return View(dt);
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
    }
}