//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ControleServices
{
    using System;
    using System.Collections.Generic;
    
    public partial class HISTORICO_SUPORTE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HISTORICO_SUPORTE()
        {
            this.HISTORICO_SUPORTE_ITENS = new HashSet<HISTORICO_SUPORTE_ITENS>();
        }
    
        public long ID { get; set; }
        public long ID_CLIENTE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HISTORICO_SUPORTE_ITENS> HISTORICO_SUPORTE_ITENS { get; set; }
        public virtual CLIENTE CLIENTE { get; set; }
    }
}
