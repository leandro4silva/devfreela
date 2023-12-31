using DevFreela.Core.Entities;

namespace DevFreela.Application.InputModels
{
    public class CreateUserInputModel
    {
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Active { get; set; }
        public List<UserSkill> Skills { get; set; } = new List<UserSkill>();
        public List<Project> OwnedProjects { get; set; } = new List<Project>();
        public List<Project> FreelanceProjects { get; set; } = new List<Project>();
    }
}