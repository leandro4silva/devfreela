using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.Project.GetById;

public class GetByIdQueryHandle 
    : IRequestHandler<GetByIdQuery, ProjectDetailsViewModel>
{
    private readonly DevFreelaDbContext _dbContext;

    public GetByIdQueryHandle(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ProjectDetailsViewModel> Handle(
        GetByIdQuery command, 
        CancellationToken cancellationToken
    )
    {
        var project = await _dbContext.Projects
            .Include(p => p.Client)
            .Include(p => p.Freelancer)
            .SingleOrDefaultAsync(p => p.Id == command.Id);

        if (project == null) return null!;

        var projectDetailsViewModel = new ProjectDetailsViewModel(
            project!.Id,
            project.Title,
            project.Description,
            project.TotalCost,
            project.StartedAt,
            project.FinishedAt,
            project.Client?.FullName,
            project.Freelancer?.FullName
        );

        return projectDetailsViewModel;
    }
}
