using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitDestroy : MonoBehaviour
{
    public GameObject roadBlock;

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "FireBall" || col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            roadBlock.SetActive(false);
        }
    }
}
