//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentCar
{
    using System;
    using System.Collections.Generic;
    
    public partial class Clients
    {
        public Clients()
        {
            this.Inspections = new HashSet<Inspections>();
            this.RentAndReturns = new HashSet<RentAndReturns>();
        }
    
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string IDCard { get; set; }
        public string CreditCard { get; set; }
        public Nullable<float> CreditLimit { get; set; }
        public string PersonType { get; set; }
        public string State { get; set; }
    
        public virtual ICollection<Inspections> Inspections { get; set; }
        public virtual ICollection<RentAndReturns> RentAndReturns { get; set; }
    }
}
