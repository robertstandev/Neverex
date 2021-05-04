using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainObstacles : MonoBehaviour
{
    [SerializeField]private int rotationSpeedMin, rotationSpeedMax;

    private int randomRot, rotationSpeed;

	private void Start ()
    {
        setRotation();
	}
	
	private void Update ()
    {
        checkRotation();
        checkChildren();
    }

    private void setRotation()
    {
        randomRot = Random.Range(0, 4);
        rotationSpeed = Random.Range(rotationSpeedMin, rotationSpeedMax);
    }

    private void checkRotation()
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

    private void checkChildren()
    {
        if (transform.childCount <= 1)
        {
            Destroy(gameObject);
        }
    }
}
