using Entitas.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThreeTypesOfDiabetesGame
{
    public class BGAudioController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            var entity = Contexts.sharedInstance.game.CreateEntity();
            IView audio = gameObject.AddComponent<AudioView>();

            // Link 
            gameObject.Link(entity);
            audio.Link(entity,Contexts.sharedInstance.game);

            entity.ReplaceThreeTypesOfDiabetesGameAudio(AudioName.Bg.ToString());
        }

        
    }
}
