//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ThesisWebApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Challenge
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Challenge()
        {
            this.ChallengeDays = new HashSet<ChallengeDay>();
            this.ChallengeDayExersices = new HashSet<ChallengeDayExersice>();
        }
    
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public string ChallengeTitle { get; set; }
        public string ChallengeDescription { get; set; }
        public string ChallengeImage { get; set; }
        public bool IsActive { get; set; }
    
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChallengeDay> ChallengeDays { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChallengeDayExersice> ChallengeDayExersices { get; set; }
    }
}
