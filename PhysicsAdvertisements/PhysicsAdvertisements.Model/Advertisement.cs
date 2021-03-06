//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhysicsAdvertisements.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Advertisement
    {
        public int Id { get; set; }
        public System.DateTime AddedDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int PhysicsAreasId { get; set; }
    
        public virtual PhysicsAreas PhysicsAreas { get; set; }
        public virtual User User { get; set; }
        public virtual Category Category { get; set; }
    }
}
