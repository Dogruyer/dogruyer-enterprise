using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BartexAccess.Controllers
{
    public class OpsController : Controller
    {
        //string connect = @"Provider=Microsoft.Jet.OleDb.4.0;Data Source=\Inetpub\vhosts\7houseburger.com\demo\bartex_aktarma.mdb";
        string connect = @"Provider=Microsoft.Jet.OleDb.4.0;Data Source=C:\Users\Dogruyer_5\Desktop\bartex_aktarma.mdb";
        DataTable dt = new DataTable();
        [Route("Ops/SipNo/{id}")]
        public ActionResult SipNo(string id)
        {
            if (id != null)
            {
                using (var con = new OleDbConnection(connect))
                {
                    var cevirID = id.Replace("-", "/");
                    var tsql = "SELECT OpPlanNo, SipNo, OpSiraNo, Operasyon, Açıklama as Aciklama, pri From dbo_Ops Where SipNo =" + "'" + cevirID + "'" + " ";
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