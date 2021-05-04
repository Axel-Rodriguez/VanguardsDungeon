using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pAttack : MonoBehaviour
{
    public bool attacking = false;
    public float look = 1;
    private float waitTime = 0.8f;
    public float timer = 0.0f;
    public float initTime = 0.0f;
    private Rigidbody2D rb;
    Animator animator;
    public GameObject AttkSound;
    private Vector3 pos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        pos = rb.position;
    }


    void Update()
    {
        timer += Time.deltaTime;
        Vector3 scale = rb.transform.localScale;
        pos = rb.position;
        pos.y += 0.59f;
        if (scale.x < 0)
        {
            look = -1;
        }
        else
        {
            look = 1;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            attacking = true;
            initTime = timer;
            Instantiate(AttkSound);
            CheckAttack();
        }
        if(attacking == false)
        {
            Debug.DrawRay(pos, Vector3.right * 2.32f * look, Color.white);
        }
        else
        {
            Debug.DrawRay(pos, Vector3.right * 2.32f * look, Color.yellow);
            CheckAttack();
        }
        if ((timer - initTime) > waitTime)
        {
            attacking = false;
        }
    }

    private void FixedUpdate()
    {
        animator.SetBool("attacking", attacking);
    }

    public void CheckAttack()
    {
        int layerMask = 1 << 9;
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector3.right * look, 2.32f, layerMask);
        if (hit.collider != null)
        {
            try
            {
                Vector2 hitPlace = hit.transform.position;
                hit.rigidbody.GetComponent<eDead>().Die();
            }
            catch
            {
                hit.rigidbody.GetComponent<Arrow>().enabled = false;
                Destroy(hit.rigidbody.gameObject);
            }
        }
    }
}
