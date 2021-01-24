using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThreeTypesOfDiabetesGame
{
    public class ModelManager 
    {
        public static ModelManager Instance { get; private set; } = new ModelManager();

        /// <summary>
        /// 场景配置文件
        /// </summary>
        public DataModel DataModel { get; private set; }


        public void Init() {
            DataModel = LoadConfigServer.Instance.LoadJson<DataModel>();
        }

    }
}
