using Entitas;
using Entitas.CodeGeneration.Attributes;
using System.Collections;
using System.Collections.Generic;
using ThreeTypesOfDiabetesGame.Data;
//using UnityEngine;

namespace ThreeTypesOfDiabetesGame {

    /// <summary>
    /// 游戏面板
    /// </summary>
    [Game]
    public class GameBoardComponent : IComponent {
        /// <summary>
        /// 行
        /// </summary>
        public int columns;

        /// <summary>
        /// 列
        /// </summary>
        public int rows;
    }

    /// <summary>
    /// 游戏面板元素
    /// </summary>
    [Game]
    public class GameBoardItemComponent : IComponent { 
    
    }

    /// <summary>
    /// 游戏元素消除组件
    /// </summary>
    [Game, Event(EventTarget.Self)]
    public class DestroyCommponent : IComponent { 
    
    }

    /// <summary>
    /// 游戏元素坐标
    /// Event(EventTarget.Self) 自己值变化触发事件 
    /// </summary>
    [Game,Event(EventTarget.Self,EventType.Added,1)]
    public class ItemIndex : IComponent {
        /// <summary>
        /// 标记可索引查询该组件值
        /// </summary>
        [EntityIndex]
        public CustomVector2 index;
    }

    /// <summary>
    /// 加载预制体组件
    /// </summary>
    [Game, Event(EventTarget.Any)]
    public class LoadPrefabCommponent : IComponent
    {
        public string path;
    }

    /// <summary>
    /// 元素是否可移动
    /// </summary>
    [Game]
    public class MovableCommponent : IComponent
    {
       
    }
}

