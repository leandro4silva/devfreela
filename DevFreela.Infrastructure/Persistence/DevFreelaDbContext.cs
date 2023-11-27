using DevFreela.Core.Entities;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }

        public DevFreelaDbContext(List<Project> projects, List<User> users, List<Skill> skills)
        {
            Projects = new List<Project>{
                new Project("Meu ASPNET Core 1", "Minha Descrição de Projeto 1", 1, 1, 10000),
                new Project("Meu ASPNET Core 2", "Minha Descrição de Projeto 2", 1, 1, 10000),
                new Project("Meu ASPNET Core 3", "Minha Descrição de Projeto 3", 1, 1, 10000)
            };

            Users = new List<User>
            {
                new User("John Doe 1", "johndoeexample@email.com", new DateTime(1996, 1, 1)),
                new User("John Doe 2", "johndoeexample@email.com", new DateTime(1997, 1, 1)),
                new User("John Doe 3", "johndoeexample@email.com", new DateTime(1998, 1, 1)),
            };

            Skills = new List<Skill>{
                new Skill("C#"),
                new Skill("JAVA"),
                new Skill("NODE.JS"),
            };
        }
    }
}