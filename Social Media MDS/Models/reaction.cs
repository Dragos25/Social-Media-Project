//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Social_Media_MDS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class reaction
    {
        public int id_user { get; set; }
        public int post_id { get; set; }
        public Nullable<int> id_reaction_type { get; set; }
    
        public virtual post post { get; set; }
        public virtual reaction_type reaction_type { get; set; }
        public virtual user user { get; set; }
    }
}
