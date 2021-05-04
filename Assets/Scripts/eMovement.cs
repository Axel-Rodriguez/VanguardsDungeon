using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eMovement : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2D;
    private float speed = -1.0f;
    private bool faceRight = false;
    private bool move = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {
        //animator.SetBool("movement", move);
        //rb2D.velocity = new Vector2(speed, rb2D.velocity.y);
        StartCoroutine(waiter());
    }

    private void Flip()
    {
        faceRight = !faceRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        speed = speed * -1;
    }
    IEnumerator waiter()
    {
        while (true)
        { 
            move = true;
            animator.SetBool("movement", move);
            rb2D.velocity = new Vector2(speed, rb2D.velocity.y);
            yield return new WaitForSeconds(3);
            Flip();
            move = true;
        }
    }
}
