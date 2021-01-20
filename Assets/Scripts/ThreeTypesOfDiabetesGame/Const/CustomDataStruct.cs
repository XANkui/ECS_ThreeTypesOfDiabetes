using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 自定义数据结构，避免过度与Unity 耦合，方便后期的可以移植性
/// </summary>
namespace ThreeTypesOfDiabetesGame.Data
{
    /// <summary>
    /// 这个自定义的结构体做好使用 struct ，使用 class 会有莫名其妙的问题
    /// </summary>
    public struct CustomVector2 {
        public int x;
        public int y;
        
        public CustomVector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

}
