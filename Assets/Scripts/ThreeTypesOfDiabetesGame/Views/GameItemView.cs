using DG.Tweening;
using Entitas;
using System.Collections;
using System.Collections.Generic;
using ThreeTypesOfDiabetesGame.Data;
using UnityEngine;

namespace ThreeTypesOfDiabetesGame
{
    /// <summary>
    /// 游戏元素视图
    /// </summary>
    public class GameItemView : ViewBase, IThreeTypesOfDiabetesGameItemIndexListener, IThreeTypesOfDiabetesGameLoadSpriteListener
    {

        public override void Link(IEntity entity, IContext context)
        {
            base.Link(entity, context);

            // 添加监听事件
            _gameEntity.AddThreeTypesOfDiabetesGameItemIndexListener(this);
            _gameEntity.AddThreeTypesOfDiabetesGameLoadSpriteListener(this);

            transform.position = new Vector3(_gameEntity.threeTypesOfDiabetesGameItemIndex.index.x, Contexts.sharedInstance.game.threeTypesOfDiabetesGameGameBoard.rows);
        }

        public void OnThreeTypesOfDiabetesGameItemIndex(GameEntity entity, CustomVector2 index)
        {
            //  移动的具体代码
            this.transform.DOMove(new Vector3(index.x,index.y,0),0.3f)
                .OnComplete(()=> { _gameEntity.isThreeTypesOfDiabetesGameMoveComplete = true; });
        }

        public override void OnThreeTypesOfDiabetesGameDestroyCommponent(GameEntity entity)
        {
            base.OnThreeTypesOfDiabetesGameDestroyCommponent(entity);

            float time = 0.5f;
            transform.DOScale(Vector3.one*1.5f, time);
            transform.GetComponent<SpriteRenderer>().DOColor(Color.clear, time).OnComplete(()=> { Destroy(this.gameObject); }); ;
        }

        public void OnThreeTypesOfDiabetesGameLoadSprite(GameEntity entity, string name)
        {
            string path = ResPath.SpritePath + name;
            Debug.Log(GetType() + "/OnThreeTypesOfDiabetesGameLoadSprite()/SpritePath = " + path);
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(path);
        }
    }
}
