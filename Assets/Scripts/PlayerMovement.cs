using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    public bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private bool isFlying = false;

    public int health = 3;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        // if (string.Equals(currentScene.name, "FireLevel"))
            // nothing

        if (string.Equals(currentScene.name, "AirLevel"))
            speed = 10f;

        if (string.Equals(currentScene.name, "WaterLevel"))
            jumpingPower = 20f;

        if (string.Equals(currentScene.name, "EarthLevel"))
            health = 5;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        //if they click jump while on the ground
        if (isFlying)
        {
            if (Input.GetButtonDown("Jump"))
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        else
        {
            if (Input.GetButtonDown("Jump") && IsGrounded())
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

            //if they are HOLDING the jump button
            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // print("COLLISION DETECTED");
        Scene currentScene = SceneManager.GetActiveScene();
        if (other.gameObject.CompareTag("KILLBOX"))
            SceneManager.LoadScene(currentScene.name);

        if (other.gameObject.CompareTag("ENEMY"))
        {
            if (health > 0)
                health--;
            else
                SceneManager.LoadScene(currentScene.name);
        }
    }
}
