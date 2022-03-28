using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingScript : MonoBehaviour
{
    public GameObject particles;
    private float healingCharges = 2;
    private float nextHeal;
    private float healRate = 0.5f;
    private bool canHeal = true;
    private GameObject player;
    public PlayerScript playerScript;
    public GameObject heal;
    public AudioSource healSound;

    void Start()
    {
        heal = GameObject.FindGameObjectWithTag("Heal");
        healSound = heal.GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerScript>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad > nextHeal) canHeal = true;
        if(healingCharges <= 0) particles.SetActive(false);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (healingCharges >=1 && playerScript.life <= 4)
        {
            if(col.gameObject.tag == "Player" && canHeal)
            {
                if(playerScript.life < 5)
                healSound.Play();
                playerScript.life++;
                healingCharges--;
                canHeal = false;
                nextHeal = Time.timeSinceLevelLoad + healRate;
            }
        }
        
    }
    
}
