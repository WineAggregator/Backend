﻿namespace Backend.Database.Models;

public class User : BaseModel
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public Role Role { get; set; }
}