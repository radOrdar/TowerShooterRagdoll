using UnityEngine;

namespace Services.Randomizer
{
    public class RandomService : IRandomService
    {
        public int Next(int minValue, int maxValue) => Random.Range(minValue, maxValue);
        public float Range(float minInclusive, float maxInclusive) => Random.Range(minInclusive, maxInclusive);
    }
}