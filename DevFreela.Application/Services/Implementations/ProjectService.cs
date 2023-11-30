using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Core.Exceptions;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _dbContext;
        public ProjectService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(CreateProjectInputModel inputModel)
        {
            var project = new Project(
                inputModel.Title,
                inputModel.Description,
                inputModel.IdClient,
                inputModel.IdFreelancer,
                inputModel.TotalCost
            );

            _dbContext.Projects.Add(project);

            return project.Id;
        }

        public void CreateComment(CreateCommentInputModel inputModel)
        {
            var comment = new ProjectComment(inputModel.Content, inputModel.IdProject, inputModel.IdUser);
            _dbContext.ProjectComments.Add(comment);
        }

        public void Delete(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            if (project is null)
            {
                throw new ResourceNotFound();
            }

            project.Cancel();
        }

        public void Finish(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            if (project is null)
            {
                throw new ResourceNotFound();
            }

            project.Finished();
        }

        public List<ProjectViewModel> GetAll(string query)
        {
            var projects = _dbContext.Projects;

            var projectViewModel = projects.Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt)).ToList();

            return projectViewModel;
        }

        public ProjectDetailsViewModel GetById(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            if (project is null)
            {
                throw new ResourceNotFound();
            }

            var projectDetailsViewModel = new ProjectDetailsViewModel(
                project.Id, project.Title,
                project.Description,
                project.StartedAt,
                project.FinishedAt,
                project.TotalCost
            );

            return projectDetailsViewModel;
        }

        public void Start(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            if (project is null)
            {
                throw new ResourceNotFound();
            }

            project.Start();
        }

        public void Update(UpdateProjectInputModel inputModel)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == inputModel.Id);

            if (project is null)
            {
                throw new ResourceNotFound();
            }

            project.Update(inputModel.Title, inputModel.Description, inputModel.TotalCost);
        }
    }
}