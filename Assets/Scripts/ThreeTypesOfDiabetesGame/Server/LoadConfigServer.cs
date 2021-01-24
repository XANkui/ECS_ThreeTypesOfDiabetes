using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace ThreeTypesOfDiabetesGame
{
    public class LoadConfigServer
    {
        public static LoadConfigServer Instance {get;private set;} = new LoadConfigServer();
        public T LoadJson<T>()where T :class{
            if (File.Exists(ResPath.DataPath))
            {
                string json = File.ReadAllText(ResPath.DataPath);
                return JsonUtility.FromJson<T>(json);
            }

            return null;
        }
    }

}
