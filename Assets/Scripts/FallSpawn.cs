using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallSpawn : MonoBehaviour
{
    public GameObject PrefabFall;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawner());
    }

    IEnumerator EnemySpawner()
    {
        while (true)
        {
            GameObject.Instantiate(PrefabFall, new Vector3(Random.Range(0f, 60.0f), 8f, 0), Quaternion.identity);
            yield return new WaitForSeconds(20);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
