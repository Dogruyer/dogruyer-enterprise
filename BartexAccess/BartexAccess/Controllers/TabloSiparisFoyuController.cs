using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BartexAccess.Controllers
{
    public class TabloSiparisFoyuController : Controller
    {
        //string connect = @"Provider=Microsoft.Jet.OleDb.4.0;Data Source=\Inetpub\vhosts\testdogruyer.duckdns.org\httpdocs\bartex_aktarma1.mdb";
        string connect = @"Provider=Microsoft.Jet.OleDb.4.0;Data Source=\Inetpub\vhosts\7houseburger.com\demo\bartex_aktarma1.mdb";
        //string connect = @"Provider=Microsoft.Jet.OleDb.4.0;Data Source=C:\Users\Dogruyer_5\Desktop\bartex_aktarma.mdb";
        DataTable dt = new DataTable();
        //GMM Tablosundaki ' Sipariş No'ya göre verileri getirme
        [Route("SiparisFoyu/SipNo/{id}")]
        public ActionResult SipNo(string id)
        {
            if (id != "")
            {
                //,[Müşteri Ünvanı] as MusteriUnvani,Metraj,Birim,[Parti No] as PartiNo,D,ÖR as OR,[Kumaş Cinsi] as KumasCinsi,En,Gramaj,[Gr/Mtül] as GrMtul,Sanfor,Zımpara as Zimpara,[Şardon Tek Yüz] as SardonTekYuz,[Şardon Çift Yüz] as SardonCiftYuz
                var cevirID = id.Replace("-", "/");
                var tsql = "SELECT [Sipariş No] as SipNo , [Sipariş Tarihi]  as SipTarih,HazırlıkSip as HazirlikSip,[Müşteri Ünvanı] as MusteriUnvani,Metraj,Birim,[Parti No] as PartiNo,D,[ÖR] as ORR,[Kumaş Cinsi] as KumasCinsi,En,Gramaj,[Gr/Mtül] as GrMtul,Sanfor,Zımpara as Zimpara,[Şardon Tek Yüz] as SardonTekYuz,[Şardon Çift Yüz] as SardonCiftYuz,[Krinkıl-] as Krinkil,Diğer as Diger,Varyant,[İpek Apre] as IpekApre,[Su İtici Apre] as SuIticiApre,[Teflon Apre],[Dolgun Apre],[Yanmaz Apre],[Buruşmaz Apre] as BurusmazApre,[Kalendı-] as Kalendi,[Ram-],Pigment,[Pigment Fonlu],Reaktif,[Reaktif Fonlu],Ronjan,B,A,O,K,Ö as O,KKL,PPV,AB,BH,BAH,KİÜ as KIU,ÇT as CT,YY,MW,YB,[Anlaşmalı Fiyat] as AnlasmaliFiyat,[Döviz Cinsi] as DovizCinsi,[Özel Anlaşma] as OzelAnlasma,[F/S] as FS,L,[Kayıt Tarihi] as KayitTarihi,Ödeme as Odeme,KayıtSaati as KayitSaati,Durumu,Kod1,Kod2,Kod3,Kod4,Kod5,Kod6,Kod7,Kod8,Alfa1,Alfa2,Num1,Num2,BAS1,BAS2,BAS3,B1,B2,B3,Fasonfiyat,Fasondoviz,Rsip,Gsip From TabloSiparişFöyü Where [Sipariş No] =" + "'" + cevirID + "'" + " ";

                using (var conn = new OleDbConnection(connect))
                {
                    var cmd = new OleDbCommand(tsql, conn);
                    var da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);
                }

                islem.LogEkle(dt);

            }            string xml = System.IO.File.ReadAllText(Server.MapPath("~/kartno.xml"));
            return Content(xml, "xml");

        }
    }
}