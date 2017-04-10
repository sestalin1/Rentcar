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
    
    public partial class RentAndReturns
    {
        public int ID { get; set; }
        public int VehicleID { get; set; }
        public int ClientID { get; set; }
        public int EmployeeID { get; set; }
        public Nullable<System.DateTime> RentDate { get; set; }
        public Nullable<System.DateTime> ReturnDate { get; set; }
        public Nullable<float> AmountXDay { get; set; }
        public Nullable<int> NumberOfDays { get; set; }
        public string Comment { get; set; }
        public string State { get; set; }
    
        public virtual Clients Clients { get; set; }
        public virtual Employees Employees { get; set; }
        public virtual Vehicles Vehicles { get; set; }
    }
}
