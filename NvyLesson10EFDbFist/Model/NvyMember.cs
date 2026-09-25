using System;
using System.Collections.Generic;

namespace NvyLesson10EFDbFist.Model;

public partial class NvyMember
{
    public long Id { get; set; }

    public string? NvyUserName { get; set; }

    public string? NvyPassword { get; set; }

    public string? NvyFullName { get; set; }

    public string? NvyEmail { get; set; }

    public string? NvyPhone { get; set; }

    public bool? NvyStatus { get; set; }
}
