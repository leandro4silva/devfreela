﻿using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Domain.Entities;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implementations;


public class UserService : IUserService
{
    private readonly DevFreelaDbContext _dbContext;

    public UserService(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public int Create(CreateUserInputModel inputModel)
    {
        var user = new User(
            inputModel.FullName,
            inputModel.Email,
            inputModel.BirthDate
        );

        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();

        return user.Id;
    }

    public User GetUser(int id)
    {
        var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

        return user!;
    }
}
