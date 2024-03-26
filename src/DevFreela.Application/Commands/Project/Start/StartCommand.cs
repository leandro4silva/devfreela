using MediatR;

namespace DevFreela.Application.Commands.Project.Start;

public class StartCommand : IRequest<Unit>
{
    public int Id { get; set; }

    public StartCommand(int id)
    {
        Id = id;
    }

}
