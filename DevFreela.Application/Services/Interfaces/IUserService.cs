using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IUserService
    {
        List<UserViewModel> GetAll();
        UserDetailsViewModel GetById(int id);
        int Create(CreateUserInputModel inputModel);
        void Update(UpdateUserInputModel inputModel);
        void Delete(int id);
    }
}