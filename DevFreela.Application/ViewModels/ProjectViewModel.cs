using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModels
{
    public class ProjectViewModel
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public DateTime CreatedAts { get; private set; }

        public ProjectViewModel(int id, string title, DateTime createdAts)
        {
            Id = id;
            Title = title;
            CreatedAts = createdAts;
        }

    }
}