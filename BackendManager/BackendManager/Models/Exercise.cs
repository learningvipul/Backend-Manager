using System;
using System.Collections.Generic;

namespace BackendManager.Models;

public partial class Exercise
{
    public int Id { get; set; }

    public string ExerciseName { get; set; } = null!;

    public int MuscleGroup { get; set; }

    public virtual ICollection<ExerciseSet> ExerciseSets { get; set; } = new List<ExerciseSet>();

    public virtual ICollection<Goal> Goals { get; set; } = new List<Goal>();

    public virtual MuscleGroup MuscleGroupNavigation { get; set; } = null!;
}
