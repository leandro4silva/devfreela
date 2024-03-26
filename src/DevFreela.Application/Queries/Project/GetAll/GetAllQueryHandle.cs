
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.Project.GetAll;
public class GetAllQueryHandle : IRequestHandler<GetAllQuery, List<ProjectViewModel>>
{
    private readonly DevFreelaDbContext _dbContext;

    public GetAllQueryHandle(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ProjectViewModel>> Handle(
        GetAllQuery request, 
        CancellationToken cancellationToken
    )
    {
        var projects = await _dbContext.Projects.ToListAsync();

        var projectsViewModel = projects
            .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
            .ToList();

        return projectsViewModel;
    }
}
