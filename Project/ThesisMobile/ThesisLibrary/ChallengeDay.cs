//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JsonModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChallengeDay
    {
        public int ID { get; set; }
        public int Day { get; set; }
        public int ChallengeID { get; set; }
        public int RepeatCircuit { get; set; }
        public string Title { get; set; }
    
        public virtual Challenge Challenge { get; set; }
    }
}
