using System;
using System.Collections.Generic;
using ProjectK.Business.Characters;
using ProjectK.Contracts;

namespace ProjectK.Business
{
    public class Skill
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Damage { get; private set; }

        public ICollection<Character> Characters { get; } = new HashSet<Character>();

        public void Update(SkillDto skill)
        {
            if (skill == null) throw new ArgumentNullException(nameof(skill));

            Name = skill.Name;
            Damage = skill.Damage;
        }

        public SkillDto ToDto() => new()
        {
            Id = Id,
            Name = Name,
            Damage = Damage,
        };
    }
}