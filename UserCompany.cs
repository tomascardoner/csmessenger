//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CSMessenger
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserCompany
    {
        public byte CompanyID { get; set; }
        public short UserID { get; set; }
        public byte AccessCompanyID { get; set; }
    
        public virtual Company CompanyGranted { get; set; }
        public virtual User User { get; set; }
    }
}
