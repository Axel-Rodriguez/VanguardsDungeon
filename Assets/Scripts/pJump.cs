using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pJump : MonoBehaviour
{
    public float jumpForce;
    public float jumpTime;
    private float jTimeCounter;
    private bool jumpStop;
    public bool grounded;
    private bool doubleJ=true;
    private Rigidbody2D rb;
    Animator animator;
    public GameObject JumpSound;
   //Aqui empiezan el anterior scrip de movement.
    public float horizontal;
    public float vertical;
    public float speed = 1.0f;
    public bool faceRight = true;
    // Sistema de particulas del polvo 
    public ParticleSystem Dust;


    [SerializeField] private Transform groundCheck;
    [SerializeField] private float radiusCirc=0.03f;
    [SerializeField] private LayerMask whatIsGround;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        jTimeCounter = jumpTime;
    }

    private void Update()
    {
        //Moviemiento
        if (rb.position.x > -7.5f & rb.position.x < 126f)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            Flip(horizontal);
            animator.SetFloat("speed", Mathf.Abs(horizontal));
        }
        else if(rb.position.x < -7.5f)
        {
            rb.transform.position = new Vector3(-7.499f, rb.position.y, 0);
        }
        else if (rb.position.x > 126f)
        {
            rb.transform.position = new Vector3(125.999f, rb.position.y, 0);
        }

        //Saltos
        grounded = Physics2D.OverlapCircle(groundCheck.position, radiusCirc, whatIsGround);
        if (grounded)
        {
            jTimeCounter = jumpTime;
            doubleJ = true;
        }
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpStop = false;
            Instantiate(JumpSound);

        }
        if (Input.GetButtonDown("Jump") && !jumpStop && jTimeCounter > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jTimeCounter -= Time.deltaTime;
        }
        if (Input.GetButtonUp("Jump"))
        {
            jTimeCounter = 0;
            jumpStop = true;
        }
        if (Input.GetButtonDown("Jump") && !grounded && doubleJ)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpStop = false;
            doubleJ = false;
            Instantiate(JumpSound);

        }
    }

    void FixedUpdate()
    {
        animator.SetBool("jump", grounded);
        if (rb.position.x > 121.5)
        {
            string score = GameObject.Find("Time").GetComponent<Timer>().textoDelReloj;
            PlayerPrefs.SetString("time", score);
            GameObject.Find("Canvas").GetComponent<Scenes>().win();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheck.position, radiusCirc);
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

    void DustPlay()
    {
        Dust.Play();
    }
   
    void DustStop()
    {
        Dust.Stop();    
    }
}
