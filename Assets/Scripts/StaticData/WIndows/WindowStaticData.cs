﻿using System.Collections.Generic;
using UnityEngine;

namespace StaticData.WIndows
{
    [CreateAssetMenu(fileName = "Static Data/Window static data", menuName = "WindowStaticData")]
    public class WindowStaticData : ScriptableObject
    {
        public List<WindowConfig> Configs;
    }
}