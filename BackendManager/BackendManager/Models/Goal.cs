using System;
using System.Collections.Generic;

namespace BackendManager.Models;

public partial class Goal
{
    public int Person { get; set; }

    public int Exercise { get; set; }

    public int FinalWeight { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public virtual Exercise ExerciseNavigation { get; set; } = null!;

    public virtual Person PersonNavigation { get; set; } = null!;
}
