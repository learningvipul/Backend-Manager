﻿using System;
using System.Collections.Generic;

namespace BackendManager.Models;

public partial class MuscleGroup
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
}
