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
    public class HomeController : Controller
    {

        //Giriş Tablosu Kısımları 


        public ActionResult Index(string ilkTarih)
        {
            
                var connect = @"Provider=Microsoft.Jet.OleDb.4.0;Data Source= C:\Users\Dogruyer_5\Desktop\bartex_aktarma1.mdb";

                DataTable dt = new DataTable();
                var unitsSQL = "SELECT * From Giriş Where Tarih LIKE '" + ilkTarih + "%" + "'";
                using (var conn = new OleDbConnection(connect))
                {
                    var cmd = new OleDbCommand(unitsSQL, conn);
                    var da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);
                }


                //DataRow row = dt.NewRow();
                //dt.Rows.Add(row["Stok Adı"]);
                //dt.Rows.Add(row["Miktar"]);


            XMLFormat xml = new XMLFormat();

            xml.ConvertDataTableToXMLDataString(dt);





                

           return View(dt);
            
        }












    }
}