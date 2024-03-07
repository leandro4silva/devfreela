
namespace DevFreela.Application.ViewModels;

public class ProjectViewModel
{
    public string Title { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public int Id { get; set; }

    public ProjectViewModel(int id, string title, DateTime createdAt)
    {
        Id = id;
        Title = title;
        CreatedAt = createdAt;
    }
}
