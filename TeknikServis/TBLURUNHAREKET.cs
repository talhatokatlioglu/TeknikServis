//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeknikServis
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLURUNHAREKET
    {
        public int HAREKETID { get; set; }
        public int URUN { get; set; }
        public Nullable<int> MUSTERI { get; set; }
        public Nullable<short> PERSONEL { get; set; }
        public Nullable<System.DateTime> TARIH { get; set; }
        public Nullable<short> ADET { get; set; }
        public Nullable<decimal> FIYAT { get; set; }
        public string URUNSERINO { get; set; }
    
        public virtual TBLCARI TBLCARI { get; set; }
        public virtual TBLPERSONEL TBLPERSONEL { get; set; }
    }
}
