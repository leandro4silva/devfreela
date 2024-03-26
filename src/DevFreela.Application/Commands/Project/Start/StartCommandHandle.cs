using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.Project.Start;

public class StartCommandHandle : IRequestHandler<StartCommand, Unit>
{
    private readonly DevFreelaDbContext _dbContext;

    public StartCommandHandle(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(
        StartCommand command, 
        CancellationToken cancellationToken)
    {
        var project = await _dbContext.Projects.SingleOrDefaultAsync(p => p.Id == command.Id);
        project!.Start();

        await _dbContext.SaveChangesAsync();
        return Unit.Value;
    }
}
