using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerData
{
    public float[] position;
    public int sceneNumber;

    public PlayerData(PlayerScript player)
    {
        // Save the current level with the player position at the begining of the level
        sceneNumber = SceneManager.GetActiveScene().buildIndex;
        position = new float[3];
        position[0] = -3.12f;
        position[1] = -3.33f;
        position[2] = 0f;
    }
}
