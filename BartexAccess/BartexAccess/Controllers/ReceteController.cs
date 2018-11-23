using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BartexAccess.Controllers
{
    public class ReceteController : Controller
    {
        string connect = @"Provider=Microsoft.Jet.OleDb.4.0;Data Source=\Inetpub\vhosts\7houseburger.com\demo\bartex_aktarma1.mdb";
        //string connect = @"Provider=Microsoft.Jet.OleDb.4.0;Data Source=C:\Users\Dogruyer_5\Desktop\bartex_aktarma.mdb";
        DataTable dt = new DataTable();
        [Route("Recete/DesenVaryant/{sorgu}")]
        public ActionResult DesentVaryant(string sorgu)
        {
            var bas = sorgu.Split('-')[0];
            var bit = sorgu.Split('-')[1];

           

            var tsql = "SELECT Adi From dbo_Reçete Where DesenNo ="+ bas.ToString()+" "+" AND VaryantNo='"+bit+"'";
            using (var conn = new OleDbConnection(connect))
            {
                var cmd = new OleDbCommand(tsql, conn);
                var da = new OleDbDataAdapter(cmd);
                da.Fill(dt);
            }
            islem.LogEkle(dt);

            string xml = System.IO.File.ReadAllText(Server.MapPath("~/kartno.xml"));
            return Content(xml, "text/xml");
        }
    }
}