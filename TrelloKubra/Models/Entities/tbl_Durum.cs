//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrelloKubra.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Durum
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Durum()
        {
            this.tbl_GorevDurumlari = new HashSet<tbl_GorevDurumlari>();
            this.tbl_Gorevler = new HashSet<tbl_Gorevler>();
        }
    
        public int DurumId { get; set; }
        public string DurumAd { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_GorevDurumlari> tbl_GorevDurumlari { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Gorevler> tbl_Gorevler { get; set; }
    }
}
