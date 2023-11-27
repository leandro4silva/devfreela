using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.Core.Exceptions
{
    public class ProjectAlreadyStatedException : Exception
    {
        public ProjectAlreadyStatedException() : base("Project already in Stated status.") { }
    }
}