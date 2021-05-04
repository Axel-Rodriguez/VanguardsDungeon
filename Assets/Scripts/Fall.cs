using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    public float speed = 3.0f;
    bool check=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 startPosition = (Vector2)transform.position + new Vector2(0f, -1f);
        RaycastHit2D hitInfo = Physics2D.Raycast(startPosition, Vector2.down,10f, LayerMask.GetMask("Default"),-5,5);
        Debug.DrawRay(startPosition, Vector2.down*10f, Color.white);
        if (hitInfo)
        {
            //Debug.Log(hitInfo.transform.name);
            //fall();
            check = true;
        }
    }

    void FixedUpdate()
    {
        if (check == true)
        {
            if (GameObject.FindGameObjectWithTag("FallingTemple").transform.position.y > -7)
            {
                GameObject.FindGameObjectWithTag("FallingTemple").transform.Translate(new Vector3(0, -1, 0) * speed * Time.deltaTime);
            }
            else
            {
                Destroy(GameObject.FindGameObjectWithTag("FallingTemple"));
            }
        }
    }
}
