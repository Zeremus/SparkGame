using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDummy : MonoBehaviour
{
    public int life = 3;
    public GameObject destroyedClip;
    public Rigidbody2D rigidBody;
    private GameObject player;
    private float speed = 3;
    public float jump = 6;
    private SpriteRenderer sprite;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        // Move the dummy in the player direction with uniform speed
        float distancePerFrame = speed * Time.deltaTime;
        Vector3 direction = player.transform.position - transform.position;
        if(life < 3)
        {
            transform.Translate(direction.normalized * distancePerFrame, Space.World);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "FireBall")
        {
            // Change dummy behavior depending on how many hits it took
            if(life == 2) sprite.color = Color.red;
            if(life == 3) sprite.color = Color.magenta;
            if(life == 3)
            {
                rigidBody.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
            }
            if(life == 1)
            {
                speed = 4;
                GameObject newExplosion = Instantiate(destroyedClip, transform.position, Quaternion.identity);
                Destroy(gameObject);
                Destroy(newExplosion, 0.4f);
            }
            life--;
        }else if (col.gameObject.tag == "EmpoweredFireBall")
        {
            GameObject newExplosion = Instantiate(destroyedClip, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(newExplosion, 0.4f);
        }
        if(life < 3)
        {
            if(col.gameObject.tag == "Ground")
            {
            rigidBody.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
            }
        }
    }
}
