using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BartexAccess.Controllers
{
    public class GirisController : Controller
    {
        string connect = @"Provider=Microsoft.Jet.OleDb.4.0;Data Source=\Inetpub\vhosts\7houseburger.com\demo\bartex_aktarma1.mdb";
        //string connect = @"Provider=Microsoft.Jet.OleDb.4.0;Data Source=C:\Users\Dogruyer_5\Desktop\bartex_aktarma.mdb";
        DataTable dt = new DataTable();
        //GMM Tablosundaki ' Sipariş No'ya göre verileri getirme
        [Route("Giris/PartiNo/{id}")]
        public ActionResult PartiNo(string id)
        {
            if (id != "")
            {
                //,[Sipariş No] as SipNo,[Çeken Personel] as CekenPersonel,Kimlik,Örgü as Orgu,Dokuma,Kod1,Kod2,Alfa1,Alfa2,GGG
                var cevirID = id.Replace("-", "/");
                var tsql = "SELECT StokCinsi,[Parti No],KumasCesidiKodu,En,Gramaj,[Ö/D] as [OD],[Stok Adı] as StokAdi,OlcuBirimi,AmbarNo,[İrsaliye No] as IrsaliyeNo,[İrsaliye Tarihi] as IrsaliyeTarihi,Miktar,DovizBirimi,Fiyatı as Fiyati,Tarih,[Sipariş No] as SipNo,[Çeken Personel] as CekenPersonel,Kimlik,Örgü as Orgu,Dokuma,Kod1,Kod2,Alfa1,Alfa2,GGG  From Giriş Where [Parti No] =" + "'" + cevirID + "'" + " ";
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