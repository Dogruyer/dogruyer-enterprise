using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BartexAccess.Controllers
{
    public class MalzemeHareketiController : Controller
    {
        string connect = @"Provider=Microsoft.Jet.OleDb.4.0;Data Source=\Inetpub\vhosts\7houseburger.com\demo\bartex_aktarma1.mdb";
        //string connect = @"Provider=Microsoft.Jet.OleDb.4.0;Data Source=C:\Users\Dogruyer_5\Desktop\bartex_aktarma.mdb";
        DataTable dt = new DataTable();
        [Route("MalzemeHareketi/Adi/{encodingType}")]
        public ActionResult Adi(string encodingType)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(encodingType);
            string deger= System.Text.Encoding.UTF8.GetString(base64EncodedBytes);


            //var cevirID = .Replace("_", " ");
            var tsql = "SELECT [Lot No], [Fiş Numarası] as FisNumarasi, FirmaAdi, [Kayıt Tarihi], Grubu, Adı as Adi, [Depoya Giren Miktar], [Çekilen Miktar] as CekilenMiktar, [Maliyet Merkezi], [Çeken Personel] as CekenPersonel, [Geliş Birim Fiyatı] as GelisBirimFiyati, [İskonto] as Iskonto, [Toplam Fiyat], Açıklama as Acıklama, [Döviz Cinsi] as DovizCinsi, DM, ABD, TL, SW, Tarih  From [dbo_Malzeme Hareketi] Where Adı =" + "'" + deger + "'" + " ";
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