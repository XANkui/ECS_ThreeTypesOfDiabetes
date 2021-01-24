using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ThreeTypesOfDiabetesGame.Data;
using UnityEngine;


namespace ThreeTypesOfDiabetesGame
{
    public class GetEmptyItemServer 
    {
        public static GetEmptyItemServer Instance { get; private set; } = new GetEmptyItemServer();

        private Contexts _contexts;

        public void Init(Contexts contexts) {
            _contexts = contexts;
        }

        /// <summary>
        /// 一直向下获取可下落的底
        /// （可穿越障碍）
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public int getNextEmptyRow(CustomVector2 pos) {
            int row = pos.y;
            for (int i = pos.y-1; i >= 0; i--)
            {
                var entity = _contexts.game.GetEntitiesWithThreeTypesOfDiabetesGameItemIndex(new CustomVector2( pos.x,i)).ToArray();
                Debug.Log(GetType()+ "/getNextEmptyRow()/entity.Length = " + entity.Length);
                if (entity.Length == 0)
                {
                    // 检测该位置元素为空，标记位置
                    row = i;
                }
                else {
                    // 检测到不可移动物体，跳过
                    if (entity[0].isThreeTypesOfDiabetesGameMovableCommponent==false)
                    {
                        continue;
                    }
                    // 检测到可移动元素，停止循环
                    break;
                }
            }

            return row;
        }
    }
}
