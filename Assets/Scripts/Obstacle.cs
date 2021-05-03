using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    public float movementSpeed, rotationSpeed;
    public Mesh[] obstMeshes;

    private Rigidbody rb;
    private bool stoppedMoving = false;


	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * -movementSpeed);

        if (CompareTag("Prism Instance"))
        {
            ChooseShape();
        }
    }
	
	void Update () {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        if ((FindObjectOfType<Collision>().gameIsOver) && (!stoppedMoving))
        {
            stoppedMoving = true;
            rb.Sleep();
        }
	}

    public void ChooseShape()
    {
        int randomMeshIndex = Random.Range(0, obstMeshes.Length);
        GetComponent<MeshFilter>().mesh = obstMeshes[randomMeshIndex];

        switch (randomMeshIndex)
        {
            case 0:
                tag = "Cube Instance";
                break;
            case 1:
                tag = "Prism Instance";
                break;
            case 2:
                tag = "Sphere Instance";
                break;
        }

    }
}
