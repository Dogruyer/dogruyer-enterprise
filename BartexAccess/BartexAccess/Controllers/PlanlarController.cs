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
        
        //string connect = @"Provider=Microsoft.Jet.OleDb.4.0;Data Source=C:\Users\Dogruyer_5\Desktop\bartex_aktarma.mdb";
        DataTable dt = new DataTable();
        string connect = @"Provider=Microsoft.Jet.OleDb.4.0;Data Source=\Inetpub\vhosts\7houseburger.com\demo\bartex_aktarma1.mdb";

        // GET: Planlar
        [Route("Planlar/SipNo/{id}")]
        public ActionResult SipNo(string id)
        {

            if (id != "")
            {


                var cevirID = id.Replace("-", "/");
                var tsql = "SELECT Kartno,SipNo, ÇalışılacakMetraj as CalisilacakMetraj,İstenenEn as IstenenEn,[Termin Tarihi],İsletmeTarih as IsletmeTarih From Planlar Where SipNo =" + "'" + cevirID + "'" + " ";
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
            var tsql = "SELECT Kartno,SipNo, ÇalışılacakMetraj as CalisilacakMetraj,İstenenEn as IstenenEn,[Termin Tarihi],İsletmeTarih as IsletmeTarih From Planlar Where İsletmeTarih LIKE '" + tarihCevir + "%" + "'";
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

        [Route("Planlar/TarihAraligi/{sorgu}")]
        public ActionResult BelirlenenTarihlerArasi(string sorgu)
        {
            var bas = sorgu.Split('a')[0];
            var bit = sorgu.Split('a')[1];

            var basTarihCevir = bas.Replace("-", "/");
            var bitisTarihCevir = bit.Replace("-", "/");

            var tsql = "SELECT Kartno,SipNo, ÇalışılacakMetraj as CalisilacakMetraj,İstenenEn as IstenenEn,[Termin Tarihi],İsletmeTarih as IsletmeTarih From Planlar Where İsletmeTarih Between #" + basTarihCevir + "# And #" + bitisTarihCevir + "#";
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