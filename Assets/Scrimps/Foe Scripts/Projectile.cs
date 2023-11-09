using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float impactStrength;

    void Start()
    {
        transform.Translate(Vector2.right / 1.25f);
        Invoke("DelayedDestroy", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * 6 * Time.deltaTime);
    }

    void DelayedDestroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D collidedBody = collision.GetComponent<Rigidbody2D>();
            Vector3 away = (collision.gameObject.transform.position - transform.position).normalized;
            collidedBody.AddForce(away * impactStrength, ForceMode2D.Impulse);
            Destroy(gameObject);
        }
    }
}
