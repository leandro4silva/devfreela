using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.Core.Entities
{
    public class UserSkill : BaseEntity
    {
        public int idUser { get; private set; }
        public int idSkill { get; private set; }

        public UserSkill(int idUser, int idSkill)
        {
            this.idUser = idUser;
            this.idSkill = idSkill;
        }
    }
}