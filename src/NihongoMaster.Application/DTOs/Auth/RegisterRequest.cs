using System;

namespace NihongoMaster.Application.DTOs.Auth;

public record RegisterRequest(
    string Username,
    string Email,
    string Password
);