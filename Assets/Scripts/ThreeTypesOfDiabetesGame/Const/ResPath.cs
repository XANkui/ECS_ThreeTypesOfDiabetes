using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThreeTypesOfDiabetesGame
{
    /// <summary>
    /// 路径管理
    /// </summary>
    public class ResPath 
    {
        public static readonly string PrefabPath = "Prefabs/";
        public static readonly string BlockerPath = PrefabPath+"Blocker";
        public static readonly string Item0Path = PrefabPath+ "Item0";
        public static readonly string Item1Path = PrefabPath+ "Item1";
        public static readonly string Item2Path = PrefabPath+ "Item2";
        public static readonly string Item3Path = PrefabPath+ "Item3";
        public static readonly string Item4Path = PrefabPath+ "Item4";
        public static readonly string Item5Path = PrefabPath+ "Item5";

        public static readonly string SpritePath = "Sprites/";
        public static readonly string AllPostfix = "_1";
        public static readonly string HorizontalPostfix = "_1";
        public static readonly string VertialPostfix = "_1";
        public static readonly string ExplodePostfix = "_1";

        public static readonly string ConfigPath = Application.streamingAssetsPath+ "/Config/";
        public static readonly string DataPath = ConfigPath+ "Data.json";

        public static readonly string AudioPath = "Audio/";
    }
}
