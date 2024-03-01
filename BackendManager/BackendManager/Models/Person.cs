using System;
using System.Collections.Generic;

namespace BackendManager.Models;

public partial class Person
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public virtual ICollection<Goal> Goals { get; set; } = new List<Goal>();
}
