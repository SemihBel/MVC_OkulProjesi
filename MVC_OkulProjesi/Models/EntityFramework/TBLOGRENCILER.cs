//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_OkulProjesi.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class TBLOGRENCILER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLOGRENCILER()
        {
            this.TBLNOTLAR = new HashSet<TBLNOTLAR>();
        }
        [DisplayName("??renci ID")]
        public int OGRENCIID { get; set; }
        [DisplayName("Ad?")]
        public string OGRAD { get; set; }
        [DisplayName("Soyad?")]
        public string OGRSOYAD { get; set; }
        [DisplayName("Foto?raf")]
        public string OGRFOTOGRAF { get; set; }
        [DisplayName("Cinsiyet")]
        public string OGRCINSIYET { get; set; }
        [DisplayName("Kul?p")]
        public Nullable<byte> OGRKULUP { get; set; }
    
        public virtual TBLKULUPLER TBLKULUPLER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLNOTLAR> TBLNOTLAR { get; set; }
    }
}
