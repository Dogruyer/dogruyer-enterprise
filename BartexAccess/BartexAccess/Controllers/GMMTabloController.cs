﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BartexAccess.Controllers
{
    public class GMMTabloController : Controller
    {
        string connect = @"Provider=Microsoft.Jet.OleDb.4.0;Data Source=\Inetpub\vhosts\7houseburger.com\demo\bartex_aktarma1.mdb";
        // string connect = @"Provider=Microsoft.Jet.OleDb.4.0;Data Source=C:\Users\Dogruyer_5\Desktop\bartex_aktarma.mdb";
        DataTable dt = new DataTable();
        //GMM Tablosundaki ' Sipariş No'ya göre verileri getirme
        [Route("GMMTablo/SipNo/{id}")]
        public ActionResult SipNo(string id)
        {
            if (id != "")
            {

                var cevirID = id.Replace("-", "/");
                var tsql = "SELECT Kısım as Kisim , Makina , KartNo,Sipariş as SiparisNo , Miktar,Gün as Gun,Vardiya, Baslama , An , Personel , SiraNo,MakinaNo,pri,En,Gramaj From dbo_GMMTablo Where Sipariş =" + "'" + cevirID + "'" + " ";
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