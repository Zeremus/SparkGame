using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject player;
    public PlayerScript playerScript;
    public GameObject pauseMenuUI;
    public static bool GameIsPaused = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerScript>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            if(GameIsPaused) Resume();
            else Pause();
        }
    }
    void Pause()
    {
        playerScript.canFire = false;
        playerScript.canMove = false;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Resume()
    {
        playerScript.canFire = true;
        playerScript.canMove = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void ExitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
