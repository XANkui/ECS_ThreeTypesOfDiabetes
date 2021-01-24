using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThreeTypesOfDiabetesGame
{
    /// <summary>
    /// 滑动方向
    /// </summary>
    public enum SlideDirection { 
    
        LEFT,
        RIGHT,
        UP,
        DOWN
    }

    /// <summary>
    /// 交换状态
    /// </summary>
    public enum ExchangeState { 
        NONE,
        START,
        EXCHANGE,
        EXCHANGE_BACK,
        END

    }

    /// <summary>
    /// 特殊元素效果名称
    /// </summary>
    public enum ItemEffectName
    {
        NONE,
        /// <summary>
        /// 消除所有相同颜色的元素（条件：五个及五个以上元素连成一条直线）特效ID：1
        /// </summary>
        ELIMINATE_SAME_COLOR,
        /// <summary>
        /// 消除行（条件：四个元素连成横线）特效ID：2
        /// </summary>
        ELIMINATE_HORIZONTAL,
        /// <summary>
        /// 消除列（条件：四个元素连成竖线）特效ID：3
        /// </summary>
        ELIMINATE_VERTICAL,
        /// <summary>
        /// 爆炸消除以此元素为中心的九宫格范围（条件：横竖都满足三个及三个元素以上）特效ID：4
        /// </summary>
        EXPLODE
    }
}