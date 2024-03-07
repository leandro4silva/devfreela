using DevFreela.Domain.Entities;

namespace DevFreela.Infrastructure.Persistence;

public class DevFreelaDbContext
{


    public List<Project> Projects { get; set; }
    public List<User> Users { get; set; }
    public List<Skill> Skills { get; set; }

    public List<ProjectComment> Comments { get; set; }

    public DevFreelaDbContext()
    {
        Projects = new List<Project>
        {
            new Project(
                "Meu projeto ASPNET Core 1",
                "Minha descrição de projeto 1",
                1,
                1,
                10_000
            ),
            new Project(
                "Meu projeto ASPNET Core 2",
                "Minha descrição de projeto 2",
                1,
                1,
                20_000
            ),
            new Project(
                "Meu projeto ASPNET Core 3",
                "Minha descrição de projeto 3",
                1,
                1,
                30_000
            )
        };

        Users = new List<User>
        {
            new User("Leandro Silva", "leandro94.a.s@gmail.com", new DateTime(1994, 11, 3)),
            new User("Robert C Martin", "robert@gmail.com", new DateTime(1970, 11, 3)),
            new User("Anderson", "anderson@gmail.com", new DateTime(1960, 11, 3))
        };

        Skills = new List<Skill>
        {
            new Skill(".NET CORE"),
            new Skill("C#"),
            new Skill("SQL"),
        };
      
    }
}
