using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.Core.Entities
{
    public class User : BaseEntity
    {
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; set; }
        public List<UserSkill> Skills { get; private set; }
        public List<Project> OwnedProjects { get; private set; }
        public List<Project> FreelanceProjects { get; private set; }


        public User(string fullName, string email, DateTime birthDate)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;

            Active = true;

            CreatedAt = DateTime.Now;
            Skills = new List<UserSkill>();
            OwnedProjects = new List<Project>();
            FreelanceProjects = new List<Project>();
        }

        public void Update(string fullName, string email, DateTime birthDate, bool active)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Active = active;
        }

        public void Delete()
        {
            if (Active == true)
            {
                Active = false;
            }
        }

    }
}