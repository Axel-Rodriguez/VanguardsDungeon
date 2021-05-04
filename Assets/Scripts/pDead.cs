using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pDead : MonoBehaviour
{

    public bool dead = false, enabledCollider=true;
    private Rigidbody2D rb;
    Animator animator;
    public float waitTime = 1.75f;
    private float timer = 0.0f;
    private float initTime = 0.0f;
    public GameObject DeathSound, GameOverSound;
    public int cont = 0;
    private int lives = 3;
 
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "Enemy1"){
            if(enabledCollider & collider.gameObject.GetComponent<Animator>().GetBool("dead") == false)
            {
                WhenCollision();
            }
        }
        else if (enabledCollider & collider.gameObject.tag == "Arrow")
        {
            collider.rigidbody.GetComponent<Arrow>().enabled = false;
            Destroy(collider.rigidbody.gameObject);
            WhenCollision();
        }
        else if (enabledCollider & collider.gameObject.tag == "Picos")
        {
            WhenCollision();
        }
    }

    public void WhenCollision()
    {
        rb.GetComponent<pJump>().enabled = false;
        rb.GetComponent<pAttack>().enabled = false;
        rb.velocity = new Vector2(0, 0);
        dead = true;
        enabledCollider = false;
        initTime = timer;
        if (lives > 0)
        {
            lives--;
            Instantiate(DeathSound);
            LoseLife();
        }
        if (lives == 0)
        {
            Instantiate(GameOverSound);
        }
    }

    public void LoseLife()
    {
        if(lives == 2)
        {
            Destroy(GameObject.Find("Canvas").GetComponent<CanvasUI>().h3);
        }
        else if (lives == 1)
        {
            Destroy(GameObject.Find("Canvas").GetComponent<CanvasUI>().h2);
        }
        else
        {
            Destroy(GameObject.Find("Canvas").GetComponent<CanvasUI>().h1);
        }
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (dead == true)
        {
            if (rb.position.y < -3.99f)
            {
                rb.bodyType = RigidbodyType2D.Static;
            }
            animator.SetBool("dead", dead);
            animator.SetFloat("speed", Mathf.Abs(0));
            if ((timer - initTime) > waitTime)
            {
                dead = false;
                gameObject.SetActive(false);
                rb.bodyType = RigidbodyType2D.Dynamic;
                if (lives > 0)
                {
                    enabledCollider = true;
                    rb.transform.position = new Vector3(-5.75f, -4, 0);
                    rb.transform.localScale = new Vector3(5, 5, 5);
                    rb.GetComponent<pJump>().enabled = true;
                    rb.GetComponent<pJump>().faceRight = true;
                    rb.GetComponent<pAttack>().enabled = true;
                    gameObject.SetActive(true);
                }
                else
                {
                    GameObject.Find("Canvas").GetComponent<Scenes>().defeat();
                }
            }
        }
    }
}
