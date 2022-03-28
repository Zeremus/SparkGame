using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveGO : MonoBehaviour
{
    public GameObject enemies;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            enemies.SetActive(true);
        }
    }
}
