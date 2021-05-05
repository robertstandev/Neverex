using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float computerSpeed, movementSpeed;

    private Touch initTouch = new Touch();
    private bool touching = false;

    private void Start() { transform.GetChild(0).GetComponent<Animation>().Play(); }

    private void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                if (touching == false)
                {
                    touching = true;
                    initTouch = touch;
                }
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                float deltaX = initTouch.position.x - touch.position.x;
                transform.RotateAround(Vector3.zero, transform.forward, deltaX * movementSpeed * Time.deltaTime);
               

                initTouch = touch;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                initTouch = new Touch();
                touching = false;
            }
        }

        //PC - remake to new Input system later
        //Bug on Linux (x64) Ubuntu 16.04+ , Android 5 with New Input System 1.0.2 ==> C++ hooks not deactivating properly

        if (Input.GetKey(KeyCode.A))
            transform.RotateAround(Vector3.zero, transform.forward, computerSpeed * movementSpeed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.D))
            transform.RotateAround(Vector3.zero, transform.forward, -computerSpeed * movementSpeed * Time.deltaTime);
    }
}