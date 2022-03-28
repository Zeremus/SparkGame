using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 15.0f;
    void Start()
    {
        Destroy(gameObject, 1.0f);
    }
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }
    void OnCollisionEnter2D (Collision2D col)
    {
        if(col.gameObject.tag == "Player") Destroy(gameObject, 0.05f);
    }
}
