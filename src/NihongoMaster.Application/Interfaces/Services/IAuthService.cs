using System;
using NihongoMaster.Application.DTOs.Auth;

namespace NihongoMaster.Application.Interfaces.Services;

public interface IAuthService
{
    Task<UserResponse> RegisterAsync(RegisterRequest request);
}
