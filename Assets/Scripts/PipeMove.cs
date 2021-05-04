using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{
    [SerializeField]private float movementSpeed;

    private Vector3 startPos;

	private void Start ()
    {
        startPos = transform.position;
        GetComponent<Rigidbody>().AddForce(transform.forward * -movementSpeed);
        Invoke("setBackToStartPos", 1.32f);
	}

    public void stopPipes()
    {
        CancelInvoke("setBackToStartPos");
        GetComponent<Rigidbody>().Sleep();
    }

    private void setBackToStartPos()
    {
        transform.position = startPos;
        Invoke("setBackToStartPos", 1.32f);
    }
}
