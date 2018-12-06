using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BartexAccess.Controllers
{
    public class PrgController : Controller
    {
        string connect = @"Provider=Microsoft.Jet.OleDb.4.0;Data Source=\Inetpub\vhosts\7houseburger.com\demo\bartex_aktarma1.mdb";
        //string connect = @"Provider=Microsoft.Jet.OleDb.4.0;Data Source=C:\Users\Dogruyer_5\Desktop\bartex_aktarma.mdb";
        DataTable dt = new DataTable();
        [Route("Prg/SipNo/{id}")]
        public ActionResult SipNo(string id)
        {
            if (id != null)
            {
                using (var con = new OleDbConnection(connect))
                {
                    var cevirID = id.Replace("-", "/");
                    var tsql = "SELECT Tarih, SipNo, İştar as Istar, Yazılış as Yazilis From dbo_Prg Where SipNo =" + "'" + cevirID + "'" + " ";
                    var command = new OleDbCommand(tsql, con);
                    var da = new OleDbDataAdapter(command);
                    da.Fill(dt);
                    islem.LogEkle(dt);
                }
            }
            string xml = System.IO.File.ReadAllText(Server.MapPath("~/kartno.xml"));
            return Content(xml, "xml");
        }
    }
}