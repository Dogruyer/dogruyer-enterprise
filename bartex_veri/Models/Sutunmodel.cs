using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bartex_veri.Models
{
    public class Sutunmodel
    {
        public Tablo Tablo { get; set; }

        public static IEnumerable<SelectListItem> GetTabloSelectItems()
        {
            yield return new SelectListItem { Text = "KartNo", Value = "KartNo" };
            yield return new SelectListItem { Text = "SipNo", Value = "SipNo" };
            yield return new SelectListItem { Text = "ÇalışılacakMetraj", Value = "ÇalışılacakMetraj" };
            yield return new SelectListItem { Text = "İstenilenEn", Value = "İstenilenEn" };
            yield return new SelectListItem { Text = "Termin_Tarihi", Value = "Termin_Tarihi" };
            yield return new SelectListItem { Text = "Op1", Value = "Op1" };
            yield return new SelectListItem { Text = "DigerMiktar", Value = "DigerMiktar" };
            yield return new SelectListItem { Text = "DigerBirim", Value = "DigerBirim" };
            yield return new SelectListItem { Text = "İsletme_Tarihi", Value = "İsletme_Tarihi" };
        }

    }
    public enum Tablo
    {
        KartNo,
        SipNo,
        ÇalışılacakMetraj,
        İstenilenEn,
        Termin_Tarihi,
        Op1,
        DigerMiktar,
        DigerBirim,
        İsletme_Tarihi
    }
}