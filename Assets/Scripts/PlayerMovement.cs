using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5;
    public float jumpSpeed = 13;
    public int coin;
    public int lives = 3;

    public bool isGrounded;

    Animator animator;

    float movementInput;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.CircleCast(transform.position, 0.77f, Vector2.down, 0.05f);
        rb.velocity = new Vector2(movementInput * movementSpeed, rb.velocity.y);

        animator.SetFloat("Horizontal", rb.velocity.x);
    }

    void OnJump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }

    void OnMove(InputValue value)
    {
        movementInput = value.Get<float>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            coin++;
            collision.gameObject.SetActive(false);
        }

        if (collision.tag == "Death")
        {
            lives--;
        }

    }
}
