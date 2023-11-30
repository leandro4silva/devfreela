using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Core.Entities;

namespace DevFreela.Application.ViewModels
{
    public class UserViewModel
    {
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; set; }
        public List<UserSkill> Skills { get; private set; }
        public List<Project> OwnedProjects { get; private set; }
        public List<Project> FreelanceProjects { get; private set; }


        public UserViewModel(string fullName, string email, DateTime birthDate, DateTime createdAt, bool active, List<UserSkill> skills, List<Project> ownedProjects, List<Project> freelanceProjects)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            CreatedAt = createdAt;
            Active = active;
            Skills = skills;
            OwnedProjects = ownedProjects;
            FreelanceProjects = freelanceProjects;
        }
    }
}