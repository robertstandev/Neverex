using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PCInput : MonoBehaviour, IInput
{
    [SerializeField]private InputAction movementInput;
    private float movementValue = 0;

    private void Awake() {
        movementInput.performed += ctx => OnMove(ctx);
        movementInput.canceled += ctx => OnMove(ctx);
    }

    private void OnEnable() { movementInput.Enable(); }
    private void OnDisable() { movementInput.Disable(); }

    private void OnMove(InputAction.CallbackContext context) { movementValue = context.ReadValue<float>(); }

    public float getMovementValue { get { return this.movementValue; } }
}
