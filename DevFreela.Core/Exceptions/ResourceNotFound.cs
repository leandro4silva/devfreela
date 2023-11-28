using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.Core.Exceptions
{
    public class ResourceNotFound : Exception
    {
        public ResourceNotFound() : base("Resource not found") { }
    }
}