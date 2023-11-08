using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{ 
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
}
