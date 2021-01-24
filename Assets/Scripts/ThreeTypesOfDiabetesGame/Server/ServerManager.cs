using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThreeTypesOfDiabetesGame
{
    public class ServerManager
    {
        /// <summary>
        /// 初始化所有服务
        /// </summary>
        /// <param name="contexts"></param>
        /// <param name="gameController"></param>
        public ServerManager(Contexts contexts, Transform gameController) {
            LoadPrefabServer.Instance.Init(contexts, gameController);
            CreatorServer.Instance.Init(contexts);
            GetEmptyItemServer.Instance.Init(contexts);
        }
    }
}
