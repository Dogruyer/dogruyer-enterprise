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

        string connect = @"Provider=Microsoft.Jet.OleDb.4.0;Data Source= C:\Users\Dogruyer_5\Desktop\bartex_aktarma.mdb";
        DataTable dt = new DataTable();
        // TODO: Belirlenen KartNumarasına Göre Planlar Tablosu Getir
        public ActionResult KartNoGetir(int? id)
        {
            if(id != null)
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

        
        //Belirlenen Tarihe Göre Giriş Tablosu Getir
        // yyyy-MM-dd   -> Yıl - Ay - Gün
        [Route("Planlar/Tarih/{belirlenenTarih}")]
        public ActionResult Tarih(string belirlenenTarih)
        {
            var tarihCevir = belirlenenTarih.Replace("-", ".");
            var tsql = "SELECT * From Giriş Where Tarih LIKE '" + tarihCevir + "%" + "'";
            using (var con = new OleDbConnection(connect))
            {
                

                var command = new OleDbCommand(tsql, con);
                var da = new OleDbDataAdapter(command);
                da.Fill(dt);

            }




            return View();
        }


        // yyyy-MM-dd -> Yıl - Ay - Gün
        [Route("Planlar/TarihAraligi/{baslangic}/{bitis}")]
        public ActionResult belirlenenTarihlerArasi(string baslangic,string bitis)
        {
            var basTarihCevir = baslangic.Replace("-", "/");
            var bitisTarihCevir = bitis.Replace("-", "/");


            //string baslangicb = "2009-01-15 16:43:02.000";
            //string bitisdeger = "2008-05-31 11:09:00.000";
            //var tsql = "Select * From Giriş Where Tarih BETWEEN '" + Convert.ToString(baslangic) + "' and '" + Convert.ToString(bitis) + "'";,
            var tsql= "SELECT * From Giriş Where Tarih Between #"+baslangic+"# And #"+bitis+"# Order By Tarih";
            using (var con = new OleDbConnection(connect))
            {


                var command = new OleDbCommand(tsql, con);
                var da = new OleDbDataAdapter(command);
                da.Fill(dt);
            }



            return View();
        }

    }
}