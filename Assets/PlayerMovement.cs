using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed; // speed of movement
    public float jump; // height of jump
    float move; // direction of movement storage

    Rigidbody2D rb; // rigidbody2d storage
    public bool isJumping; // check for jumping

    public string sceneName;

    void Start()
    {
        // setting variables 
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        move = Input.GetAxis("Horizontal"); // when horizontal keys are pressed
        rb.velocity = new Vector2(speed * move, rb.velocity.y); // change value of velocity.x with input * speed

        if (Input.GetButtonDown("Jump") && !isJumping) // if space is pressed and player is not jumping/false
        {
            // add force up to jump and set isjumping to true
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if player on the ground set isjumping false
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
        if (collision.gameObject.CompareTag("Kill"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
