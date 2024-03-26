using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.Projects.CreateComment;
public class CreateCommentCommand : IRequest<Unit>
{
    public string Content { get; set; }
    public int IdUser { get; set; }
    public int IdProject { get; set; }

    public CreateCommentCommand(string content, int idUser, int idProject)
    {
        Content = content;
        IdUser = idUser;
        IdProject = idProject;
    }

}
