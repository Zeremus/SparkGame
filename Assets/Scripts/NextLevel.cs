using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private GameObject player;
    private PlayerScript playerScript;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerScript>();
    }
    void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            if(playerScript.hasLetter == true)
            {
                int x = SceneManager.GetActiveScene().buildIndex;
                if( x == 1) PlayerPrefs.SetInt("letterH", 1);
                if( x == 2) PlayerPrefs.SetInt("letterE", 1);
                if( x == 3) PlayerPrefs.SetInt("letterR", 1);
                if( x == 4) PlayerPrefs.SetInt("letterO", 1);
                PlayerPrefs.Save();
            }
            LoadNextLevel();
        }
    }
}
