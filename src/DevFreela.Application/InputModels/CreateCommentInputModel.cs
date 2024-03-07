
namespace DevFreela.Application.InputModels;

public class CreateCommentInputModel
{
    public string Content { get; set; }
    public int IdUser { get; set; }
    public int IdProject { get; set; }

    public CreateCommentInputModel(string content, int idUser, int idProject)
    {
        Content = content;
        IdUser = idUser;
        IdProject = idProject;
    }    
}
