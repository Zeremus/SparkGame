using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyScript : MonoBehaviour
{
    private Vector2 explosionPosision;
    public GameObject destroyedClip;

    void Start()
    {
        explosionPosision = new Vector2(transform.position.x, transform.position.y + 1);
    }
    void OnCollisionEnter2D(Collision2D col)
    { 
        if(col.gameObject.tag == "FireBall" || col.gameObject.tag == "EmpoweredFireBall")
        {
            GameObject isDestroyed = Instantiate(destroyedClip, explosionPosision, Quaternion.identity);
            Destroy(isDestroyed, 0.4f);
            Destroy(gameObject);
        }
    }
}
