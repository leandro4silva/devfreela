using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.Project.Finish;

public class FinishCommandHandle : IRequestHandler<FinishCommand, Unit>
{
    private readonly DevFreelaDbContext _dbContext;

    public FinishCommandHandle(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(
        FinishCommand command, CancellationToken cancellationToken)
    {
        var project = _dbContext.Projects.SingleOrDefault(p => p.Id == command.Id);

        project!.Finish();

        await _dbContext.SaveChangesAsync();

        return Unit.Value;
    }
}
