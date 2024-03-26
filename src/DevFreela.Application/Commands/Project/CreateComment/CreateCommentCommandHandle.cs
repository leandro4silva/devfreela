using DevFreela.Domain.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.Projects.CreateComment;

public class CreateCommentCommandHandle : IRequestHandler<CreateCommentCommand, Unit>
{
    private readonly DevFreelaDbContext _dbContext;

    public CreateCommentCommandHandle(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(CreateCommentCommand command, CancellationToken cancellationToken)
    {
        var comment = new ProjectComment(
            command.Content,
            command.IdProject,
            command.IdUser
        );

        await _dbContext.Comments.AddAsync(comment);
        await _dbContext.SaveChangesAsync();

        return Unit.Value;
    }
}
