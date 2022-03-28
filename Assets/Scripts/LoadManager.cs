using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    public void LoadGame()
    {
        PlayerData data = SaveSystem.LoadGame();
        SceneManager.LoadScene(data.sceneNumber);

        // Load game with the player in the begining of the level he last saved on
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
    public void DeleteGameData()
    {
        SaveSystem.DeleteSave();
    }
}
