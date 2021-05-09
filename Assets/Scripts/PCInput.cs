using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PCInput : MonoBehaviour, IInput
{
    [SerializeField]private InputAction movementInput;
    public InputAction getMovementInput { get { return this.movementInput; } }
}
