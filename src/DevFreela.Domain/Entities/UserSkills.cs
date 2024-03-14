namespace DevFreela.Domain.Entities;

public class UserSkill : BaseEntity
{
    public int IdUser { get; private set; }
    public int IdSkill { get; private set; }
    public Skill? Skill { get; set; }

    public UserSkill(int idUser, int idSkill)
    {
        IdUser = idUser;
        IdSkill = idSkill;
    }
}
