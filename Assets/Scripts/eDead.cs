using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eDead : MonoBehaviour
{
    private Rigidbody2D rb;
    Animator animator;
    public float timerE = 0.0f;
    public float initTimeE = 0.0f;
    public GameObject BonesSound;
    private bool dead = false;
    private float posX = 0.0f, posY = 0.0f;


    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Die()
    {
        animator.SetBool("dead", true);
        rb.GetComponent<Collider2D>().enabled = false;
        try
        {
            rb.GetComponent<CircleCollider2D>().enabled = false;
        }
        catch
        {
            rb.GetComponent<Enemy2>().alive = false;
            rb.GetComponent<Enemy2>().enabled = false;
        }
        dead = true;
        posX = rb.position.x;
        posY = rb.position.y;
        StartCoroutine(waiter());
        Instantiate(BonesSound);
    }

    private void Update()
    {
        if (dead)
        {
            rb.transform.position = new Vector3(posX, posY - 0.65f, 0);
        }
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
