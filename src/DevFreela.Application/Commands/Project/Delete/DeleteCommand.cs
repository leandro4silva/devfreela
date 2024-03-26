
using MediatR;

namespace DevFreela.Application.Commands.Projects.Delete;

public class DeleteCommand : IRequest<Unit>
{
    public int Id { get; set; }

    public DeleteCommand(int id)
    {
        Id = id;
    }
}
