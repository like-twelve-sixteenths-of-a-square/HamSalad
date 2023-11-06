using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    public float speed;
    public float jump;
    public bool onFloor;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        onFloor = true;
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(Vector2.right * speed * horizontalInput * 5);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && onFloor)
        {
            playerRb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            onFloor = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Just checks if you can jump again lol :3
        if (collision.gameObject.CompareTag("Platform"))
        {
            onFloor = true;
        }
        //Just checks if you can jump again lol :3
        if (collision.gameObject.CompareTag("Enemy"))
        {
            onFloor = true;
        }
    }
}
