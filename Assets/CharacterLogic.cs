using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterLogic : MonoBehaviour
{
    public float movementSpeed;
    public InputAction MoveAction;

    private bool isMoving;

    private Vector2 input;

    private void Update()
    {
        Vector2 move = MoveAction.ReadValue<Vector2>();
        Debug.Log(move);
        Vector2 position = (Vector2)transform.position + move * 0.1f;
        transform.position = position;
    }

}
