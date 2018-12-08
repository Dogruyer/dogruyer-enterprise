using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BartexAccess.Controllers
{
    public class StokController : Controller
    {
        //string connect = @"Provider=Microsoft.Jet.OleDb.4.0;Data Source=\Inetpub\vhosts\testdogruyer.duckdns.org\httpdocs\bartex_aktarma1.mdb";
        string connect = @"Provider=Microsoft.Jet.OleDb.4.0;Data Source=\Inetpub\vhosts\7houseburger.com\demo\bartex_aktarma1.mdb";
        //string connect = @"Provider=Microsoft.Jet.OleDb.4.0;Data Source=C:\Users\Dogruyer_5\Desktop\bartex_aktarma1.mdb";
        DataTable dt = new DataTable();
        [Route("Stok/Adi/{encodingType}/{tarih}")]
        public ActionResult Adi(string encodingType, string tarih)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(encodingType);
            string deger = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);

            var basTarihCevir = tarih.Replace("-", "/");
            //var cevirID = .Replace("_", " ");
            // 31 Aralık 2017 ' ye kadar olan stok Ambar 
            var tsql = "SELECT (Sum([Depoya Giren Miktar]) - Sum([Çekilen Miktar])) as StokAmbar From [dbo_Malzeme Hareketi]  Where Adı =" + "'" + deger + "' AND [Kayıt Tarihi] <= #" + basTarihCevir + "#  Group By Adı ";
            using (var conn = new OleDbConnection(connect))
            {
                var cmd = new OleDbCommand(tsql, conn);
                var da = new OleDbDataAdapter(cmd);
                da.Fill(dt);
            }

            islem.LogEkle(dt);


            string xml = System.IO.File.ReadAllText(Server.MapPath("~/kartno.xml"));
            return Content(xml, "xml");
        }
    }
}