using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBall : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private Rigidbody2D rb;
    private GameObject player;
    public GameObject projectile;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Fellaball");
        StartCoroutine(Repeating());
    }
    IEnumerator Repeating()
    {
        yield return new WaitForSeconds(1);

        while (true)
        {
            for (int i = 0; i < Random.Range(3, 8); i++)
            {
                yield return new WaitForSeconds(0.5f);
                Vector2 lookDirection = (player.transform.position - transform.position).normalized;
                rb.AddForce(lookDirection * speed, ForceMode2D.Impulse);
                rb.AddForce(Vector2.up * jumpForce * 2, ForceMode2D.Impulse);
            }

            yield return new WaitForSeconds(1);

            rb.velocity = Vector2.zero;
            rb.freezeRotation = true;

            yield return new WaitForSeconds(0.5f);

            rb.AddForce(Vector2.up * jumpForce * 7, ForceMode2D.Impulse);

            yield return new WaitForSeconds(0.4f);

            rb.freezeRotation = false;
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0;

            yield return new WaitForSeconds(0.1f);

            for (int i = 0; i < 16; i++)
            {
                transform.Rotate(Vector3.forward * 22.5f);
                Instantiate(projectile, transform.position, transform.rotation);
            }

            yield return new WaitForSeconds(0.5f);

            rb.gravityScale = 1;
        }
    }
}
