using System;
using System.Collections.Generic;
using System.Linq;
using ProjectK.Business.ExperiencePoints;
using ProjectK.Business.Weapons;
using ProjectK.Contracts;

namespace ProjectK.Business.Characters
{
    public interface ICharacterEdit
    {
        ICharacterEdit ByUser(int userId);
        ICharacterEdit WithWeapon(WeaponDto weapon);
        ICharacterEdit WithCombatStats(int hitPoints, int strength, int defence, int intelligence);
        ICharacterEdit WithName(string name);
    }

    public class Character : ICharacterEdit
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int HitPoints { get; private set; }
        public int Strength { get; private set; }
        public int Defence { get; private set; }
        public int Intelligence { get; private set; }

        // public int UserId { get; private set; }
        // public User User { get; private set; }

        public int? WeaponId { get; private set; }
        public Weapon Weapon { get; private set; }

        // public Statistics Statistics { get; private set; }
        // public int? StatisticsId { get; private set; }

        public DateTime CreateDate { get; private set; }
        public DateTime? ModifyDate { get; private set; }

        // public ICollection<Skill> Skills { get; } = new HashSet<Skill>();

        public int Level { get; private set; }
        public long TotalXp { get; set; }
        public Experience Experience { get; private set; }

        public Character()
        {
        }

        public CharacterDto ToDto() => new()
        {
            Id = Id,
            Name = Name,
            HitPoints = HitPoints,
            Strength = Strength,
            Defence = Defence,
            Intelligence = Intelligence,
            // UserId = UserId,
            Weapon = Weapon?.ToDto(),
            // Statistics = Statistics?.ToDto(),
            // Skills = Skills.Select(s => s.ToDto()).ToArray()
            Level = Level,
            TotalXp = TotalXp,
            Experience = Experience?.ToDto(),
        };

        public ICharacterEdit ByUser(int userId)
        {
            if (userId <= 0) throw new ArgumentOutOfRangeException(nameof(userId));

            // if (UserId > 0)
            // {
            //     ModifyDate = DateTime.Now;
            // }
            // else
            // {
            // Statistics = new Statistics();
            CreateDate = DateTime.Now;
            // }

            // UserId = userId;

            return this;
        }

        ICharacterEdit ICharacterEdit.WithWeapon(WeaponDto weapon)
        {
            WeaponId = weapon?.Id;

            return this;
        }

        // TODO: Validate later
        ICharacterEdit ICharacterEdit.WithCombatStats(int hitPoints, int strength, int defence, int intelligence)
        {
            HitPoints = hitPoints;
            Strength = strength;
            Defence = defence;
            Intelligence = intelligence;

            return this;
        }

        ICharacterEdit ICharacterEdit.WithName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));

            Name = name;
            return this;
        }

        // public void AddSkill(Skill skill)
        // {
        //     if (skill == null) throw new ArgumentNullException(nameof(skill));
        //
        //     var existingSkill = Skills.FirstOrDefault(s => s.Id == skill.Id);
        //
        //     if (existingSkill == null) Skills.Add(skill);
        // }
        //
        // public void RemoveSkill(Skill skill)
        // {
        //     if (skill == null) throw new ArgumentNullException(nameof(skill));
        //
        //     var existingSkill = Skills.FirstOrDefault(s => s.Id == skill.Id);
        //
        //     if (existingSkill != null) Skills.Remove(existingSkill);
        // }
    }
}