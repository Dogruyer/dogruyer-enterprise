﻿using System;
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
        // GET: Planlar
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
            


                //var unitsSQL = "SELECT * From Giriş Where Tarih LIKE '" + ilkTarih + "%" + "'";
                //using (var conn = new OleDbConnection(connect))
                //{
                //    var cmd = new OleDbCommand(unitsSQL, conn);
                //    var da = new OleDbDataAdapter(cmd);
                //    da.Fill(dt);
                //}


                //DataRow row = dt.NewRow();
                //dt.Rows.Add(row["Stok Adı"]);
                //dt.Rows.Add(row["Miktar"]);


                ////dt.Rows.Add(row);

                //return View(dt);
                return View();
        }
    }
}