namespace Services.Randomizer
{
    public interface IRandomService : IService
    {
        int Next(int minValue, int maxValue);
        float Range(float minInclusive, float maxInclusive);
    }
}