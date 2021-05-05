using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainObstacles : MonoBehaviour
{
    [SerializeField]private int rotationSpeedMin, rotationSpeedMax;

    private int randomRot, rotationSpeed;
    private bool hasCube, hasPrism, hasSphere;
    private int createdObstacles;

	private void Start () { setRotation(); }
	
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

    public void setHasCube() { this.hasCube = true; }
    public void setHasPrism() { this.hasPrism = true; }
    public void setHasSphere() { this.hasSphere = true; }
    public void increaseCreatedObstacles() { this.createdObstacles += 1; }

    public bool getHasCube() { return this.hasCube; }
    public bool getHasPrism() { return this.hasPrism; }
    public bool getHasSphere() { return this.hasSphere; }
    public int getCreatedObstacles() { return this.createdObstacles; }
}