//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentCartWPF
{
    using System;
    using System.Collections.Generic;
    
    public partial class VehicleModels
    {
        public VehicleModels()
        {
            this.Vehicles = new HashSet<Vehicles>();
        }
    
        public int ID { get; set; }
        public Nullable<int> BrandID { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
    
        public virtual Brands Brands { get; set; }
        public virtual ICollection<Vehicles> Vehicles { get; set; }
    }
}
