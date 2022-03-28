using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbScript : MonoBehaviour
{
    public GameObject boss;
    public BossScript bossScript;
    public GameObject orbSpawn;
    public GameObject forceShield;
    public ForceShieldScript shieldScript;
    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss");
        bossScript = boss.GetComponent<BossScript>();
        forceShield = GameObject.FindGameObjectWithTag("ForceShield");
        shieldScript = forceShield.GetComponent<ForceShieldScript>();
    }
    void Update()
    {
        if(bossScript.life <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player" || col.gameObject.tag == "FireBall")
        {
            shieldScript.Activate();
            GameObject newOrb = Instantiate(orbSpawn, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
