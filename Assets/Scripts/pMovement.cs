using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class pMovement : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2D;
    public float horizontal;
    public float vertical;
    public float speed = 1.0f;
    private bool faceRight = true;

    Vector2 direction = new Vector2(1, 0);

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        /*vertical = Input.GetAxisRaw("Vertical");

        Vector2 move = new Vector2(horizontal, rb2D.position.y /*vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            direction.Set(move.x, move.y);
            direction.Normalize();
        }*/

        //animator.SetFloat()
    }

    private void FixedUpdate()
    {
        /*Vector2 position = rb2D.position;
        position.x = position.x + horizontal * Time.deltaTime*speed;
        position.y = position.y + vertical * Time.deltaTime*speed;
        rb2D.MovePosition(position);
        Flip(horizontal);
        animator.SetFloat("speed", Mathf.Abs(horizontal));*/
        rb2D.velocity = new Vector2(horizontal*speed, rb2D.velocity.y);
        Flip(horizontal);
        animator.SetFloat("speed", Mathf.Abs(horizontal));
    }

    private void Flip(float horizontal)
    {
        if (horizontal < 0 && faceRight || horizontal > 0 && !faceRight)
        {
            faceRight = !faceRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

}
