using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.Application.Queries.Project.GetAll;

public class GetAllQuery : IRequest<List<ProjectViewModel>>
{
    public string Query { get; set; }

    public GetAllQuery(string query)
    {
        Query = query;
    }
}
