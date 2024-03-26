
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.Project.Update;

public class UpdateCommandHandle : IRequestHandler<UpdateCommand, Unit>
{
    private readonly DevFreelaDbContext _dbContext;

    public UpdateCommandHandle(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(
        UpdateCommand command, 
        CancellationToken cancellationToken
    )
    {
        var project = _dbContext.Projects.SingleOrDefault(p => p.Id == command.Id);
        project!.Update(project.Title, project.Description, project.TotalCost);

        await _dbContext.SaveChangesAsync();

        return Unit.Value;
    }
}
