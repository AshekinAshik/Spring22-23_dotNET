//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mid_Lab_5.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderedProduct
    {
        public int id { get; set; }
        public Nullable<int> pid { get; set; }
        public Nullable<int> oid { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
