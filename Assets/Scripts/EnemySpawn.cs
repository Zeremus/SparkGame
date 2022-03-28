using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject goblinPrefab;
    public bool isSpawned = false;

    void OnTriggerEnter2D (Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            GetComponent<BoxCollider2D>().enabled = false;
            isSpawned = true;
            GameObject firstGoblin = Instantiate(goblinPrefab, transform.position + new Vector3(8.0f, 1, 0), Quaternion.identity);
            GameObject secondGoblin = Instantiate(goblinPrefab, transform.position + new Vector3(-8.0f, 1, 0), Quaternion.identity);
        }
    }
}
