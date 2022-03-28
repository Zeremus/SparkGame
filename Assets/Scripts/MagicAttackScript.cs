using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicAttackScript : MonoBehaviour
{  
    public BossScript bossScript;
    public GameObject boss;
    private float speed = 10f;
    public GameObject target;
    private Vector3 direction;
    void Start()
    {   boss = GameObject.FindGameObjectWithTag("Boss");
        bossScript = boss.GetComponent<BossScript>();
        target = GameObject.FindGameObjectWithTag("Player");
        direction = target.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Change boss' attack pattern when bellow 6 life
        float distancePerFrame = speed * Time.deltaTime;
        Vector3 secondDirection = target.transform.position - transform.position;
        if(bossScript.life > 7) transform.Translate(direction.normalized * distancePerFrame, Space.World);
        if(bossScript.life < 8)
        {
            speed = 3f;
            transform.Translate(secondDirection.normalized * distancePerFrame, Space.World);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
