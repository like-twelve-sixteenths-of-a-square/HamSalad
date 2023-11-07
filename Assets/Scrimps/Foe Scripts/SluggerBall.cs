using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SluggerBall : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private Rigidbody2D rb;
    private GameObject player;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Fellaball");
        animator = GetComponent<Animator>();
        StartCoroutine(Repeating());
    }

    private void Update()
    {
        if (transform.position.y < -10) { Destroy(gameObject); }
    }

    IEnumerator Repeating()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.5f);

            //Prepare charge
            Debug.Log("Preparing Charge...");
            animator.SetTrigger("Prime");

            yield return new WaitForSeconds(1);

            //Warn charge
            Debug.Log("Warning! Charge imminent!");
            animator.SetTrigger("Ignite");

            yield return new WaitForSeconds(1);

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            Vector2 spinDirection = (player.transform.position - transform.position).normalized;
            if (spinDirection.x > 0)
            {
                rb.AddTorque(1500);
            }
            else
            {
                rb.AddTorque(-1500);
            }

            yield return new WaitForSeconds(0.5f);

            Vector2 lookDirection = (player.transform.position - transform.position).normalized;
            rb.AddForce(lookDirection * speed * 200, ForceMode2D.Impulse);

            yield return new WaitForSeconds(0.5f);

            Debug.Log("Recovering...");
            animator.SetTrigger("Cool");
        }
    }
}
