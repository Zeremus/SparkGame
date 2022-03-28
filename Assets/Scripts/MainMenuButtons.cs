using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject newGameText;
    public GameObject yesButton;
    public GameObject noButton;
    public GameObject newGameButton;
    public GameObject loadGameButton;
    public GameObject quitGameButton;
    public void NewGame()
    {
        SceneManager.LoadScene("TuturialLevel");
        PlayerPrefs.DeleteAll();
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ActivateNewGame()
    {
        newGameText.SetActive(true);
        yesButton.SetActive(true);
        noButton.SetActive(true);
        newGameButton.SetActive(false);
        loadGameButton.SetActive(false);
        quitGameButton.SetActive(false);
    }
    public void CancelNewGame()
    {
        newGameText.SetActive(false);
        yesButton.SetActive(false);
        noButton.SetActive(false);
        newGameButton.SetActive(true);
        loadGameButton.SetActive(true);
        quitGameButton.SetActive(true);
    }
}
