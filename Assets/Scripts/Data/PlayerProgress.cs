using System.Collections.Generic;

namespace Data
{
    public class PlayerProgress
    {
        public State HeroState;
        public WorldData WorldData;
        public List<string> ClearedSpawners = new();

        public PlayerProgress(string initialLevel)
        {
            WorldData = new WorldData(initialLevel);
            HeroState = new State();
        }
    }
}