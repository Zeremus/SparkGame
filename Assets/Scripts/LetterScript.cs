using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterScript : MonoBehaviour
{
    public AudioSource letterSource;
    private GameObject player;
    private PlayerScript playerScript;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerScript>();
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            letterSource.Play();
            playerScript.hasLetter = true;
            Destroy(gameObject);
        }
    }
}
