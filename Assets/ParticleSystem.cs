using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParticleSystem : MonoBehaviour
{
    public GameObject ps1;
    public GameObject ps2;
    public GameObject player;
    public PlayerScript playerScript;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerScript>();
        if(playerScript.isEmpowered == false)
        {
            ps1.SetActive(false);
            ps2.SetActive(false);
        }else if (playerScript.isEmpowered == true)
        {
            ps1.SetActive(true);
            ps2.SetActive(true);
        }
    }
}
