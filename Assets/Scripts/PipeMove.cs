using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour {

    public float movementSpeed;

    private Vector3 startPos;

	void Start () {
        startPos = transform.position;
        GetComponent<Rigidbody>().AddForce(transform.forward * -movementSpeed);
        Invoke("SetBackToStartPos", 1.32f);
	}

    public void StopPipes()
    {
        CancelInvoke("SetBackToStartPos");
        GetComponent<Rigidbody>().Sleep();
    }

    public void SetBackToStartPos()
    {
        transform.position = startPos;
        Invoke("SetBackToStartPos", 1.32f);
    }
}
