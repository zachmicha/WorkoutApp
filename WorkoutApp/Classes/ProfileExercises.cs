using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutApp.Classes
{
    internal class ProfileExercises
    {
        int Id { get; set; }
        int ProfileId { get; set; }
        int ExerciseId { get; set; }
        int Reps { get; set; }
        int Sets { get; set; }
        int Weight { get; set; }
    }
}
