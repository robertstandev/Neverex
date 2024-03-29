﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]private float movementSpeed, rotationSpeed;
    [SerializeField]private Mesh[] obstMeshes;

    private Rigidbody rb;
    private bool stoppedMoving = false;

    private Collision collisionComponent;
    private MainObstacles mainObstaclesComponent;

    private BoxCollider bc;
    private Vector3 bcSpecialSize = new Vector3(1.2f, 1.1f, 0.5f);

    private void Awake()
    {
        mainObstaclesComponent = transform.parent.GetComponent<MainObstacles>();
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
        collisionComponent = FindObjectOfType<Collision>();
    }

	private void Start ()
    {
        rb.AddForce(transform.forward * -movementSpeed);

        if (CompareTag("Prism Instance"))
        {
            checkAndSelectShape();
        }
    }
	
	private void Update ()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        if (collisionComponent.isGameOver() && !stoppedMoving)
        {
            stoppedMoving = true;
            rb.Sleep();
        }
	}

    private void checkAndSelectShape()
    {
        int randomMeshIndex = Random.Range(0, obstMeshes.Length);

        if(mainObstaclesComponent.getCreatedObstacles() == 7 && !mainObstaclesComponent.getHasCube())
        {
            randomMeshIndex = 0;
        }
        if(mainObstaclesComponent.getCreatedObstacles() == 8 && !mainObstaclesComponent.getHasPrism())
        {
            randomMeshIndex = 1;
        }
        if(mainObstaclesComponent.getCreatedObstacles() == 9 && !mainObstaclesComponent.getHasSphere())
        {
            randomMeshIndex = 2;
        }

        configureAndCreateShape(randomMeshIndex);
    }

    private void configureAndCreateShape(int index)
    {
        switch (index)
        {
            case 0:
                tag = "Cube Instance";
                transform.Rotate(Vector3.right, 90f);
                mainObstaclesComponent.setHasCube();
                break;
            case 1:
                tag = "Prism Instance";
                transform.Rotate(Vector3.right, -90f);
                mainObstaclesComponent.setHasPrism();
                break;
            case 2:
                tag = "Sphere Instance";
                bc.size = bcSpecialSize;
                mainObstaclesComponent.setHasSphere();
                break;
        }
        GetComponent<MeshFilter>().mesh = obstMeshes[index];
        mainObstaclesComponent.increaseCreatedObstacles();
    }
}