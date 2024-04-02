using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public InputAction MoveAction;

    private bool isMoving;

    private Vector2 movement;

    public Animator animator;

    bool facingRight = false;

    private Rigidbody2D rb2D;

    public LayerMask groundMask;
    private RaycastHit2D hit;

    public float groundCheckDistance = 0.1f; 

    private void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        MoveAction.Enable();
    }

    private void Update()
    {
        movement = MoveAction.ReadValue<Vector2>();

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        // transform.localScale.Set(, transform.localScale.y, transform.localScale.z);
        // Vector3 theScale = transform.localScale;
        // theScale.x *= MathF.Sign(movement.x);
        // transform.localScale = theScale;
        if(movement.x > 0 && !facingRight)
            Flip();
        else if(movement.x < 0 && facingRight)
            Flip();
        
    }

    private void FixedUpdate() {
        Vector2 position = rb2D.position + movement * Time.fixedDeltaTime * movementSpeed;
        // hit = Physics2D.Raycast(transform.position, movement, movementSpeed, groundMask);
        // if (hit.collider != null) {
        //     
            
        // } else {
        //     rb2D.MovePosition(rb2D.position - movement * Time.fixedDeltaTime * movementSpeed);
        // }
        rb2D.MovePosition(position);

        // Physics.Raycast(transform.position, Vector3.zero, out hitInfo);
        Debug.Log(hit.collider);
    }

    void Flip ()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log("Collision");
    }

}
