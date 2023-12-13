using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5;
    public float jumpSpeed = 13;
    private float radius = 0.77f;
    public int coin;
    public int timeLapse = 3;

    public bool isGrounded;
    public bool isTimeStopped = false;
    public GameObject sound;

    Animator animator;

    float movementInput;

    Rigidbody2D rb;

    // Start is called before the first frame update

    private void Awake()
    {
        //SoundManager.instance.Play("BgMusic");
        if(!PlayerPrefs.HasKey("currLevel")) PlayerPrefs.SetInt("currLevel", SceneManager.GetActiveScene().buildIndex);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        if (SceneManager.GetActiveScene().name != "Level1") radius = 0.79f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.CircleCast(transform.position, radius, Vector2.down, 0.05f);
        rb.velocity = new Vector2(movementInput * movementSpeed, rb.velocity.y);

        animator.SetFloat("Horizontal", rb.velocity.x);
        animator.SetFloat("Vertical", rb.velocity.y);
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

    void OnTimeStop()
    {
        if (timeLapse != 0)
        {
            isTimeStopped = true;
            timeLapse--;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            coin++;
            collision.gameObject.SetActive(false);
            sound.GetComponent<AudioSource>().Play();
        }

        if (collision.tag == "Finish")
        {
            PlayerPrefs.SetInt("currLevel", SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.LoadScene(PlayerPrefs.GetInt("currLevel"));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Platform") transform.parent = collision.transform;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Platform") transform.parent = null;
    }
}
