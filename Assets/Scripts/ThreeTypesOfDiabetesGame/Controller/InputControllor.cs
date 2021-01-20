using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControllor : MonoBehaviour
{
    private InputContext _inputContext;
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
            var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero,100);
            if (hit.collider !=null)
            {
                _inputContext.ReplaceThreeTypesOfDiabetesGameClick((int)hit.transform.position.x,(int)hit.transform.position.y);
            }
        }
    }
}
