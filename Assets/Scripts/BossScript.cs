using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Collider2D col;
    public GameObject death;
    public int life = 14;
    public GameObject magicAttack;
    public Transform shootPoint;
    private bool canAttack;
    private float nextAttack;
    private float attackRate = 2;
    public AudioSource music;
    public AudioSource bossMusic;
    void Start()
    {
        canAttack = false;
    }

    void Update()
    {
        if(life <= 0)
        { 
            sprite.enabled = false;
            col.enabled = false;
        }
        if(life < 8) attackRate = 4; // Slow boss' attack rate when life drops bellow 6
        if(Time.timeSinceLevelLoad > nextAttack)
        {
            canAttack = true;
        }
        if (canAttack && life >= 1)
        {
            GameObject newAttack = Instantiate(magicAttack, shootPoint.transform.position, Quaternion.Euler(0, 0, 180));
            canAttack = false;
            nextAttack = Time.timeSinceLevelLoad + attackRate;
            if (life > 7) Destroy(newAttack, 1.0f);
            if (life < 8)
            {
                Destroy(newAttack, 4f);
            } 
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "FireBall")
        {
            sprite.color = Color.red;
            Invoke("NormalColor", 0.1f);
            if(life < 2)
            {
                GameObject bossDeath = Instantiate(death, transform.position, Quaternion.identity);
                bossMusic.Stop();
                music.Play();
            }
            life--;
        }else if (col.gameObject.tag == "EmpoweredFireBall")
        {
            sprite.color = Color.red;
            Invoke("NormalColor", 0.1f);
            if(life < 3)
            {
                GameObject bossDeath = Instantiate(death, transform.position, Quaternion.identity);
                bossMusic.Stop();
                music.Play();
            }
            life-=2;
        }
    }
    void NormalColor()
    {
        sprite.color = Color.white;
    }
}
