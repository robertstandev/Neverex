using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float computerSpeed, movementSpeed;
    private InputAction movementInput;
    private float movementValue = 0;

    private void Awake() {
        movementInput = GetComponent<IInput>().getMovementInput;
        movementInput.performed += ctx => OnMove(ctx);
        movementInput.canceled += ctx => OnMove(ctx);
    }

    private void OnEnable() { movementInput.Enable(); }
    private void OnDisable() { movementInput.Disable(); }

    private void OnMove(InputAction.CallbackContext context) { movementValue = context.ReadValue<float>(); }

    private void Start() { transform.GetChild(0).GetComponent<Animation>().Play(); }

    private void FixedUpdate()
    {
        if(movementValue != 0)
        {
            transform.RotateAround(Vector3.zero, transform.forward, (movementValue * computerSpeed) * movementSpeed * Time.deltaTime);
        }
    }
}