using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Core.Exceptions;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _dbContext;

        public UserService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(CreateUserInputModel inputModel)
        {
            var user = new User(inputModel.FullName, inputModel.Email, inputModel.BirthDate);

            return user.Id;
        }

        public void Delete(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

            if (user is null)
            {
                throw new ResourceNotFound();
            }

            user.Delete();
        }

        public List<UserViewModel> GetAll()
        {
            var users = _dbContext.Users;

            var userViewModel = users.Select(u => new UserViewModel(
                u.Id,
                u.FullName,
                u.Email,
                u.BirthDate,
                u.CreatedAt,
                u.Active,
                u.Skills,
                u.OwnedProjects,
                u.FreelanceProjects
            )).ToList();

            return userViewModel;
        }

        public UserDetailsViewModel GetById(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

            if (user is null)
            {
                throw new ResourceNotFound();
            }

            var userDetailsViewModel = new UserDetailsViewModel(
                user.Id,
                user.FullName,
                user.Email,
                user.BirthDate,
                user.CreatedAt,
                user.Active,
                user.Skills,
                user.OwnedProjects,
                user.FreelanceProjects
            );

            return userDetailsViewModel;
        }

        public void Update(UpdateUserInputModel inputModel)
        {
            var user = _dbContext.Users.Find(u => u.Id == inputModel.Id);

            if (user is null)
            {
                throw new ResourceNotFound();
            }

            user.Update(inputModel.FullName, inputModel.Email, inputModel.BirthDate, inputModel.Active);
        }
    }
}