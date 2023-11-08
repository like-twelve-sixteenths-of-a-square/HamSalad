using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Animator animator;
    public float speed;
    public float jump;
    public bool onFloor;
    public float powerupLength;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();    
        onFloor = true;
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(Vector2.right * speed * horizontalInput * 5);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onFloor)
        {
            playerRb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            onFloor = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Lets you jump off the floor
        if (collision.gameObject.CompareTag("Platform"))
        {
            onFloor = true;
        }
        //Lets you jump off enemies
        if (collision.gameObject.CompareTag("Enemy"))
        {
            onFloor = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If you collide with a powerup, delete the powerup and become powered up
        if (collision.CompareTag("Swagger"))
        {
            //Begins Swag Process
            animator.SetBool("IsSwagged", true);


            //Makes the player heavy and retains speed
            gameObject.GetComponent<Rigidbody2D>().mass *= 5;
            speed *= 5;
            jump *= 5;

            //removes the powerup item
            Destroy(collision.gameObject);

            //starts powerdown routine
            StartCoroutine(PowerupCDR());
        }
    }

    IEnumerator PowerupCDR()
    {
        //When powered up, wait for a set time, then stop being powered up
        yield return new WaitForSeconds(powerupLength);
        animator.SetBool("IsSwagged", false);


        //Returns normal mass and variables
        gameObject.GetComponent<Rigidbody2D>().mass /= 5;
        speed /= 5;
        jump /= 5;
    }
}
