using Entitas;
using Entitas.CodeGeneration.Attributes;
using System.Collections;
using System.Collections.Generic;
using ThreeTypesOfDiabetesGame.Data;
//using UnityEngine;

namespace ThreeTypesOfDiabetesGame {

    /// <summary>
    /// 游戏面板
    /// Unique 全局唯一（具有单例属性），并能单例获得
    /// </summary>
    [Game,Unique]
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

    /// <summary>
    /// 球交换状态
    /// </summary>
    [Game]
    public class ExchangeComponent : IComponent {
        public ExchangeState exchangeState;
    }

    /// <summary>
    /// 球移动是否完成
    /// 没有参数，就会是默认 bool 
    /// </summary>
    [Game]
    public class MoveComplete : IComponent
    {
    }

    /// <summary>
    /// 是否获取相同颜色球组件
    /// 没有参数，就会是默认 bool 
    /// </summary>
    [Game]
    public class GetSameColor : IComponent
    {
    }

    /// <summary>
    /// 是否获取相同颜色球组件
    /// 没有参数，就会是默认 bool 
    /// </summary>
    [Game]
    public class DetectionSameItem : IComponent {
        public List<IEntity> _leftEntities;
        public List<IEntity> _rightEntities;
        public List<IEntity> _upEntities;
        public List<IEntity> _downEntities;
    }

    /// <summary>
    /// 判断队形是否满足生成特殊元素的条件
    /// 没有参数，就会是默认 bool 
    /// </summary>
    [Game]
    public class JudgeFormatiom : IComponent
    {
    }

    /// <summary>
    /// 标记是否可消除元素
    /// 没有参数，就会是默认 bool (注意只有值变化的时候才触发事件，之前是false,再次设置false 是不会触发事件的)
    /// 改造为自己带参数的
    /// </summary>
    [Game]
    public class Elimainate : IComponent
    {
        public bool canElimainate;
    }

    /// <summary>
    /// 生成的特效队形的标志组件
    /// </summary>
    [Game]
    public class ItemEffectState : IComponent
    {
        public ItemEffectName state;
    }

    /// <summary>
    /// 加载图片组件
    /// </summary>
    [Game,Event(EventTarget.Self)]
    public class LoadSprite : IComponent {
        // 图片名称
        public string name;
    }
}

