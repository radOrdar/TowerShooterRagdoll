using System.Collections.Generic;
using System.Linq;
using Logic;
using StaticData;
using StaticData.Audio;
using StaticData.WIndows;
using UI.Services.Windows;
using UnityEngine;

namespace Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string MonsterDataPath = "Static Data/Monsters";
        private const string LevelsDataPath = "Static Data/Levels";
        private const string StaticDataWindowPath = "Static Data/UI/WindowStaticData";
        private const string AudioDataPath = "Static Data/Audio/AudioData";

        private Dictionary<MonsterTypeId, MonsterStaticData> _monsters;
        private Dictionary<string, LevelStaticData> _levels;
        private Dictionary<WindowId, WindowConfig> _windowConfigs;
        private Dictionary<AudioTypeId, AudioClip> _audioSources;

        public void Load()
        {
            _monsters = Resources
                .LoadAll<MonsterStaticData>(MonsterDataPath)
                .ToDictionary(x => x.MonsterTypeId, x => x);

            _levels = Resources
                .LoadAll<LevelStaticData>(LevelsDataPath)
                .ToDictionary(x => x.LevelKey, x => x);

            _windowConfigs = Resources
                .Load<WindowStaticData>(StaticDataWindowPath)
                .Configs
                .ToDictionary(x => x.WindowId, x => x);

            _audioSources = Resources
                .Load<AudioClipStaticDataList>(AudioDataPath)
                .AudioClipDatas
                .ToDictionary(a => a.AudioTypeId, a => a.AudioClip);
        }

        public MonsterStaticData ForMonster(MonsterTypeId typeId) =>
            _monsters.TryGetValue(typeId, out MonsterStaticData staticData)
                ? staticData
                : null;

        public LevelStaticData ForLevel(string sceneKey) =>
            _levels.TryGetValue(sceneKey, out LevelStaticData staticData)
                ? staticData
                : null;

        public WindowConfig ForWindow(WindowId windowId) =>
            _windowConfigs.TryGetValue(windowId, out WindowConfig windowConfig)
                ? windowConfig
                : null;

        public AudioClip ForAudioClip(AudioTypeId audioTypeId) =>
            _audioSources.TryGetValue(audioTypeId, out AudioClip audioClip)
                ? audioClip
                : null;
    }
}