using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerScript : MonoBehaviour
{
    public float speed = 5.0f;
    public GameObject myPlayer;
    private Vector3 mouseOrigin;    
    private bool isRotating;   

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseOrigin = Input.mousePosition;
            isRotating = true;
        }

        if (!Input.GetMouseButton(0)) isRotating = false;

        if (isRotating)
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

            transform.RotateAround(transform.position, transform.right, -pos.y * speed);
            //transform.RotateAround(transform.position, Vector3.up, pos.x * speed);

            myPlayer.transform.RotateAround(myPlayer.transform.position, Vector3.up, pos.x * speed);
        }
    }
}
