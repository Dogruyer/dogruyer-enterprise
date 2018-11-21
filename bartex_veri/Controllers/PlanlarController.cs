using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
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
                    islem.LogEkle(dt);                
                }
            }
            string xml = System.IO.File.ReadAllText(Server.MapPath("~/kartno.xml"));               
            return Content(xml,"xml");
        }


        //GÜN/AY/YIL FORMATINDA GİR ÖNEMLİ!!!

        [Route("Planlar/Tarih/{belirlenenTarih}")]
        public ActionResult Tarih(string belirlenenTarih)
        {
            var tarihCevir = belirlenenTarih.Replace("-", ".");
            var tsql = "SELECT * From Planlar Where İsletmeTarih LIKE '" + tarihCevir + "%" + "'";
            using (var con = new OleDbConnection(connect))
            {
                var command = new OleDbCommand(tsql, con);
                var da = new OleDbDataAdapter(command);
                da.Fill(dt);
                islem.LogEkle(dt);
            }
            string xml = System.IO.File.ReadAllText(Server.MapPath("~/kartno.xml"));
            return Content(xml, "text/xml");
        }



        //ay/gün/yıl FORMATINDA GİR ÖNEMLİ!!!

        [Route("Planlar/TarihAraligi/{baslangic}/{bitis}")]
        public ActionResult BelirlenenTarihlerArasi(string baslangic, string bitis)
        {
            var basTarihCevir = baslangic.Replace("-", "/");
            var bitisTarihCevir = bitis.Replace("-", "/");
            var tsql = "SELECT * From Planlar Where İsletmeTarih Between #" + basTarihCevir + "# And #" + bitisTarihCevir + "#";
            using (var con = new OleDbConnection(connect))
            {
                var command = new OleDbCommand(tsql, con);
                var da = new OleDbDataAdapter(command);
                da.Fill(dt);
                islem.LogEkle(dt);
            }
            string xml = System.IO.File.ReadAllText(Server.MapPath("~/kartno.xml"));
            return Content(xml, "text/xml");
        }
    }
}
