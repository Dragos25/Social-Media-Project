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
    
    public partial class notification
    {
        public int id_notification { get; set; }
        public int id_recipient { get; set; }
        public Nullable<int> id_sender { get; set; }
        public int type_action { get; set; }
        public Nullable<int> post_id { get; set; }
        public Nullable<int> id_message { get; set; }
    
        public virtual action action { get; set; }
        public virtual direct_messages direct_messages { get; set; }
        public virtual user user { get; set; }
        public virtual user user1 { get; set; }
        public virtual post post { get; set; }
    }
}
