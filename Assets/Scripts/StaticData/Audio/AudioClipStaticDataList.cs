using System.Collections.Generic;
using UnityEngine;

namespace StaticData.Audio
{
    [CreateAssetMenu(fileName = "Static Data/Audio static data", menuName = "AudioStaticData", order = 0)]
    public class AudioClipStaticDataList : ScriptableObject
    {
        public List<AudioClipData> AudioClipDatas;
    }
}