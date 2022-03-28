using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallScript : MonoBehaviour
{
    public float speed = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.75f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        Destroy(gameObject);
    }
}
