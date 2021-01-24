using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThreeTypesOfDiabetesGame{

    // 计分管理
    public class ScoreController : MonoBehaviour,IThreeTypesOfDiabetesGameAnyScoreListener
    {
        private TextMesh _scoreText;

        public TextMesh ScoreText { get {

                if (_scoreText == null)
                {
                    _scoreText = GameObject.Find("Main Camera/Score").GetComponent<TextMesh>();

                }
                return _scoreText;


            }
        
        }

        // Start is called before the first frame update
        void Start()
        {
            // 绑定监听
            Contexts.sharedInstance.game.CreateEntity().AddThreeTypesOfDiabetesGameAnyScoreListener(this);
        }


        public void OnThreeTypesOfDiabetesGameAnyScore(GameEntity entity, int score)
        {
            ScoreText.text = score.ToString();
        }
    }
}
