using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbSpawn : MonoBehaviour
{
    public GameObject boss;
    public BossScript bossScript;
    public GameObject orb;
    public Transform orbSpawn1;
    public Transform orbSpawn2;
    public Transform orbSpawn3;
    public Transform orbSpawn4;
    public Transform orbSpawn5;
    public Transform orbSpawn6;
    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss");
        bossScript = boss.GetComponent<BossScript>();
        orbSpawn1 = GameObject.FindGameObjectWithTag("Spawn1").transform;
        orbSpawn2 = GameObject.FindGameObjectWithTag("Spawn2").transform;
        orbSpawn3 = GameObject.FindGameObjectWithTag("Spawn3").transform;
        orbSpawn4 = GameObject.FindGameObjectWithTag("Spawn4").transform;
        orbSpawn5 = GameObject.FindGameObjectWithTag("Spawn5").transform;
        orbSpawn6 = GameObject.FindGameObjectWithTag("Spawn6").transform;

        if(bossScript.life >= 1)
        {
            // Generate a random number to randomly choose which platform the next orb will spawn on
            int x = Random.Range(1,7);
            if(x == 1)
            {
                Invoke("SpawnPoint1", 15);
            }else if(x == 2)
            {
                Invoke("SpawnPoint2", 15);        
            }else if(x == 3)
            {
                Invoke("SpawnPoint3", 15);
            }else if(x == 4)
            {
                Invoke("SpawnPoint4", 15);
            }else if(x == 5)
            {
                Invoke("SpawnPoint5", 15);
            }else if(x == 6)
            {
                Invoke("SpawnPoint6", 15);
            }
        }
        
        Destroy(gameObject, 15);
    }
    void SpawnPoint1()
    {
        GameObject newOrb = Instantiate(orb, orbSpawn1.transform.position, Quaternion.identity);
    }
    void SpawnPoint2()
    {
        GameObject newOrb = Instantiate(orb, orbSpawn2.transform.position, Quaternion.identity);
    }
    void SpawnPoint3()
    {
        GameObject newOrb = Instantiate(orb, orbSpawn3.transform.position, Quaternion.identity);
    }
    void SpawnPoint4()
    {
        GameObject newOrb = Instantiate(orb, orbSpawn4.transform.position, Quaternion.identity);
    }
    void SpawnPoint5()
    {
        GameObject newOrb = Instantiate(orb, orbSpawn5.transform.position, Quaternion.identity);
    }
    void SpawnPoint6()
    {
        GameObject newOrb = Instantiate(orb, orbSpawn6.transform.position, Quaternion.identity);
    }
}
