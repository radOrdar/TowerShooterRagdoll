using Logic;
using StaticData;
using StaticData.WIndows;
using UI.Services.Windows;
using UnityEngine;

namespace Services.StaticData
{
    public interface IStaticDataService : IService
    {
        void Load();

        MonsterStaticData ForMonster(MonsterTypeId typeId);
        LevelStaticData ForLevel(string sceneKey);
        WindowConfig ForWindow(WindowId windowId);

        AudioClip ForAudioClip(AudioTypeId audioTypeId);
    }
}