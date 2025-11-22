using System;
using NihongoMaster.Application.DTOs.Auth;
using NihongoMaster.Application.Interfaces;
using NihongoMaster.Application.Interfaces.Services;
using NihongoMaster.Application.Mappers;
using NihongoMaster.Domain.Entities;

namespace NihongoMaster.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork _unitOfWork;
    public AuthService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<UserResponse> RegisterAsync(RegisterRequest request)
    {
        // check email
        var emailExists = await _unitOfWork.Repository<User>()
            .AnyAsync(u => u.Email == request.Email);
        
        if(emailExists)
            throw new ArgumentException("Email already exist");

        // check username
        var usernameExists = await _unitOfWork.Repository<User>()
            .AnyAsync(u => u.Username == request.Username);

        if (usernameExists)
            throw new ArgumentException("Username aldready exist.");

        var newUser = request.ToUserFromRegisterRequest();
        newUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        await _unitOfWork.Repository<User>().AddAsync(newUser);
        await _unitOfWork.CompleteAsync();

        return newUser.ToUserResponse();
    }
}
