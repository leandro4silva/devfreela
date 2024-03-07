using DevFreela.Application.InputModels;
using DevFreela.Domain.Entities;

namespace DevFreela.Application.Services.Interfaces;

public interface IUserService
{
    int Create(CreateUserInputModel inputModel);
    User GetUser(int id);
}
