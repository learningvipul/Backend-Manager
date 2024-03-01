using System;
using System.Collections.Generic;

namespace BackendManager.Models;

public partial class ExerciseSet
{
    public int Id { get; set; }

    public int Rep { get; set; }

    public int ExerciseWeight { get; set; }

    public int Exercise { get; set; }

    public DateTime? ExerciseDate { get; set; }

    public virtual Exercise ExerciseNavigation { get; set; } = null!;
}
