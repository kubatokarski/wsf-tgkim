using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Left Click
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log(Input.mousePosition);

            Debug.Log("World Point: " + Camera.main.ScreenToWorldPoint(Input.mousePosition));

            Debug.Log("Viewport Point: " + Camera.main.ScreenToViewportPoint(Input.mousePosition));
        }
         
        // Right Click
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Mouse 1 – Right Click");
        }

        // Middle Click
        if (Input.GetMouseButtonDown(2))
        {
            Debug.Log("Mouse 2 – Middle Click");
        }
    }
}
