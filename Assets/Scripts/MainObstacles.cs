using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainObstacles : MonoBehaviour {

    [SerializeField]private int rotationSpeedMin, rotationSpeedMax;

    private int randomRot, rotationSpeed;

	private void Start ()
    {
        SetRotation();
	}
	
	private void Update ()
    {
        CheckRotation();
        CheckChildren();
    }

    private void SetRotation()
    {
        randomRot = Random.Range(0, 4);
        rotationSpeed = Random.Range(rotationSpeedMin, rotationSpeedMax);
    }

    private void CheckRotation()
    {
        switch (randomRot)
        {
            case 1:
                transform.Rotate(transform.forward, rotationSpeed * Time.deltaTime);
                break;
            case 2:
                transform.Rotate(transform.forward, -rotationSpeed * Time.deltaTime);
                break;
        }
    }

    private void CheckChildren()
    {
        if (transform.childCount <= 1)
        {
            Destroy(gameObject);
        }
    }
}
