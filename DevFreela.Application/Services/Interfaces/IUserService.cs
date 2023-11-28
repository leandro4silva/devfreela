using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Application.InputModels;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IUserService
    {
        int Create(CreateUserInputModel inputModel);
    }
}