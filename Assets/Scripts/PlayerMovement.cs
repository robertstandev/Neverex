using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float computerSpeed, movementSpeed;

    private Touch initTouch = new Touch();
    private bool touching = false;

    void Start()
    {
        transform.GetChild(0).GetComponent<Animation>().Play();
    }

    void Update()
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

        if (Input.GetKey(KeyCode.A))
            transform.RotateAround(Vector3.zero, transform.forward, computerSpeed * movementSpeed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.D))
            transform.RotateAround(Vector3.zero, transform.forward, -computerSpeed * movementSpeed * Time.deltaTime);
    }
}
