using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareEnemy : MonoBehaviour
{
    public GameObject explosionPrefab;
    private float speed = 5.0f;
    public Rigidbody2D enemyRB;
    public GameObject player;
    private SpriteRenderer spriteColor;
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        spriteColor = GetComponentInChildren<SpriteRenderer>(); 
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {   float distancePerFrame = speed * Time.deltaTime;
        Vector3 direction = player.transform.position - transform.position;
        enemyRB.MovePosition(transform.position + (direction.normalized * speed * distancePerFrame));
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            speed = 3.0f;
            spriteColor.color = Color.red;;
            Invoke("Explosion", 1.5f);
            Destroy(gameObject, 1.5f);
        } 
    }

    void Explosion()
    {
        GameObject newExplosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "FireBall")
        {
            Explosion();
            Destroy(gameObject);
        }
    }
}
