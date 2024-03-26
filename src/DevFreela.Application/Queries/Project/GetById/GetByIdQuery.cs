using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.Application.Queries.Project.GetById;

public class GetByIdQuery : IRequest<ProjectDetailsViewModel>
{
    public int Id { get; set; }

    public GetByIdQuery(int id)
    {
        Id = id;
    }
}
