using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThreeTypesOfDiabetesGame
{
    public class GameController : MonoBehaviour
    {
        private Systems _systems;
        private Contexts _contexts;

        private void Awake()
        {
            _contexts = Contexts.sharedInstance;
            _systems = GetSystems(_contexts);
            new ServerManager(_contexts, this.transform);
            ModelManager.Instance.Init();
        }

        // Start is called before the first frame update
        void Start()
        {
            _systems.Initialize();
        }

        // Update is called once per frame
        void Update()
        {
            _systems.Execute();
            _systems.Cleanup();
        }

        private Systems GetSystems(Contexts contexts) { 
            return new GameFeature(contexts)
                .Add(new GameEventSystems(contexts))
                .Add(new InputFeature(contexts));
        }
    }
}
