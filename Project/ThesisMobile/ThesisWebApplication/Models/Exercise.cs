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
    
    public partial class Exercise
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Exercise()
        {
            this.ChallengeDayExersices = new HashSet<ChallengeDayExersice>();
        }
    
        public int ID { get; set; }
        public string ExerciseName { get; set; }
        public string ExerciseDescription { get; set; }
        public string ExerciseImage { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChallengeDayExersice> ChallengeDayExersices { get; set; }
    }
}
