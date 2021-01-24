using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThreeTypesOfDiabetesGame
{
    public class InputControllor : MonoBehaviour
    {
        private InputContext _inputContext;
        private float _time;
        private float _timeIntervalMax = 0.5f;
        private float _timeIntervalMin = 0.2f;
        private float _offsetX;
        private float _offsetY;

        private Vector2 clickPos;

        // Start is called before the first frame update
        void Start()
        {
            _inputContext = Contexts.sharedInstance.input;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100);
                if (hit.collider != null)
                {
                    clickPos = hit.transform.position;
                    _inputContext.ReplaceThreeTypesOfDiabetesGameClick((int)clickPos.x, (int)clickPos.y);
                }

                _time = 0;
                _offsetX = 0;
                _offsetY = 0;
            }

            if (Input.GetMouseButton(0))
            {
                if (_time < _timeIntervalMax)
                {
                    _time += Time.deltaTime;
                    _offsetX += Input.GetAxis("Mouse X");
                    _offsetY += Input.GetAxis("Mouse Y");
                }
                else
                {
                    Slide();
                }
            }

            if (Input.GetMouseButtonUp(0) && _time < _timeIntervalMax && _time > _timeIntervalMin)
            {
                Slide();
            }
        }

        private void Slide() {
            SlideDirection direction = Mathf.Abs(_offsetX)>Mathf.Abs(_offsetY)
                ?(_offsetX>0?SlideDirection.RIGHT:SlideDirection.LEFT)
                : (_offsetY > 0 ? SlideDirection.UP : SlideDirection.DOWN);

            _inputContext.ReplaceThreeTypesOfDiabetesGameSlide(new Data.CustomVector2((int)clickPos.x, (int)clickPos.y),direction);
        }
    }
}
