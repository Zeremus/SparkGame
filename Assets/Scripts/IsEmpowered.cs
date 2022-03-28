using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsEmpowered : MonoBehaviour
{
    public GameObject player;
    public PlayerScript playerScript;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerScript>();
        if(playerScript.isEmpowered == false)
        {
            Destroy(gameObject);
        }else if(playerScript.isEmpowered == true)
        {
            gameObject.SetActive(true);
        }
    }
}
