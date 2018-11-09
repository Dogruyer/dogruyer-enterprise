using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace bartex_veri.Controllers
{
    public class PlanlarController : Controller
    {

        string connect = @"Provider=Microsoft.Jet.OleDb.4.0;Data Source= C:\Users\Dogruyer_2\Desktop\oztektekstil\bartex\bartex_baglanti.mdb";
        DataTable dt = new DataTable();
        // GET: Planlar
        public ActionResult PlanlarKartNoGetir(int? id)
        {
            if (id != null)
            {
                using (var con = new OleDbConnection(connect))
                {
                    var tsql = "SELECT * From Planlar Where KartNo =" + id + " ";
                    var command = new OleDbCommand(tsql, con);
                    var da = new OleDbDataAdapter(command);
                    da.Fill(dt);
                }
            }
            return View(dt);
        }

        public ActionResult abcd(int? id)
        {
            if (id != null)
            {
                using (var con = new OleDbConnection(connect))
                {
                    var tsql = "SELECT * From Planlar Where KartNo =" + id + " ";
                    var command = new OleDbCommand(tsql, con);
                    var da = new OleDbDataAdapter(command);
                    da.Fill(dt);
                }
            }
            return View(dt);
        }


    }
}
