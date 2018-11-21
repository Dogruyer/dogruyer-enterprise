using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BartexAccess.Controllers
{
    public class PlanlarController : Controller
    {
        // user id=hous7086; password=6a7a5a3ebdT; database=bartex_aktarma.mdb;Persist Security Info=False

        DataTable dt = new DataTable();
        string connect = @"Provider=Microsoft.Jet.OleDb.4.0;Data Source=\Inetpub\vhosts\7houseburger.com\demo\bartex_aktarma.mdb";

        // GET: Planlar
        [Route("Planlar/SipNo/{id}")]
        public ActionResult SipNo(string id)
        {

            if (id != "")
            {


                var cevirID = id.Replace("-", "/");
                var tsql = "SELECT * From Planlar Where SipNo =" + "'" + cevirID + "'" + " ";
                using (var conn = new OleDbConnection(connect))
                {
                    var cmd = new OleDbCommand(tsql, conn);
                    var da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);
                }
                islem.LogEkle(dt);


            }
            string xml = System.IO.File.ReadAllText(Server.MapPath("~/kartno.xml"));
            return Content(xml, "xml");
        }


        //GÜN/AY/YIL FORMATINDA GİR ÖNEMLİ!!!

        [Route("Planlar/Tarih/{belirlenenTarih}")]
        public ActionResult Tarih(string belirlenenTarih)
        {
            var tarihCevir = belirlenenTarih.Replace("-", ".");
            var tsql = "SELECT * From Planlar Where İsletmeTarih LIKE '" + tarihCevir + "%" + "'";
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



        //ay/gün/yıl FORMATINDA GİR ÖNEMLİ!!!

        [Route("Planlar/TarihAraligi/{baslangic}/{bitis}")]
        public ActionResult BelirlenenTarihlerArasi(string baslangic, string bitis)
        {
            var basTarihCevir = baslangic.Replace("-", "/");
            var bitisTarihCevir = bitis.Replace("-", "/");
            var tsql = "SELECT * From Planlar Where İsletmeTarih Between #" + basTarihCevir + "# And #" + bitisTarihCevir + "#";
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

        //GMM Tablosundaki ' Sipariş No'ya göre verileri getirme
        [Route("GMMTablo/Siparis/{id}")]
        public ActionResult GmmSipNo(string id)
        {
            if (id != "")
            {

                var cevirID = id.Replace("-", "/");
                var tsql = "SELECT * From dbo_GMMTablo Where Sipariş =" + "'" + cevirID + "'" + " ";
                using (var conn = new OleDbConnection(connect))
                {
                    var cmd = new OleDbCommand(tsql, conn);
                    var da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);
                }

                islem.LogEkle(dt);

            }
            string xml = System.IO.File.ReadAllText(Server.MapPath("~/kartno.xml"));
            return Content(xml, "xml");

        }
    }
}