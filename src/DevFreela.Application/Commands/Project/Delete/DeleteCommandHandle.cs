using DevFreela.Application.Commands.Projects.Delete;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.Project.Delete;
public class DeleteCommandHandle : IRequestHandler<DeleteCommand, Unit>
{
    private readonly DevFreelaDbContext _dbContext;

    public DeleteCommandHandle(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(
        DeleteCommand command, 
        CancellationToken cancellationToken
    )
    {
        var project = _dbContext.Projects.SingleOrDefault(p => p.Id == command.Id);

        project!.Cancel();

        await _dbContext.SaveChangesAsync();

        return Unit.Value;
    }
}
