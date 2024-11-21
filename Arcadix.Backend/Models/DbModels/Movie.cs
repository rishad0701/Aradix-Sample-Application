using System;
using System.Collections.Generic;

namespace API;

public partial class Movie
{
    public int MovieId { get; set; }

    public string MovieName { get; set; } = null!;

    public string? ReviewComments { get; set; }
}
