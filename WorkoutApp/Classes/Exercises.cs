using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutApp.Classes
{
    public class Exercises
    {
        public int ExerciseId { get; set; }
        public string NameOfExercise { get; set; }
        public string TargetedMusclePart { get; set; }
        public string LinkForVideo { get; set; }
        public int? Sets {  get; set; }
        public int? Reps { get; set; }
        public int? Weight { get; set; }
    }
}
