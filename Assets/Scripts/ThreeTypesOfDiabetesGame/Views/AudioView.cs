using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThreeTypesOfDiabetesGame
{
    /// <summary>
    /// 音效视图
    /// 拆分视图，需要添加即可
    /// </summary>
    public class AudioView : MonoBehaviour, IThreeTypesOfDiabetesGameAudioListener, IView
    {
        private AudioSource _audioSource;

        public void Link(IEntity entity, IContext context)
        {
            GameEntity gameEntity = entity as GameEntity;
            if (gameEntity !=null)
            {
                // 添加监听
                gameEntity.AddThreeTypesOfDiabetesGameAudioListener(this);
            }
        }

        public void OnThreeTypesOfDiabetesGameAudio(GameEntity entity, string path)
        {
            if (_audioSource==null)
            {
                _audioSource = gameObject.AddComponent<AudioSource>();
            }

            _audioSource.clip = Resources.Load<AudioClip>(ResPath.AudioPath + path);
            _audioSource.Play();
        }
    }
}
