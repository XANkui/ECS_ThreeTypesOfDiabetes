using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InteractionDemo
{
    public class GameController : MonoBehaviour
    {
        private Contexts _context;
        private Systems _systems;
        // Start is called before the first frame update
        void Start()
        {
            _context = Contexts.sharedInstance;
            _systems = new Feature("System")
                .Add(new GameFeature(_context))
                .Add(new InputFeature(_context));
        }

        // Update is called once per frame
        void Update()
        {
            _systems.Execute();
            _systems.Cleanup();
        }
    }
}
