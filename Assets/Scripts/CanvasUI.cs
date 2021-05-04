using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasUI : MonoBehaviour
{
    public GameObject heart, h1, h2, h3;

    void Start()
    {
        h1 = Instantiate(heart) as GameObject;
        h1.transform.SetParent(GameObject.Find("Canvas").transform, false);
        h2 = Instantiate(heart, new Vector3(-187.5f, 119, 0), Quaternion.identity) as GameObject;
        h2.transform.SetParent(GameObject.Find("Canvas").transform, false);
        h3 = Instantiate(heart, new Vector3(-147.5f, 119, 0), Quaternion.identity) as GameObject;
        h3.transform.SetParent(GameObject.Find("Canvas").transform, false);
    }
}
