using System;

namespace ProjectK.Business.Stats
{
    public static class StatsGenerator
    {
        private static readonly Random Random = new();

        public static (int HitPoints, int Strength, int Defence, int Intelligence) GenerateRandomStats()
        {
            var hitPoints = Random.Next(90, 151);
            var strength = Random.Next(5, 16);
            var defence = Random.Next(6, 16);
            var intelligence = Random.Next(6, 16);

            return (hitPoints, strength, defence, intelligence);
        }
    }
}