using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThesisMobile.DataModel
{
    public class JCategory
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public int? CategoryType { get; set; }
        public string CategoryImage { get; set; }
        public IEnumerable<JChallenge> Challenges { get; set; }
    }
    public class JChallenge
    {
        public int ID { get; set; }
        public string ChallengeTitle { get; set; }
        public string ChallengeDescription { get; set; }
        public string ChallengeImage { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<JChallengeDayExersice> ChallengeDayExersices { get; set; }
    }
    public partial class JChallengeDayExersice
    {
        public int ID { get; set; }
        public int DayID { get; set; }
        public int ChallengeID { get; set; }
        public int Repeats { get; set; }
        public int RepeatType { get; set; }
        public int RepeatCircuit { get; set; }
        public JExercise Exercise { get; set; }
    }
    public partial class JExercise
    {
        public int ID { get; set; }
        public string ExerciseName { get; set; }
        public string ExerciseDescription { get; set; }
        public string ExerciseImage { get; set; }
    }
    public partial class JRepeatType
    {
        public int ID { get; set; }
        public string RepeatTypeName { get; set; }
    }
    public partial class JCategoryType
    {
        public int ID { get; set; }
        public string CategoryTypeName { get; set; }
    }
}
