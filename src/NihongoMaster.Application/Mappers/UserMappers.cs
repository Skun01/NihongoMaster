using System;
using NihongoMaster.Application.DTOs.Auth;
using NihongoMaster.Domain.Entities;
using NihongoMaster.Domain.Enums;

namespace NihongoMaster.Application.Mappers;

public static class UserMappers
{
    public static User ToUserFromRegisterRequest(this RegisterRequest request)
    {
        return new User
        {
            Username = request.Username,
            Email = request.Email,
            Role = UserRole.Learner,
            PasswordHash = string.Empty
        };
    }

    public static UserResponse ToUserResponse(this User user)
    {
        return new UserResponse(
            user.Id,
            user.Username,
            user.Email,
            user.Role.ToString(),
            user.CreatedAt
        );
    }
}
