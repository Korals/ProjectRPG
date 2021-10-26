using System;
using ProjectK.Contracts;

namespace ProjectK.Business.Weapons
{
    public class Weapon
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Damage { get; private set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }

        protected Weapon()
        {
        }

        public Weapon(WeaponDto weapon)
        {
            if (weapon == null) throw new ArgumentNullException(nameof(weapon));

            Name = weapon.Name;
            Damage = weapon.Damage;
            CreateDate = DateTime.Now;
        }

        public WeaponDto ToDto() => new()
        {
            Id = Id,
            Name = Name,
            Damage = Damage,
        };

        public void Update(WeaponDto weapon)
        {
            if (weapon == null) throw new ArgumentNullException(nameof(weapon));

            ModifyDate = DateTime.Now;
            Name = weapon.Name;
            Damage = weapon.Damage;
        }
    }
}