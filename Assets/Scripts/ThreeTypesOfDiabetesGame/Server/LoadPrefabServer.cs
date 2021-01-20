using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

namespace ThreeTypesOfDiabetesGame
{
    public class LoadPrefabServer:IThreeTypesOfDiabetesGameAnyLoadPrefabCommponentListener
    {
        public static LoadPrefabServer Instance { get; private set; } = new LoadPrefabServer();

        private Contexts _contexts;
        private Transform _settleParent;
        private Transform _moveableParent;

        public void Init(Contexts contexts, Transform gameController) {
            _contexts = contexts;
            contexts.game.CreateEntity().AddThreeTypesOfDiabetesGameAnyLoadPrefabCommponentListener(this);
            CreateSubParent(gameController);
        }

        private void CreateSubParent(Transform parent) {
            _settleParent = new GameObject("Settle").transform;
            _settleParent.SetParent(parent);

            _moveableParent = new GameObject("moveable").transform;
            _moveableParent.SetParent(parent);
        }

        public void OnThreeTypesOfDiabetesGameAnyLoadPrefabCommponent(GameEntity entity, string path)
        {
            Transform temp = _settleParent;
            if (entity.isThreeTypesOfDiabetesGameMovableCommponent)
            {
                temp = _moveableParent;
            }

            GameObject prefab = Resources.Load<GameObject>(path);
            IView view = GameObject.Instantiate(prefab, temp).GetComponent<IView>();
            view.Link(entity, _contexts.game);
        }
    }
}
