using MediatR;

namespace DevFreela.Application.Commands.Project.Finish;


public class FinishCommand : IRequest<Unit>
{
    public int Id { get; set; }

    public FinishCommand(int id)
    {
        Id = id;
    }

}
