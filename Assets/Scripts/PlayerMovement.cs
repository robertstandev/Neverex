using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float movementSpeed;
    private IInput movementInput;

    private void Awake() { movementInput = GetComponent<IInput>(); }

    private void Start() { transform.GetChild(0).GetComponent<Animation>().Play(); }

    private void FixedUpdate()
    {
        if(movementInput.getMovementValue != 0)
        {
            transform.RotateAround(Vector3.zero, transform.forward, movementInput.getMovementValue * movementSpeed * Time.deltaTime);
        }
    }
}
