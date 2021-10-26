using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectK.Business;
using ProjectK.Business.Characters;
using ProjectK.Business.Weapons;

namespace ProjectK.Data
{
    public class ProjectKContext : DbContext
    {
        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<Weapon> Weapons { get; set; }

        public ProjectKContext(DbContextOptions<ProjectKContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("prk");

            var localDateTimeConverter = new ValueConverter<DateTime?, DateTime?>(
                v => v,
                v => DateTime.SpecifyKind(v.Value, DateTimeKind.Local));

            modelBuilder.Entity<Character>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseIdentityColumn();
                entity.Property(e => e.Name).HasMaxLength(255);
                entity.Property(e => e.HitPoints);
                entity.Property(e => e.Strength);
                entity.Property(e => e.Defence);
                entity.Property(e => e.Intelligence);
                entity.Property(e => e.CreateDate).HasConversion(localDateTimeConverter);
                entity.Property(e => e.ModifyDate).HasConversion(localDateTimeConverter);

                // entity.HasOne(e => e.Statistics)
                //     .WithOne(e => e.Character)
                //     .HasForeignKey<Character>(c => c.StatisticsId)
                //     .HasPrincipalKey<Statistics>(s => s.CharacterId);
                //
                // entity.HasOne(e => e.User)
                //     .WithMany()
                //     .HasForeignKey(e => e.UserId);
                //
                // entity.HasMany(e => e.Skills)
                //     .WithMany(e => e.Characters);

                entity.HasOne(e => e.Weapon)
                    .WithMany()
                    .HasForeignKey(e => e.WeaponId);
            });

            modelBuilder.Entity<Weapon>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseIdentityColumn();
                entity.Property(e => e.Name).HasMaxLength(255);
                entity.Property(e => e.CreateDate).HasConversion(localDateTimeConverter);
                entity.Property(e => e.ModifyDate).HasConversion(localDateTimeConverter);
            });
        }
    }
}