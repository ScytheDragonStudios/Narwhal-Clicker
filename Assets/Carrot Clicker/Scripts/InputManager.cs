using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{

    [Header(" Action ")]
    public static Action onCarrotClicked;
    public static Action<Vector2> onCarrotClickedPosition;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ThrowRaycast();
    }

    private void ThrowRaycast()
    {
        RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));

        if (hit.collider == null)
            return;

        Debug.Log("We Hit the Narwhal!!");
        onCarrotClicked?.Invoke();

        onCarrotClickedPosition?.Invoke(hit.point);
    }
}
