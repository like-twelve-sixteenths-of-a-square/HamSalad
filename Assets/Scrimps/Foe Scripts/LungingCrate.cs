using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LungingCrate : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Fellaball");
    }

    private void FixedUpdate()
    {
        Vector2 lookDirection = (player.transform.position - transform.position).normalized;
        rb.AddForce(lookDirection * speed * 5);

        if (transform.position.y < -10) { Destroy(gameObject); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 lookDirection = (player.transform.position - transform.position).normalized;
            rb.AddForce(lookDirection * speed * 8, ForceMode2D.Impulse);
            rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
        }
    }
}
