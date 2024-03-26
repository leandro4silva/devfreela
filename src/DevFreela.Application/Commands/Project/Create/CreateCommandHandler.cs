using DomainEntity = DevFreela.Domain.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.Projects.CreateProject;

public class CreateCommandHandler : IRequestHandler<CreateCommand, int>
{
    private DevFreelaDbContext _dbContext;
    public CreateCommandHandler(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Handle(
        CreateCommand request,
        CancellationToken cancellationToken
    )
    {
        var project = new DomainEntity.Project(
            request.Title,
            request.Description,
            request.IdClient,
            request.IdFreelancer,
            request.TotalCost
        );

        await _dbContext.Projects.AddAsync(project);
        await _dbContext.SaveChangesAsync();

        return project.Id;
    }
}
