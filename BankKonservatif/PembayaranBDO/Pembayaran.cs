//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PembayaranBDO
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pembayaran
    {
        public string invoice_number { get; set; }
        public System.DateTime waktu_pemesanan { get; set; }
        public Nullable<System.DateTime> waktu_pembayaran { get; set; }
        public double nominal { get; set; }
        public int status_bayar { get; set; }
        public string norek_bayar { get; set; }
    }
}
