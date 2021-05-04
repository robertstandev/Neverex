using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]private float movementSpeed, rotationSpeed;
    [SerializeField]private Mesh[] obstMeshes;

    private Rigidbody rb;
    private bool stoppedMoving = false;

    private BoxCollider bc;
    private Vector3 bcOriginalSize = new Vector3(1.183293f, 0.5000002f, 1.087185f);
    private Vector3 bcSpecialSize = new Vector3(1.2f, 1.1f, 0.5f);

	private void Start ()
    {
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
        rb.AddForce(transform.forward * -movementSpeed);

        if (CompareTag("Prism Instance"))
        {
            chooseShape();
        }
    }
	
	private void Update ()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        if ((FindObjectOfType<Collision>().isGameOver()) && (!stoppedMoving))
        {
            stoppedMoving = true;
            rb.Sleep();
        }
	}

    private void chooseShape()
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

        bc.size = bcOriginalSize;

        if (CompareTag("Prism Instance"))
        {
            transform.Rotate(Vector3.right, -90f);
        }
        if (CompareTag("Cube Instance"))
        {
            transform.Rotate(Vector3.right, 90f);
        }
        if(CompareTag("Sphere Instance"))
        {
            bc.size = bcSpecialSize;
        }
    }
}
