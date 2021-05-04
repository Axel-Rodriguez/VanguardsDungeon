using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public GameObject arrow;
    private Rigidbody2D rb;
    public bool attack = false, alive = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while(alive)
        {
            Instantiate(arrow, new Vector3(rb.position.x - 1f, rb.position.y - 0.595f, 0), Quaternion.identity);
            attack = true;
            rb.GetComponent<Animator>().SetBool("attack", true);
            yield return new WaitForSeconds(1f);
            attack = false;
            rb.GetComponent<Animator>().SetBool("attack", false);
            yield return new WaitForSeconds(1f);
        }
    }
}
