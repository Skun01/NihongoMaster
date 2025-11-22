using System;

namespace NihongoMaster.Application.DTOs.Auth;

public record UserResponse(
    int Id,
    string Username,
    string Email,
    string Role,
    DateTime CreatedAt
);
