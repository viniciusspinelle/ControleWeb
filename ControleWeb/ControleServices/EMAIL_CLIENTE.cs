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
    
    public partial class EMAIL_CLIENTE
    {
        public long ID { get; set; }
        public long ID_CLIENTE { get; set; }
        public string EMAIL { get; set; }
        public bool PRINCIPAL { get; set; }
    
        public virtual CLIENTE CLIENTE { get; set; }
    }
}
