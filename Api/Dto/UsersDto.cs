using Backend.Database.Enums;

using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Dto;

public class UserRegistrationDto : BaseDto
{
    public required string Email { get; init; }
    public required string Password { get; init; }
    public Role UserType { get; init; }
}

public class UserAuthResponseDto
{
    public int Id { get; init; }
    public Role UserType { get; init; }
}

public class UserLoginDto : BaseDto
{
    public required string Email { get; init; }
    public required string Password { get; init; }
}

public class UserAuthInfo
{
    [FromHeader]
    public int Id { get; init; }

    [FromHeader]
    public Role UserType { get; init; }
}