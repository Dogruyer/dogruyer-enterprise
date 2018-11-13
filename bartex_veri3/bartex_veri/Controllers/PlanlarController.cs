using bartex_veri.xml;
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

        string connect = @"Provider=Microsoft.Jet.OleDb.4.0;Data Source= C:\Users\Dogruyer_5\Desktop\bartex_aktarma1.mdb";
        DataTable dt = new DataTable();
        // TODO: Belirlenen KartNumarasına Göre Planlar Tablosu Getir
        //[Route("Planlar/KartNo/{id}")]
        public ActionResult KartNoGetir(int? id)
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
            XMLFormat xml = new XMLFormat();

            ViewData["Test"]= xml.ConvertDataTableToXMLDataString(dt);

            return View();
        }

        
        //Belirlenen Tarihe Göre Giriş Tablosu Getir
        // Gün - Ay - Yıl 
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

            }




            return View();
        }


        // yyyy-MM-dd -> Yıl - Ay - Gün Şeklinde.
        [Route("Planlar/TarihAraligi/{baslangic}/{bitis}")]
        public ActionResult BelirlenenTarihlerArasi(string baslangic,string bitis)
        {
            var basTarihCevir = baslangic.Replace("-", "/");
            var bitisTarihCevir = bitis.Replace("-", "/");


            var tsql= "SELECT * From Giriş Where İsletmeTarih Between #"+baslangic+"# And #"+bitis+"# Order By asc";
            using (var con = new OleDbConnection(connect))
            {


                var command = new OleDbCommand(tsql, con);
                var da = new OleDbDataAdapter(command);
                da.Fill(dt);
            }



            return View();
        }

        //public ActionResult PlanlarSonBirAy()
        //{
        //    var tsql = "SELECT * FROM Planlar Where İsletmeTarih 

        //    return View();

        //}

    }
}