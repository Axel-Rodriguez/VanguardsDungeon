using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 2.25f;
    private float posX = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        posX = rb.position.x;
    }

    private void FixedUpdate()
    {
        Vector2 position = rb .position;
        position.x = position.x - speed * Time.deltaTime;
        if ((position.x + 14.14f) < posX)
        {
            Destroy(gameObject);
        }
        else
        {
            rb.MovePosition(position);
        }
    }
}
