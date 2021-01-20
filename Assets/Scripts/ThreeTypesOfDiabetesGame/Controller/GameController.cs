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
            _systems = new GameFeature(_contexts).Add(new GameEventSystems(_contexts));
            new ServerManager(_contexts, this.transform);
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
    }
}
